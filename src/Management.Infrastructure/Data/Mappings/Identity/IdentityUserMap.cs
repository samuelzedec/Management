using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Managment.Infrastructure.Data.Mappings.Identity;

public class IdentityUserMap 
    : IEntityTypeConfiguration<IdentityUser<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUser<Guid>> builder)
    {
        builder.ToTable("IdentityUser");

        builder
            .HasKey(u => u.Id)
            .HasName("PK_IdentityUser_Id");
        
        builder
            .Property(u => u.Id)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("Id")
            .HasDefaultValueSql("NEWID()");

        builder
            .Property(u => u.UserName)
            .HasColumnType("NVARCHAR")
            .HasColumnName("UserName")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(u => u.NormalizedUserName)
            .HasColumnType("NVARCHAR")
            .HasColumnName("NormalizedUserName")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .HasIndex(u => u.NormalizedUserName, "IX_IdentityUser_NormalizedUserName")
            .IsUnique();
        
        builder
            .Property(u => u.Email)
            .HasColumnType("NVARCHAR")
            .HasColumnName("Email")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .HasIndex(ui => ui.Id, "IX_User_Email")
            .IsUnique();
        
        builder
            .Property(u => u.NormalizedEmail)
            .HasColumnType("NVARCHAR")
            .HasColumnName("NormalizedEmail")
            .HasMaxLength(255);
        
        builder
            .Property(u => u.EmailConfirmed)
            .HasColumnType("BIT")
            .HasColumnName("EmailConfirmed")
            .IsRequired();
        
        builder
            .Property(u => u.PasswordHash)
            .HasColumnType("NVARCHAR")
            .HasColumnName("PasswordHash")
            .HasMaxLength(255)
            .IsRequired();
        
        builder
            .Property(u => u.PasswordHash)
            .HasColumnType("NVARCHAR")
            .HasColumnName("PasswordHash")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(u => u.PhoneNumber)
            .HasColumnType("NVARCHAR")
            .HasColumnName("PhoneNumber")
            .HasMaxLength(11)
            .IsRequired();
        
        builder
            .Property(u => u.PhoneNumberConfirmed)
            .HasColumnType("BIT")
            .HasColumnName("PhoneNumberConfirmed")
            .IsRequired();
    }
}