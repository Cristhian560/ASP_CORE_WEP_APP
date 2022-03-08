
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
   
{
    public class StarwarsDb : DbContext
    {
        public DbSet<Personaje> Personajes { get; set; }
        public StarwarsDb()
        {

        }
        public StarwarsDb(DbContextOptions<StarwarsDb>options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseInMemoryDatabase("Starwars");
        }
    }
}
