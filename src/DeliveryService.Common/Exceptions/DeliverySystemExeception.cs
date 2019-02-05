using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Exceptions
{
    public class DeliverySystemException : Exception
    {
        public string Code { get; }

        public DeliverySystemException()
        {
        }

        public DeliverySystemException(string code, string v):base(v)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }


    }
}
