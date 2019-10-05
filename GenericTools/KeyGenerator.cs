using System;

namespace GenericTools
{
    public class KeyGenerator
    {
        private static string _lasId ;

        public static string GetNewId()
        {
            string str = 
                BitConverter.ToUInt64(Guid.NewGuid().ToByteArray(), 8).ToString();
            long ticks = 
                DateTime.Now.Ticks;
            int length = 
                8;
            if (str.Length < 8)
                length = str.Length;
            var key = $"{(object)ticks}.{(object)str.Substring(0, length)}";
            if (key.Equals(KeyGenerator._lasId)  )
                return KeyGenerator.GetNewId();
            KeyGenerator._lasId = key;
            return key;
        }
    }
}
