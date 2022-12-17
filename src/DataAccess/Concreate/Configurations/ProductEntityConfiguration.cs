using DataAccess.Consts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Configurations
{
    internal class ProductEntityConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            
            builder.Property((Product p) => p.Name)
                .IsRequired()
                .HasMaxLength(ProductConsts.NameMaxLength)
                .HasColumnName("name");

            builder.Property((Product p) => p.Brand)
                .IsRequired()
                .HasMaxLength(ProductConsts.BrandMaxLength)
                .HasColumnName("brand");

            builder.Property((Product p) => p.Category)
                .IsRequired()
                .HasMaxLength(ProductConsts.CategoryMaxLength)
                .HasColumnName("category");

            builder.Property((Product p) => p.Price)
                .IsRequired()
                .HasColumnName("price");

            builder.Property((Product p) => p.StockQuantity)
                .HasColumnName("stockQuantity")
                .HasDefaultValueSql("0");

            builder.Property((Product p) => p.CreateDateTime)
                .HasColumnName("createDateTime")
                .HasDefaultValueSql("getdate()");
        }
    }
}
