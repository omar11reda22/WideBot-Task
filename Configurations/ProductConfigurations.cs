using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WideBot.Models;

namespace WideBot.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ID);
            builder.HasOne(s => s.category).WithMany(s => s.Products).HasForeignKey(s => s.Ctg_ID);
        }
    }
}
