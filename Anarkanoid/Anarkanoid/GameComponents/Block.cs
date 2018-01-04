using System;
using System.Collections.Generic;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.GameComponents
{
    public abstract class Block : GameComponent, IBlock
    {
        List<IBlockObserver> _observers;

        public Block(IGameConfiguration configuration, Size size) : base(configuration, size)
        {
            Scale = new Microsoft.Xna.Framework.Vector2(.7f, .7f);
            _observers = new List<IBlockObserver>();
        }

        public virtual bool Breakable
        {
            get { return true; }
        }

        public void AddObserver(IBlockObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public virtual void Explode()
        {
            foreach(IBlockObserver observer in _observers)
            {
                observer.NotifyExplosion(this);
            }
        }
    }
}