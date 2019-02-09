using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Exceptions
{
    public class DeliveryServiceException : Exception
    {
        public string Code { get; }

        public DeliveryServiceException()
        {
        }

        public DeliveryServiceException(string code, string v):base(v)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }


    }
}
