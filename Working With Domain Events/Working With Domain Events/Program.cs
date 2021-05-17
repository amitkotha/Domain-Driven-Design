using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Working_With_Domain_Events
{
    class Program
    {
        static void Main(string[] args)
        {
           new Program().ExecuteDemo();
        }

          void ExecuteDemo()
        {
            Customer a = new Customer() { Name = "Amit" };
            a.isNameChanged();
            //Just for testing
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddServiceCollectionTypes(GetType().Assembly);
            var provider = serviceCollection.BuildServiceProvider();
            CustomerDbContext dbContext = new CustomerDbContext(new Dispatcher(provider));

            dbContext.Customers.Add(a);
            dbContext.SaveChangesAsync();
        }
    }
}
