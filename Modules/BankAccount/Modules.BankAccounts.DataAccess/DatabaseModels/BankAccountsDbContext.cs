using Microsoft.EntityFrameworkCore;
using Modules.BankAccount.DataAccess.Entities;

namespace Modules.BankAccount.DataAccess.DatabaseModels;

public class BankAccountsDbContext(DbContextOptions<BankAccountsDbContext> options) : DbContext(options)
{
    public DbSet<BankAccountEntity> BankAccount => Set<BankAccountEntity>();
    public DbSet<TransactionEntity> Transaction => Set<TransactionEntity>();

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

        modelBuilder.Entity<TransactionEntity>(entity =>
        {
            entity.ToTable("Transaction");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.BankAccountId).HasColumnName("bankaccountid");
            entity.Property(e => e.CardId).HasColumnName("cardid");
        });
    }
}