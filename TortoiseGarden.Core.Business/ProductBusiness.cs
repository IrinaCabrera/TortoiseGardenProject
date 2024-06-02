using TortoiseGarden.Core.Data;
using TortoiseGarden.Core.Entities;
namespace TortoiseGarden.Core.Business
{
    public class ProductBusiness
    {
        ProductRepository data;
        public ProductBusiness() { 

            data = new ProductRepository();
        }

        public List<Producto> obtenerProductos() { 
            return data.obtenerProductos();
        }



    }
}
