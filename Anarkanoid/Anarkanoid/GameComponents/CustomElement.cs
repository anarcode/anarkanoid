using System;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.GameComponents
{
    public class CustomElement : GameComponent
    {
        public CustomElement(IGameConfiguration configuration, Size size) : base(configuration, size)
        {
        }
    }
}