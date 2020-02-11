using System;

namespace Space.Card.Game.WebApi.Interfaces.Base
{
    public interface IHandlerBase<TResponse> : IDisposable
        where TResponse : IResponseBase, new()
    {
        IResponseBase Execute(IRequestBase request);
    }
}
