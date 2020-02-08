using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Interfaces.Base
{
    public interface IHandlerBase<TResponse> : IDisposable
        where TResponse : IResponseBase, new()
    {
        IResponseBase Execute(IRequestBase request);
    }
}
