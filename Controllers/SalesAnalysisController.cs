using System;
using System.Collections;
//using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using SalesRecord_WebAPI.Models;


namespace SalesRecord_WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SalesAnalysisController : ControllerBase
    {
        /*
        In the event that the .csv file does not follow the conventional format, use the following code snippet to adjust the csv reader parameters:

        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                Comment = '#',
                HasHeaderRecord = false
            };
        
        */

        // Helper function that reads the data contained in the .csv file and store it in a List data structure
        public static List<SaleEntry> readCsvRecordFile(){


            //creating an absolute path to the .csv file containing the data
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;              
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"../../../assets/SalesRecords.csv");  
            string sFilePath = Path.GetFullPath(sFile);

            using (var reader = new StreamReader(sFilePath))

            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<SaleEntryMap>();
                var SaleRecord = csv.GetRecords<SaleEntry>().ToList<SaleEntry>();
                return SaleRecord;
            }
        }

        // Helper function to create a SaleAnalysis object an calculate/determine it's attribute appropriately
        public static SalesAnalysis CreateSalesRecordAnalysis()
        {
            //private static SalesAnalysis apiOutput = new SalesAnalysis();
            SalesAnalysis apiOutput = new SalesAnalysis();
            List<double> unitPrices = new List<double>();
            Dictionary<string, int> regions = new Dictionary<string, int>();

            //private static List<SaleEntry> salesRecord = SalesAnalysisController.readCsvRecordFile();
            List<SaleEntry> salesRecord = SalesAnalysisController.readCsvRecordFile();

            foreach (SaleEntry item in salesRecord)
            {
                //adding the current item unit price to our list of prices to faciliitate  the calculation of the median value later on
                unitPrices.Add(item.UnitPrice);

                //Adding the current item order total revenue to the global revenue for the whole record
                apiOutput.TotalRevenue = apiOutput.TotalRevenue + item.TotalRevenue;

                //Checking if the curent item order date is ealier than than the first order date on record
                if (item.OrderDate < apiOutput.FirstOrderDate){ apiOutput.FirstOrderDate = item.OrderDate;}

                //Checking if the curent item order date is later than than the last order date on record
                if (item.OrderDate > apiOutput.LastOrderDate){ apiOutput.LastOrderDate = item.OrderDate;}

                //checking if the region is presentin the region hashtable: if yes, increment it's frequency/value, if no then add to the table
                if (regions.ContainsKey(item.Region)) {regions[item.Region] = Convert.ToInt32(regions[item.Region])+ 1;}
                else { regions.Add(item.Region, 1);}

            }

            //Sort the unit price list before calculating the median 
            unitPrices.Sort();
            System.Diagnostics.Debug.WriteLine(unitPrices);

            /*
            Median calcuation
                -first check if the total number of unit prices (n) is odd or even
                -use the appropriate formula to calculate the median unit price: 
                    (n+1)/2 if the count is odd or ((n/2)+((n/2)+1))/2 if the count is even
            */
            if ((unitPrices.Count % 2)!=0) {apiOutput.MedianUnitCost = unitPrices[(unitPrices.Count + 1)/2];}
            else {apiOutput.MedianUnitCost = unitPrices[((unitPrices.Count/2)+((unitPrices.Count/2)+1))/2];}

            //Check for the most common region
            apiOutput.MostCommonRegionn = regions.Aggregate((x,y) => x.Value > y.Value ? x : y).Key;

            return apiOutput;

        }
        

        [HttpGet]
        public ActionResult<SalesAnalysis> Get()
        {
            SalesAnalysis result = CreateSalesRecordAnalysis();
            //Console.WriteLine(result);
            return Ok(result);
        }

    }

}