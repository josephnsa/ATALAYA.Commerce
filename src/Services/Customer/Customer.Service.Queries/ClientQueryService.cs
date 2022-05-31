using Customer.Persistence.Database;
using Customer.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Service.Queries
{
    public interface IClientQueryService
    {
        Task<DataCollection<ClientDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null);
        Task<ClientDto> GetAsync(int id);
    }

    public class ClientQueryService : IClientQueryService
    {
        private readonly ApplicationDbContext _context;

        public ClientQueryService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<ClientDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null)
        {
            var collection = await _context.Client
                .Where(x => products == null || products.Contains(x.ClientId))
                .OrderBy(x => x.Name)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ClientDto>>();
        }

        public async Task<ClientDto> GetAsync(int id)
        {
            return (await _context.Client.SingleAsync(x => x.ClientId == id)).MapTo<ClientDto>();
        }
    }
}
