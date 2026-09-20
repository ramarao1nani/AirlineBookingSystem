using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Notifications.Application.Comamnds
{
    public record SebdNotificationCommand(string Recipent, string Message, string Type) : IRequest;
}
