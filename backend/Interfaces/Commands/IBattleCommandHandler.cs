using Space.Card.Game.WebApi.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Interfaces.Commands
{
    public interface IBattleCommandHandler<TResponse> : IHandlerBase<TResponse>
        where TResponse : IBattleCommandResponse, new()
    {
    }
}
