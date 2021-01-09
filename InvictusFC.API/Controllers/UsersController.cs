using System;
using System.Collections.Generic;
using InvictusFC.Service;
using InvictusFC.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvictusFC.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private IUserService _userService;
        public UsersController(IUserService ClientsManager, ILogger<UsersController> logger)
        {
            _userService = ClientsManager;
            _logger = logger;
        }
        // GET api/values
        [HttpGet("clients")]
        public ActionResult<IEnumerable<ClientResponse>> GetClients(int officeBranchId)
        {
            return _userService.GetAllClients(officeBranchId);
        }

        [HttpGet("coaches")]
        public ActionResult<IEnumerable<ClientResponse>> GetCoaches(int officeBranchId)
        {
            return _userService.GetAllCoaches(officeBranchId);
        }
        [HttpGet("{id}")]
        public ActionResult<ClientResponse> Get(Guid id)
        {
            return _userService.GetUserById(id);
        }
        [HttpPost]
        public ClientResponse Post([FromBody] ClientRequest Client)
        {
            return _userService.SaveUser(Client);
        }
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ClientRequest Client)
        {
            _userService.UpdateUser(Client,id);
        }
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _userService.DeleteUser(id);
        }
    }
}
