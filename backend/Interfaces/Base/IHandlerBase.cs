using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Interfaces.Base
{
    public interface IHandlerBase
    {
        IResponseBase Execute(IRequestBase request);
    }
}
