using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using TollCalculator.Models;




namespace TollCalculator.Pages.Pages
{
    public class DemoModel : PageModel
    {
        public SelectList vhcl { get; set; }
        //public string InsideZone { get; set; }

        [BindProperty]
        public DemoModel CurrentDate { get; set; }
        public DemoModel CurrentTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int SelectedVehicleId { get; set; }
        public static List<int> VehiclesInsideZoneList = new List<int>();
        public static List<VehicleInfo> VehicleInfos = new List<VehicleInfo>();
        // List containing all vehicles in and out, where and when
        public static List<ZoneInfo> zoneInfos = new List<ZoneInfo>();

        public static DateTime dateTime = new DateTime();

        
        List<string> vizList = new List<string>();
        static List<string> zaList = new List<string>();

        public const int minVehicles = 1;
        public const int maxVehicles = 12;

        public void CalculateAll()
        {


            for(int i = minVehicles; i<maxVehicles; i++)
            {
                DateTime[] dates = new DateTime[]
                {

                };

                TollCalc tollCalc = new TollCalc();
                int total = tollCalc.GetTollFee(dates);
                // update page with fee info per vehicle
            }



            //TollCalc tollCalc = new TollCalc();
            //int total = tollCalc.GetTollFee(dates);



        }

        public void OnGet(int VehicleId, string aDate, string aTime, string id)
        {
            try
            {


                if (!string.IsNullOrEmpty(aDate) && !string.IsNullOrEmpty(aTime))
                {
                    var cultureInfo = new CultureInfo("se-SE");
                    dateTime = DateTime.ParseExact(aDate, "yyyyMMdd", CultureInfo.InvariantCulture);
                }
                else
                {
                    dateTime = DateTime.Now;
                }
            }
            catch (System.Exception e)
            {
                string link = "/Pages/Error";
                Redirect(link);
            }

            if (id != null)
            {
                CalculateAll();
            }
            // ToDo: get this from db
            var vehicles = new List<Vehicles>{
                new Vehicles{ Id = 1, Name = "Car 1", Department = "Toll", Fee = true},
                new Vehicles{ Id = 2, Name = "Car 2", Department = "Toll", Fee = true},
                new Vehicles{ Id = 3, Name = "Truck", Department = "Toll", Fee = true},
                new Vehicles{ Id = 4, Name = "Bus", Department = "Toll", Fee = true},
                new Vehicles{ Id = 5, Name = "Police", Department = "Emergency", Fee = false},
                new Vehicles{ Id = 6, Name = "Ambulance", Department = "Emergency", Fee = false},
                new Vehicles{ Id = 7, Name = "Fire engine", Department = "Emergency", Fee = false},
                new Vehicles{ Id = 8, Name = "Motorbike", Department = "Other Toll free", Fee = false},
                new Vehicles{ Id = 9, Name = "Tractor", Department = "Other Toll free", Fee = false},
                new Vehicles{ Id = 10, Name = "Diplomat", Department = "Other Toll free", Fee = false},
                new Vehicles{ Id = 11, Name = "Foreign", Department = "Other Toll free", Fee = false},
                new Vehicles{ Id = 12, Name = "Military", Department = "Other Toll free", Fee = false},
            };

            vhcl = new SelectList(vehicles, nameof(Vehicles.Id), nameof(Vehicles.Name), null, nameof(Vehicles.Department));
            if (VehiclesInsideZoneList == null)
            {
                VehiclesInsideZoneList = new List<int>();
            }

            if (VehicleId > 0)
            {
                int viz = VehiclesInsideZoneList.Find(item => item == VehicleId);
                if (viz > 0)
                {
                    

                    ZoneInfo zInfo = new ZoneInfo();
                    zInfo.id = VehicleId;
                    zInfo.dateTime = dateTime;
                    zInfo.ZoneAction = ZoneAction.Leave;
                    zoneInfos.Add(zInfo);
                    Vehicles item = vehicles.Find(item => item.Id == VehicleId);
                    zaList.Add(item.Name + ", " + dateTime + " Leave");
                    //remove item
                    VehiclesInsideZoneList.Remove(VehicleId);

                }
                else
                {
                    // Add item
                    VehiclesInsideZoneList.Add(VehicleId);
                    VehicleInfo info = new VehicleInfo();
                    info.id = VehicleId;
                    info.dateTime = dateTime;
                    Vehicles item = vehicles.Find(item => item.Id == VehicleId);
                    info.isFee = item.Fee;
                    VehicleInfos.Add(info);

                    ZoneInfo zInfo = new ZoneInfo();
                    zInfo.id = VehicleId;
                    zInfo.dateTime = dateTime;
                    zInfo.ZoneAction = ZoneAction.Enter;
                    zoneInfos.Add(zInfo);
                    Vehicles vItem = vehicles.Find(vitem => vitem.Id == VehicleId);
                    zaList.Add(vItem.Name + ", " + dateTime + " Enter");


                }

                foreach (Vehicles el in vehicles)
                {
                    int value = VehiclesInsideZoneList.Find(item => item == el.Id);
                    if (value > 0)
                    {
                        VehicleInfo item = VehicleInfos.Find(item => item.id == el.Id);
                        if (item != null)
                        {
                            aDate = item.dateTime.Date.ToString();
                        }
                        vizList.Add(el.Name + ", " + el.Department + " [" + aDate + " " + aTime + "]");
                    }
                }

                ViewData["InsideZone"] = vizList;
                //ViewData["date"] = aDate;
                //ViewData["time"] = aTime;
                ViewData["ZoneActions"] = zaList;
            }
            else
            {
                string currDate = Request.Query["CurrentDate"];
                string currTime = Request.Query["CurrentTime"];
            }
        }
    }
}
