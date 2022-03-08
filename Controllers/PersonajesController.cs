using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class PersonajesController : Controller
    {
        public StarwarsDb ctx { get; set; }
        public PersonajesController(StarwarsDb ctx)
        {
            this.ctx=ctx;
        }
        [HttpPost]
        public IActionResult Editar(Personaje p)
        {
            this.ctx.Attach(p);
            this.ctx.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.ctx.SaveChanges();
            var model = ctx.Personajes.Find(p.Id);
            return View(model);
        }
        public IActionResult Editar(string id)
        {
            int Id = 0;
            int.TryParse(id, out Id);
            var model = this.ctx.Personajes.Find(Id);
            return View(model);
        }
        public IActionResult Listado(string nombre)
        {
            var model = new PersonajeListadoModel();
            model.Listado = this.ctx.Personajes.ToList();
            return View(model);
        }
        public IActionResult Index(string id, string nombre)
        {
            if (!string.IsNullOrEmpty(id))
            {
                int Id = 0;
                if (int.TryParse(id, out Id))
                {
                    this.ctx.Personajes.Add(new Personaje { Id = Id, Nombre = nombre , Apellido="hola"});
                    this.ctx.SaveChanges();
                }
            }
            return View();
        }
    }
}
