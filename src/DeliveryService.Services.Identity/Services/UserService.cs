using DeliveryService.Common.Exceptions;
using DeliveryService.Services.Identity.Domain.Models;
using DeliveryService.Services.Identity.Domain.Repositories;
using DeliveryService.Services.Identity.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;

        public UserService(IUserRepository userRepository, IEncrypter encrypter)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _encrypter = encrypter ?? throw new ArgumentNullException(nameof(encrypter));
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
                throw new DeliveryServiceException("user_doesnt_exists", "Invalid User");
            if (!user.ValidatePassword(password, _encrypter))
                throw new DeliveryServiceException("invalid_password", "Invalid password");
        }

        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new DeliveryServiceException("email_in_use", email + " is already in use.");
            }
            user = new User(email, name);
            user.SetPassword(password, _encrypter);
            await _userRepository.AddAsync(user);
        }
    }
}
