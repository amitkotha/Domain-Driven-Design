using System;
using System.Collections.Generic;
using System.Text;

namespace Working_With_Domain_Events
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }

        public void isNameChanged()
        {
            //Raise an event when Name is changed
            RaiseEvent(new CustomerIsChanged
            {
                Name = Name,
                Id=Id
            }) ;
        }

        public class CustomerIsChanged : IEvent
        {

            public string Name { get; set; }
            public int Id { get; set; }

        }
    }
}
