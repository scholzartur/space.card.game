using Space.Card.Game.WebApi.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Space.Card.Game.WebApi.Dtos;

namespace Space.Card.Game.WebApi.Interfaces.Queries
{
    public interface IStarshipQueryRequest: IRequestBase
    {
         int StartingIndex { get; set; }
         int AmountToReturn { get; set; }
    }
}
