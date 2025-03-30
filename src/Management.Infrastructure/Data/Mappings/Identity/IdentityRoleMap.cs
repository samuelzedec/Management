using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Managment.Infrastructure.Data.Mappings.Identity;

public class IdentityRoleMap 
    : IEntityTypeConfiguration<IdentityRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
    {
        builder.ToTable("IdentityRole");

        builder
            .HasKey(r => r.Id)
            .HasName("PK_IdentityRole_Id");
        
        builder
            .Property(u => u.Id)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");
        
        builder
            .Property(r => r.Name)
            .HasColumnType("NVARCHAR")
            .HasColumnName("Name")
            .HasMaxLength(255)
            .IsRequired();
        
        builder
            .Property(r => r.NormalizedName)
            .HasColumnType("NVARCHAR")
            .HasColumnName("NormalizedName")
            .HasMaxLength(255)
            .IsRequired();
        
        builder
            .HasIndex(r => r.NormalizedName, "IX_IdentityRole_NormalizedName")
            .IsUnique();
    }
}