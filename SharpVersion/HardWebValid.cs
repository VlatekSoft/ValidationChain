using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpVersion
{
    static class HardWebValid
    {
        public static void Put_Hash(Dictionary<string, byte[]> dict)
        {
            //отправить полный хеш на хранение в блокчейн?
        }

        public static bool Check_Hash(Dictionary<string, byte[]> finaly_hash)
        {
            //проверка локального кеша и хранящегося удалённо
            bool result = true || false;
            return result;
        }
    }
}
