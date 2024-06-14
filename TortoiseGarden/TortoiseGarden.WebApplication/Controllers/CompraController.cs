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
        public JsonResult ObtenerNombreProducto()
        {
            List<string> pNombres=new List<string>();
            List<object[]> productos = new List<object[]>();
            ProductBusiness pb = new ProductBusiness();
            
            productos = pb.obtenerProductos();

            foreach (var producto in productos)
            {
                pNombres.Add(producto[0].ToString());
            }


            return Json(pNombres);
        }
    }
}
