﻿using Space.Card.Game.WebApi.Interfaces.Base;
using Space.Card.Game.WebApi.Dtos;

namespace Space.Card.Game.WebApi.Interfaces.Commands
{
    public interface IBattleCommandResponse: IResponseBase
    {
         bool WinnerFound { get; set; }
         StarshipDto WinnerShip { get; set; }
    }
}
