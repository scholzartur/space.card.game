using Microsoft.AspNetCore.Mvc;
using Space.Card.Game.WebApi.Dtos;
using Space.Card.Game.WebApi.Interfaces;
using Space.Card.Game.WebApi.Interfaces.Base;

namespace Space.Card.Game.WebApi.Controllers
{
    [ApiController]
    public class SpaceController : ControllerBase
    {
        private IHandlerExecutor<StarshipQueryResponseDto> starshipHandler;
        private IHandlerExecutor<BattleCommandResponseDto> battleHandler;

        public SpaceController(IHandlerExecutor<StarshipQueryResponseDto> _starshipHandler,
                               IHandlerExecutor<BattleCommandResponseDto> _battleHandler)
        {
            starshipHandler = _starshipHandler;
            battleHandler = _battleHandler;
        }

        [HttpPost]
        [Route("v1/space/start-battle")]
        public IResponseBase StartBattle(BattleCommandRequestDto request)
        {
            var result = battleHandler.Execute(request);
            return result;
        }

        [HttpPost]
        [Route("v1/space/get-starships")]
        public IResponseBase GetStarships(StarshipQueryRequestDto request)
        {
            return starshipHandler.Execute(request);
        }
    }
}