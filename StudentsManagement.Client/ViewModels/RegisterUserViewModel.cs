using System.ComponentModel.DataAnnotations;

namespace StudentsManagement.Client.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = "";

        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; } = "";

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = "";

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = "";

        [Display(Name = "Photo")]
        public string Photo { get; set; } = "";

        [Required]
        [Display(Name = "Gender")]
        public int GenderId { get; set; } = 0;

        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        public bool IsActive { get; set; } = true;

        public DateTime LastActivityDate { get; set; } = DateTime.Now;

        public DateTime? DeactivatedOn { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = "";

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = "";
    }
}
