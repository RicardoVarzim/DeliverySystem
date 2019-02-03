using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Common.Mongo
{
    public interface IDatabaseInit
    {
        Task InitAsync();
    }
}
