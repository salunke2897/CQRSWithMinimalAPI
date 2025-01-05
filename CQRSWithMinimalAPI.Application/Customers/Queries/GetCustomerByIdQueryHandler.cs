using CQRSWithMinimalAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CQRSWithMinimalAPI.Domain.Entities;
using CQRSWithMinimalAPI.Application.Interfaces;
using CQRSWithMinimalAPI.Application.DTO;

namespace CQRSWithMinimalAPI.Application.Customers.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly IRepository<Customer> _repository;

        public GetCustomerByIdQueryHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetByIdAsync(request.Id);
            CustomerDto customerDto = new CustomerDto();
            customerDto.Id = request.Id;
            customerDto.Name = response.Name;
            return customerDto;
        }
    }
}
