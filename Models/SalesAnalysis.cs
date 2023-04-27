using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesRecord_WebAPI.Models
{
    
    public class SalesAnalysis
    {
        public double MedianUnitCost { get; set; } = 0.0;

        public string MostCommonRegionn { get; set; } = "North America";

        //The default first order date will be the latest possible date
        public DateOnly FirstOrderDate { get; set; } = new DateOnly(9999, 12, 31);

        //The default last order date will be the earliest possible date
        public DateOnly LastOrderDate { get; set; } = new DateOnly(0001, 01, 01);

        public double TotalRevenue { get; set; } = 0.0;
    }
}