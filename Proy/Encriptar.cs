using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Proy
{
    class Encriptar
    {
        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();//crear instancia para implementar algoritmo MD5
            ASCIIEncoding encoding = new ASCIIEncoding();//Codifica un juego de caracteres del objeto String especificado en la matriz de bytes especificada.
            byte[] stream = null; //creamos un array tipo byte
            StringBuilder sb = new StringBuilder();//modificar cadena sin crear nuevo objeto
            stream = md5.ComputeHash(encoding.GetBytes(str));//codificar cadena
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);//codifica cada elemento del array
            return sb.ToString();
        }
    }
}
