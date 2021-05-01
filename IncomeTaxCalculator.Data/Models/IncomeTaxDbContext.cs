using IncomeTaxCalculator.Data.Helpers;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IncomeTaxCalculator.Data.Models
{
    public partial class IncomeTaxDbContext : DbContext
    {
        public IncomeTaxDbContext()
        {
        }

        public IncomeTaxDbContext(DbContextOptions<IncomeTaxDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IncomeTax> IncomeTaxes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AmazonSecretsManager.GetIncomeTaxDbSecret());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<IncomeTax>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("IncomeTax");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.LowerLimit).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpperLimit).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
