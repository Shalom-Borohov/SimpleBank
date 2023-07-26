using System;
using SimpleBank.Utils;

namespace SimpleBank.IO.Readers
{
    public class Reader
    {
        public EnumUtil EnumUtil = new EnumUtil();

        public string ReadLine() => Console.ReadLine();
        public uint ReadUInt()
        {
            var isParsed = uint.TryParse(ReadLine(), out var naturalNum);

            if (isParsed)
            {
                return naturalNum;
            }

            throw new FormatException("Unable to get natural number");
        }

        public T ReadEnum<T>() => EnumUtil.ParseEnum<T>(ReadLine());
    }
}
