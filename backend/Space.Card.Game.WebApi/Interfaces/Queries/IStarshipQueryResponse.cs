using Space.Card.Game.WebApi.Interfaces.Base;
using System.Collections.Generic;
using Space.Card.Game.WebApi.Dtos;

namespace Space.Card.Game.WebApi.Interfaces.Queries
{
    public interface IStarshipQueryResponse : IResponseBase
    {
        ICollection<StarshipDto> Starships { get; set; }
        int AllStarshipsCount { get; set; }
    }
}
