﻿using Space.Card.Game.WebApi.Interfaces.Base;
using Space.Card.Game.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Interfaces.Commands
{
    public interface IBattleCommandRequest: IRequestBase
    {
        public int StarshipOneId { get; set; }
        public int StarshipTwoId { get; set; }
    }
}
