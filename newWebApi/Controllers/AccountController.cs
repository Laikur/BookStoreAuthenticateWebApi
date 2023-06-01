using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using newWebApi.Model;
using newWebApi.Repositories;

namespace newWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]Signup signupModel)
        {
            var result = await _accountRepository.SignupAsync(signupModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> SignIn([FromBody] SigninModel signinModel)
        {
            var result = await _accountRepository.SignInAsync(signinModel);
          
            if(result.IsNullOrEmpty())
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
