using Space.Card.Game.WebApi.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Handlers.Base
{
    /// <summary>
    /// The response Type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HandlerBase<TResponse> : IHandlerBase<TResponse>
        where TResponse : IResponseBase, new()
    {
        private IHandlerBase<TResponse> handler;
        private TResponse response;
        
        //todo reconsider where: new()
        //create response here via automapper or get from unity container
        public HandlerBase(IHandlerBase<TResponse> _handler)
        {
            handler = _handler;
        }

        public IResponseBase Execute(IRequestBase request)
        {
            try
            {
                response = (TResponse) handler.Execute(request);
                response.Status = "SUCCESS";
                
                return response;
            }
            catch
            {
                response = new TResponse();
                response.Status = "FAILURE";
                response.Message = "Could not process the request";

                return response;
            }           
        }
    }
}
