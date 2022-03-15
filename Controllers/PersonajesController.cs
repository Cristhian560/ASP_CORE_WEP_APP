using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            if (p.Id == 0)
            {
                this.ctx.Personajes.Add(p);
            }
            else
            {
                this.ctx.Attach(p);
                this.ctx.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            this.ctx.SaveChanges();
            return RedirectToAction("Listado"); 
        }
        public IActionResult Editar(string id)
        {
        //    int Id = 0;
        //    int.TryParse(id, out Id);
            var model = this.ctx.Personajes.Find(Convert.ToInt32(id));
            

            List<KeyValuePair<int, string>> tipos = new();
            tipos.Add(new KeyValuePair<int, string>(1, "Jedi"));
            tipos.Add(new KeyValuePair<int, string>(2, "Sith"));
            SelectList lista_tipos = new(tipos, "Key", "Value");
            ViewBag.Tipos = lista_tipos;    

            return View(model);
        }
        public IActionResult Nuevo(Personaje p)
        {

            return View();
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
                this.ctx.Personajes.Add(new Personaje { Nombre = nombre });
                this.ctx.SaveChanges();
            }
            return View();
        }
        //public IActionResult Index(string id, string nombre)
        //{
        //    this.ctx.Personajes.Add(new Personaje { Nombre = nombre });
        //    this.ctx.SaveChanges();
        //    if (!string.IsNullOrEmpty(id))
        //    {
        //        int Id = 0;
        //        if (int.TryParse(id, out Id))
        //        {
        //            this.ctx.Personajes.Add(new Personaje { Nombre = nombre });
        //            this.ctx.SaveChanges();
        //        }
        //    }
        //    return View();
        //}
    }
}
