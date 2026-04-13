using System.Web.Mvc;
using Skart.Entities;
using Skart.Services;

namespace Skart.Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoService productoService = new ProductoService();

        public ActionResult Index() => View(productoService.ListarProductos());

        public ActionResult Detalle(int id) => View(productoService.ObtenerProducto(id));

        [HttpGet]
        public ActionResult Crear() => View();

        [HttpPost]
        public ActionResult Crear(Producto p)
        {
            if (ModelState.IsValid)
            {
                productoService.CrearProducto(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Editar(int id) => View(productoService.ObtenerProducto(id));

        [HttpPost]
        public ActionResult Editar(Producto p)
        {
            if (ModelState.IsValid)
            {
                productoService.ActualizarProducto(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public ActionResult Eliminar(int id)
        {
            productoService.EliminarProducto(id);
            return RedirectToAction("Index");
        }
    }
}