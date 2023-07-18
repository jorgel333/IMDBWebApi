using IMDBWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBWebApi.Infra.Database.EntitiesConfiguration
{
    public class CastConfiguration : IEntityTypeConfiguration<Cast>
    {
        public void Configure(EntityTypeBuilder<Cast> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(g => g.Name).IsUnique();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);

            builder.Property(c => c.Description).IsRequired().HasMaxLength(350);

            builder.HasMany(c => c.ActedMovies).WithOne(c => c.CastAct).HasForeignKey(c => c.CastActId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.DirectedMovies).WithOne(c => c.CastDirector).HasForeignKey(cm => cm.CastDirectorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
