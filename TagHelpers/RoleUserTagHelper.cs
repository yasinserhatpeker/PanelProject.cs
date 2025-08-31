using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PanelProject.Models;

namespace PanelProject.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "asp-role-users")]
    public class RoleUserTagHelper : TagHelper
    {

        private readonly UserManager<AppUser> _userManager;

        private readonly RoleManager<AppRole> _roleManager;

        public RoleUserTagHelper(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HtmlAttributeName("asp-role-users")]

        public string RoleId { get; set; } = null!;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var userNames = new List<string>();
            var role = await _roleManager.FindByIdAsync(RoleId);

            if (role != null && role.Name != null)
            {
                foreach (var user in _userManager.Users)
                {
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        userNames.Add(user.UserName ?? "");
                    }
                }
                output.Content.SetHtmlContent(userNames.Count == 0 ? "There's no user." : setHtml(userNames));
            }


        }
        private string setHtml(List<string> userNames) {
            var html = "<ul>";
            foreach (var item in userNames)
            {
                html += "<li>" + item + "</li>";
            }
            html += "</ul>";
            return html;

        }
    }
}