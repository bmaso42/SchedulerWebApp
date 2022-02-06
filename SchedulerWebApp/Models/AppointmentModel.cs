using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchedulerWebApp.Models
{
    public class AppointmentModel
    {
        //set to be invisible in ViewPage - don't want it seen by user, but required for Update/Delete logic
        public int AppointmentID{ get; set; }

        [Display(Name = "Customer")] //meant to use CustomerID AND merged FullName for dropdown selection
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = " Customer Name")]
        public string FullName { get; set; }
        
        [Display(Name = "Appointment Type")]
        public string Type { get; set; }

        [Display(Name = "Appointment Start")]
        public DateTime Start { get; set; }

        [Display(Name = "Appointment End")]
        public DateTime End { get; set; }
    }
}