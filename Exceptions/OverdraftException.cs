using System;

namespace SimpleBank.Exceptions
{
    public class OverdraftException : Exception
    {
        public OverdraftException() { }

        public OverdraftException(string message) : base(message) { }

        public OverdraftException(string message, Exception inner) : base(message, inner) { }
    }
}
