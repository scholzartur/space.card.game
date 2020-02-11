using Space.Card.Game.WebApi.Dtos;
using Space.Card.Game.WebApi.Interfaces.Base;
using Space.Card.Game.WebApi.Interfaces.Commands;
using System.Linq;
using AutoMapper;
using Space.Card.Game.WebApi.Common;
using Space.Card.Game.WebApi.Infrastructure;
using Space.Card.Game.WebApi.Model;

namespace Space.Card.Game.WebApi.Handlers.Commands
{
    /// <summary>
    /// Handles the fight between two starships
    /// </summary>
    /// <typeparam name="TResponse">Returns IBattleCommandResponse</typeparam>
    public class BattleCommandHandler<TResponse> : IHandlerBase<TResponse>
        where TResponse : IBattleCommandResponse, new()
    {
        private readonly ApiContext context;
        private readonly IMapper mapper;

        public BattleCommandHandler(ApiContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public IResponseBase Execute(IRequestBase request)
        {
            var battleRequest = (IBattleCommandRequest) request;

            var starshipOne = context.Starships.FirstOrDefault(x => x.Id == battleRequest.StarshipOneId);
            var starshipTwo = context.Starships.FirstOrDefault(x => x.Id == battleRequest.StarshipTwoId);

            if (starshipOne == null || starshipTwo == null)
                throw new BussinessException(Messages.StarshipIsNull);

            return GetWinner(starshipOne, starshipTwo);
        }

        public void Dispose()
        {
            context?.Dispose();
        }

        protected virtual TResponse GetWinner(Starship starshipOne, Starship starshipTwo)
        {
            bool winnerFound = false;
            Starship winner = null;

            if (starshipOne.FightingPotential == starshipTwo.FightingPotential)
            {
                winnerFound = false;
            }
            else
            {
                winner = starshipOne.FightingPotential > starshipTwo.FightingPotential ? starshipOne : starshipTwo;
                winnerFound = true;
                winner.MarkAsWinner();
                context.SaveChanges();
            }

            return new TResponse()
            {
                WinnerFound = winnerFound,
                WinnerShip = (winnerFound) ? mapper.Map<StarshipDto>(winner) : null
            };
        }
    }
}
