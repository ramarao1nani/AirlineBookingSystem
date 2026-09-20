using AirlineBookingSystem.Notifications.Application.Comamnds;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Notifications.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] SebdNotificationCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
