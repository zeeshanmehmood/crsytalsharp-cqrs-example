using CrystalSharp.Application;

namespace CrystalSharpCqrsExample.Application.Notifications
{
    public class OrderCreatedNotification : INotification
    {
        public string OrderCode { get; set; }
    }
}
