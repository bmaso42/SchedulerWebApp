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

        public int CustomerID { get; set; }
        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = " Customer Name")]
        public string FullName { get; set; }
        
        [Display(Name = "Appointment Type")]
        public string Type { get; set; }

        [Display(Name = "Appointment Start")]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [Display(Name = "Appointment End")]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }
    }
}