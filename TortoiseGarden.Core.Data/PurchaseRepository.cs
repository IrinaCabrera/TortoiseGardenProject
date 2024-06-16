using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TortoiseGarden.Core.Entities;

namespace TortoiseGarden.Core.Data
{
    public class PurchaseRepository
    {
        public List<object[]> ObtenerCompras()
        {
            List<object[]> compras = new List<object[]>();

            using (var db = new TortoiseGardenContext())
            {
                var query = from compra in db.Compras
                            join producto in db.Productos on compra.ProductoId equals producto.ProductoId
                            join usuario in db.Usuarios on compra.UsuarioId equals usuario.UsuarioId
                            select new
                            {
                                cCompraId = compra.CompraId,
                                cFecha = compra.Fecha,
                                cNombreProducto = producto.Nombre,
                                cCantidad = compra.Cantidad,
                                cUsuarioId = usuario.UsuarioId,
                                cNombreUsuario = usuario.Nombre

                            };

                foreach (var item in query)
                {
                    compras.Add(
                            [item.cCompraId,
                             item.cFecha,
                             item.cNombreProducto,
                             item.cCantidad,
                             item.cUsuarioId,
                             item.cNombreUsuario]
                    );
                }
                return compras;
            }
        }

        public void AgregarCompra(Compra compra)
        {
            using (var db = new TortoiseGardenContext())
            {
                db.Compras.Add(compra);
                db.SaveChanges();
            }
        }

        public int ObtenerCompraPorId(Compra compra)
        {
            using (var db = new TortoiseGardenContext())
            {
                var query = from c in db.Compras
                            where c.ProductoId == compra.ProductoId &&
                                  c.Cantidad == compra.Cantidad &&
                                  c.UsuarioId == c.UsuarioId &&
                                  c.Fecha == c.Fecha
                            select c.CompraId;

                return query.FirstOrDefault();
            }
        }
    }
}
