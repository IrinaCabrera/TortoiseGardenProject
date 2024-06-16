using Microsoft.AspNetCore.Mvc;
using TortoiseGarden.Core.Business;
using TortoiseGarden.Core.Entities;
using static TortoiseGarden.WebApplication.Controllers.HomeController;

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

        [HttpPost]
        public JsonResult AgregarCompra([FromBody] AgregarCompraDTO compra)
        {
            if (compra == null)
            {
                return Json(new { success = false, message = "Faltan campos por rellenar." });
            }

            int Idproducto = new ProductBusiness().obtenerProductoEspecifico(compra.nombreProducto).ProductoId;


            bool registroExitoso = new PurchaseBusiness().AgregarCompra(new Compra( compra.fecha, Idproducto, compra.cantidadProducto, compra.idUsuario));

            if (registroExitoso)
            {
                return Json(new { success = true, message = "Registro exitoso" });
            }
            else
            {
                return Json(new { success = false, message = "Error al registrar compra" });
            }
        }
        public class AgregarCompraDTO{
            public int idUsuario { get; set; }
            public DateTime fecha { get; set; }
            public string nombreProducto { get; set; }
            public int cantidadProducto { get; set; }
            
        }
       
    }
}
