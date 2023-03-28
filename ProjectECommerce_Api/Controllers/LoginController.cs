using Microsoft.AspNetCore.Mvc;
using ProjectECommerce_Api.DalClasses;

namespace ProjectECommerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UserDal userDal = new UserDal();

        [HttpGet]
        public async Task<ActionResult> Login(string name ,string email)
        {
            var result = userDal.LoginUser(name,email);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
