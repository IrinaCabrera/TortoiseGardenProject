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
            bool seEncontro = false;
            HashHandler Hash = new HashHandler();
            List<string[]> infoUsr = ur.ObtenerHashSalUsuarios(name);
            
            foreach (var item in infoUsr)
            {
               var claveHasheada = Hash.HashearClave(pass, Encoding.UTF8.GetBytes(item[1]));
                
                if (Convert.ToBase64String(claveHasheada) == item[0])
                {
                    seEncontro = true;
                }
                break;
            }
            return seEncontro;
        }

    }
}
