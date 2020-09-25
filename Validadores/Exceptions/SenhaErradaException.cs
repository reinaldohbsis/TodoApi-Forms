using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Validadores.Exceptions
{
    public class SenhaErradaException : Exception
    {
        public SenhaErradaException() : this("A senha digitada está incorreta"){ }

        public SenhaErradaException(string message)
            : base(message) { }

        public SenhaErradaException(string message, Exception inner)
            : base(message, inner) { }
    }
}
