using DeliveryService.Api.Controllers;
using DeliveryService.Common.Commands;
using DeliveryService.Services.Points.Domain.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Xunit;

namespace DeliveryService.Api.Tests.Controllers
{
    public class PointsControllerTests
    {
        [Fact]
        public async void points_controller_post_should_return_accepted()
        {
            var busClientMock = new Mock<IBusClient>();
            var pointsRepositoryMock = new Mock<IPointRepository>();           
            var controller = new PointsController(busClientMock.Object);
            var userId = Guid.NewGuid();
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim(ClaimTypes.Name, userId.ToString())
                        }, "test"))
                }
            };

            var command = new CreatePoint
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };

            var result = await controller.Post(command);

            var contentResult = result as AcceptedResult;
            contentResult.Should().NotBeNull();
            contentResult.Location.Should().BeEquivalentTo("points/" + command.Id);

        }

    }
}
