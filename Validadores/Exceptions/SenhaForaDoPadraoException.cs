using System;
using System.Collections.Generic;
using System.Text;

namespace Validadores.Exceptions
{
    public class SenhaForaDoPadraoException : Exception
    {
        public SenhaForaDoPadraoException() : this("Senha fora dos padrões\n\nA senha deve conter no mínimo 6 caracteres\nE deve ser preenchida apenas numericamente")
        {
        }

        public SenhaForaDoPadraoException(string message) : base(message)
        {
        }
    }
}
