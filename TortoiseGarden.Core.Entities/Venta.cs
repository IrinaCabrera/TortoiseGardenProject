using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TortoiseGarden.Core.Entities
{
    [Table("Venta")]
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int UsuarioId { get; set; }

        public Venta(int ventaId, DateTime fecha, int productoId, int cantidad, int usuarioId)
        {
            VentaId = ventaId;
            Fecha = fecha;
            ProductoId = productoId;
            Cantidad = cantidad;
            UsuarioId = usuarioId;
        }
        public Venta(DateTime fecha, int productoId, int cantidad, int usuarioId)
        {
            Fecha = fecha;
            ProductoId = productoId;
            Cantidad = cantidad;
            UsuarioId = usuarioId;
        }
    }
}
