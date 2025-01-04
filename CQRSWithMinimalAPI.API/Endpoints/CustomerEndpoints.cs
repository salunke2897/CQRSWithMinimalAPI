
using CQRSWithMinimalAPI.Application.Customers.Commands;
using CQRSWithMinimalAPI.Application.Customers.Queries;
using MediatR;

namespace CQRSWithMinimalAPI.API.Endpoints
{
    public static class CustomerEndpoints
    {
        public static void MapCustomerEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/customer/{id}", GetCustomerByIdAsync);
            app.MapPost("/customer", CreateCustomerAsync);
        }

        private static async Task<IResult> CreateCustomerAsync(IMediator mediator, CreateCustomerCommand command)
        {
            var id = await mediator.Send(command);
            return Results.Ok(id);
        }

        private static async Task<IResult> GetCustomerByIdAsync(IMediator mediator, Guid id)
        {
            var customer = await mediator.Send(new GetCustomerByIdQuery { Id = id });
            return customer != null ? Results.Ok(customer) : Results.NotFound();
        }
    }
}
