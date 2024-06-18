using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TortoiseGarden.Core.Data;
using TortoiseGarden.Core.Entities;


namespace TortoiseGarden.Core.Business
{
    public class UserBusiness
    {
        public readonly UserRepository ur;

        public UserBusiness() {
            ur = new UserRepository();
        }

        public bool RegistrarUsuario(string pass, string name)
        {
            HashHandler Hash = new HashHandler();
            var salt = Hash.GenerarSalt();
            var hashPass = Convert.ToBase64String(Hash.HashearClave(pass, salt));
            var user = new Usuario(name, hashPass, Convert.ToBase64String(salt));
            ur.RegistrarUsuario(user);

            if(ObtenerIdUsuario(user) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public int ObtenerIdUsuario(Usuario user)
        {
            return ur.ObtenerIdUsuario(user);
        }

        public bool AutenticarUsuario(string pass, string name)
        {

            HashHandler Hash = new HashHandler();
            List<string[]> infoUsr = ur.ObtenerHashSalUsuarios(name);
            
            foreach (var item in infoUsr)
            {
                byte[] salt = Convert.FromBase64String(item[1]);

                byte[] claveHasheada = Hash.HashearClave(pass, salt);
               string claveHasheadaString = Convert.ToBase64String(claveHasheada);
                
                if (claveHasheadaString.Equals(item[0]))
                {
                    return true;
                }
                
            }
            return false;
        }

        public List<int> ObtenerIdUsuarios()
        {
            return ur.ObtenerIdUsuarios();
        }
    }
}
