using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TollCalculator.Models
{
    public enum ZoneAction
    {
        Enter,
        Leave,
    }

    public class ZoneInfo
    {
        public int id { get; set; }
        public DateTime dateTime { get; set; }
        public ZoneAction ZoneAction { get; set; }
        public bool Fee { get; set; }
    }
}
