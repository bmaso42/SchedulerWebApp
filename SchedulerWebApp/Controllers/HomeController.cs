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
        MySqlCommand cmd = new MySqlCommand();
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
            con.ConnectionString = "server=localhost;uid=sqlUser;pwd=Passw0rd!;database=client_schedule";

        }
        [HttpPost]
        public ActionResult Verify(Login login)
        {
            connectionString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from user where userName='"+login.Name+"' and password='"+login.Password+"'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                con.Close();
                return View("SuccessView");
            }
            else
            {
                con.Close();
                return View("FailedLogin");
            }
        }
    }
}