using Space.Card.Game.WebApi.Interfaces.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Space.Card.Game.WebApi.Dtos;
using Space.Card.Game.WebApi.Model;

namespace Space.Card.Game.WebApi.Interfaces.Queries
{
    public interface IStarshipQueryResponse : IResponseBase
    {
        ICollection<StarshipDto> Starships { get; set; }
    }
}
