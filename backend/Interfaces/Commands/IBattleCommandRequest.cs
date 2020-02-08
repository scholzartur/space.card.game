using Space.Card.Game.WebApi.Interfaces.Base;
using Space.Card.Game.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Interfaces.Commands
{
    public interface IBattleCommandRequest: IRequestBase
    {
         int StarshipOneId { get; set; }
         int StarshipTwoId { get; set; }
    }
}
