using Space.Card.Game.WebApi.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Handlers.Base
{
    public class HandlerBase<T> : IHandlerBase
        where T: IHandlerBase
    {
        private T handler;
        private IResponseBase response;
        
        //todo reconsider where: new()
        //create response here via automapper or get from unity container
        public HandlerBase(T _handler, IResponseBase _response)
        {
            handler = _handler;
            response = _response;
        }

        public IResponseBase Execute(IRequestBase request)
        {
            try
            {
                response = handler.Execute(request);
                response.Status = "SUCCESS";
                
                return response;
            }
            catch(Exception ex)
            {
                response.Status = "FAILURE";
                response.Message = "Could not process the request";

                return response;
            }           
        }
    }
}
