using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirManage.Controllers
{
    public class SecondController : Controller
    {
        //
        // GET: /Second/
        public ActionResult Index()
        {
            return View();
        }

        #region IndexProc
        public ActionResult show()//Select Data from db
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString =
               ("Data Source = DEVP-052\\DEVP_052_SQL2019; Initial Catalog = AirlineDB; User Id = sa; Password =  Sipl1234 ");
            conn.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Book_info";

            comm.ExecuteNonQuery();


            using (SqlDataAdapter da = new SqlDataAdapter(comm))
            {
                DataTable t2 = new DataTable();
                da.Fill(t2);


                return View("~/Views/Second/show.cshtml", t2);
            }
        }
        #endregion


        //
        // GET: /Second/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Second/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Second/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            
          SqlConnection conn = new SqlConnection();

                conn.ConnectionString =
                   ("Data Source = DEVP-052\\DEVP_052_SQL2019; Initial Catalog = AirlineDB; User Id = sa; Password =  Sipl1234 ");
                DataTable dt = new DataTable();
                try
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand();

                    SqlParameter Booking_id;
                    SqlParameter Booking_Pass_id;
                    SqlParameter Booking_date;
                    SqlParameter Booking_Type;
                  
                   
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertbook";


                   Booking_id= new SqlParameter("@Booking_id", SqlDbType.Int);
                    Booking_Pass_id= new SqlParameter("@Booking_Pass_id", SqlDbType.VarChar);
                    Booking_date = new SqlParameter("@Booking_date", SqlDbType.VarChar);
                    Booking_Type = new SqlParameter("@Booking_Type", SqlDbType.VarChar);




                    cmd.Parameters.Add(Booking_id);
                    cmd.Parameters.Add(Booking_Pass_id);
                    cmd.Parameters.Add(Booking_date);
                    cmd.Parameters.Add(Booking_Type);



                    Booking_id.Value = collection["Booking_id"];
                    Booking_Pass_id.Value = collection["Booking_Pass_id"];
                    Booking_date.Value = collection["Booking_date"];
                    Booking_Type.Value = collection["Booking_Type"];
                 

                    cmd.ExecuteNonQuery();

                }

                catch (Exception e )
                {
                   throw e;
                }
               
            return RedirectToAction("show");
           
        
        }

        //
        // GET: /Second/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Second/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ("Data Source = DEVP-052\\DEVP_052_SQL2019; Initial Catalog = AirlineDB; User Id = sa; Password =  Sipl1234 ");

            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand();

                SqlParameter Booking_id;
                SqlParameter Booking_Pass_id;
                SqlParameter Booking_date;
                SqlParameter Booking_Type;
                
                
               
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EditBook";

                Booking_id = new SqlParameter("@Booking_id", SqlDbType.Int);
                Booking_Pass_id = new SqlParameter("@Booking_Pass_id", SqlDbType.VarChar);
                Booking_date = new SqlParameter("@Booking_date", SqlDbType.VarChar);
                Booking_Type = new SqlParameter("@Booking_Type", SqlDbType.VarChar);





                cmd.Parameters.Add(Booking_id);
                cmd.Parameters.Add(Booking_Pass_id);
                cmd.Parameters.Add(Booking_date);
                cmd.Parameters.Add(Booking_Type);
         ;


              Booking_id.Value = collection["Booking_id"];
              Booking_Pass_id.Value = collection["Booking_Pass_id"];
              Booking_date.Value = collection["Booking_date"];
              Booking_Type.Value = collection["Booking_Type"];
           
                cmd.ExecuteNonQuery();


            }
            catch
            {
                return View();
            }
            return RedirectToAction("show");
        


        }

        //
        // GET: /Second/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Second/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
           SqlConnection conn = new SqlConnection();

            conn.ConnectionString =  ("Data Source = DEVP-052\\DEVP_052_SQL2019; Initial Catalog = AirlineDB; User Id = sa; Password =  Sipl1234 ");
            DataTable dt = new DataTable();
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand();

                SqlParameter idd;
                
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteP";

                idd = new SqlParameter("@id", SqlDbType.Int);
               
                cmd.Parameters.Add(idd);

                idd.Value = id;
                
               

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                return View();
            }
            return RedirectToAction("show");
        }
        
        
    }
}
