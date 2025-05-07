using Api.Application.Dtos.ProductDtos;

namespace Api.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDtos> GetProductAsync();
    }
}
