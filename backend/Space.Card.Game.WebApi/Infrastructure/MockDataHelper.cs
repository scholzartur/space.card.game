using System.Linq;
using System.Security.Cryptography;
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
            for (int i = 1; i < 20; i++)
            {
                var starship = new Starship(RandomNumberGenerator.GetInt32(1, 10));
                context.Starships.Add(starship);
                //save to get the right id after
                context.SaveChanges();
                starship.Name = "Starship " + starship.Id;
            }
        }
    }
}
