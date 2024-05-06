using System;
using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Application;
using CrystalSharp.Application.Handlers;
using CrystalSharpCqrsExample.Application.Commands;
using CrystalSharpCqrsExample.Application.Responses;

namespace CrystalSharpCqrsExample.Application.CommandHandlers
{
    public class PlaceOrderCommandHandler : CommandHandler<PlaceOrderCommand, PlaceOrderResponse>
    {
        public override async Task<CommandExecutionResult<PlaceOrderResponse>> Handle(PlaceOrderCommand request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid command.");

            PlaceOrderResponse response = new()
            {
                OrderId = Guid.NewGuid(),
                Message = $"Order for {request.ProductName} with quantity {request.Quantity} has been submitted."
            };

            return await Ok(response);
        }
    }
}
