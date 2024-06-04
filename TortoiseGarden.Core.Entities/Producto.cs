using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TortoiseGarden.Core.Entities
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
        public bool Habilitado { get; set; }

        public Producto(int productoId, string nombre, int categoriaId, bool habilitado)
        {
            ProductoId = productoId;
            Nombre = nombre;
            CategoriaId = categoriaId;
            Habilitado = habilitado;
        }

        public Producto(string nombre, int categoriaId, bool habilitado)
        {
            Nombre = nombre;
            CategoriaId = categoriaId;
            Habilitado = habilitado;
        }

        public override string ToString()
        {
            return 
                $"id: {ProductoId} " +
                $" name: {Nombre} " +
                $" idCategoria: {CategoriaId} " +
                $" habilitado: {Habilitado}\n";

        }



    }
}
