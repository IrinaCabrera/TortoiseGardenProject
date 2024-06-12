using System;
using System.Collections.Generic;
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

        public void RegistrarUsuario(string password, string name)
        {
            HashHandler Hash = new HashHandler();
            var salt = Hash.GenerarSalt();
            var hashPass = Convert.ToBase64String(Hash.HashearClave(password, salt));
            ur.RegistrarUsuario(new Usuario(name, hashPass, Convert.ToBase64String(salt)));

        }
        public void ComprobarUsuario()
        {


        }

    }
}
