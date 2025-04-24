using Microsoft.EntityFrameworkCore;
using Modules.BankAccount.DataAccess.Entities;

namespace Modules.BankAccount.DataAccess.DatabaseModels;

public class BankAccountsDbContext(DbContextOptions<BankAccountsDbContext> options) : DbContext(options)
{
    public DbSet<BankAccountEntity> BankAccount => Set<BankAccountEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BankAccountEntity>(entity =>
        {
            entity.ToTable("BankAccount");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Iban).HasColumnName("iban");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.CreatedAt).HasColumnName("createdat");
            entity.Property(e => e.UserId).HasColumnName("userid");
        });
    }
}