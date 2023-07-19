using System;

namespace SimpleBank.Exceptions
{
    public class DuplicateAccountIdException : Exception
    {
        public DuplicateAccountIdException() { }

        public DuplicateAccountIdException(string message) : base(message) { }

        public DuplicateAccountIdException(string message, Exception innerException) : base(message, innerException) { }
    }
}
