using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Working_With_Domain_Events
{
   public class CustomerDbContext:DbContext
    {

        public DbSet<Customer> Customers { get; set; }

        
        public IDispatcher _dispatcher { get; set; }
        public CustomerDbContext(IDispatcher dispatcher):base()
        {
            _dispatcher = dispatcher;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = database.sqlite");
        }

        public CustomerDbContext()
        {
        }

        public override  System.Threading.Tasks.Task<int> SaveChangesAsync(CancellationToken cancellationToken=new CancellationToken())
        {
            var domainEntities = ChangeTracker.Entries<IBaseEntity>();
            foreach(var entities in domainEntities)
            {
                var domainEvents = entities.Entity.GetEvents();
                foreach(var events in domainEvents)
                {
                     _dispatcher.PublishEvent(events);
                }
            }
            //Before Saving changes to database raise the events
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
