
using IMDBWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDBWebApi.Infra.Database.EntitiesConfiguration
{
    public class CastActMoviesConfiguration : IEntityTypeConfiguration<CastActMovies>
    {
        public void Configure(EntityTypeBuilder<CastActMovies> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.CastAct).WithMany(c => c.ActedMovies).HasForeignKey(c => c.CastActId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.MovieAct).WithMany(c => c.ActorMovies).HasForeignKey(c => c.MovieActId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
