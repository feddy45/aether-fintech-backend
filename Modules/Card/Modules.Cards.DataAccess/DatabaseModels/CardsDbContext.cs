using Microsoft.EntityFrameworkCore;
using Modules.Cards.DataAccess.Entities;

namespace Modules.Cards.DataAccess.DatabaseModels;

public class CardsDbContext(DbContextOptions<CardsDbContext> options) : DbContext(options)
{
    public DbSet<CardEntity> Card => Set<CardEntity>();
    public DbSet<TransactionEntity> Transaction => Set<TransactionEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CardEntity>(entity =>
        {
            entity.ToTable("Card");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CardNumber).HasColumnName("cardnumber");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ExpirationDate).HasColumnName("expirationdate");
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
            entity.Property(e => e.CardId).HasColumnName("cardid");
        });
    }
}