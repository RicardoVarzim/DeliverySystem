using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Events
{
    public class CreatePointRejected : IEvent
    {
        private Guid id;
        private string message;
        private string code;

        public CreatePointRejected(Guid id, string message, string code)
        {
            this.id = id;
            this.message = message;
            this.code = code;
        }
    }
}
