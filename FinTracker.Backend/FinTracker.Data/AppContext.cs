using Microsoft.EntityFrameworkCore;
using FinTracker.Domain.Models;

namespace FinTracker.Data;

public class AppContext(DbContextOptions<AppContext> options) : DbContext(options)
{
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Scope> Scopes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TransactionTag> TransactionTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Transaction
        modelBuilder.Entity<Transaction>().HasKey(t => t.Id);  // PRIMARY KEY
        modelBuilder.Entity<Transaction>().Property(t => t.Amount).IsRequired();  // NOT NULL
        modelBuilder.Entity<Transaction>().Property(t => t.Currency).IsRequired();  // NOT NULL
        modelBuilder.Entity<Transaction>().Property(t => t.Date).IsRequired();  // NOT NULL
        modelBuilder.Entity<Transaction>().Property(t => t.Type).IsRequired();  // NOT NULL
        modelBuilder.Entity<Transaction>().Property(t => t.IsDeleted).IsRequired();  // NOT NULL
        modelBuilder.Entity<Transaction>().Property(t => t.CategoryId).IsRequired();  // NOT NULL

        // Category
        modelBuilder.Entity<Category>().HasKey(c => c.Id);  // PRIMARY KEY
        modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired();  // NOT NULL
        modelBuilder.Entity<Category>().HasAlternateKey(c => c.Name);  // UNIQUE

        // Scope
        modelBuilder.Entity<Scope>().HasKey(s => s.Id);  // PRIMARY KEY
        modelBuilder.Entity<Scope>().Property(s => s.Name).IsRequired();  // NOT NULL
        modelBuilder.Entity<Scope>().HasAlternateKey(s => s.Name);  // UNIQUE

        // Tag
        modelBuilder.Entity<Tag>().HasKey(t => t.Id);  // PRIMARY KEY
        modelBuilder.Entity<Tag>().Property(t => t.Name).IsRequired();  // NOT NULL
        modelBuilder.Entity<Tag>().HasAlternateKey(t => t.Name);  // UNIQUE

        // TransactionTag
        modelBuilder.Entity<TransactionTag>().HasKey(tt => tt.TransactionId);  // PRIMARY KEY
        modelBuilder.Entity<TransactionTag>().HasKey(tt => tt.TagId);  // PRIMARY KEY


        base.OnModelCreating(modelBuilder);
    }
}
