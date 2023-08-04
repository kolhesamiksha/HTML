using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace AirManage.Controllers
{
    public class ThirdController : Controller
    {
        //
        // GET: /Third/
        public ActionResult Index()
        {
            return View();
        }

        #region IndexProc
        public ActionResult Pshow()//Select Data from db
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString =
               ("Data Source = DEVP-052\\DEVP_052_SQL2019; Initial Catalog = AirlineDB; User Id = sa; Password =  Sipl1234 ");
            conn.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Pass_info";

            comm.ExecuteNonQuery();


            using (SqlDataAdapter da = new SqlDataAdapter(comm))
            {
                DataTable t2 = new DataTable();
                da.Fill(t2);


                return View("~/Views/Third/Pshow.cshtml", t2);
            }
        }
        #endregion

        //
        // GET: /Third/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Third/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Third/Create
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
        // GET: /Third/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Third/Edit/5
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
        // GET: /Third/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Third/Delete/5
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
