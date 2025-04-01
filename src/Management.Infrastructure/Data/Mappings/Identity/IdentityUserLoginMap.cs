using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Management.Infrastructure.Data.Mappings.Identity;

public class IdentityUserLoginMap : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
    {
        builder.ToTable("IdentityUserLogin");
        
        builder
            .HasKey(ul => new { ul.UserId, ul.LoginProvider, ul.ProviderKey })
            .HasName("PK_IdentityUserLogin_UserId_LoginProvider_ProviderKey");
        
        builder
            .Property(ul => ul.UserId)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("UserId")
            .IsRequired();
        
        builder
            .Property(ul => ul.LoginProvider)
            .HasColumnType("NVARCHAR")
            .HasColumnName("LoginProvider")
            .HasMaxLength(255)
            .IsRequired();
        
        builder
            .Property(ul => ul.ProviderKey)
            .HasColumnType("NVARCHAR")
            .HasColumnName("ProviderKey")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(ul => ul.ProviderDisplayName)
            .HasColumnType("NVARCHAR")
            .HasColumnName("ProviderDisplayName")
            .HasMaxLength(255)
            .IsRequired();
    }
}