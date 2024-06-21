using Game_Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game_Store.EntityConfig;

internal class UsersConfigurations : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.HasKey(e => e.UserId);
        builder.Property(e => e.UserName).IsRequired();
        builder.Property(e => e.Email).IsRequired();
        builder.Property(e => e.Password).IsRequired();
        builder.Property(e => e.Balance).IsRequired();
    }
}