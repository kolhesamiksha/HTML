using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirManage.Controllers
{
    public class worklistController : Controller
    {
        //
        // GET: /worklist/
        public ActionResult Index()
        {
            return View();
        }

        //#region IndexProc
        //public ActionResult Work()//Select Data from db
        //{
        //    SqlConnection conn = new SqlConnection();

        //    conn.ConnectionString =
        //       ("Data Source = DEVP-052\\DEVP_052_SQL2019; Initial Catalog = AirlineDB; User Id = sa; Password =  Sipl1234 ");
        //    conn.Open();

        //    SqlCommand comm = new SqlCommand();
        //    comm.Connection = conn;
        //    comm.CommandType = CommandType.StoredProcedure;
        //    comm.CommandText = "Plane_Info";

        //    comm.ExecuteNonQuery();


        //    using (SqlDataAdapter da = new SqlDataAdapter(comm))
        //    {
        //        DataTable t2 = new DataTable();
        //        da.Fill(t2);


        //        return View("~/Views/worklist/Work.cshtml", t2);
        //    }
        //}
        //#endregion

        
        // GET: /worklist/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /worklist/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /worklist/Create
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
        // GET: /worklist/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /worklist/Edit/5
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
        // GET: /worklist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /worklist/Delete/5
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

        //get
        public ActionResult Filter2()
        {
            return View();
        }
        //post
        [HttpPost]
        public ActionResult Filter2(FormCollection collection)
        {
             SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ("Data Source = DEVP-052\\DEVP_052_SQL2019; Initial Catalog = AirlineDB; User Id = sa; Password =  Sipl1234 ");
            DataTable dt = new DataTable();
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                    
                    
                    
                   SqlParameter Start_Location;
                  SqlParameter Destination;
                  
                  
                  
               
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Planet";

               
                Start_Location = new SqlParameter("@Start_Location", SqlDbType.VarChar);
                Destination = new SqlParameter("@Destination", SqlDbType.VarChar);
                
            




             
                cmd.Parameters.Add(Start_Location);
                cmd.Parameters.Add(Destination);
                
               


            
                Start_Location.Value = collection["Start_Location"];
                Destination.Value = collection["Destination"];

               
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    ad.Fill(dt);

                }
            }
            catch
            {
                return View();
            }
            return View("Filter3",dt);
        }

        }
    }

