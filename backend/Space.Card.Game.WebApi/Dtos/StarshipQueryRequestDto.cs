using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Space.Card.Game.WebApi.Interfaces.Queries;

namespace Space.Card.Game.WebApi.Dtos
{
    public class StarshipQueryRequestDto : IStarshipQueryRequest
    {
        public int StartingIndex { get; set; }
        public int AmountToReturn { get; set; }
    }
}
