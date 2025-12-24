using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
using DTOs;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices _IProductsServices;
        public ProductsController(IProductsServices productsServices)
        {
            _IProductsServices = productsServices;
        }
        //private static  List<User> users = new List<User>();


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            IEnumerable<ProductDTO> products = await _IProductsServices.GetProducts();
            if (products != null && products.Any())
                return Ok(products);
            return NoContent();
        }



        //[HttpGet("{id}")]

        //[HttpPost("Login")]


        //[HttpPost]

        //// PUT api/<Users>/5
        //[HttpPut("{id}")]







    }
}


