
using IMDBWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDBWebApi.Infra.Database.EntitiesConfiguration
{
    public class AssessmentRecordConfiguration : IEntityTypeConfiguration<AssessmentRecord>
    {
        public void Configure(EntityTypeBuilder<AssessmentRecord> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Rate).IsRequired().HasMaxLength(3);

            builder.HasOne(a => a.Movie).WithMany(a => a.Assessments).HasForeignKey(a => a.MovieId);

            builder.HasOne(a => a.CommonUser).WithMany(a => a.Assessments).HasForeignKey(a => a.CommonUserId);
        }
    }
}
