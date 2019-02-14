using System;
using System.Threading.Tasks;
using DeliveryService.Common.Commands;
using DeliveryService.Common.Events;
using DeliveryService.Common.Exceptions;
using DeliveryService.Services.Points.Domain.Models;
using DeliveryService.Services.Points.Services;
using Microsoft.Extensions.Logging;
using Neo4j;
using RawRabbit;

namespace DeliveryService.Services.Points.Handlers
{
    public class CreatePointHandler : ICommandHandler<CreatePoint>
    {
        private readonly IBusClient _busClient;
        private readonly IPointService _pointService;
        private ILogger _logger;
        private Neo4j.Driver.V1.IDriver _graphDriver; //TODO:

        public CreatePointHandler(IBusClient busClient,
            IPointService pointService,
            ILogger<CreatePointHandler> logger,
            Neo4j.Driver.V1.IDriver graphDriver)
        {
            _busClient = busClient;
            _pointService = pointService;
            _logger = logger;
            _graphDriver = graphDriver;
        }

        public async Task HandleAsync(CreatePoint command)
        {
            _logger.LogInformation($"Creating Point: {command.Name}");

            try
            {
                await _pointService.AddPointAsync(command.Id, command.Name,
                    command.UserId, command.CreatedAt);
                await _busClient.PublishAsync(new PointCreated(command.Id, 
                    command.Name,
                    command.UserId, command.CreatedAt));

                return;
            }
            catch (DeliveryServiceException ex)
            {
                await _busClient.PublishAsync(new CreatePointRejected(command.Id, ex.Message, ex.Code));
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new CreatePointRejected(command.Id, ex.Message, "error"));
                _logger.LogError(ex.Message);
            }
        }
    }
}
