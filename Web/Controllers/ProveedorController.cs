using System.Web.Mvc;
using Skart.Entities;
using Skart.Services;

namespace Skart.Web.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly ProveedorService proveedorService = new ProveedorService();

        public ActionResult Index() => View(proveedorService.ListarProveedores());

        public ActionResult Detalle(int id) => View(proveedorService.ObtenerProveedor(id));

        [HttpGet]
        public ActionResult Crear() => View();

        [HttpPost]
        public ActionResult Crear(Proveedor p)
        {
            if (ModelState.IsValid)
            {
                proveedorService.CrearProveedor(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Editar(int id) => View(proveedorService.ObtenerProveedor(id));

        [HttpPost]
        public ActionResult Editar(Proveedor p)
        {
            if (ModelState.IsValid)
            {
                proveedorService.ActualizarProveedor(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public ActionResult Eliminar(int id)
        {
            proveedorService.EliminarProveedor(id);
            return RedirectToAction("Index");
        }
    }
}