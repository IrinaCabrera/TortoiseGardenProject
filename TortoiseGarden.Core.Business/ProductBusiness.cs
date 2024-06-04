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
        public List<object[]> ObtenerProductosConInformacionCompleta()
        {
            return data.ObtenerProductosConInformacionCompleta();
        }

        public Producto obtenerProductoEspecifico(string condicion)
        {
            
            if(int.TryParse(condicion, out int productoId))
            {
                
                return data.ObtenerPorId(productoId);  
            }
            else 
            {
                return data.ObtenerPorNombre(condicion.Trim());
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

        public void EliminarProducto(Producto p)
        {
            data.EliminarProducto(p);
        }

        public void ModificarProducto(int id, Producto pNuevo)
        {
            data.ModificarProducto( id, pNuevo);
        }
    }
}
