using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TortoiseGarden.Core.Business
{
    public class HashHandler
    {

        public byte[] GenerarSalt()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[16];
                rng.GetBytes(salt);
               
                return salt;
            }
        }
        public byte[] HashearClave(string password, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

            // Concatenar password y salt
            Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

            //Hashear la concatenacion de password y salt
            byte[] hashedBytes = SHA256.HashData(saltedPassword);

            return hashedBytes;
        }

    }
}
