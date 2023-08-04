using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace AirManage.Controllers
{
    public class RouteController : Controller
    {
        //
        // GET: /Route/
        public ActionResult Index()
        {
            return View();
        }
        #region IndexProc
        public ActionResult show_route()//Select Data from db
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString =
               ("Data Source = DEVP-052\\DEVP_052_SQL2019; Initial Catalog = AirlineDB; User Id = sa; Password =  Sipl1234 ");
            conn.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Route_info";

            comm.ExecuteNonQuery();


            using (SqlDataAdapter da = new SqlDataAdapter(comm))
            {
                DataTable t2 = new DataTable();
                da.Fill(t2);


                return View("~/Views/Route/show_route.cshtml", t2);
            }
        }
        #endregion


        //
        // GET: /Route/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Route/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Route/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Route/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Route/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Route/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Route/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
