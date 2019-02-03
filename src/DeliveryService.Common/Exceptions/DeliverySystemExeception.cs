using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Exceptions
{
    public class DeliverySystemExeception : Exception
    {
        public string Code { get; }

        public DeliverySystemExeception()
        {
        }

        public DeliverySystemExeception(string code, string v):base(v)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }


    }
}
