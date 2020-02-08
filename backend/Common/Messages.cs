using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Common
{
    public class Messages
    {
        public const string StarshipIsNull = "One of the starships does not exist";
        public const string Success = "SUCCESS";
        public const string Failure = "FAILURE";
        public const string GeneralException = "Something went wrong";
    }
}
