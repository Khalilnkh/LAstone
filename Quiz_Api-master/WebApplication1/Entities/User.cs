using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
