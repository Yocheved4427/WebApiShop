using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase,IUserServices
    {
        private readonly IUserServices _IuserServices;
        public UserController(IUserServices userServices)
        {
            _IuserServices = userServices;
        }
        //private static  List<User> users = new List<User>();


        [HttpGet]
        //public IEnumerable <User> Get()
        //{
        //    return users;
        //}


        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            User? user= _IuserServices.GetUserById(id);
            if (user != null)
                return Ok(user);
            return NotFound();
        }
        [HttpPost("Login")]
        public ActionResult<User> Login([FromBody] ExistingUser existingUser)
        {

            User? user= _IuserServices.Login(existingUser);
            if (user != null)
                return Ok(user);
            return Unauthorized("Invalid email or password");
        }

        [HttpPost]
        public ActionResult<User> Register([FromBody] User user)
        {
            User? user1=_IuserServices.Register(user);
            if (user1 == null)
                return BadRequest("Password");
           
            return CreatedAtAction(nameof(GetUserById), new { user.id }, user);


        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User updateUser)
        {
            
            bool success=_IuserServices.Upadate(id,updateUser);
            if (!success)
                return BadRequest();
            return Ok();
        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _IuserServices.Delete(id);
        }

        User? IUserServices.GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        User? IUserServices.Login(ExistingUser existingUser)
        {
            throw new NotImplementedException();
        }

        User IUserServices.Register(User user)
        {
            throw new NotImplementedException();
        }

        public bool Upadate(int id, User updateUser)
        {
            throw new NotImplementedException();
        }
    }
}


