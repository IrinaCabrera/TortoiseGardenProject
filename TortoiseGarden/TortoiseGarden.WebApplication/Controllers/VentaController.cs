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

        public JsonResult ObtenerIdUsuarios()
        {
            List<int> ids = new UserBusiness().ObtenerIdUsuarios();

            return Json(ids);
        }
        public JsonResult ObtenerNombreProducto()
        {
            List<string> pNombres = new List<string>();
            List<object[]> productos = new ProductBusiness().obtenerProductos();

            foreach (var producto in productos)
            {
                pNombres.Add(producto[0].ToString());
            }


            return Json(pNombres);
        }

        [HttpPost]
        public JsonResult AgregarVenta([FromBody] AgregarVentaDTO venta)
        {
            if (venta == null)
            {
                return Json(new { success = false, message = "Faltan campos por rellenar." });
            }

            int Idproducto = new ProductBusiness().obtenerProductoEspecifico(venta.nombreProducto).ProductoId;


            bool registroExitoso = new SaleBusiness().AgregarVenta(new Venta(venta.fecha, Idproducto, venta.cantidadProducto, venta.idUsuario));

            if (registroExitoso)
            {
                return Json(new { success = true, message = "Registro exitoso" });
            }
            else
            {
                return Json(new { success = false, message = "Error al registrar venta." });
            }
        }
        public class AgregarVentaDTO
        {
            public int idUsuario { get; set; }
            public DateTime fecha { get; set; }
            public string nombreProducto { get; set; }
            public int cantidadProducto { get; set; }

        }

        [HttpPost]
        public JsonResult ObtenerCantidadMaxima([FromBody] string producto)
        {
            int cantidadMaxima = new SaleBusiness().CantidadDisoinibleProducto(producto);
            if (cantidadMaxima > 0)
            {
                return Json(cantidadMaxima);
            }
            else
            {
                return  Json(new { success = false, message = "chale" });
            }
            
        }
    }
}
