using Space.Card.Game.WebApi.Dtos;
using Space.Card.Game.WebApi.Interfaces.Base;
using Space.Card.Game.WebApi.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Handlers.Queires
{
    public class StarshipQueryHandler : IStarshipQueryHandler
    {
        public IResponseBase Execute(IRequestBase request)
        {
            var starshipQuery = (IStarshipQueryRequest) request;
            //todo
            return new StarshipQueryResponseDto();
        }
    }
}
