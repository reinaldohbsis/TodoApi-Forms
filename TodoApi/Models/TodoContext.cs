using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.API.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoContext).Assembly);


        }

        public DbSet<Tarefa> TodoItems { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Time> Times { get; set; }

    }
}
