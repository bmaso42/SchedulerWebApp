using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchedulerWebApp.Models;
using MySql.Data.MySqlClient;

namespace SchedulerWebApp.Controllers
{
    public class HomeController : Controller
    {
        MySqlConnection con = new MySqlConnection();
        //MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "server=localhost;user=sqlUser;database=client_schedule;port=3306;password=Passw0rd!;";

        }
        [HttpPost]
        public ActionResult Verify(Login login)
        {
            //connectionString();
            //con.Open();
            //cmd.Connection = con;
            //cmd.CommandText = "select * from user where userName='"+login.Name+"' and password='"+login.Password+"'";
            //dr = cmd.ExecuteReader();
            connectionString();
            con.Open();

            string sql = "select * from client_schedule.user where userName=@Name and password=@Password";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", login.Name);
            cmd.Parameters.AddWithValue("@Password", login.Password);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Console.WriteLine("Username and password match.");
                con.Close();
                return RedirectToAction("Index", "Main");
            }
            else
            {
                Console.WriteLine("Username and password DO NOT match.");
                con.Close();
                return View("FailedLogin");
            }
        }
    }
}