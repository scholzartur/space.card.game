using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Space.Card.Game.WebApi.Dtos;
using Space.Card.Game.WebApi.Interfaces;
using Space.Card.Game.WebApi.Interfaces.Base;
using Space.Card.Game.WebApi.Interfaces.Commands;
using Space.Card.Game.WebApi.Interfaces.Queries;

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

        [HttpGet]
        [Route("v1/space/get-all-starships")]
        public IResponseBase GetAllStarships()
        {
            return starshipHandler.Execute(new StarshipQueryRequestDto());
        }
    }
}