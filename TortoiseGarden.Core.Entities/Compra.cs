using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TortoiseGarden.Core.Entities
{
    [Table("Compra")]
    public class Compra
    {
        [Key]
        public int CompraId { get; set; }
        public DateTime Fecha { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int UsuarioId { get; set; }

        public Compra(int compraId, DateTime fecha, int productoId, int cantidad, int usuarioId)
        {
            CompraId = compraId;
            Fecha = fecha;
            ProductoId = productoId;
            Cantidad = cantidad;
            UsuarioId = usuarioId;
        }
        public Compra(DateTime fecha, int productoId, int cantidad, int usuarioId)
        {
            Fecha = fecha;
            ProductoId = productoId;
            Cantidad = cantidad;
            UsuarioId = usuarioId;
        }

    }
}
