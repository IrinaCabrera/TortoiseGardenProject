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
        public void ComprobarUsuario() { 
        
        
        }

    }
}
