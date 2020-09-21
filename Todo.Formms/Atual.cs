using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Formms
{
    
    public class Atual
    {
        public static Atual _Id;
        public int Id { get; set; }
        public string User { get; set; }
        public string Senha { get; set; }

        public override string ToString()
        {
            string retorno = ""; 
            return retorno+_Id.Id;
        }

    }
}
