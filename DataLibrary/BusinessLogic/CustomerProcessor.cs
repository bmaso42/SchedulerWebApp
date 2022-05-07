using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class CustomerProcessor
    {
        public static int CreateCustomer(string firstName, string lastName, string emailAddress)
        {
            CustomerModel data = new CustomerModel
            {
                //customerId = customerId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

            string sql = @"Insert into customer (FirstName, LastName, EmailAddress)
                          values (@FirstName, @LastName, @EmailAddress);";

            return MySqlDataAccess.SaveData(sql, data);
        }

        public static int UpdateCustomer(int customer_ID, string firstName, string lastName, string emailAddress)
        {
            CustomerModel data = new CustomerModel
            {
                customerId = customer_ID,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

            string sql = @"Update customer set Firstname = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress
                            WHERE customerId = @customerId;";

            return MySqlDataAccess.SaveData(sql, data);
        }

        public static int DeleteCustomer(int customer_ID)
        {
            CustomerModel data = new CustomerModel
            {
                customerId = customer_ID,
                //FirstName = firstName
            };

            string sql = @"delete from customer where customerId = @customerId;";

            return MySqlDataAccess.SaveData(sql, data);
        }

        public static int CreateAppointment(int CustomerID, /*string FirstName, string LastName,*/ DateTime Start)
        ///*int AppointmentID*/int CustomerID, string FirstName, string LastName, string Type, DateTime Start, DateTime End)
        {
            AppointmentModel data = new AppointmentModel
            {
                //AppointmentID = AppointmentID,
                CustomerID = CustomerID,
                //FirstName = FirstName,
                //LastName = LastName,
                //Type = null,
                Start = Start,
                //End = End
            };

            string sql = @"Insert into appointment (CustomerID, Start)
                          values (@CustomerID, @Start);";

            //@"Insert into appointment (CustomerID, FirstName, LastName, Start)
            //              values (@CustomerID, @FirstName, @LastName, @Start);";

            //@"Insert into appointment (CustomerID, FirstName, LastName, Type, Start, End)
            //              values (@CustomerID, @FirstName, @LastName, @Type, @Start, @End);";

            return MySqlDataAccess.SaveData(sql, data);
        }
        public static int UpdateAppointment(int AppointmentID, int CustomerID, DateTime Start)
        {
            AppointmentModel data = new AppointmentModel
            {
                AppointmentID = AppointmentID,
                CustomerID = CustomerID,
                //FirstName = FirstName,
                //LastName = LastName,
                //Type = null,
                Start = Start,
                //End = End
            };

            string sql = @"update appointment set customerID = @CustomerID, start = @Start WHERE appointmentID = @AppointmentID";
            //@"Update customer set Firstname = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress
            //                WHERE customerId = @customerId;"

            return MySqlDataAccess.SaveData(sql, data);
        }

        public static int DeleteAppointment(int appointment_ID)
        {
            AppointmentModel data = new AppointmentModel
            {
                AppointmentID = appointment_ID
                //FirstName = firstName
            };

            string sql = @"delete from appointment where appointmentId = @AppointmentID;";

            return MySqlDataAccess.SaveData(sql, data);
        }

        public static List<CustomerModel> LoadCustomers()
        {
            string sql = @"select * from customer;";

            return MySqlDataAccess.LoadData<CustomerModel>(sql);
        }

        public static List<AppointmentModel> LoadAppointments()
        {
            string sql = @"SELECT a.appointmentId, a.customerId, b.FirstName, b.LastName, a.start
                            FROM appointment as a
                            INNER JOIN customer as b
                            on a.customerId = b.customerId;";

            //@"SELECT a.appointmentId, a.customerId, b.FirstName, b.LastName, a.type, a.start, a.end
            //                FROM appointment as a
            //                INNER JOIN customer as b
            //                on a.customerId = b.customerId;";

            return MySqlDataAccess.LoadData<AppointmentModel>(sql);
        }
        public static DataTable CustomerList()
        {
            string sql = "select customerId, FirstName, LastName from customer;";

            return MySqlDataAccess.GetDataTable(sql);
        }

        public static List<AppointmentModel> CreateReport(DateTime start, DateTime end)
        {
            string sql = @"SELECT a.appointmentId, a.customerId, b.FirstName, b.LastName, a.start
                            FROM appointment as a
                            INNER JOIN customer as b
                            on a.customerId = b.customerId;";

            //@"SELECT a.appointmentId, a.customerId, b.FirstName, b.LastName, a.type, a.start, a.end
            //                FROM appointment as a
            //                INNER JOIN customer as b
            //                on a.customerId = b.customerId;";

            return MySqlDataAccess.LoadData<AppointmentModel>(sql);
        }

    }
    
}
