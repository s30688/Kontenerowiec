using System;

namespace Kontenerowiec.Exceptions
{
    public class OverfillException : Exception
    {
        public OverfillException(string message) : base(message) { }
    }
}
