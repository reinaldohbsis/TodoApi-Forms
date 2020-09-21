using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.API.Models
{
    public class Tarefa
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        public string Descricao { get; set; }

        public long IdPessoa { get; set; }

        public virtual Pessoa Pessoas { get; set; }


    }
}
