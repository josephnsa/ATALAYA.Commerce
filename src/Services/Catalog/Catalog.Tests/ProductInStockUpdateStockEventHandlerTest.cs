using Catalog.Domain;
using Catalog.Service.EventHandlers;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.EventHandlers.Exceptions;
using Catalog.Tests.Config;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Catalog.Tests
{
    public class ProductInStockUpdateStockEventHandlerTest
    {
        private static ILogger<ProductInStockUpdateStockEventHandler> GetIlogger => new Mock<ILogger<ProductInStockUpdateStockEventHandler>>().Object;

        [Fact]
        public async Task TryToSubstractStockWhenProductHasStock()
        {
            Persistence.Database.ApplicationDbContext context = ApplicationDbContextInMemory.Get();

            int productInStockId = 1;
            int productId = 1;

            // Add product
            context.Stock.Add(new ProductStock
            {
                ProductStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            ProductInStockUpdateStockEventHandler command = new(context, GetIlogger);

            await command.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductInStockUpdateItem> {
                    new ProductInStockUpdateItem {
                        ProductId = 1,
                        Stock = 1,
                        Action = Common.Enums.ProductInStockAction.Substract
                    }
                }
            }, new System.Threading.CancellationToken());
        }

        [Fact]
        //[ExpectedException(typeof(ProductInStockUpdateStockCommandException))]
        public void TryToSubstractStockWhenProductHasntStock()
        {
            Persistence.Database.ApplicationDbContext context = ApplicationDbContextInMemory.Get();

            ProductInStockUpdateStockCommandException expectedException = null;

            int productInStockId = 2;
            int productId = 2;

            // Add product
            context.Stock.Add(new ProductStock
            {
                ProductStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            ProductInStockUpdateStockEventHandler command = new ProductInStockUpdateStockEventHandler(context, GetIlogger);

            try
            {
                command.Handle(new ProductInStockUpdateStockCommand
                {
                    Items = new List<ProductInStockUpdateItem> {
                    new ProductInStockUpdateItem {
                        ProductId = productId,
                        Stock = 2,
                        Action = Common.Enums.ProductInStockAction.Substract
                    }
                }
                }, new System.Threading.CancellationToken()).Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.GetBaseException() is ProductInStockUpdateStockCommandException)
                {
                    //throw new ProductInStockUpdateStockCommandException(ae.InnerException?.Message);
                    expectedException = new ProductInStockUpdateStockCommandException(ae.InnerException?.Message);
                }
            }

            Assert.NotNull(expectedException);
            Assert.IsType<ProductInStockUpdateStockCommandException>(expectedException);
        }

        [Fact]
        public void TryToAddStockWhenProductExists()
        {
            Persistence.Database.ApplicationDbContext context = ApplicationDbContextInMemory.Get();

            int productInStockId = 3;
            int productId = 3;

            // Add product
            context.Stock.Add(new ProductStock
            {
                ProductStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            ProductInStockUpdateStockEventHandler command = new(context, GetIlogger);

            command.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductInStockUpdateItem> {
                    new ProductInStockUpdateItem {
                        ProductId = productId,
                        Stock = 2,
                        Action = Common.Enums.ProductInStockAction.Add
                    }
                }
            }, new System.Threading.CancellationToken()).Wait();

            Assert.Equal(3, context.Stock.First(x => x.ProductStockId == productInStockId).Stock);
        }

        [Fact]
        public void TryToAddStockWhenProductNotExists()
        {
            Persistence.Database.ApplicationDbContext context = ApplicationDbContextInMemory.Get();
            ProductInStockUpdateStockEventHandler command = new(context, GetIlogger);

            int productId = 4;

            command.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductInStockUpdateItem> {
                    new ProductInStockUpdateItem {
                        ProductId = productId,
                        Stock = 2,
                        Action = Common.Enums.ProductInStockAction.Add
                    }
                }
            }, new System.Threading.CancellationToken()).Wait();

            Assert.Equal(2, context.Stock.First(x => x.ProductId == productId).Stock);
        }
    }
}
