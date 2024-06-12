using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TortoiseGarden.Core.Entities
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }

        public string Hash { get; set; }
        public string Salt { get; set; }

        public Usuario(string nombre, string hash, string salt)
        {
            Nombre = nombre;
            Hash = hash;
            Salt = salt;
        }
        public Usuario(int usuarioId, string nombre, string hash, string salt)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Hash = hash;
            Salt = salt;
        }

    }
}
