using Microsoft.EntityFrameworkCore;
using FinTracker.Domain.Models;

namespace FinTracker.Data;

public class AppContext(DbContextOptions<AppContext> options) : DbContext(options)
{
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
        modelBuilder.Entity<Transaction>().Property(t => t.Currency).HasMaxLength(3);
        // Проверить остальные поля для Transaction

        base.OnModelCreating(modelBuilder);
    }
}
