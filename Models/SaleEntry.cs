using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesRecord_WebAPI.Models
{
    public enum SalesChannel { Offline, Online}
    public class SaleEntry
    {
            public string Region { get; set; } = "North America";
            public string Country { get; set; } = "United States of America";
            public string ItemType { get; set; } = "Household";
            
            //public SalesChannel SalesChannel { get; set; }
            public string SalesChannel { get; set; } = "Online";
            public string OrderPriority { get; set; } = "L";
            public DateOnly OrderDate { get; set; }
            public int OrderID { get; set; }
            public DateOnly ShipDate { get; set; }
            public int UnitsSold { get; set; } = 0;
            public double UnitPrice { get; set; } = 0;
            public double UnitCost { get; set; } = 0;
            public double TotalRevenue { get; set; } = 0;
            public double TotalCost { get; set; } = 0;
            public double TotalProfit { get; set; } = 0;

    }
}