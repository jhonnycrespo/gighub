using System.ComponentModel.DataAnnotations;

namespace GigHubApp.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
