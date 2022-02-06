using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SchedulerWebApp.Database;
using SchedulerWebApp.Models;
using DataLibrary;
using DataLibrary.BusinessLogic;
using System.Data;

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

        public ActionResult DeleteCustomer(int id)
        {
            int SelectedIndex = id;
            var data = CustomerProcessor.LoadCustomers();
            List<CustomerModel> customers = new List<CustomerModel>();

            CustomerModel selectedCustomer = new CustomerModel();
            foreach (var row in data)
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
        public ActionResult DeleteCustomer(int id, string first)
        {
            if (ModelState.IsValid)
            {
            int recordsDeleted = CustomerProcessor.DeleteCustomer(id);

                return RedirectToAction("Index");
            }

            return View();
        }
        
        public ActionResult ViewAppointments()
        {
            ViewBag.Message = "List of Appointments";
            ViewBag.CustomerList = CustomerProcessor.CustomerList();

            var data = CustomerProcessor.LoadAppointments();
            List<AppointmentModel> appointments = new List<AppointmentModel>();

            foreach (var row in data)
            {
                appointments.Add(new AppointmentModel
                {
                    AppointmentID = row.AppointmentID,
                    CustomerID = row.CustomerID,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    FullName = row.FirstName + " " + row.LastName, //concat field to use for dropdown along with CustomerID
                    Type = row.Type,
                    Start = row.Start,
                    End = row.End
                });
            }


            return View(appointments);
        }

        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        public ActionResult CreateAppointment()
        {
            ViewBag.Message = "Create a New Appointment";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAppointment(AppointmentModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CustomerProcessor.CreateAppointment(
                    model.CustomerID,
                    model.FirstName,
                    model.LastName,
                    model.Type,
                    model.Start,
                    model.End);

                return RedirectToAction("ViewAppointments");
            }
            return View();
        }
    }
}