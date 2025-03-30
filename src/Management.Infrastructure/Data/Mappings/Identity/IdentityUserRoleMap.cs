using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Managment.Infrastructure.Data.Mappings.Identity;

public class IdentityUserRoleMap
    : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.ToTable("IdentityUserRole");

        builder
            .HasKey(ur => new { ur.UserId, ur.RoleId })
            .HasName("PK_IdentityUserRole_UserId_RoleId");

        builder
            .Property(ur => ur.UserId)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("UserId")
            .IsRequired();
        
        builder
            .Property(ur => ur.RoleId)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("RoleId")
            .IsRequired();
    }
}