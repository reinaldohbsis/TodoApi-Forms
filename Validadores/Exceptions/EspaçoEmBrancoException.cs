using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Validadores.Exceptions
{
    public class EspaçoEmBrancoException : Exception
    {
        public EspaçoEmBrancoException()
        {
            
        }

        public EspaçoEmBrancoException(string message) : base(message)
        {
            
        }

        public EspaçoEmBrancoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EspaçoEmBrancoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
