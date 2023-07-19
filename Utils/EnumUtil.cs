using System;

namespace SimpleBank.Utils
{
    public class EnumUtil
    {
        public T ParseEnum<T>(string value) =>
            (T)Enum.Parse(typeof(T), value, true);
    }
}
