using System.Web.Mvc;
using Skart.Entities;
using Skart.Services;

namespace Skart.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaService categoriaService = new CategoriaService();

        public ActionResult Index() => View(categoriaService.ListarCategorias());

        public ActionResult Detalle(int id) => View(categoriaService.ObtenerCategoria(id));

        [HttpGet]
        public ActionResult Crear() => View();

        [HttpPost]
        public ActionResult Crear(Categoria c)
        {
            if (ModelState.IsValid)
            {
                categoriaService.CrearCategoria(c);
                return RedirectToAction("Index");
            }
            return View(c);
        }

        [HttpGet]
        public ActionResult Editar(int id) => View(categoriaService.ObtenerCategoria(id));

        [HttpPost]
        public ActionResult Editar(Categoria c)
        {
            if (ModelState.IsValid)
            {
                categoriaService.ActualizarCategoria(c);
                return RedirectToAction("Index");
            }
            return View(c);
        }

        public ActionResult Eliminar(int id)
        {
            categoriaService.EliminarCategoria(id);
            return RedirectToAction("Index");
        }
    }
}