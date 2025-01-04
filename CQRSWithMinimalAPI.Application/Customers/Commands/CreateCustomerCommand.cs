using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSWithMinimalAPI.Application.Customers.Commands;
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
