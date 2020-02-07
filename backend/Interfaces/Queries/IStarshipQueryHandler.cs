using Space.Card.Game.WebApi.Handlers.Base;
using Space.Card.Game.WebApi.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Interfaces.Queries
{
    public interface IStarshipQueryHandler<TResponse> : IHandlerBase<TResponse> 
        where TResponse : IStarshipQueryResponse, new()
    {
    }
}
