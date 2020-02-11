using Space.Card.Game.WebApi.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Dtos
{
    public class BattleCommandResponseDto : IBattleCommandResponse
    {
        public string Status { get;set ; }
        public string Message { get; set; }
        public StarshipDto WinnerShip { get; set; }
        public bool WinnerFound { get; set; }
    }
}
