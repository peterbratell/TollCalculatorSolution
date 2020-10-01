using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TollCalculator.Models
{
    public class VehicleModel
    {
        public string Name { get; set; }
        public int Type { get; set; } // Enum type; car, bus, mc etc
        public bool Fee { get; set; }


    }
    public interface Vehicle
    {
        String GetVehicleType();
    }
}
