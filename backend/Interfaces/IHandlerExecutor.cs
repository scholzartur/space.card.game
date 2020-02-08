using Space.Card.Game.WebApi.Interfaces.Base;

namespace Space.Card.Game.WebApi.Interfaces
{
    public interface IHandlerExecutor<TResponse>
        where TResponse : IResponseBase, new()
    {

        IResponseBase Execute(IRequestBase request);
    }
}