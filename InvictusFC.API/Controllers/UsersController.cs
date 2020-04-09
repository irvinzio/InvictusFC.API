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
        [HttpGet("clients")]
        public ActionResult<IEnumerable<User>> GetClients(int officeBranchId)
        {
            return _userManager.GetAllClients(officeBranchId);
        }

        [HttpGet("coaches")]
        public ActionResult<IEnumerable<User>> GetCoaches(int officeBranchId)
        {
            return _userManager.GetAllCoaches(officeBranchId);
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUser(int officeBranchId)
        {
            return _userManager.GetAllUsers(officeBranchId);
        }
        [HttpGet("{id}")]
        public ActionResult<User> Get(Guid id)
        {
            return _userManager.GetUserById(id);
        }
        [HttpPost]
        public User Post([FromBody] User user)
        {
            return _userManager.SaveUser(user);
        }
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] User user)
        {
            _userManager.SaveUser(user);
        }
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _userManager.DeleteUser(id);
        }
    }
}
