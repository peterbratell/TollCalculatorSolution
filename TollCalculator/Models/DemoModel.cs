using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TollCalculator.Models
{
    public class DemoModel
    {
        public static string CurrentDate { get; set; }
        public static string CurrentTime { get; set; }

        public HttpContext Context;
        //public List<int> VehiclesInsideZoneList { get; set; }


        Dictionary<int, string> vehiclesTollFreeDict = new Dictionary<int, string>();

        public DemoModel()
        {
           
        }


        public Dictionary<int, string> returnTollFreeDict()
        {

            vehiclesTollFreeDict.Add(0, "Motorbike");
            vehiclesTollFreeDict.Add(1, "Tractor");
            vehiclesTollFreeDict.Add(2, "Emergency");
            vehiclesTollFreeDict.Add(3, "Diplomat");
            vehiclesTollFreeDict.Add(4, "Foreign");
            vehiclesTollFreeDict.Add(5, "Military");
            return vehiclesTollFreeDict;
        }

        Dictionary<int, string> vehiclesTollDict = new Dictionary<int, string>();

        public Dictionary<int, string> returnTollDict()
        {

            vehiclesTollDict.Add(0, "Car");
            vehiclesTollDict.Add(1, "Truck");
            vehiclesTollDict.Add(2, "Bus");

            return vehiclesTollDict;
        }

       


    }
    







}
