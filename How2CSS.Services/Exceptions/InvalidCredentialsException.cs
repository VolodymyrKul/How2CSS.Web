using System;

namespace How2CSS.Services.Exceptions
{
    public sealed class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base("Invalid username or password.") { }
    }
}
