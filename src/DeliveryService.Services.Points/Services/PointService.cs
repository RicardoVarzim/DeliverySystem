using DeliveryService.Common.Exceptions;
using DeliveryService.Services.Points.Domain.Models;
using DeliveryService.Services.Points.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.Services.Points.Services
{
    public class PointService : IPointService
    {
        private readonly IPointRepository _pointRepository;
        private readonly IConnectionRepository _connectionRepository;
        private readonly IGraphRepository _graphRepository; 

        public PointService(IPointRepository pointRepository,
            IConnectionRepository connectionRepository, IGraphRepository graphRepository)
        {
            _pointRepository = pointRepository;
            _connectionRepository = connectionRepository;
            _graphRepository = graphRepository;
        }

        public async Task AddConnectionAsync(Guid id, decimal cost, Guid destination, string observations)
        {
            var pointConnection = await _pointRepository.GetAsync(destination);
            if (pointConnection == null)
            {
                throw new DeliveryServiceException("destination_not_found", destination + " was not found.");
            }
            var connection = new Connection(id, cost, destination, observations);
            await Task.WhenAll(_connectionRepository.AddAsync(connection), _graphRepository.AddConnectionAsync(id,connection));
        }

        public async Task AddPointAsync(Guid id, string name, Guid userId, DateTime createdAt)
        {
            var point = new MyPoint(id, name, userId, createdAt, null);
            await Task.WhenAll(_pointRepository.AddAssync(point), _graphRepository.AddPointAsync(point));
        }

        public async Task AddPointAsync(Guid id, string name, Guid userId, DateTime createdAt, IEnumerable<Connection> connections)
        {
            var point = new MyPoint(id, name, userId, createdAt, null);
            await Task.WhenAll(_pointRepository.AddAssync(point), _graphRepository.AddPointAsync(point));

            foreach (var item in connections)
            {
                var connection = new Connection(item.Id, item.Cost, item.Destination, item.Observations);
                await Task.WhenAll(_connectionRepository.AddAsync(connection), _graphRepository.AddConnectionAsync(id, connection));
            }
        }

        public Task<IEnumerable<MyPoint>> BrowsePointsAsync()
        {
            return _pointRepository.BrowseAsync();
        }

        public async Task<IEnumerable<Path>> GetPath(Guid originId, Guid destinationId)
        {
            var originPoint = await _pointRepository.GetAsync(originId);
            var destinationPoint = await _pointRepository.GetAsync(destinationId);
            var pathList = await _graphRepository.PathAsync(originPoint, destinationPoint);

            if (pathList == null)
            {
                return null;
            }

            return pathList;
        }
    }
}
