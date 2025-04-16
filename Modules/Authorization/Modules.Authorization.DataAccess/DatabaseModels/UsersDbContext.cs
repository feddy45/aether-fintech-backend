using Microsoft.EntityFrameworkCore;
using Modules.Authorization.DataAccess.Entities;

namespace Modules.Authorization.DataAccess.DatabaseModels;

public class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> User => Set<UserEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Username).HasColumnName("username");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.LastLogin).HasColumnName("lastlogin");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateofbirth");
            entity.Property(e => e.FirstName).HasColumnName("firstname");
            entity.Property(e => e.LastName).HasColumnName("lastname");
        });
    }
}