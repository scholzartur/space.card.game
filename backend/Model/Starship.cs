using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Card.Game.WebApi.Model
{
    [Table("Starships")]
    public class Starship
    {
        //Required for the sake of EF:
        public Starship() { }
        public Starship(int amountOfPeopleInCrew)
        {
            AmountOfPeopleInCrew = amountOfPeopleInCrew;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public int AmountOfPeopleInCrew { get; private set; }
        public string Name { get; set; }
        public int AmountOfWins { get; private set; }
        public int FightingPotential => AmountOfPeopleInCrew;

        public void MarkAsWinner()
        {
            AmountOfWins += 1;
        }
    }
}
