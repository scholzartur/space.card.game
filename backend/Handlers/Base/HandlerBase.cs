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
    public class HandlerBase<T> : IHandlerBase<T>
        where T: IResponseBase, new()
    {
        private IHandlerBase<T> handler;
        private T response;
        
        //todo reconsider where: new()
        //create response here via automapper or get from unity container
        public HandlerBase(IHandlerBase<T> _handler)
        {
            handler = _handler;
        }

        public IResponseBase Execute(IRequestBase request)
        {
            try
            {
                response = (T) handler.Execute(request);
                response.Status = "SUCCESS";
                
                return response;
            }
            catch
            {
                response = new T();
                response.Status = "FAILURE";
                response.Message = "Could not process the request";

                return response;
            }           
        }
    }
}
