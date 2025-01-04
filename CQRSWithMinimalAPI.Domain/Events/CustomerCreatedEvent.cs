using CQRSWithMinimalAPI.Domain.comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSWithMinimalAPI.Domain.Events
{
    public class CustomerCreatedEvent : DomainEvent
    {
        public Guid CustomerId { get; }
        public string Name { get; }

        public CustomerCreatedEvent(Guid customerId, string name)
        {
            CustomerId = customerId;
            Name = name;
        }
    }
}
