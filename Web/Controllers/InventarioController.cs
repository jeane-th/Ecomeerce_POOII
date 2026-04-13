using System.Web.Mvc;
using Skart.Services;

namespace Skart.Web.Controllers
{
    public class InventarioController : Controller
    {
        private readonly InventarioService inventarioService = new InventarioService();

        public ActionResult Movimientos(int productoId)
            => View(inventarioService.ListarMovimientos(productoId));
    }

    
}