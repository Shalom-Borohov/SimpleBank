using System;

namespace SimpleBank.IO.Writers
{
    public abstract class Writer
    {
        public virtual void WriteLine(string message) => Console.WriteLine(message);
        public virtual void WriteNewLine() => WriteLine(string.Empty);
    }
}
