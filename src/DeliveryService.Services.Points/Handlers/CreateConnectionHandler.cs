using DeliveryService.Common.Commands;
using DeliveryService.Common.Events;
using DeliveryService.Common.Exceptions;
using DeliveryService.Services.Points.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Points.Handlers
{
    public class CreateConnectionHandler : ICommandHandler<CreateConnection>
    {
        private readonly IBusClient _busClient;
        private readonly IPointService _pointService;
        private ILogger _logger;

        public CreateConnectionHandler(IBusClient busClient, 
            IPointService pointService, ILogger logger)
        {
            _busClient = busClient ?? throw new ArgumentNullException(nameof(busClient));
            _pointService = pointService ?? throw new ArgumentNullException(nameof(pointService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task HandleAsync(CreateConnection command)
        {
            //_logger.LogInformation("Creating Connection: ", command.Observations);

            try
            {
                await _pointService.AddConnectionAsync(command.Id, 
                    command.Cost, command.Destination, command.Observations);
                await _busClient.PublishAsync(new ConnectionCreated(command.Id,
                    command.Cost, command.Destination, command.Observations));

                return;
            }
            catch (DeliveryServiceException ex)
            {
                await _busClient.PublishAsync(new ConnectionCreatedRejected(command.Id, ex.Message, ex.Code));
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new ConnectionCreatedRejected(command.Id, ex.Message, "error"));
                _logger.LogError(ex.Message);
            }
        }
    }
}
