using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Guestbook.Models
{
    // model dedicated to login 
    public class LogOnModel
    {
        // syntax of a required attribute
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        // required email
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // required password
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    // model dedicated to changing password? yes

    public class ChangePasswordModel
    {
        // syntax of required fields
        // annotation of required fields
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        // annotation to confirm password length
        [Required]
        //[ValidatePasswordLength]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        // confirm new password
        // annotations to confirm
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password" + " and confirmation password do not match")]
        public string ConfirmPassword { get; set; }


    }
}