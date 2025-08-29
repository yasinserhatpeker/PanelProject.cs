using System.ComponentModel.DataAnnotations;

namespace PanelProject.ViewModels
{
    public class CreateViewModel
    {

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = string.Empty;

         [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password must be equal.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
         public string PhoneNumber { get; set; } = string.Empty;
    }
}