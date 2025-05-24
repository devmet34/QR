using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
  public class QrDbContext : DbContext
  {
    public QrDbContext(DbContextOptions<QrDbContext> options) : base(options)
    {
    }
    public DbSet<Core.Entities.QrCode> QrCodes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Core.Entities.QrCode>()
        .Property(q => q.Code)
        .IsRequired()        
        .HasMaxLength(12);

      modelBuilder.Entity<Core.Entities.QrCode>()
        .HasIndex(q => q.Code)
        .IsUnique();
    }



  }
}
