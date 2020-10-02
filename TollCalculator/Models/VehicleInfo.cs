using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TollCalculator.Models
{
    public class VehicleInfo
    {
        public int id { get; set; }
        public DateTime dateTime { get; set; }

        public bool isFee { get; set; }
    }
}
