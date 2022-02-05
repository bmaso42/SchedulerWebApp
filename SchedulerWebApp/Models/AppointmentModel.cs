using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerWebApp.Models
{
    public class AppointmentModel
    {
        public int AppointmentID{ get; set; }
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        //public string title { get; set; }
        //public string description { get; set; }
        //public string location { get; set; }
        //public string contact { get; set; }
        //public string url { get; set; }

        //public DateTime createDate { get; set; }
        //public string createdBy { get; set; }
        //public DateTime lastUpdate { get; set; }
        //public string lastUpdateBy { get; set; }

    }
}