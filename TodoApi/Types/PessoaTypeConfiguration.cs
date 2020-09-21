using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.API.Models;

namespace Todo.API.Types
{
    public class PessoaTypeConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Nome).IsRequired().HasMaxLength(60);
            builder.Property(q => q.Usuario).IsRequired().HasMaxLength(20);
            builder.Property(q => q.Senha).IsRequired().HasMaxLength(20);


        }
    }
}
