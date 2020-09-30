using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.API.Models
{
    public class Time
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; } = new HashSet<Tarefa>();
        public ICollection<Pessoa> Pessoas { get; set; } = new HashSet<Pessoa>();

    }
}
