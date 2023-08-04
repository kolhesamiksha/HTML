using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirManage.Models
{
    public class Route
    {

       public int Route_id { get; set; }
       public string Origin { get; set; }
        public string Destination { get; set; }
  public string Arrival_Time { get; set; }
  public string Departure_Time { get; set;}

    }
}