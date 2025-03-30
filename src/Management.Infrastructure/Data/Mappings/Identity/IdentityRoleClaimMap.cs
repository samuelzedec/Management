using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Managment.Infrastructure.Data.Mappings.Identity;

public class IdentityRoleClaimMap : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
    {
        builder.ToTable("IdentityRoleClaim");

        builder
            .HasKey(rc => rc.Id)
            .HasName("PK_IdentityRoleClaim_Id");

        builder
            .Property(rc => rc.Id)
            .HasColumnType("INT")
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        builder
            .Property(rc => rc.RoleId)
            .HasColumnType("UNIQUEIDENTIFIER") 
            .HasColumnName("UserId")
            .IsRequired();

        builder
            .Property(rc => rc.ClaimType)
            .HasColumnType("NVARCHAR")
            .HasColumnName("ClaimType")
            .HasMaxLength(80)
            .IsRequired();
        
        builder
            .Property(rc => rc.ClaimValue)
            .HasColumnType("NVARCHAR")
            .HasColumnName("ClaimValue")
            .HasMaxLength(80)
            .IsRequired();
    }
}