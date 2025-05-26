using Microsoft.EntityFrameworkCore;

namespace Infra
{
  public class QrDbContext : DbContext
  {
    public QrDbContext(DbContextOptions<QrDbContext> options) : base(options)
    {
    }
    public DbSet<Core.Entities.QrCode> QrCodes { get; set; }
    public DbSet<Core.Entities.ExtProduct> ExtProducts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Core.Entities.QrCode>()
        .Property(q => q.Code)
        .IsRequired()
        .HasMaxLength(12);

      modelBuilder.Entity<Core.Entities.QrCode>()
        .HasIndex(q => q.Code)
        .IsUnique();

      modelBuilder.Entity<Core.Entities.ExtProduct>()
        .HasIndex(e => e.ExtProductId)
        .IsUnique();

    }



  }
}
