using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TortoiseGarden.Core.Data;
using TortoiseGarden.Core.Entities;

namespace TortoiseGarden.Core.Business
{
    public class SaleBusiness
    {
        public readonly SaleRepository sr;
        public SaleBusiness() {
            sr = new SaleRepository();
        }

        public List<object[]> ObtenerVentas()
        {
            return sr.ObtenerVentas();
        }
        public bool AgregarVenta(Venta venta)
        {
            sr.AgregarVenta(venta);

            if (sr.ObtenerVentaPorId(venta) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CantidadDisoinibleProducto(string pName)
        {
            Producto producto = new ProductBusiness().obtenerProductoEspecifico(pName);
            int cantidadComprada = new PurchaseBusiness().ObtenerCantidadDeProductoCompra(producto.ProductoId);
            int cantidadVendida = sr.ObtenerCantidadDeProductoVenta(producto.ProductoId);

            int cantidadDisponible = cantidadComprada - cantidadVendida;
            if(cantidadDisponible > 0)
            {
                return cantidadDisponible;
            }
            return 0;
        }
        public int ObtenerCantidadDeProductoVenta(int productoId)
        {
            return sr.ObtenerCantidadDeProductoVenta(productoId);
        }
    }
}
