using System.ComponentModel.DataAnnotations;
 
namespace SocialNetwork.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}