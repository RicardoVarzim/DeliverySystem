using System;

namespace DeliveryService.Common.Neo4j
{
    class Neo4jOptions
    {
        public string ConnectionString { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
    }
}
