using Microsoft.AspNetCore.Identity;

namespace Lab7_net.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public long CustomerId { get; set; }
    }
}
