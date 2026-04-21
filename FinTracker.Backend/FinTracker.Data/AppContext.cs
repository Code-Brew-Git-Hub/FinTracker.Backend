using Microsoft.EntityFrameworkCore;
using FinTracker.Domain.Models;

namespace FinTracker.Data;

public class AppContext(DbContextOptions<AppContext> options) : DbContext(options)
{
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Scope> Scopes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
        modelBuilder.Entity<Transaction>().Property(t => t.Date).IsRequired();
        modelBuilder.Entity<Transaction>().Property(t => t.Amount).IsRequired();
        modelBuilder.Entity<Transaction>().Property(t => t.Currency).IsRequired();
        modelBuilder.Entity<Transaction>().Property(t => t.Category).IsRequired();
        modelBuilder.Entity<Transaction>().Property(t => t.Type).IsRequired();
        modelBuilder.Entity<Transaction>().Property(t => t.IsDeleted).IsRequired();
        //modelBuilder.Entity<Transaction>().Property(t => t.Currency).HasMaxLength(3);

        modelBuilder.Entity<Scope>().HasKey(s => s.Id);
        modelBuilder.Entity<Scope>().Property(s => s.Name).IsRequired();
        modelBuilder.Entity<Scope>().HasAlternateKey(s => s.Name);  // name must be unique

        base.OnModelCreating(modelBuilder);
    }
}
