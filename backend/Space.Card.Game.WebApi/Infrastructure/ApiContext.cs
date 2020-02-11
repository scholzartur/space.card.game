using Microsoft.EntityFrameworkCore;
using Space.Card.Game.WebApi.Model;

namespace Space.Card.Game.WebApi.Infrastructure
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Starship> Starships { get; set; }


    }
}
