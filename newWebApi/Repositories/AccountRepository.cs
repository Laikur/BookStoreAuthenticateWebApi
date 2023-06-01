using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using newWebApi.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace newWebApi.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationModel> _userManager;
        private readonly SignInManager<ApplicationModel> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<ApplicationModel> userManager, 
            SignInManager<ApplicationModel> signInManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> SignupAsync(Signup signupModel)
        {
            var user = new ApplicationModel()
            {
                FirstName = signupModel.FirstName,
                LastName = signupModel.LastName,
                Email = signupModel.Email,
                UserName = signupModel.Email
            };
           return await _userManager.CreateAsync(user, signupModel.Password);
        }

        public async Task<string> SignInAsync(SigninModel signinModel)
        {
            var secretKey = _configuration["JWT:secret"];
            var issuer = _configuration["JWT:ValidIssuer"];
            var audience = _configuration["JWT:ValidAudience"];
            var result = await _signInManager.PasswordSignInAsync(signinModel.Email, signinModel.Password, false, false);
            if(!result.Succeeded)
            {
                return null;
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signinModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };
            //var secret = _configuration["JWT:secret"];
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddMinutes(1),
                claims: authClaims,
                signingCredentials:new SigningCredentials(authSigninKey,SecurityAlgorithms.HmacSha256Signature)
                ) ;
            return new JwtSecurityTokenHandler().WriteToken(token);
            

        }
    }
}
