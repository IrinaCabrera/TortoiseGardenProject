using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TortoiseGarden.Core.Entities;

namespace TortoiseGarden.Core.Data
{
    public class ProductRepository
    {


        //obtener productos con categoria y sus respectivos id, ayudara apra la modificacion
        public List<object[]> obtenerProductosModificables()
        {
            List<object[]> productos = new List<object[]>();

            using (var db = new TortoiseGardenContext())
            {
                var query = from p in db.Productos
                            join c in db.Categorias
                            on p.CategoriaId equals c.CategoriaId
                            select new
                            {
                                Producto = p,
                                Categoria = c
                            };
                foreach (var item in query)
                {
                    productos.Add(
                        [item.Producto.ProductoId,
                         item.Producto.Nombre,
                         item.Producto.Habilitado,
                         item.Producto.CategoriaId,
                         item.Categoria.Nombre]
                    );
                }
                return productos;
            }
        }


        public List<object[]> obtenerProductos()
        {
            List<object[]> productos = new List<object[]>();

            using (var db = new TortoiseGardenContext())
            {
                var query = from p in db.Productos
                            join c in db.Categorias
                            on p.CategoriaId equals c.CategoriaId
                            select new
                            {
                                pname = p.Nombre,
                                pcategoria = c.Nombre,
                                phabilitado = p.Habilitado
                            };

                foreach (var item in query)
                {
                    productos.Add(
                        [item.pname,item.pcategoria,item.phabilitado]
                    );
                }

                return productos;
            }
        }


        public Producto ObtenerPorId(int condicion)
        {
            using (var db = new TortoiseGardenContext())
            {
                var query = from p in db.Productos
                            where p.ProductoId == condicion
                            select p;

                return query.FirstOrDefault();
            }
        }
        public Producto ObtenerPorNombre(string condicion)
        {
            using (var db = new TortoiseGardenContext())
            {
                var query = from p in db.Productos
                            where p.Nombre == condicion
                            select p;

                return query.FirstOrDefault();
            }
        }

        public List<Categoria> obtenerCategoria()
        {
            using (var db = new TortoiseGardenContext())
            {
                var query = from c in db.Categorias
                            select c;

                return query.ToList();
            }
        }

        public void crearProducto(Producto p)
        {
            using (var db = new TortoiseGardenContext())
            {
                db.Productos.Add(p);
                db.SaveChanges();
            }
        }
    }
}
