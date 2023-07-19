using System;

namespace SimpleBank.IO.Readers
{
    public class Reader
    {
        public int ReadInt() => int.Parse(Console.ReadLine() ?? string.Empty);
    }
}
