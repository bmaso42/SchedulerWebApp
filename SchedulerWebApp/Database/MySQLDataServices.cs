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
        void connectionString()
        {
            con.ConnectionString = "server=localhost;user=sqlUser;database=client_schedule;port=3306;password=Passw0rd!;";

        }

        //con.Open();
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
        public List<CustomerModel> GetAllCustomers() {
            string sql = "select * from client_schedule.customer";

            connectionString();
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader AllCustomerReader = cmd.ExecuteReader();

            List<CustomerModel> customerList = new List<CustomerModel>();

            while (AllCustomerReader.Read())
            {
                CustomerModel customerModel = new CustomerModel();

                //customerModel.customerID = AllCustomerReader.GetInt32(0);
                //customerModel.customerName = AllCustomerReader.GetString(1);
                //customerModel.addressId = AllCustomerReader.GetInt32(2);
                //customerModel.active = AllCustomerReader.GetBoolean(3);
                //customerModel.createDate = AllCustomerReader.GetDateTime(4);
                //customerModel.createdBy = AllCustomerReader.GetString(5);
                //customerModel.lastUpdate = AllCustomerReader.GetDateTime(6);
                //customerModel.lastUpdateBy = AllCustomerReader.GetString(7);

                customerList.Add(customerModel);
            }
            return customerList;
        }
        //List<AppointmentModel> GetAllAppointments() { }
        //List<AppointmentModel> GetAppointmentsByDate() { }
        //List<AppointmentModel> GetAppointmentsByType() { }
    }
}