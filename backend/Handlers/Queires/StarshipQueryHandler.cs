using Space.Card.Game.WebApi.Dtos;
using Space.Card.Game.WebApi.Interfaces.Base;
using Space.Card.Game.WebApi.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Space.Card.Game.WebApi.Infrastructure;
using Space.Card.Game.WebApi.Model;

namespace Space.Card.Game.WebApi.Handlers.Queires
{
    /// <summary>
    /// Handles starship retriving
    /// </summary>
    /// <typeparam name="TResponse">Returns IStarshipQueryResponse</typeparam>
    public class StarshipQueryHandler<TResponse> : IHandlerBase<TResponse> 
        where TResponse : IStarshipQueryResponse, new ()
    {
        private readonly ApiContext context;
        private readonly IMapper mapper;

        public StarshipQueryHandler(ApiContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public IResponseBase Execute(IRequestBase request)
        {
            var starshipQuery = (IStarshipQueryRequest)request;

            return new TResponse
            {
                Starships =  mapper.Map<StarshipDto[]>(context.Starships.ToList())
            };
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
