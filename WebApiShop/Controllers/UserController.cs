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
        private readonly IUserServices _IuserServices;
        public UserController(IUserServices userServices)
        {
            _IuserServices = userServices;
        }
        //private static  List<User> users = new List<User>();


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            IEnumerable<User> users = await _IuserServices.GetUsers();
            if (users != null && users.Any())
                return Ok(users);
            return NoContent();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            User user = await _IuserServices.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login([FromBody] ExistingUser existingUser)
        {

            User user = await _IuserServices.Login(existingUser);
            if (user != null)
                return Ok(user);
            return Unauthorized("Invalid email or password");
        }

        [HttpPost]
        public async Task<ActionResult<User>> Register([FromBody] User user)
        {
            User user1 = await _IuserServices.Register(user);
            if (user1 == null)
                return BadRequest("Password");

            return CreatedAtAction(nameof(GetUserById), new { user.Id }, user);


        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User updateUser)
        {

            bool success = await _IuserServices.Upadate(id, updateUser);
            if (!success)
                return BadRequest();
            return Ok();
        }






    }
}


