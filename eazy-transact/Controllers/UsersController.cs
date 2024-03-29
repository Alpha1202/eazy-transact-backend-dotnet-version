using eazy_transact.Models;
using eazy_transact.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eazy_transact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }      

        [HttpGet]
        public ActionResult<List<User>> Get() => 
            _userService.Get();

        [HttpPost("{user}")]
        public ActionResult<User> Get(User user)
        {
            var userData = _userService.Get(user.Email);
        
            if (userData == null)
            {
                return NotFound();
            }

            return userData;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _userService.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User userIn)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _userService.Get(id);

            if (user == null) 
            {
                return NotFound();
            }

            _userService.Remove(user.Id);

            return NoContent();
        }
    }
}