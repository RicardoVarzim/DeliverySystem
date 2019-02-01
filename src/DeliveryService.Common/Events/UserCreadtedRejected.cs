using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Events
{
    public class UserCreadtedRejected : IRejectedEvent
    {
        public string Email { get; }

        public string Reason { get; }

        public string Code { get; }

        protected UserCreadtedRejected() { }

        public UserCreadtedRejected(string email, string reason, string code)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Reason = reason ?? throw new ArgumentNullException(nameof(reason));
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }
    }
}
