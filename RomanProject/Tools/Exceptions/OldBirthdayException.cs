using System;

namespace RomanProject.Tools.Exceptions
{
    class OldBirthdayException : PersonPropertyException
    {
        public OldBirthdayException()
        {
        }

        public OldBirthdayException(string message) : base(message)
        {
        }

        public OldBirthdayException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
