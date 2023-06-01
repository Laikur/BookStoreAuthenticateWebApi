using Microsoft.AspNetCore.Identity;

namespace newWebApi.Model
{
    public class ApplicationModel:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
