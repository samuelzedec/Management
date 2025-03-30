using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Managment.Infrastructure.Data.Mappings.Identity;

public class IdentityUserClaimMap : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
    {
        builder.ToTable("IdentityUserClaim");

        builder
            .HasKey(uc => uc.Id)
            .HasName("PK_IdentityUserClaim_Id");

        builder
            .Property(uc => uc.Id)
            .HasColumnType("INT")
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        builder
            .Property(uc => uc.UserId)
            .HasColumnType("UNIQUEIDENTIFIER") 
            .HasColumnName("UserId")
            .IsRequired();

        builder
            .Property(uc => uc.ClaimType)
            .HasColumnType("NVARCHAR")
            .HasColumnName("ClaimType")
            .HasMaxLength(80)
            .IsRequired();
        
        builder
            .Property(uc => uc.ClaimValue)
            .HasColumnType("NVARCHAR")
            .HasColumnName("ClaimValue")
            .HasMaxLength(80)
            .IsRequired();
    }
}