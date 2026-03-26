using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using ClassWestWindSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ClassWestWindSystem.BLL; // we need to add services to BLL to use here
#endregion Additional Namespaces


namespace ClassWestWindSystem
{
    public static class WestWindExtensions
    {
        // setup the extension method for this library
        public static void WWExtensions(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            // IServiceCollection is the collection of services that are registered with the application
            // we will register all services that will be available for usage by any system using this library. services will coded 
            // in the BLL and DAL using individual classes related to Entity. 


            //DBContext connection
            // we will register the DB connection to be used by any service requiring access to database


            //Register the context srvice

            services.AddDbContext<WestWindContext>(options);
            // we add code to register a BLL service over here, so that it can be accessed by outside world
            // each service will be added with the AddTransient method, which means that a new instance of the service will be created each time it is requested.
            services.AddTransient<BuildVersionServices>((ServiceProvider) =>
            {
                // get the conext of class that was registered above 
                var context = ServiceProvider.GetService<WestWindContext>();
                // create an instance of the service and return it to the caller or supply context reference to service class
                return new BuildVersionServices(context);

            });
            // we add code to register a BLL service over here, so that it can be accessed by outside world
            // each service will be added with the AddTransient method, which means that a new instance of the service will be created each time it is requested.
            services.AddTransient<RegionServices>((ServiceProvider) =>
            {
                // get the conext of class that was registered above 
                var context = ServiceProvider.GetService<WestWindContext>();
                // create an instance of the service and return it to the caller or supply context reference to service class
                return new RegionServices(context);

            });


        }
    }
}

