using DeliveryService.Api.Controllers;
using DeliveryService.Common.Commands;
using DeliveryService.Services.Identity.Domain.Repositories;
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
    public class UsersControllerTest
    {
        [Fact]
        public async void user_controller_create_user_should_return_accepted()
        {
            var busClientMock = new Mock<IBusClient>();
            var controller = new UsersController(busClientMock.Object);
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

            var command = new CreateUser
            {
                Email = "test@email.com",
                Name = "test",
                Password = "12345"
            };

            var result = await controller.Post(command);

            var contentResult = result as AcceptedResult;
            contentResult.Should().NotBeNull();
            contentResult.Location.Should().BeEquivalentTo("users/" + command.Name);
        }
    }
}
