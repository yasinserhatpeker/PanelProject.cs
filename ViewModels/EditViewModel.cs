using System.ComponentModel.DataAnnotations;

namespace PanelProject.ViewModels
{
    public class EditViewModel
    {


        [Display(Name = "User Name")]
        public string? UserName { get; set; }
        public string? Id { get; set; }


        [Display(Name = "Full Name")]
        public string? FullName { get; set; }


        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;


        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password must be equal.")]
        public string ConfirmPassword { get; set; } = string.Empty;
        
        public IList<string>? SelectedRole { get; set; } 
    }
}