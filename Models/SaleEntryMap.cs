using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using SalesRecord_WebAPI;

namespace SalesRecord_WebAPI.Models
{
    public class SaleEntryMap: ClassMap<SaleEntry>
    {
        public SaleEntryMap()
        {
            Map(se => se.Region).Index(0);
            Map(se => se.Country).Index(1);
            Map(se => se.ItemType).Index(2);
            Map(se => se.SalesChannel).Index(3);
            Map(se => se.OrderPriority).Index(4);
            Map(se => se.OrderDate).Index(5);
            Map(se => se.OrderID).Index(6);
            Map(se => se.ShipDate).Index(7);
            Map(se => se.UnitsSold).Index(8);
            Map(se => se.UnitPrice).Index(9);
            Map(se => se.UnitCost).Index(10);
            Map(se => se.TotalRevenue).Index(11);
            Map(se => se.TotalCost).Index(12);
            Map(se => se.TotalProfit).Index(13);
        }
    }
}