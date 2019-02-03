using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Events
{
    public class UserCreatedRejected : IRejectedEvent
    {
        public string Email { get; }

        public string Reason { get; }

        public string Code { get; }

        protected UserCreatedRejected() { }

        public UserCreatedRejected(string email, string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}
