using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Lab.Models
{
    public enum Status
    {
        Online, Offline, Unknown
    }

    public class User
    {
        public int UserId { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string RealName { get; set; }
        public string Email { get; set; }
        public string About { get; set; }
        public Status? Status { get; set; }
        public bool RememberMe { get; set; }
        //public string temp { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}