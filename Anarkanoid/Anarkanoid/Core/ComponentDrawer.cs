using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Anarkanoid.Interfaces;

namespace Anarkanoid.Core
{
    public class ComponentDrawer
    {
        GraphicsDevice _graphicsDevice;

        Dictionary<IGameComponent, Tuple<Texture2D, SpriteBatch>> _spritesByComponent;

        Dictionary<IGameComponent, Pair<string, SpriteBatch>> _textsByComponent;

        SpriteFont _spriteFont;

        public ComponentDrawer(GraphicsDevice graphicsDevice, SpriteFont spriteFont)
        {
            _graphicsDevice = graphicsDevice;
            _spritesByComponent = new Dictionary<IGameComponent, Tuple<Texture2D, SpriteBatch>>();
            _textsByComponent = new Dictionary<IGameComponent, Pair<string, SpriteBatch>>();
            _spriteFont = spriteFont;
        }

        public void Add(IGameComponent component, Texture2D texture)
        {
            if (!_spritesByComponent.ContainsKey(component))
            {
                var spriteBatch = new SpriteBatch(_graphicsDevice);
                _spritesByComponent.Add(component, new Tuple<Texture2D, SpriteBatch>(texture, spriteBatch));
            }
        }

        public void Add(IGameComponent component, string text)
        {
            if (!_textsByComponent.ContainsKey(component))
            {
                var spriteBatch = new SpriteBatch(_graphicsDevice);
                _textsByComponent.Add(component, new Pair<string, SpriteBatch>(text, spriteBatch));
            }
            else
            {
                _textsByComponent[component].First = text;
            }
        }

        public void Remove(IGameComponent component)
        {
            if (_textsByComponent.ContainsKey(component))
            {
                _textsByComponent.Remove(component);
            }

            if (_spritesByComponent.ContainsKey(component))
            {
                _spritesByComponent.Remove(component);
            }
        }

        public void Draw()
        {
            //Enumerador
            foreach (IGameComponent component in _spritesByComponent.Keys)
            {
                var spriteBatch = _spritesByComponent[component].Item2;
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                spriteBatch.Draw(_spritesByComponent[component].Item1, component.Position, null, component.SpriteColor, 0, Microsoft.Xna.Framework.Vector2.Zero, component.Scale, SpriteEffects.None, 0);
                spriteBatch.End();
            }

            var textsEnumerator = _textsByComponent.Keys.GetEnumerator();
            while (textsEnumerator.MoveNext())
            {
                var currentText = textsEnumerator.Current;
                var spriteBatch = _textsByComponent[currentText].Second;
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                spriteBatch.DrawString(_spriteFont, _textsByComponent[currentText].First, currentText.Position, currentText.SpriteColor, 0, Microsoft.Xna.Framework.Vector2.Zero, currentText.Scale, SpriteEffects.None, 0);
                spriteBatch.End();
            }
        }

        public void Clear()
        {
            _spritesByComponent.Clear();
            _textsByComponent.Clear();
        }
    }
}