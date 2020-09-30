using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.API.Models;

namespace Todo.API.Types
{
    public class TarefaTypeConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.Property(q => q.Nome).IsRequired().HasMaxLength(30);
            builder.Property(q => q.Status).IsRequired();
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Descricao).IsRequired().HasMaxLength(500);
            builder.Property(q => q.Data);
            builder.HasOne(q => q.Pessoas).WithMany().HasForeignKey(q => q.IdPessoa);
            //builder.HasOne(q => q.Times).WithMany().HasForeignKey(q => q.IdTime);
            
        }
    }
}
