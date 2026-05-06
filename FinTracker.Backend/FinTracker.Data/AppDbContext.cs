using Microsoft.EntityFrameworkCore;
using FinTracker.Domain.Models;

namespace FinTracker.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Scope> Scopes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TransactionTag> TransactionTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Transaction
        modelBuilder.Entity<Transaction>()
            .HasKey(t => t.Id);  // PRIMARY KEY
        modelBuilder.Entity<Transaction>()
            .Property(t => t.Amount)
            .IsRequired();  // NOT NULL
        modelBuilder.Entity<Transaction>()
            .Property(t => t.Currency)
            .IsRequired();  // NOT NULL
        modelBuilder.Entity<Transaction>()
            .Property(t => t.Date)
            .IsRequired();  // NOT NULL
        modelBuilder.Entity<Transaction>()
            .Property(t => t.Type)
            .IsRequired();  // NOT NULL
        modelBuilder.Entity<Transaction>()
            .Property(t => t.IsDeleted)
            .IsRequired();  // NOT NULL
        modelBuilder.Entity<Transaction>()
            .Property(t => t.CategoryId)
            .IsRequired();  // NOT NULL
        //modelBuilder.Entity<Transaction>()
        //    .HasQueryFilter(t => !t.IsDeleted);
        modelBuilder.Entity<Transaction>()
            .Property(t => t.Amount)
            .HasPrecision(18, 4);

        // Category
        modelBuilder.Entity<Category>()
            .HasKey(c => c.Id);  // PRIMARY KEY
        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);  // NOT NULL
        modelBuilder.Entity<Category>()
            .HasIndex(c => c.Name)
            .IsUnique();  // UNIQUE

        // Scope
        modelBuilder.Entity<Scope>()
            .HasKey(s => s.Id);  // PRIMARY KEY
        modelBuilder.Entity<Scope>()
            .Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);  // NOT NULL
        modelBuilder.Entity<Scope>()
            .HasIndex(s => s.Name)
            .IsUnique();  // UNIQUE

        // Tag
        modelBuilder.Entity<Tag>()
            .HasKey(t => t.Id);  // PRIMARY KEY
        modelBuilder.Entity<Tag>()
            .Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(50);  // NOT NULL
        modelBuilder.Entity<Tag>()
            .HasIndex(t => t.Name)
            .IsUnique();  // UNIQUE

        // TransactionTag
        modelBuilder.Entity<TransactionTag>()
            .HasKey(tt => new { tt.TransactionId, tt.TagId });  // PRIMARY KEY
        //modelBuilder.Entity<TransactionTag>()
        //    .HasQueryFilter(tt => !tt.Transaction.IsDeleted);

        base.OnModelCreating(modelBuilder);
    }
}
