using System;
using SimpleBank.Utils;

namespace SimpleBank.IO.Readers
{
    public class Reader
    {
        public EnumUtil EnumUtil = new EnumUtil();

        public string ReadLine() => Console.ReadLine();
        public T ReadEnum<T>() => EnumUtil.ParseEnum<T>(ReadLine());
    }
}
