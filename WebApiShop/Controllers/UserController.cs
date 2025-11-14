using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserServices services = new UserServices();
        //private static  List<User> users = new List<User>();


        [HttpGet]
        //public IEnumerable <User> Get()
        //{
        //    return users;
        //}


        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            User? user=services.GetUserById(id);
            if (user != null)
                return Ok(user);
            return NotFound();
        }
        [HttpPost("Login")]
        public ActionResult<User> Login([FromBody] ExistingUser existingUser)
        {

            User? user=services.Login(existingUser);
            if (user != null)
                return Ok(user);
            return NotFound();
        }

        [HttpPost]
        public ActionResult<User> Register([FromBody] User user)
        {
            User? user1=services.Register(user);
            if (user1 == null)
                return BadRequest("Password");
           
            return CreatedAtAction(nameof(GetUserById), new { user.id }, user);


        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User updateUser)
        {
            
            bool success=services.Upadate(id,updateUser);
            if (!success)
                return BadRequest();
            return Ok();
        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            services.Delete(id);
        }
        

    }
}


