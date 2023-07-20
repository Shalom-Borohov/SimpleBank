using System;

namespace SimpleBank.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException() { }

        public AccountNotFoundException(string message) : base(message) { }

        public AccountNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
