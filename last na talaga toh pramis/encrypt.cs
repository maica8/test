using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace last_na_talaga_toh_pramis
{
    internal class encrypt
    {
        public static string hashstring(string passwordstring)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(passwordstring))
                sb.Append(b.ToString("X3"));
            return sb.ToString();

        }

        public static byte[] GetHash(string passwordstring)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(passwordstring));
        }
    }
}
