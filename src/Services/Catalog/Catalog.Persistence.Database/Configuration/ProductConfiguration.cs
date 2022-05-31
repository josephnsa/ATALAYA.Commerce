using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Catalog.Persistence.Database.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(x => x.ProductId);
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityTypeBuilder.Property(x => x.Description).IsRequired().HasMaxLength(500);

            #region Products by default
            List<Product> products = new();
            Random random = new();
            for (int i = 1; i <= 100; i++)
            {
                products.Add(new Product
                {
                    ProductId = i,
                    Name = $"Product {i}",
                    Description = $"Description for product {i}",
                    Price = random.Next(100, 1000),
                });
            }
            entityTypeBuilder.HasData(products);
            #endregion
        }
    }
}
