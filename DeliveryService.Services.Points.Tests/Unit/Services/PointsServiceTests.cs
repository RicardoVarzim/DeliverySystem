﻿using DeliveryService.Services.Points.Domain.Models;
using DeliveryService.Services.Points.Domain.Repositories;
using DeliveryService.Services.Points.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeliveryService.Services.Points.Tests.Unit.Services
{
    public class PointsServiceTests
    {
        [Fact]
        public async Task points_service_add_async_should_succeed()
        {
            var pointsRepositoryMock = new Mock<IPointRepository>();
            var connectionRepositoryMock = new Mock<IConnectionRepository>();

            var pointsService = new PointService(pointsRepositoryMock.Object, connectionRepositoryMock.Object);

            var id = Guid.NewGuid();

            await pointsService.AddPointAsync(id, "point", Guid.NewGuid(), DateTime.UtcNow);

            pointsRepositoryMock.Verify(x => x.AddAssync(It.IsAny<Point>()), Times.Once);
        }
    }
}
