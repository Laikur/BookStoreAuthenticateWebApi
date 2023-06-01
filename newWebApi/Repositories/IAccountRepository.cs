using Microsoft.AspNetCore.Identity;
using newWebApi.Model;
using System.Threading.Tasks;

namespace newWebApi.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignupAsync(Signup signupModel);
        Task<string> SignInAsync(SigninModel signinModel);
    }
}
