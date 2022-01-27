using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerWebApp.Models
{
    public class CustomerModel
    {
        public int customerID { get; set; }
        public string customerName { get; set; }
        public int addressId { get; set; }
        public bool active { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }
    }
}