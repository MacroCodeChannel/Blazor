

namespace StudentsManagement.Client.Models
{
    public class UserCreateActivity
    {
        public string CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class UserModifyActivity : UserCreateActivity
    {
        public string? ModifiedById { get; set; }
        public ApplicationUser ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
