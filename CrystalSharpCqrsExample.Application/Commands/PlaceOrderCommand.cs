using System;
using CrystalSharp.Application;
using CrystalSharpCqrsExample.Application.Responses;

namespace CrystalSharpCqrsExample.Application.Commands
{
    public class PlaceOrderCommand : ICommand<CommandExecutionResult<PlaceOrderResponse>>
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
