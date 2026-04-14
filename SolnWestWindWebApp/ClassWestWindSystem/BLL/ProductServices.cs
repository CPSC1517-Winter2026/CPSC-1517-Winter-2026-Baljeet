using ClassWestWindSystem.DAL;
using ClassWestWindSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWestWindSystem.BLL
{
    public class ProductServices
    {
        // setup the context connection variable and class constructure
        // this connection will be used by all methods in this class to access the database

        private readonly WestWindContext _context;

        // constructor to be used in the creation of the instance of this class 
        // the registered reference for the context connection will be passes from the service IserviceCollection registered service


        internal ProductServices(WestWindContext registered_context)
        {
            _context = registered_context;
        }
        // add your required services a.k.a queries over here
        //get products by categoryid

        public List<Product> Product_GetByCategory( int categoryid)
        {
            IEnumerable<Product> info = _context.Products.Where(
                                        p => p.CategoryId == categoryid)
                                        .OrderBy(p=> p.ProductName) ;
            return info.ToList();
        }



        // get product details by productid

        public Product Product_GetByProductID( int productid)
        {
            Product info = _context.Products.Where(
                                    p => p.ProductId == productid).FirstOrDefault();
            return info;
        }


    }
}
