using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrystalSharp.Application;
using CrystalSharp.Application.Execution;
using CrystalSharpCqrsExample.Api.Dto;
using CrystalSharpCqrsExample.Application.Commands;
using CrystalSharpCqrsExample.Application.Responses;
using CrystalSharpCqrsExample.Application.Notifications;

namespace CrystalSharpCqrsExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly INotificationPublisher _notificationPublisher;

        public OrderController(ICommandExecutor commandExecutor, INotificationPublisher notificationPublisher)
        {
            _commandExecutor = commandExecutor;
            _notificationPublisher = notificationPublisher;
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult<PlaceOrderResponse>>> Post([FromBody]PlaceOrderRequest request)
        {
            PlaceOrderCommand command = new() { ProductName = request.ProductName, Quantity = request.Quantity };

            return await _commandExecutor.Execute(command, CancellationToken.None).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("send-notification")]
        public async Task<ActionResult> PostSendNotification([FromBody] OrderInfoRequest request)
        {
            OrderCreatedNotification notification = new() { OrderCode = request.OrderCode };

            await _notificationPublisher.Publish(notification, CancellationToken.None).ConfigureAwait(false);

            return Ok("Notification sent.");
        }
    }
}
