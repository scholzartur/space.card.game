using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Dtos
{
    public class StarshipDto
    {
        public int Id;
        public int AmountOfPeopleInCrew;
        public string Name;
        public int AmountOfWins;
        public int FightingPotential;
    }
}
