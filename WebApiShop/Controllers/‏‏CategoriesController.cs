using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesServices _ICategoriesServices;
        public CategoriesController(ICategoriesServices categoriesServices)
        {
            _ICategoriesServices = categoriesServices;
        }
        //private static  List<User> users = new List<User>();


        //[HttpGet]


        //[HttpGet("{id}")]

        //[HttpPost("Login")]


        //[HttpPost]


        //// PUT api/<Users>/5
        //[HttpPut("{id}")]

    }
}


