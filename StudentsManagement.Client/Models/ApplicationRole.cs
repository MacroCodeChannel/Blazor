

using Microsoft.AspNetCore.Identity;

namespace StudentsManagement.Client.Models
{
    public class ApplicationRole :IdentityRole
    {
        public string Description { get; set; }
        public string CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public string? ReviewedById { get; set; }
        public ApplicationUser ReviewedBy { get; set; }
    }
}
