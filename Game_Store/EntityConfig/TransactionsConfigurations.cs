using Game_Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game_Store.EntityConfig;

internal class TransactionsConfigurations: IEntityTypeConfiguration<Transactions>
{
    public void Configure(EntityTypeBuilder<Transactions> builder)
    {
        builder.HasKey(e => e.TransactionsId);
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.GameId).IsRequired();
        builder.Property(e => e.PurchaseDate).IsRequired();
        builder.Property(e => e.Amount).IsRequired();
    }
}