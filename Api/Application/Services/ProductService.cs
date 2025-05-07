using Api.Application.Dtos.ProductDtos;
using Api.Application.Interfaces;
using Api.Domain.Entities;
using Api.Infrastructure.Interfaces;

namespace Api.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDataClient _productdataClient;
        public ProductService(IProductDataClient productdataClient)
        {
            _productdataClient = productdataClient;
        }
        public async Task<ProductDtos> GetProductAsync()
        {

            Product product = new Product
            {
                Id = 1,
                Name = "Test",
                Price = 10.1,
                Description = "TestDescription",
                CodeProduct = "ps-1"
            };
             var result = await _productdataClient.GetProductAsync(product);

            return new ProductDtos
            {
                Name = result.Name,
                Description = result.Description,
            }; 



        }

    }
}
