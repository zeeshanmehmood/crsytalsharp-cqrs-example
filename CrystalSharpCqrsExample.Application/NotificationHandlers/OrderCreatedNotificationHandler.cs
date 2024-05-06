using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Application.Handlers;
using CrystalSharpCqrsExample.Application.Notifications;

namespace CrystalSharpCqrsExample.Application.NotificationHandlers
{
    public class OrderCreatedNotificationHandler : NotificationHandler<OrderCreatedNotification>
    {
        public override async Task Handle(OrderCreatedNotification notification, CancellationToken cancellationToken = default)
        {
            // Handle logic here.
        }
    }
}
