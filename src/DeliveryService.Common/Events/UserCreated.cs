﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Events
{
    public class UserCreated : IEvent
    {
        public string Email { get; }
        public string Name { get; }

        protected UserCreated()
        {

        }

        public UserCreated(string email, string name)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
