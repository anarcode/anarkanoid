using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;
using Anarkanoid.CollisionDetectors;

namespace Anarkanoid.GameComponents
{
    public class Board : IBoard
    {
        delegate void CollisionDetected(IBall ball, IBlock block);

        List<IBlock> _blocks, _irromptableBlocks;
        IBlockCollisionDetector _blockCollisionDetector;
        Dictionary<BlockCollisionType, CollisionDetected> _actionsOnCollision;
        float _ballDiameter, _ballRadius;
        RegionManager _regionManager;
        Vector2 _nextBallSpeed;

        void OnLeftCollision(IBall ball, IBlock block)
        {
            if (ball.Rebounds || !block.Breakable)
            {
                _nextBallSpeed = new Vector2(_nextBallSpeed.X * -1, _nextBallSpeed.Y);
            }
        }

        void OnTopCollision(IBall ball, IBlock block)
        {
            if (ball.Rebounds || !block.Breakable)
            {
                _nextBallSpeed = new Vector2(_nextBallSpeed.X, _nextBallSpeed.Y * -1);
            }
        }

        void OnRightCollision(IBall ball, IBlock block)
        {
            if (ball.Rebounds || !block.Breakable)
            {
                _nextBallSpeed = new Vector2(_nextBallSpeed.X * -1, _nextBallSpeed.Y);
            }
        }

        void OnBottomCollision(IBall ball, IBlock block)
        {
            if (ball.Rebounds || !block.Breakable)
            {
                _nextBallSpeed = new Vector2(_nextBallSpeed.X, _nextBallSpeed.Y * -1);
            }
        }

        //Aqui puedo filtrar por los que son destruibles
        //para saber si el tablero está completo cuandlo length == 0
        public IEnumerable<IBlock> Blocks
        {
            get { return _blocks; }
        }

        public IEnumerable<IBlock> IrromptableBlocks
        {
            get { return _irromptableBlocks; }
        }

        //Este debería mirar los límites, no el playing state (creo)
        public Board(List<IBlock> blocks, List<IBlock> irromptableBlocks, Size boardSize, float ballDiameter)
        {
            _blocks = blocks;
            _irromptableBlocks = irromptableBlocks;
            _actionsOnCollision = new Dictionary<BlockCollisionType, CollisionDetected>()
            {
                { BlockCollisionType.Left, OnLeftCollision },
                { BlockCollisionType.Top, OnTopCollision },
                { BlockCollisionType.Right, OnRightCollision },
                { BlockCollisionType.Bottom, OnBottomCollision }
            };

            //Esto es Ball.Size.Width * Ball.Scale
            _ballDiameter = ballDiameter;
            _ballRadius = _ballDiameter / 2;

            List<IBlock> allBlocks = new List<IBlock>(_blocks);
            allBlocks.AddRange(_irromptableBlocks);

            foreach(IBlock block in _blocks) //Creo que aqui no hace falta todos porque los irrompibles me dan igual
            {
                block.AddObserver(this);
            }

            var regionManagerConfiguration = new RegionManagerConfiguration
            {
                Columns = 3,
                Rows = 5,
                TotalSize = boardSize
            };
            _regionManager = new RegionManager(regionManagerConfiguration, allBlocks);

            _blockCollisionDetector = new BallBlockCollisionDetector(allBlocks, _ballDiameter);
        }

        public IBlock Collides(IBall ball)
        {
            //Si a ballCenter le sumo la velocidad tengo un paso posterior y puedo recalcular la velocidad
            //de la bola para que no se pase de frenada
            
            Vector2 normalizedBallSpeed = new Vector2(ball.Speed.X, ball.Speed.Y);
            normalizedBallSpeed.Normalize();
            var speedLength = ball.Speed.Length();
            _nextBallSpeed = ball.Speed;

            var blocks = _regionManager.GetBlocksByRegion(ball.Position);
            if(blocks != null)
            {
                foreach (IBlock block in blocks)
                {
                    //Tengo que mirar las siguientes posiciones teoricas de la bola (vector normalizado) a ver si colisiona
                    //si lo hace, cambio velocidad para que en el siguiente fotograma sí colisione "limpiamente"
                    //esto es, manteniendole la velocidad de salida real

                    var collision = _blockCollisionDetector.Collides(ball.Position, block);
                    if (collision.Collides)
                    {
                        _actionsOnCollision[collision.Type](ball, block);
                        ball.Speed = _nextBallSpeed;
                        return block;
                    }

                    Vector2 nextPoint = new Vector2(ball.Position.X + normalizedBallSpeed.X, ball.Position.Y + normalizedBallSpeed.Y);

                    //Igual tengo que mirar primero si en mi posicion actual colisiono, y si no calculo
                    //asi me aseguro, ya que si colisiono en los siguientes puntos, lo dejo listo para que aqui salte

                    while (nextPoint.Length() < speedLength)
                    {
                        //Miro si colisiona y si no, incremento el normalizado
                        collision = _blockCollisionDetector.Collides(nextPoint, block);
                        if (collision.Collides)
                        {
                            //Segun el tipo actualizo la velocidad
                            _actionsOnCollision[collision.Type](ball, block);
                            ball.Position = nextPoint;
                            ball.Speed = Vector2.Zero;
                            return null;
                        }

                        nextPoint = new Vector2(nextPoint.X + normalizedBallSpeed.X, nextPoint.Y + normalizedBallSpeed.Y);
                    }
                }
            }

            return null;
        }

        //Que este bsque las colisiones con la bola y con los premios
        public void FindCollisions() { }

        public void NotifyExplosion(IBlock observable)
        {
            _blocks.Remove(observable);
        }
    }
}