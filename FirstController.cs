using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Common;

namespace AirManage.Controllers
{
    public class FirstController : Controller
    {
        //
        // GET: /First/
        public ActionResult Index()
        {
            return View();
        }

        #region IndexProc
        public ActionResult IndexProc()//Select Data from db
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString =
               ("Data Source = DEVP-052\\DEVP_052_SQL2019; Initial Catalog = AirlineDB; User Id = sa; Password =  Sipl1234 ");
            conn.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "SelectAllFlights";

            comm.ExecuteNonQuery();


            using (SqlDataAdapter da = new SqlDataAdapter(comm))
            {
                DataTable t2 = new DataTable();
                da.Fill(t2);


                return View("~/Views/First/IndexProc.cshtml", t2);
            }
        }
        #endregion







         //GET: flight/Details/5
        public ActionResult Detail(int id)
        {
          return View();
       }


       
        ////Post: /First/Detail/5
        [HttpPost]
        public ActionResult Detail(int id , FormCollection collection )
        {
            
           SqlConnection conn = new SqlConnection();

           conn.ConnectionString = ("Data Source = DEVP-052\\DEVP_052_SQL2019; Initial Catalog = AirlineDB; User Id = sa; Password =  Sipl1234 ");
            DataTable dt = new DataTable();
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand();

                //SqlParameter Flight_id;
                //SqlParameter Start_Location;
                //SqlParameter Destination;
                //SqlParameter Arrival_Time;
                //SqlParameter Departure_Time;
                //SqlParameter ticket_price;
                //SqlParameter Class;


                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DetailsProc";

        //        Flight_id = new SqlParameter("@Flight_id", SqlDbType.Int);
        //        cmd.Parameters.Add(Flight_id);
        //        Flight_id.Value = Flight_id;

        //        Start_Location = new SqlParameter("@Start_Location", SqlDbType.VarChar);
        //        cmd.Parameters.Add(Start_Location);
        //        Start_Location.Value = Start_Location;


        //  Destination = new SqlParameter("@Destination", SqlDbType.VarChar);
        //     cmd.Parameters.Add(Destination);
        //    Destination.Value = Destination;

        //    Arrival_Time = new SqlParameter("@Arrival_Time", SqlDbType.VarChar);
        //    cmd.Parameters.Add(Arrival_Time);
        //    Arrival_Time.Value = Arrival_Time;

        //  Departure_Time = new SqlParameter("@Departure_Time", SqlDbType.VarChar);
        //    cmd.Parameters.Add(Departure_Time);
        // Departure_Time.Value = Departure_Time;


        // ticket_price = new SqlParameter("@ticket_price", SqlDbType.Int);
        // cmd.Parameters.Add(ticket_price);
        // ticket_price.Value = ticket_price;

        // Class = new SqlParameter("@Class", SqlDbType.Int);
        // cmd.Parameters.Add(Class);
        //Class.Value = Class;





                cmd.ExecuteNonQuery();

                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    ad.Fill(dt);

                }
                 
            }
            catch (Exception)
            {
                throw;
            }
            return View(dt);
        }
        




        
        // GET: /First/Create
        public ActionResult Create()
        {
            return View();
        }

        
        // POST: /First/Create
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

                    SqlParameter Flight_id;
                    SqlParameter Start_Location;
                    SqlParameter Destination ;
                    SqlParameter Arrival_Time ;
                    SqlParameter Departure_Time;
                    SqlParameter ticket_price ;
                    SqlParameter Class ;
                   
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertflight";

                     
                    Flight_id = new SqlParameter("@Flight_id", SqlDbType.Int);
                    Start_Location = new SqlParameter("@Start_Location ", SqlDbType.VarChar);
                    Destination = new SqlParameter("@Destination", SqlDbType.VarChar);
                     Arrival_Time = new SqlParameter("@Arrival_Time ", SqlDbType.VarChar);
                     Departure_Time = new SqlParameter("@Departure_Time", SqlDbType.VarChar );
                     ticket_price  = new SqlParameter("@ticket_price ", SqlDbType.Int);
                     Class  = new SqlParameter("@Class", SqlDbType.VarChar);



                    cmd.Parameters.Add(Flight_id);
                    cmd.Parameters.Add(Start_Location);
                    cmd.Parameters.Add( Destination );
                    cmd.Parameters.Add(Arrival_Time);
                    cmd.Parameters.Add(Departure_Time);
                    cmd.Parameters.Add(ticket_price);
                    cmd.Parameters.Add( Class);


                     Flight_id.Value = collection["Flight_id"];
                    Start_Location.Value = collection["Start_Location"];
                   Destination .Value = collection["Destination"];
                   Arrival_Time.Value = collection["Arrival_Time"];
                   Departure_Time.Value = collection["Departure_Time"];
                   ticket_price .Value = collection["ticket_price"];
                    Class .Value = collection["Class"];

                    cmd.ExecuteNonQuery();

                }

                catch (Exception )
                {
                   return View();
                }
               
            return RedirectToAction("IndexProc");
           
        }
    
        

        //
        // GET: /First/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /First/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ("Data Source = DEVP-052\\DEVP_052_SQL2019; Initial Catalog = AirlineDB; User Id = sa; Password =  Sipl1234 ");

            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                    
                    SqlParameter Flight_id;
                    SqlParameter Start_Location;
                    SqlParameter Destination ;
                    SqlParameter Arrival_Time ;
                    SqlParameter Departure_Time;
                    SqlParameter ticket_price ;
                    SqlParameter Class ;
               
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EditProc";

                Flight_id = new SqlParameter("@Flight_id", SqlDbType.Int);
                Start_Location = new SqlParameter("@Start_Location", SqlDbType.VarChar);
                Destination = new SqlParameter("@Destination", SqlDbType.VarChar);
                Arrival_Time = new SqlParameter("@Arrival_Time", SqlDbType.VarChar);
                Departure_Time = new SqlParameter("@Departure_Time", SqlDbType.VarChar);
                ticket_price = new SqlParameter("@ticket_price", SqlDbType.VarChar);
                Class = new SqlParameter("@Class", SqlDbType.VarChar);




                cmd.Parameters.Add(Flight_id);
                cmd.Parameters.Add(Start_Location);
                cmd.Parameters.Add(Destination);
                cmd.Parameters.Add(Arrival_Time);
                cmd.Parameters.Add(Departure_Time);
                cmd.Parameters.Add(ticket_price);
                cmd.Parameters.Add(Class);


                Flight_id.Value = collection["Flight_id"];
                Start_Location.Value = collection["Start_Location"];
                Destination.Value = collection["Destination"];
                Arrival_Time.Value = collection["Arrival_Time"];
                Departure_Time.Value = collection["Departure_Time"];
                ticket_price.Value = collection["ticket_price"];
                Class.Value = collection["Class"];

                cmd.ExecuteNonQuery();


            }
            catch
            {
                return View();
            }
            return RedirectToAction("IndexProc");
        }





        //DELETE STARTED
        // GET: /First/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /First/Delete/5
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
                cmd.CommandText = "DeleteProc";

                idd = new SqlParameter("@id", SqlDbType.Int);
               
                cmd.Parameters.Add(idd);

                idd.Value = id;
                
               

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("IndexProc");
        }
        }
    }
