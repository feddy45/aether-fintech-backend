using Microsoft.EntityFrameworkCore;
using Modules.Transfers.DataAccess.Entities;

namespace Modules.Transfers.DataAccess.DatabaseModels;

public class TransfersDbContext(DbContextOptions<TransfersDbContext> options) : DbContext(options)
{
    public DbSet<TransferEntity> Transfer => Set<TransferEntity>();
    public DbSet<BankAccountEntity> BankAccount => Set<BankAccountEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TransferEntity>(entity =>
        {
            entity.ToTable("Transfer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Iban).HasColumnName("iban");
            entity.Property(e => e.Beneficiary).HasColumnName("beneficiary");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.BankAccountId).HasColumnName("bankaccountid");
            entity.Property(e => e.TransactionId).HasColumnName("transactionid");
        });

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