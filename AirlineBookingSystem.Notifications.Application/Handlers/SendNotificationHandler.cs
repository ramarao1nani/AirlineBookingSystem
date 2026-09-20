using AirlineBookingSystem.Notifications.Application.Comamnds;
using AirlineBookingSystem.Notifications.Application.Interfaces;
using AirlineBookingSystem.Notifications.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Notifications.Application.Handlers
{
    public class SendNotificationHandler : IRequestHandler<SebdNotificationCommand>
    {
        private readonly INotificationService _notificationService;
        public SendNotificationHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public async Task Handle(SebdNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = new Notification
            {
                Id = Guid.NewGuid(),
                Recipient = request.Recipent,
                Message = request.Message,
                Type = request.Type
            };
            await _notificationService.SendNotificationAsync(notification);
        }
    }
}
