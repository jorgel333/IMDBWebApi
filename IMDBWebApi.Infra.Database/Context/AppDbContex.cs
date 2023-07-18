using IMDBWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMDBWebApi.Infra.Database.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Admin> Administrators { get; set; }
        public DbSet<CommonUser> CommonUsers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<AssessmentRecord> AssessmentRecords { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<CastActMovies> CastActMovies { get; set; }
        public DbSet<CastDirectMovies> CastDirectMovies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreMovies> GenreMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
