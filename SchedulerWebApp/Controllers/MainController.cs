using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchedulerWebApp.Database;

namespace SchedulerWebApp.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Customer()
        {
            var db = new MySQLDataServices();
            var customerList = db.GetAllCustomers();
            return View(customerList);
        }
    }
}