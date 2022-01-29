using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchedulerWebApp.Models
{
    public class CustomerModel
    {
        [Display(Name ="First Name")]
        [Required(ErrorMessage ="You must provide a first name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You must provide a last name.")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "You must provide a valid Email Address.")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = "Confirm Email")]
        [Compare("EmailAddress", ErrorMessage ="The Email and Confirm Email Addresses must match.")]
        public string ConfirmEmail { get; set; }
        
        //set to be invisible in ViewPage - don't want it to be seen by user, but required for Update/Delete logic
        public int customerId { get; set; }
    }
}