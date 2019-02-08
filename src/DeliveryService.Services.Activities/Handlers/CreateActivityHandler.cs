using System;
using System.Threading.Tasks;
using DeliveryService.Common.Commands;
using DeliveryService.Common.Events;
using DeliveryService.Common.Exceptions;
using DeliveryService.Services.Activities.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace DeliveryService.Api.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly IBusClient _busClient;
        private readonly IActivityService _activityService;
        private ILogger _logger;

        public CreateActivityHandler(IBusClient busClient, 
            IActivityService activityService,
            ILogger<CreateActivityHandler> logger)
        {
            _busClient = busClient ?? throw new ArgumentNullException(nameof(busClient));
            _activityService = activityService;
            _logger = logger;
        }

        public async Task HandleAsync(CreateActivity command)
        {
            _logger.LogInformation($"Creating activity: {command.Name}");

            try
            {
                await _activityService.AddAsync(command.Id, command.UserId, 
                    command.Category, command.Name, 
                    command.Description, command.CreatedAt);
                await _busClient.PublishAsync(new ActivityCreated(command.Id,
                    command.UserId, command.Category, command.Name, 
                    command.Description, command.CreatedAt));

                return;
            }
            catch(DeliverySystemException ex)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, ex.Message, ex.Code));
                _logger.LogError(ex.Message);
            }
            catch(Exception ex)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, ex.Message, "error"));
                _logger.LogError(ex.Message);
            }
        }
    }
}