using Microsoft.AspNetCore.Mvc;
using TortoiseGarden.Core.Business;
using TortoiseGarden.Core.Entities;

namespace TortoiseGarden.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly SaleBusiness sb;
        private readonly PurchaseBusiness purb;

        public ProductoController()
        {
            sb = new SaleBusiness();
            purb = new PurchaseBusiness();

        }

        [HttpGet("{IdProducto:int}/stock")]
        public int ObtenerStockProducto(int IdProducto)
        {
            int cantComprada = purb.ObtenerCantidadDeProductoCompra(IdProducto);
            int cantidadVendida = sb.ObtenerCantidadDeProductoVenta(IdProducto);

            return cantComprada - cantidadVendida;
            
        }
    }
}
