using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ClientesController : Controller
    {
        public StarwarsDb ctx { get; set; }
        public ClientesController(StarwarsDb ctx)
        {
            this.ctx = ctx;
        }
        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                this.ctx.Clientes.Add(cliente);
            }
            else
            {
                this.ctx.Attach(cliente);
                this.ctx.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            this.ctx.SaveChanges();
            return RedirectToAction("Listado");
        }
        public IActionResult Borrar(string id)
        {
            //    int Id = 0;
            //    int.TryParse(id, out Id);
            var model = this.ctx.Clientes.Find(Convert.ToInt32(id));
            this.ctx.Remove(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            this.ctx.SaveChanges(); 
            return RedirectToAction("Listado");
        }
        public IActionResult Editar(string id)
        {
            //    int Id = 0;
            //    int.TryParse(id, out Id);
            var model = this.ctx.Clientes.Find(Convert.ToInt32(id));
            return View(model);
        }
        public ActionResult Listado()
        {
            //var model = new PersonajeListadoModel();
            //model.Listado = this.ctx.Personajes.ToList();
            List<Cliente> lista_clientes = new List<Cliente>();
            lista_clientes = this.ctx.Clientes.ToList();
            return View(lista_clientes);
        }
    }
}
