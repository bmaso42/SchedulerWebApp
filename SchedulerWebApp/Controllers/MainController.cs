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

            CustomerModel selectedCustomer = new CustomerModel();
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
                int appointmentsDeleted = CustomerProcessor.DeleteCustomerFromAppointments(id);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult ViewAppointments(string searchString)
        {
            ViewBag.Message = "List of Appointments";
            ViewBag.CustomerList = CustomerProcessor.CustomerList();

            var data = CustomerProcessor.LoadAppointments();
            List<AppointmentModel> appointments = new List<AppointmentModel>();

            if (!String.IsNullOrEmpty(searchString))
            {
                foreach (var row in data.Where(s => s.FirstName.ToLower().Contains(searchString.ToLower()) || s.LastName.ToLower().Contains(searchString.ToLower())))
                {
                    appointments.Add(new AppointmentModel
                    {
                        AppointmentID = row.AppointmentID,
                        CustomerID = row.CustomerID,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        FullName = row.FirstName + " " + row.LastName, //concat field to use for dropdown along with CustomerID
                        Start = row.Start
                    });
                }
            }
            else
            {
                foreach (var row in data)
                {
                    appointments.Add(new AppointmentModel
                    {
                        AppointmentID = row.AppointmentID,
                        CustomerID = row.CustomerID,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        FullName = row.FirstName + " " + row.LastName, //concat field to use for dropdown along with CustomerID
                        Start = row.Start
                    });
                }
            }

            appointments = appointments.OrderBy(s => s.Start).ToList();

            return View(appointments);
        }

        public ActionResult ReportSearch()
        {
            ViewBag.Message = "Search For Appointments";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReportSearch( ReportModel model)
        {
            ReportModel reportModel = new ReportModel();

            var data = CustomerProcessor.LoadAppointments();
            List<AppointmentModel> appointments = new List<AppointmentModel>();
            ViewBag.Timestamp = DateTime.Now;

            if (ModelState.IsValid)
            {
                DateTime start = model.Beginning;
                DateTime end = model.End;

                foreach (var row in data.Where(s => s.Start >= start && s.Start <= end))
                {
                    appointments.Add(new AppointmentModel
                    {
                        AppointmentID = row.AppointmentID,
                        CustomerID = row.CustomerID,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        FullName = row.FirstName + " " + row.LastName, //concat field to use for dropdown along with CustomerID
                        Start = row.Start
                    });
                }

                appointments = appointments.OrderBy(s => s.Start).ToList();

                return View("ReportResult", appointments);
            }

            return View();
        }

        public ActionResult ReportResult(List<AppointmentModel> appointments)
        {
            ViewBag.Message = "Report of Appointments";
            ViewBag.Timestamp = "SAMPLE STRING";

            return View(appointments);
        }

        [NonAction]
        public SelectList ToSelectList(DataTable table) //helper function to combine first+last name from datatable, used to populate dropdownlist
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[0].ToString(),
                    Value = row[1].ToString() + " " + row[2].ToString()
                }); ;
            }

            return new SelectList(list, "Value", "Text");
        }

        public ActionResult CreateAppointment()
        {
            ViewBag.Message = "Create a New Appointment";
            ViewBag.CustomerList = ToSelectList(CustomerProcessor.CustomerList());
 
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
                    model.Start);

                return RedirectToAction("ViewAppointments");
            }
            return View();
        }

        public ActionResult DeleteAppointment(int id)
        {
            int SelectedIndex = id;
            var data = CustomerProcessor.LoadAppointments();
            List<AppointmentModel> appointments = new List<AppointmentModel>();
            SelectList customerNames = ToSelectList(CustomerProcessor.CustomerList());

            AppointmentModel selectedAppointment = new AppointmentModel();
            foreach (var row in data)
            {
                if (row.AppointmentID == id)
                {
                    selectedAppointment.AppointmentID = row.AppointmentID;
                    selectedAppointment.CustomerID = row.CustomerID;
                    selectedAppointment.FullName = row.FirstName + " " + row.LastName;                   
                    selectedAppointment.Start= row.Start;
                }
            }
            return View(selectedAppointment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAppointment(int id, string first)
        {
            if (ModelState.IsValid)
            {
                int recordsDeleted = CustomerProcessor.DeleteAppointment(id);

                return RedirectToAction("ViewAppointments");
            }

            return View();
        }

        public ActionResult EditAppointment(int id)
        {
            ViewBag.CustomerList = ToSelectList(CustomerProcessor.CustomerList());

            int SelectedIndex = id;
            var data = CustomerProcessor.LoadAppointments();
            List<AppointmentModel> appointments = new List<AppointmentModel>();

            AppointmentModel selectedAppointment = new AppointmentModel();
            foreach (var row in data)
            {
                if (row.AppointmentID == id)
                {
                    selectedAppointment.AppointmentID = row.AppointmentID;
                    selectedAppointment.CustomerID = row.CustomerID;
                    selectedAppointment.FirstName = row.FirstName;
                    selectedAppointment.LastName = row.LastName;
                    selectedAppointment.Start = row.Start;
                }
            }
            return View(selectedAppointment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAppointment(AppointmentModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CustomerProcessor.UpdateAppointment(
                    model.AppointmentID,
                    model.CustomerID,
                    model.Start);

                return RedirectToAction("ViewAppointments");
            }
            return View();
        }
    }
}