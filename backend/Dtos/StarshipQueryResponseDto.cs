using Space.Card.Game.WebApi.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Dtos
{
    public class StarshipQueryResponseDto : IStarshipQueryResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public ICollection<StarshipDto> Starships { get; set; }
    }
}
