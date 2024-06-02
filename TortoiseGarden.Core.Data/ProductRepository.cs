using TortoiseGarden.Core.Entities;

namespace TortoiseGarden.Core.Data
{
    public class ProductRepository
    {


        public List<Producto> obtenerProductos()
        {
            using (var bd = new TortoiseGardenContext())
            {
                var query = from p in bd.Productos
                            select p;
                    
                return query.ToList();
            }
        }
    }
}
