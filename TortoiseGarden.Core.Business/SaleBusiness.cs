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


    }
}
