using DataAccessLayer;
using DataAccessLayer.DbContext;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly Service service;

        public UserController(Service service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> Get()
        {
            var res = await service.GetAllUsers();
            return Ok(res);
        }
        [HttpGet]
        [Route("GetUser/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var res = await service.GetUser(Id);
            return Ok(res);
        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> Post(User user)
        {
            await service.AddUser(user);
            return Ok("Added successfully");
        }
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> Put(User user)
        {
            await service.UpdateUser(user);
            return Ok("Successfully updated");
        }
        [HttpDelete]
        [Route("DeleteUser/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await service.DeleteUser(Id);
            return Ok("Deleted Successfully");
        }
        [HttpPost]
        [Route("ValidateUser")]
        public async Task<IActionResult> ValidateUSer(LoginUser user)
        {
            var result = await service.ValidateEmailAndPassword(user);
            if (result)
                return Ok("validated");
            else return BadRequest();
        }
    }
}
