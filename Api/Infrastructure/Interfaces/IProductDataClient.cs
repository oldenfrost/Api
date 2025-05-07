
using Api.Domain.Entities;

namespace Api.Infrastructure.Interfaces
{
    public interface IProductDataClient
    {
        public Task<Product> GetProductAsync(Product product);

    }
}
