using Microsoft.AspNetCore.Identity;

namespace LojaDiversidade.IdentityServer.Data;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }  = string.Empty;
    public string LastName { get; set; } = String.Empty;   
}
