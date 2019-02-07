using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Commands
{
    public class AuthUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
