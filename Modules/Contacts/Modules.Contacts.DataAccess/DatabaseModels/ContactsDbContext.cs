using Microsoft.EntityFrameworkCore;
using Modules.Contacts.DataAccess.Entities;

namespace Modules.Contacts.DataAccess.DatabaseModels;

public class ContactsDbContext(DbContextOptions<ContactsDbContext> options) : DbContext(options)
{
    public DbSet<ContactEntity> Contact => Set<ContactEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>(entity =>
        {
            entity.ToTable("Contact");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Iban).HasColumnName("iban");
            entity.Property(e => e.FirstName).HasColumnName("firstname");
            entity.Property(e => e.LastName).HasColumnName("lastname");
            entity.Property(e => e.UserId).HasColumnName("userid");
        });
    }
}