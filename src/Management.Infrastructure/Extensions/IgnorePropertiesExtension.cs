using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Managment.Infrastructure.Extensions;

public static class IgnorePropertiesExtension
{
    public static void IgnorePropertiesIdentity(this ModelBuilder modelBuilder)
    {
        // Properties of IdentityUser<Guid> ignored
        modelBuilder.Entity<IdentityUser<Guid>>().Ignore(u => u.SecurityStamp);
        modelBuilder.Entity<IdentityUser<Guid>>().Ignore(u => u.ConcurrencyStamp);
        modelBuilder.Entity<IdentityUser<Guid>>().Ignore(u => u.TwoFactorEnabled);
        modelBuilder.Entity<IdentityUser<Guid>>().Ignore(u => u.LockoutEnd);
        modelBuilder.Entity<IdentityUser<Guid>>().Ignore(u => u.LockoutEnabled);
        modelBuilder.Entity<IdentityUser<Guid>>().Ignore(u => u.AccessFailedCount);
        
        // Properties of IdentityRole<Guid> ignored
        modelBuilder.Entity<IdentityRole<Guid>>().Ignore(r => r.ConcurrencyStamp);
        
        
    }
}