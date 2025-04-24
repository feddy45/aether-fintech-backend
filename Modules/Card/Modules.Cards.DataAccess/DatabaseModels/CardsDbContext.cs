using Microsoft.EntityFrameworkCore;
using Modules.Cards.DataAccess.Entities;

namespace Modules.Cards.DataAccess.DatabaseModels;

public class CardsDbContext(DbContextOptions<CardsDbContext> options) : DbContext(options)
{
    public DbSet<CardEntity> Card => Set<CardEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CardEntity>(entity =>
        {
            entity.ToTable("Card");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CardNumber).HasColumnName("cardnumber");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ExpirationDate).HasColumnName("expirationdate");
            entity.Property(e => e.BankAccountId).HasColumnName("bankaccountid");
        });
    }
}