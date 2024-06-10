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

    }
}
