using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerWebApp.Models
{
    public class CityModel
    {
        public int cityId { get; set; }
        public string city { get; set; }
        public int countryId { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }
    }
}