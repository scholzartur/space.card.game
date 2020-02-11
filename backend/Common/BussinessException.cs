using System;

namespace Space.Card.Game.WebApi.Common
{
    public class BussinessException : Exception
    {
        public BussinessException(string message) : base(message) { }
    }
}
