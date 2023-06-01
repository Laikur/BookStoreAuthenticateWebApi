using System.ComponentModel.DataAnnotations;

namespace newWebApi.Model

{
    public class SigninModel
    {
        [Required, EmailAddress]
        public string  Email { get; set; }

        [Required]
        public string  Password { get; set; }
    }
}
