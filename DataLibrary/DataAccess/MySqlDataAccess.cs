using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataLibrary.DataAccess
{
    public static class MySqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "C868DBClient")
        {
            //return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            return "server=localhost;user=sqlUser;database=client_schedule;port=3306;password=Passw0rd!;";
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new MySqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new MySqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

        public static DataTable GetDataTable(string sql)
        {
            MySqlConnection con = new MySqlConnection(GetConnectionString());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand(sql);
            DataTable getdatatable = new DataTable();

            adapter.SelectCommand = cmd;
            adapter.SelectCommand.Connection = con;
            adapter.Fill(getdatatable);
            return getdatatable;
        }
    }
}
