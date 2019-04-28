using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using TPJ.Encrypt;
using TPJ.Encrypt.Models;

namespace SharpVersion
{
    static class Crypt
    {
        public static byte[] Get_Hash(string s)
        {
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(s); ;
            byte[] tmpHash = new SHA256CryptoServiceProvider().ComputeHash(tmpSource);
            return tmpHash;
        }

        public static string Byte_To_String(byte[] arr)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arr.Length);
            for (i = 0; i < arr.Length; i++)
            {
                sOutput.Append(arr[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

        public static byte[] Encrypt(byte[] data, byte[] key)
        {
            Encryption e = new Encryption(new EncryptSettings(Convert.ToBase64String(key)));
            return Convert.FromBase64String(e.Encrypt(Convert.ToBase64String(data)));
        }

        public static byte[] Decrypt(byte[] data, byte[] key)
        {
            Encryption e = new Encryption(new EncryptSettings(Convert.ToBase64String(key)));
            return Convert.FromBase64String(e.Decrypt(Convert.ToBase64String(data)));
        }
    }
}
