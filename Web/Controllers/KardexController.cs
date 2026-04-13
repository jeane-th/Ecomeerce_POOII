using System.Web.Mvc;
using Skart.Services;

namespace Skart.Web.Controllers
{
    public class KardexController : Controller
    {
        private readonly KardexService kardexService = new KardexService();

        public ActionResult Index(int productoId)
            => View(kardexService.ObtenerKardex(productoId));
    }
}