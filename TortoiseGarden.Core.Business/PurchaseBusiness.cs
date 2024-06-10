using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TortoiseGarden.Core.Data;
using TortoiseGarden.Core.Entities;

namespace TortoiseGarden.Core.Business
{
    public class PurchaseBusiness
    {
        public readonly PurchaseRepository sr;
        public PurchaseBusiness()
        {
            sr = new PurchaseRepository();
        }

        public List<object[]> ObtenerCompras()
        {
            return sr.ObtenerCompras();
        }
    }
}
