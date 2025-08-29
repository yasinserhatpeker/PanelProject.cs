using Microsoft.AspNetCore.Identity;

namespace PanelProject.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } =string.Empty;
    }
}