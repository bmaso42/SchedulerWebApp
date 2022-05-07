using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchedulerWebApp.Models
{
    public class ReportModel
    {
        [Display(Name = "Select beginning of date range:")]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [Display(Name = "Select end of date range:")]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }
    }
}