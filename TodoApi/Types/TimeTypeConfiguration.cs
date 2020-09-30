using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.API.Models;

namespace Todo.API.Types
{
    public class TimeTypeConfiguration : IEntityTypeConfiguration<Time>
    {
       public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Nome).IsRequired().HasMaxLength(60);
        }
    }
}
