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
    }
}
