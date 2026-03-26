using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 1. add required namespaces
// 2. you need connection string and the constructor 
#region add required namespaces

using ClassWestWindSystem.DAL;
using ClassWestWindSystem.Entity;
#endregion

namespace ClassWestWindSystem.BLL
{
    public class RegionServices
    {
        // setup the context connection variable and class constructure
        // this connection will be used by all methods in this class to access the database

        private readonly WestWindContext _context;

        // constructor to be used in the creation of the instance of this class 
        // the registered reference for the context connection will be passes from the service IserviceCollection registered service


        internal RegionServices(WestWindContext registered_context)
        {
            _context = registered_context;
        }
        // add your required services a.k.a queries over here
        public List<Region> Region_GetList() // entityname_methode
        {
            IEnumerable<Region> info = _context.Regions.OrderBy(r => r.RegionDescription);
            return info.ToList();
        }

        // lookup the specific region record for supplied region ID

        public Region Region_GetByID(int regionID)
        {

            Region info = _context.Regions.Where(r=> r.RegionId == regionID).FirstOrDefault();
            return info;
        }


    }
}
