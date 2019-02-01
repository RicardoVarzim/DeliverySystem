using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Commands
{
    public interface IAuthCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}
