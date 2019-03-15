using System;

namespace RomanProject.Tools.Exceptions
{
    class WrongNameException : PersonPropertyException
    {
        public WrongNameException()
        {
        }

        public WrongNameException(string message) : base(message)
        {
        }

        public WrongNameException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
