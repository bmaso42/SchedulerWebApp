using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using SchedulerWebApp.Models;

namespace SchedulerWebApp.Database
{
    public class MySQLDataServices : ILocalDataServices
    {
        MySqlConnection con = new MySqlConnection();
        public void Close() {
            con.Close();
        }
        void AddCustomer() { 
        
        }
        void AddAppointment() { }
        void DeleteCustomer() { }
        void DeleteAppointment() { }
        void UpdateCustomer() { }
        void UpdateAppointment() { }
        List<CustomerModel> GetAllCustomers() {
            string sql = "select * from client_schedule.customer";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader AllCustomerReader = cmd.ExecuteReader();

        }
        List<AppointmentModel> GetAllAppointments() { }
        List<AppointmentModel> GetAppointmentsByDate() { }
        List<AppointmentModel> GetAppointmentsByType() { }
    }
}