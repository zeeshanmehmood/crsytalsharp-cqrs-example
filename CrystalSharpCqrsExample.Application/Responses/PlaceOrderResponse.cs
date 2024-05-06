using System;

namespace CrystalSharpCqrsExample.Application.Responses
{
    public class PlaceOrderResponse
    {
        public Guid OrderId { get; set; }
        public string Message { get; set; }
    }
}
