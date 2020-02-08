using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Space.Card.Game.WebApi.Model;

namespace Space.Card.Game.WebApi.Infrastructure
{
    public class MockDataHelper
    {
        private static ApiContext context;

        public static void CreateMockData(ApiContext _context)
        {
            context = _context;
            context.Database.EnsureCreated();

            if (context.Starships.Any())
            {
                return;
            }
            CreateStarships();
        }

        private static void CreateStarships()
        {
            for (int i = 0; i < 20; i++)
            {
                context.Starships.Add(
                    new Starship(RandomNumberGenerator.GetInt32(0, 10))
                    {
                        Name = "Starship " + i,
                    });
            }

            context.SaveChanges();
        }
    }
}
