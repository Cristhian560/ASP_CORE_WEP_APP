
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
   
{
    public class StarwarsDb : DbContext
    {
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public StarwarsDb()
        {

        }
        public StarwarsDb(DbContextOptions<StarwarsDb>options):base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        //{
        //    //options.UseSqlServer(builder.Configuration.GetConnectionString("SwContext"));
        //    optionBuilder.UseSqlServer("SwContext");
        //    //optionBuilder.UseInMemoryDatabase("Starwars");
        //}
    }
}
