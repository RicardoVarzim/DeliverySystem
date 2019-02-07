using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Events
{
    public class UserAuthed : IEvent
    {
        public string Email { get; }

        protected UserAuthed() { }

        public UserAuthed(string email)
        {
            Email = email;
        }
    }
}
