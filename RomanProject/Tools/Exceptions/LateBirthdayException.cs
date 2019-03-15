using System;

namespace RomanProject.Tools.Exceptions
{
    class LateBirthdayException : PersonPropertyException
    {
        public LateBirthdayException()
        {
        }

        public LateBirthdayException(string message) : base(message)
        {
        }

        public LateBirthdayException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
