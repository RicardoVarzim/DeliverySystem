using DeliveryService.Common.Exceptions;
using DeliveryService.Services.Identity.Domain.Services;
using System;

namespace DeliveryService.Services.Identity.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedAt { get; set; }

        protected User() { }

        public User(string email, string name)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new DeliveryServiceException("empty_user_email", "User email can not be empty");
            
            if (string.IsNullOrWhiteSpace(name))
                throw new DeliveryServiceException("empty_user_name", "User name can not be empty");

            Id =  Guid.NewGuid();
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            CreatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new DeliveryServiceException("empty_password", "Password can note be empty");

            Salt = encrypter.GetSalt(password);
            Password = encrypter.GetHash(password, Salt);
        }

        public bool ValidatePassword(string password, IEncrypter encrypter)
        {
            return password.Equals(encrypter.GetHash(password, Salt));
        }
    }
}
