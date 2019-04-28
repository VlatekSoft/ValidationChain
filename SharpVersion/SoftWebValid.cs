using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SharpVersion
{
    static class SoftWebValid
    {
        public static async Task<bool> Check_Face(string image1, string image2)
        {
            //подключить API Azure для проверки лиц
            bool result = false;
            Azure az = new Azure();
            result = await az.f();
            return result;
        }

        public static byte[] Get_Image(byte[] hash, byte[] finaly_hash)
        {
            byte[] result = File.ReadAllBytes("img\\" + Crypt.Byte_To_String(hash));
            result = Crypt.Decrypt(result, finaly_hash);
            File.WriteAllBytes("1.jpg", result);
            return result;
        }

        public static void Put_Bio(byte[] hash, byte[] finaly_hash, byte[] image)
        {
            string name = Crypt.Byte_To_String(hash);
            byte[] result = Crypt.Encrypt(image, finaly_hash);
            File.WriteAllBytes("img\\" + name, result);
        }
    }
}
