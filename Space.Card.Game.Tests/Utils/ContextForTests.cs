using System;
using Microsoft.EntityFrameworkCore;
using Space.Card.Game.WebApi.Infrastructure;
using Space.Card.Game.WebApi.Model;

namespace Space.Card.Game.Tests.Utils
{
    public class ContextForTests : IDisposable
    {
        public  ApiContext context { get; private set; }

        public ContextForTests GetContextWrapper()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                // Make sure that db names wont double in pararell executions
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            context = new ApiContext(options);
            CreateStarships();

            return this;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        private void CreateStarships()
        {

            for (int i = 1; i < 11; i++)
            {
                context.Starships.Add(
                    new Starship(i)
                    {
                        Name = "Starship " + i,
                    });
            }

            context.Starships.Add(
                new Starship(1)
                {
                    Name = "Starship " + 11,
                });
            context.Starships.Add(
                new Starship(2)
                {
                    Name = "Starship " + 12,
                });
            context.Starships.Add(
                new Starship(3)
                {
                    Name = "Starship " + 13,
                });

            context.SaveChanges();
        }
    }
}
