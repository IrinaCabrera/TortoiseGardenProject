using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TortoiseGarden.Core.Entities;

namespace TortoiseGarden.Core.Data
{
    public class UserRepository
    {

        public void RegistrarUsuario(Usuario user)
        {
            using (var db = new TortoiseGardenContext())
            {
                db.Usuarios.Add(user);
                db.SaveChanges();
            }
        }
        public int ObtenerIdUsuario(Usuario user) {
            
            using (var db = new TortoiseGardenContext())
            {
                var query = from u in db.Usuarios
                             where u.Nombre == user.Nombre &&
                                   u.Hash == user.Hash &&
                                   u.Salt == user.Salt
                             select u.UsuarioId;

                    return query.FirstOrDefault();

            }

        }

    }
}
