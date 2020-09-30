using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Validadores.Exceptions
{
    public class SenhaNaoBateException : Exception
    {
        public SenhaNaoBateException() : this("Senhas não conferem")
        {
        }

        public SenhaNaoBateException(string message) : base(message)
        {
        }

        public SenhaNaoBateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SenhaNaoBateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
