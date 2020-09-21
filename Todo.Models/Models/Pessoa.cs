using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.API.Models
{
    public class Pessoa
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; } = new HashSet<Tarefa>();

    }
}
