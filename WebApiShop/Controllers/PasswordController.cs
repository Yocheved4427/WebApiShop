using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase,IPasswordServices
    {
        private readonly IPasswordServices _passwordServices;
        public PasswordController(IPasswordServices passwordServices)
        {
            _passwordServices = passwordServices;
        }
        // GET: api/<PasswordsController>
        
        // GET api/<PasswordsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PasswordsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PasswordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PasswordsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost("PasswordScore")]
        public ActionResult<int> PasswordScore([FromBody] string password)
        {
            int strength = _passwordServices.PasswordScore(password);
            return Ok(strength);
        }

        int IPasswordServices.PasswordScore(string password)
        {
            throw new NotImplementedException();
        }
    }
}
