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
                    customerId = row.customerId,
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

        public ActionResult EditCustomer(int id)
        {
            int SelectedIndex = id;
            var data = CustomerProcessor.LoadCustomers();
            List<CustomerModel> customers = new List<CustomerModel>();

            CustomerModel selectedCustomer = new CustomerModel();//data.SingleOrDefault(x => x.customerId == selectedIndex)
            foreach(var row in data)
            {
                if (row.customerId == id)
                {
                    selectedCustomer.customerId = row.customerId;
                    selectedCustomer.FirstName = row.FirstName;
                    selectedCustomer.LastName = row.LastName;
                    selectedCustomer.EmailAddress = row.EmailAddress;
                    selectedCustomer.ConfirmEmail = row.EmailAddress;
                }
            }
            return View(selectedCustomer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CustomerProcessor.UpdateCustomer(model.customerId,
                    model.FirstName,
                    model.LastName,
                    model.EmailAddress);

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}