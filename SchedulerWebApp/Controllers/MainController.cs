using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchedulerWebApp.Database;
using SchedulerWebApp.Models;
using DataLibrary;
using DataLibrary.BusinessLogic;

namespace SchedulerWebApp.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewCustomers()
        {
            ViewBag.Message = "List of Customers";

            var data = CustomerProcessor.LoadCustomers();
            List<CustomerModel> customers = new List<CustomerModel>();

            foreach (var row in data)
            {
                customers.Add(new CustomerModel
                {
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress,
                    ConfirmEmail = row.EmailAddress
                });
            }

            return View(customers);

            //var db = new MySQLDataServices();
            //var customerList = db.GetAllCustomers();
            //return View(customerList);
        }
        public ActionResult CreateCustomer()
        {
            ViewBag.Message = "Create a New Customer";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CustomerProcessor.CreateCustomer(model.FirstName, 
                    model.LastName, 
                    model.EmailAddress);

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}