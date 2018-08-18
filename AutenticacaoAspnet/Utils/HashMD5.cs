using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AutenticacaoAspnet.Utils
{
    public class HashMD5
    {
        public static string GerarHash(string texto)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            byte[] hash = md5.ComputeHash(bytes);
            StringBuilder result = new StringBuilder();

            for(int i = 0; i < hash[i]; i++)
            {
                result.Append(hash[i].ToString("X"));
            }
            return result.ToString();

        }
    }
}