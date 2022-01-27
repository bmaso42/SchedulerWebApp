using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulerWebApp.Models;

namespace SchedulerWebApp.Database
{
    public interface ILocalDataServices
    {
        //void Close();
        //void AddCustomer();
        //void AddAppointment();
        //void DeleteCustomer();
        //void DeleteAppointment();
        //void UpdateCustomer();
        //void UpdateAppointment();
        List<CustomerModel> GetAllCustomers();
    //    List<AppointmentModel> GetAllAppointments();
    //    List<AppointmentModel> GetAppointmentsByDate();
    //    List<AppointmentModel> GetAppointmentsByType();
    }
}
