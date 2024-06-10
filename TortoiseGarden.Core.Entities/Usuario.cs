using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TortoiseGarden.Core.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }

        public string Hash { get; set; }
        public string Salt { get; set; }

        public Usuario(int usuarioId, string nombre, string hash, string salt)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Hash = hash;
            Salt = salt;
        }

    }
}
