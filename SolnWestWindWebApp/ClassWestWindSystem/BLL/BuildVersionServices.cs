using ClassWestWindSystem.DAL;
using ClassWestWindSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWestWindSystem.BLL
{
    public class BuildVersionServices
    {
        // setup the context connection variable and class constructure
        // this connection will be used by all methods in this class to access the database

        private readonly WestWindContext _context;

        // constructor to be used in the creation of the instance of this class 
        // the registered reference for the context connection will be passes from the service IserviceCollection registered service


        internal BuildVersionServices(WestWindContext registered_context)
        {
            _context = registered_context;
        }


        #region Services
        /*********************** Services *****************************/
        // a service is a method
        //this class will be referenced by external users (aka web app)
        //therefore the class and the services need to be public

        public BuildVersion BuildVersion_Get()
        {
            /*
          * this will use the context property BuildVersions to obtain the
          *      data from the database via the context class
          *  the call return the dataset (DbSet) from the sql table
          *  data returned by the query in this fashion is returned as a set
          *      with the datatype of IEnumerable<T>, where T is the
          *      name of the entity
          *  the dataset create will contain 0, 1 or more records, one for
          *      each row on your sql table
          */
            //get the data from the database as a collection of records
            IEnumerable<BuildVersion> info = _context.BuildVersions;

            /*
          * data to returned is one row from the data placed within info
          * Linq has a method that limits the number of rows from a
          *      data collection: .FirstOrDefault()
          * this method will return the first record in the dataset collection
          * if lthe collection is empty it will return the default of the datatype
          *  (in this case, it is an instance of a class, thus the default is null)
          */

            return info.FirstOrDefault();
        }
    }
    #endregion
}
