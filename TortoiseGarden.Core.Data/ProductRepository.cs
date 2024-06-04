using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using TortoiseGarden.Core.Entities;

namespace TortoiseGarden.Core.Data
{
    public class ProductRepository
    {


        //obtener productos con categoria y sus respectivos id, ayudara apra la modificacion
        public List<object[]> ObtenerProductosConInformacionCompleta()
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


        public void EliminarProducto(Producto productoAEliminar)
        {
            using (var bd = new TortoiseGardenContext())
            {
                bd.Productos.Remove(productoAEliminar);
                bd.SaveChanges();
            }
        }

        
        public void ModificarProducto(int id,Producto pNuevo)
        {
            using (var bd = new TortoiseGardenContext())
            {
                //busco
                var pModificable = bd.Productos.SingleOrDefault(p => p.ProductoId == id);

                pModificable.Nombre = pNuevo.Nombre;
                pModificable.CategoriaId = pNuevo.CategoriaId;
                pModificable.Habilitado = pNuevo.Habilitado;

                bd.SaveChanges();
            }
        }
    }
}
