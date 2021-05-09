using Microsoft.EntityFrameworkCore;

namespace MoviesGQL.Models
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
        }
    }
}
