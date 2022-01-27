using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerWebApp.Models
{
    public class AddressModel
    {
        public int addressId { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public int postalCode { get; set; }
        public string phone { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }
    }
}