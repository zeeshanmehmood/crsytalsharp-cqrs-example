namespace CrystalSharpCqrsExample.Api.Dto
{
    public class PlaceOrderRequest
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
