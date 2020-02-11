using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Dtos
{
    public class StarshipDto
    {
        public int Id { get; set; }
        public int AmountOfPeopleInCrew { get; set; }
        public string Name { get; set; }
        public int AmountOfWins { get; set; }
        public int FightingPotential { get; set; }
    }
}
