using System;

namespace Parser
{
    public class ParseException : Exception
    {
        public ParseException (string message = null) : base (message)
        {

        }
    }
}