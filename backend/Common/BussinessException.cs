using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Common
{
    public class BussinessException : Exception
    {
        public BussinessException(string message) : base(message) { }
    }
}
