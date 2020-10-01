using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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


        
        List<string> vizList = new List<string>();

        public void CalculateAll()
        {
            // send every vehicle with all entry dates and time
            //GetTollFee(Vehicle vehicle, DateTime[] dates);
            TollCalc tollCalc = new TollCalc();
            tollCalc.GetTollFee(null, null);

            
        }

        public void OnGet(int VehicleId, string aDate, string aTime, string id)
        {
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
                    //remove item
                    VehiclesInsideZoneList.Remove(VehicleId);
                }
                else
                {
                    // Add item
                    VehiclesInsideZoneList.Add(VehicleId);
                    VehicleInfo info = new VehicleInfo();
                    info.id = VehicleId;
                    info.dateTime = DateTime.Now; // ToDo: Add correct date & time from page
                    Vehicles item = vehicles.Find(item => item.Id == VehicleId);
                    info.isFee = item.Fee;
                    VehicleInfos.Add(info);
                }

                foreach (Vehicles el in vehicles)
                {
                    int value = VehiclesInsideZoneList.Find(item => item == el.Id);
                    if (value > 0)
                    {
                        vizList.Add(el.Name + ", " + el.Department + " [" + aDate + " " + aTime + "]");
                    }
                }
                ViewData["InsideZone"] = vizList;
            }
            else
            {
                string currDate = Request.Query["CurrentDate"];
                string currTime = Request.Query["CurrentTime"];
                

            }
        }
    }
}
