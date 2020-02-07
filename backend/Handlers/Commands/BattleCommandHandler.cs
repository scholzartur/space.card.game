using Space.Card.Game.WebApi.Dtos;
using Space.Card.Game.WebApi.Interfaces.Base;
using Space.Card.Game.WebApi.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Handlers.Commands
{
    public class BattleCommandHandler<TResponse> : IBattleCommandHandler<TResponse>
        where TResponse : IBattleCommandResponse, new()
    {
        public IResponseBase Execute(IRequestBase request)
        {
            var battleRequest = (IBattleCommandRequest)request;

            //if()
            //{

            //}
            //else
            //{

            //}

            return new TResponse();
        }
    }
}
