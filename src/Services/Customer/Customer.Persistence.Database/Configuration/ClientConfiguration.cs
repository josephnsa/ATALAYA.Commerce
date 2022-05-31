using Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Customer.Persistence.Database.Configuration
{
    public class ClientConfiguration
    {
        public ClientConfiguration(EntityTypeBuilder<Client> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(x => x.ClientId);
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            #region Clients by default
            List<Client> clients = new();
            for (int i = 1; i <= 10; i++)
            {
                clients.Add(new Client
                {
                    ClientId = i,
                    Name = $"Client {i}",
                });
            }
            entityTypeBuilder.HasData(clients);
            #endregion
        }
    }
}
