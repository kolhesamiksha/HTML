using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirManage.Controllers
{
    public class HomeController : Controller
    {
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


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            string User = collection.Get("Username");
            string Pass = collection.Get("Password");

            if (User == "admin" && Pass == "admin@123")
            {
                return View("../Shared/Dashboard");
            }

            else
            {
                Console.WriteLine("Enter Valid UserName and Password");
            }


            return View();

        }



        //public ActionResult view(string p)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
