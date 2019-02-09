using DeliveryService.Common.Exceptions;
using DeliveryService.Services.Points.Domain.Models;
using DeliveryService.Services.Points.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Points.Services
{
    public class PointService : IPointService
    {
        private readonly IPointRepository _pointRepository;
        private readonly IConnectionRepository _connectionRepository;

        public PointService(IPointRepository pointRepository,
            IConnectionRepository connectionRepository)
        {
            _pointRepository = pointRepository ?? throw new ArgumentNullException(nameof(pointRepository));
            _connectionRepository = connectionRepository;
        }

        public async Task AddConnectionAsync(Guid id, decimal cost, Guid destination, string observations)
        {
            var pointConnection = await _pointRepository.GetAsync(destination);
            if (pointConnection == null)
            {
                throw new DeliveryServiceException("destination_not_found", destination + " was not found.");
            }
            var connection = new Connection(id, cost, destination, observations);
            await _connectionRepository.AddAsync(connection);
        }

        public async Task AddPointAsync(Guid id, string name, Guid userId, DateTime createdAt)
        {
            var point = new Point(id, name, userId, createdAt, null);
            await _pointRepository.AddAssync(point);
        }

        public async Task AddPointAsync(Guid id, string name, Guid userId, DateTime createdAt, IEnumerable<Connection> connections)
        {
            var point = new Point(id, name, userId, createdAt, null);
            await _pointRepository.AddAssync(point);

            foreach (var item in connections)
            {
                var connection = new Connection(item.Id, item.Cost, item.Destination, item.Observations);
                await _connectionRepository.AddAsync(connection);
            }
        }
    }
}
