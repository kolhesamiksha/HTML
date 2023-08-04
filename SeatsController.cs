using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirManage.Controllers
{
    public class SeatsController : Controller
    {
        //
        // GET: /Seats/
        public ActionResult Seat()
        {
            return View("~/Views/Seats/Seat.cshtml");
        }
	}
}