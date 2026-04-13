using ClassWestWindSystem.DAL;
using ClassWestWindSystem.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;



namespace ClassWestWindSystem.BLL
{
    public class ShipmentServices
    {

        // setup the context connection variable and class constructure
        // this connection will be used by all methods in this class to access the database

        private readonly WestWindContext _context;

        // constructor to be used in the creation of the instance of this class 
        // the registered reference for the context connection will be passes from the service IserviceCollection registered service


        internal ShipmentServices(WestWindContext registered_context)
        {
            _context = registered_context;
        }
        // add your required services a.k.a queries over here copy from 

        public List<Shipment> Shipment_GetByYearMonth(int yeararg, int montharg)
        {


            //it is possible to place validation of incoming parameters within your services
            //remember the services are independent of the outside user

            if (yeararg < 1950 || yeararg > DateTime.Today.Year)
            {
                throw new ArgumentException($"Invalid year {yeararg}. Year must be between 1950 and today");
            }
            if (montharg < 1 || montharg > 12)
            {
                throw new ArgumentException($"Invalid month {montharg}. Month must be between 1 and 12");
            }
            // fetch records for yearmontharg
            IEnumerable<Shipment> info = _context.Shipments.Where(s => s.ShippedDate.Year == yeararg
                                                        && s.ShippedDate.Month == montharg)
                                                 .OrderBy(s => s.ShippedDate);
            return info.ToList();


            // lookup the specific region record for supplied region ID
        }

        //Pagination

        //return the total number of records that would be returned for the query
        //this query will NOT return any actual query result records

        public int Shipment_GetByYearAndMonthCount(int year, int month)
        {
            if (year < 1950 || year > DateTime.Today.Year)
            {
                throw new ArgumentException($"Invalid year {year}. Year must be between 1950 and today");
            }
            if (month < 1 || month > 12)
            {
                throw new ArgumentException($"Invalid month {month}. Month must be between 1 and 12");
            }
            //execute the query without any additional methods use to join other tables or organize the 
            //   queried dataset
            IEnumerable<Shipment> info = _context.Shipments
                                                .Where(s => s.ShippedDate.Year == year
                                                        && s.ShippedDate.Month == month);
            return info.Count(); //just get the count of the dataset records

            // alternative Linq statements
            //return _context.Shipments
            //                .Where(s => s.ShippedDate.Year == year
            //                        && s.ShippedDate.Month == month)
            //                .Count();

            //return _context.Shipments
            //               .Count(s => s.ShippedDate.Year == year
            //                       && s.ShippedDate.Month == month);
        }

        //this method will return the data set records that are NEEDED for the current page
        //it does NOT return the entire data set collection
        //the method needs to determine the record subset to return

        public List<Shipment> Shipment_GetByYearAndMonthPaging(int year,
                                                                int month,
                                                                int currentpagenumber,
                                                                int itemsperpage)
        {
            //the currentpagenumber and itemsperpage are used in the determination of which
            //  dataset record subset is to be returned from the entire dataset query collection

            if (year < 1950 || year > DateTime.Today.Year)
            {
                throw new ArgumentException($"Invalid year {year}. Year must be between 1950 and today");
            }
            if (month < 1 || month > 12)
            {
                throw new ArgumentException($"Invalid month {month}. Month must be between 1 and 12");
            }
            IEnumerable<Shipment> info = _context.Shipments
                                                .Include(s => s.ShipViaNavigation)
                                                .Where(s => s.ShippedDate.Year == year
                                                        && s.ShippedDate.Month == month)
                                                .OrderBy(s => s.ShippedDate);

            //pagination calculation logic
            //calculate the number of records to skip
            //subtract 1 from the natural page number to get the page index number
            int recordsSkipped = itemsperpage * (currentpagenumber - 1);

            //return JUST the records for the current page
            //Skip: skip the first x items representing previous pages
            //Take: take up to the necessary number of items on a page
            return info.Skip(recordsSkipped).Take(itemsperpage).ToList();
        }
    }
}