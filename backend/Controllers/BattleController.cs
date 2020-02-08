using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Space.Card.Game.WebApi.Dtos;
using Space.Card.Game.WebApi.Handlers.Base;
using Space.Card.Game.WebApi.Handlers.Commands;
using Space.Card.Game.WebApi.Interfaces;
using Space.Card.Game.WebApi.Interfaces.Base;
using Space.Card.Game.WebApi.Interfaces.Commands;

namespace Space.Card.Game.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattleController : ControllerBase
    {
        private IHandlerExecutor<BattleCommandResponseDto> handlerExecutor;
        public BattleController(IHandlerExecutor<BattleCommandResponseDto> _handlerExecutor)
        
        {
            this.handlerExecutor = _handlerExecutor;
        }

        [HttpGet]
        public string Get()
        {
            handlerExecutor.Execute(new BattleCommandRequestDto());

            return "";
        }
    }
}