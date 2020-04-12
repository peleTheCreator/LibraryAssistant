using System.ComponentModel.DataAnnotations;

namespace LibraryAssistant.Core.Models.Identity
{
    public class UserLoginRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
