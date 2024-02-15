using Microsoft.EntityFrameworkCore;

namespace mission6_barney.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base (options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
