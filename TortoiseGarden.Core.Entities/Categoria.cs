using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TortoiseGarden.Core.Entities
{
    [Table ("Categoria")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        public string Nombre { get; set; }

    }
}
