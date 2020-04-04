using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvictusFC.BL;
using InvictusFC.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvictusFC.API.Controllers
{   
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserManager _userManager;
        public UserController(IUserManager userManager, ILogger<UserController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userManager.GetAllUsers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(Guid guid)
        {
            return _userManager.GetUserById(guid);
        }

        // POST api/values
        [HttpPost]
        public User Post([FromBody] User user)
        {
            return _userManager.SaveUser(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] User user)
        {
            _userManager.SaveUser(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _userManager.DeleteUser(id);
        }
    }
}
