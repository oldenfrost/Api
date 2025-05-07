using Api.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductoController(IProductService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetProductAsync()
        {
            var lista = await _service.GetProductAsync();
            return Ok(lista);
        }

    }
}
