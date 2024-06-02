using System.Drawing;
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

        public List<object[]> obtenerProductos()
        {
            return data.obtenerProductos();
        }

        //info completa
        public List<object[]> obtenerProductosModificables()
        {
            return data.obtenerProductosModificables();
        }

        public Producto obtenerProductoEspecifico(dynamic condicion)
        {
            try
            {
                return data.ObtenerPorId(condicion);  
            }
            catch (Exception ex)
            {

                return data.ObtenerPorNombre(condicion);
            }
        }

        public List<Categoria> obtenerCategoria()
        {
            return data.obtenerCategoria();
        }

        public void CrearProducto(Producto p)
        {
            data.crearProducto(p);
        }
    }
}
