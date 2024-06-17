using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TortoiseGarden.Core.Entities;

namespace TortoiseGarden.Core.Data
{
    public class SaleRepository
    {


        /*get all venta*/
        public List<object[]> ObtenerVentas()
        {
            List<object[]> ventas = new List<object[]>();

            using (var db= new TortoiseGardenContext())
            {
                var query =  from venta in db.Ventas
                             join producto in db.Productos on venta.ProductoId equals producto.ProductoId
                             join usuario in db.Usuarios on venta.UsuarioId equals usuario.UsuarioId
                             select new
                             {
                                 vVentaId = venta.VentaId,
                                 vFecha = venta.Fecha,
                                 vNombreProducto = producto.Nombre,
                                 vCantidad = venta.Cantidad,
                                 vUsuarioId = usuario.UsuarioId,
                                 vNombreUsuario = usuario.Nombre

                             };

                foreach (var item in query)
                {
                    ventas.Add(
                            [item.vVentaId, 
                            item.vFecha, 
                            item.vNombreProducto,
                            item.vCantidad, 
                            item.vUsuarioId, 
                            item.vNombreUsuario]
                    );
                }
                return ventas;
            }
        }

        public void AgregarVenta(Venta venta)
        {
            using (var db = new TortoiseGardenContext())
            {
                db.Ventas.Add(venta);
                db.SaveChanges();
            }
        }

        public int ObtenerVentaPorId(Venta venta)
        {
            using (var db = new TortoiseGardenContext())
            {
                var query = from v in db.Ventas
                            where v.ProductoId == venta.ProductoId &&
                                  v.Cantidad == venta.Cantidad &&
                                  v.UsuarioId == venta.UsuarioId &&
                                  v.Fecha == venta.Fecha
                            select v.VentaId;

                return query.FirstOrDefault();
            }
        }
    }
}
