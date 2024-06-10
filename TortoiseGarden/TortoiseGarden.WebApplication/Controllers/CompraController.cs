using Microsoft.AspNetCore.Mvc;
using TortoiseGarden.Core.Business;

namespace TortoiseGarden.WebApplication.Controllers
{
    public class CompraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ObtenerCompras()
        {
            List<object[]> compras = new List<object[]>();
            compras = new PurchaseBusiness().ObtenerCompras();

            return Json(compras);
        }
    }
}
