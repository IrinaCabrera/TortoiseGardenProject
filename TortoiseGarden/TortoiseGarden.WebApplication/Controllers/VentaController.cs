using Microsoft.AspNetCore.Mvc;
using TortoiseGarden.Core.Entities;
using TortoiseGarden.Core.Business;

namespace TortoiseGarden.WebApplication.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ObtenerVentas()
        {
            List<object[]> ventas = new List<object[]>();
            ventas = new SaleBusiness().ObtenerVentas();

            return Json(ventas);
        }
    }
}
