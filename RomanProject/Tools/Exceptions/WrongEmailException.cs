using System;

namespace RomanProject.Tools.Exceptions
{
    class WrongEmailException : PersonPropertyException
    {
        public WrongEmailException()
        {
        }

        public WrongEmailException(string message) : base(message)
        {
        }

        public WrongEmailException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
