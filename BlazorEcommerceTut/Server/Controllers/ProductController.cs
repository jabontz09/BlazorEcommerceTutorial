using BlazorEcommerceTut.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerceTut.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext context;

        public ProductController(DataContext context)
        {
            this.context = context;
        }
   
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var response = new ServiceResponse<List<Product>>()
            { 
                Data= await context.Products.ToListAsync() 
            };

            return Ok(response);
        }
    }
}
