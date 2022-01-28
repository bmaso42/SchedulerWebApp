using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
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
        public static List<CustomerModel> LoadCustomers()
        {
            string sql = @"select * from customer;";

            return MySqlDataAccess.LoadData<CustomerModel>(sql);
        }
    }
    
}
