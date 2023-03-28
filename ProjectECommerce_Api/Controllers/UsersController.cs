using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using Newtonsoft.Json;
using ProjectECommerce_Api.Models;
using ProjectECommerce_Api.DalClasses;

namespace ProjectECommerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        UserDal userDal=new UserDal();  

        [HttpGet]
        public async Task<ActionResult> UsersGet()
        {
            var result = userDal.GetUsers();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> UserById(int id)
        {
            var result = userDal.GetUserById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<User>> ADD(User user)
        {
            bool result = userDal.UserAdd(user);
            if (result == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update(User user)
        {
            bool result = userDal.UserUpdate(user);
            if (result == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool result = userDal.UserDelete(id);
            if (result == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
