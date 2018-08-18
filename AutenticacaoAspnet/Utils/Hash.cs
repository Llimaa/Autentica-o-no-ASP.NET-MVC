using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AutenticacaoAspnet.Utils
{
    public class Hash
    {
        public static string GerarHash (string texto)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(texto);//transformo um conjunto de testo para bytes
            byte[] hash = sha256.ComputeHash(bytes);// aqui e onde ele gera a ciptografia e ele retorna um array de 16 bytes
            StringBuilder result = new StringBuilder();// e como ele vai mandando de dois em dois bytes a class stringBuild e responsavel para ir recebendo esse bytes ate forma a palavra.

            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X"));
            }
            return result.ToString();
        }
    }
}