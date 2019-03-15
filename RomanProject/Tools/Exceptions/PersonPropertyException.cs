using System;

namespace RomanProject.Tools.Exceptions
{
    class PersonPropertyException : Exception
    {
        public PersonPropertyException()
        {
        }

        public PersonPropertyException(string message) : base(message)
        {
        }

        public PersonPropertyException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
