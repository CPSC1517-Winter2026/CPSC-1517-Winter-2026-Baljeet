using ClassWestWindSystem.DAL;
using ClassWestWindSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWestWindSystem.BLL
{
    public class CategoryServices
    {
        // setup the context connection variable and class constructure
        // this connection will be used by all methods in this class to access the database

        private readonly WestWindContext _context;

        // constructor to be used in the creation of the instance of this class 
        // the registered reference for the context connection will be passes from the service IserviceCollection registered service


        internal CategoryServices(WestWindContext registered_context)
        {
            _context = registered_context;
        }
        // add your required services a.k.a queries over here

        public List<Category> Category_GetAll()
        {
            IEnumerable<Category> info = _context.Categories;
            return info.OrderBy(x=> x.CategoryName).ToList();
        }




    }
}
