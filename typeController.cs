using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirManage.Controllers
{
    public class typeController : Controller
    {
        //
        // GET: /type/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /type/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /type/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /type/Create
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
        // GET: /type/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /type/Edit/5
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
        // GET: /type/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /type/Delete/5
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
         public ActionResult type()
        {
            return View();
        }
        //post
        [HttpPost]
        public ActionResult type(FormCollection collection)
        {
             SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ("Data Source = DEVP-052\\DEVP_052_SQL2019; Initial Catalog = AirlineDB; User Id = sa; Password =  Sipl1234 ");
            DataTable dt = new DataTable();
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                    
                    
                    
                   SqlParameter ptype;
              
                  
                  
                  
               
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "proc1";

               
                ptype = new SqlParameter("@ptype", SqlDbType.VarChar);
               
            




             
                cmd.Parameters.Add(ptype);
          
                
               


            
                ptype.Value = collection["ptype"];
              

               
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
            return View("type1",dt);
        }

        }
    }


    
