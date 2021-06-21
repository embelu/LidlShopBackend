using System;
using System.Collections.Generic;
using System.Text;

namespace LidlShop.BL.Exceptions
{
    public class CommandeException : Exception
    {
        public CommandeException()
        {
        }

        public CommandeException(string message) : base(message)
        {
        }

        public CommandeException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
