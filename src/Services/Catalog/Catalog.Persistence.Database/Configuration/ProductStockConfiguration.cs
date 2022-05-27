using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Catalog.Persistence.Database.Configuration
{
    public class ProductStockConfiguration
    {
        public ProductStockConfiguration(EntityTypeBuilder<ProductStock> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.ProductStockId);

            var random = new Random();
            var products = new List<ProductStock>();

            for (int i = 1; i <= 100; i++)
            {
                products.Add(new ProductStock
                {
                    ProductStockId = i,
                    ProductId = i,
                    Stock = random.Next(0, 20)
                });
            }
            entityTypeBuilder.HasData(products);
        }
    }
}
