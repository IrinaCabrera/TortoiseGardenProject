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
        public JsonResult ObtenerIdUsuarios()
        {
            List<int> ids = new UserBusiness().ObtenerIdUsuarios();

            return Json(ids);
        }
        public JsonResult ObtenerNombreProducto()
        {
            List<string> pNombres=new List<string>();
            List<object[]> productos = new ProductBusiness().obtenerProductos();

            foreach (var producto in productos)
            {
                pNombres.Add(producto[0].ToString());
            }


            return Json(pNombres);
        }
    }
}
