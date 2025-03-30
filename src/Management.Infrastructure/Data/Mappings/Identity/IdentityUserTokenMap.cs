using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Managment.Infrastructure.Data.Mappings.Identity;

public class IdentityUserTokenMap 
    : IEntityTypeConfiguration<IdentityUserToken<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> builder)
    {
        builder.ToTable("IdentityUserToken");

        builder
            .HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name })
            .HasName("PK_IdentityUserToken_UserId_LoginProvider_Name");
        
        builder
            .Property(ut => ut.UserId)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("UserId")
            .IsRequired();
        
        builder
            .Property(ut => ut.LoginProvider)
            .HasColumnType("NVARCHAR")
            .HasColumnName("LoginProvider")
            .HasMaxLength(255)
            .IsRequired();
        
        builder
            .Property(ut => ut.Name)
            .HasColumnType("NVARCHAR")
            .HasColumnName("Name")
            .HasMaxLength(255)
            .IsRequired();
        
        builder
            .Property(ut => ut.Value)
            .HasColumnType("NVARCHAR")
            .HasColumnName("Value")
            .HasMaxLength(755)
            .IsRequired();

    }
}