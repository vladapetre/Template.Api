using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Template.Application.Components.Customers.CreateCustomer;

namespace Template.Presentation.Components.Customers.CreateCustomer;

public static class CreateCustomerEndpoint
{
    public static void MapCreateCustomerEndpoint( this IEndpointRouteBuilder endpointRouteBuilder )
    {
        endpointRouteBuilder
            .MapPost("/customers", CreateCustomer);
    }

    private static Func<CreateCustomerRequest, ICreateCustomerCommandHandler, Task<IResult>> CreateCustomer =>
        async ( CreateCustomerRequest request, ICreateCustomerCommandHandler createCustomerCommandHandler )
            =>
            {
                var command = new CreateCustomerCommand(request.Name);
                var result = await createCustomerCommandHandler.HandlerAsync(command);

                return result.Match(
                    onSuccess: ( customer ) => Results.Created($"/customers/{customer.Id.Id}", customer),
                    onError: ( error ) => Results.Problem(detail: error.Message, statusCode: (int)error.Code));
            };

}
