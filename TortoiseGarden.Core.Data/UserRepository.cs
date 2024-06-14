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
        public int ObtenerIdUsuario(Usuario user)
        {

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
        public List<string[]> ObtenerHashSalUsuarios(string name)
        {
            using (var db = new TortoiseGardenContext())
            {
                List<string[]> infoUsr = new List<string[]>();
                var query = from u in db.Usuarios
                            where u.Nombre == name
                            select new
                            {
                                hash = u.Hash,
                                salt = u.Salt
                            };
                
                foreach (var item in query)
                {
                    infoUsr.Add(item: [item.hash, item.salt]);
                }

                return infoUsr;
            }

        }
    }
}
