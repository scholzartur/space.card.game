using Space.Card.Game.WebApi.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Space.Card.Game.WebApi.Common;
using Space.Card.Game.WebApi.Interfaces;

namespace Space.Card.Game.WebApi.Handlers.Base
{
    public class HandlerExecutor<TResponse> : IHandlerExecutor<TResponse>
        where TResponse : IResponseBase, new()

    {
        private IHandlerBase<TResponse> handler;
        private TResponse response;
        
        public HandlerExecutor(IHandlerBase<TResponse> _handler)
        {
            handler = _handler;
        }

        public IResponseBase Execute(IRequestBase request)
        {
            try
            {
                response = (TResponse) handler.Execute(request);
                response.Status = Messages.Success;

                return response;
            }
            catch (Exception ex)
            {
                response = new TResponse
                {
                    Status = Messages.Failure,
                    Message = (ex is BussinessException) ? ex.Message : Messages.GeneralException
                };

                return response;
            }
            finally
            {
                handler.Dispose();
            }
            
        }
    }
}
