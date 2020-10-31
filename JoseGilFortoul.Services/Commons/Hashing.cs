using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness.Hashing
{
    public class Hashing
    {
        public static string Encrypted(string pass)
        {
            SHA1CryptoServiceProvider encriptador = new SHA1CryptoServiceProvider();
            Byte[] arregloBytes = Encoding.ASCII.GetBytes(pass);
            arregloBytes = encriptador.ComputeHash(arregloBytes);
            string resultado = "";

            foreach (var item in arregloBytes)
            {
                resultado += item.ToString("x2");
            }

            return resultado;
        }
    }
}
