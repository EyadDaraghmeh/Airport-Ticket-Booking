using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_Ticket_Booking.EnumClass;

namespace Airport_Ticket_Booking.Modle
{
    internal class Passenger
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Email {  get; set; }

        public string Password { get; set; }

        public Passenger(string id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public Passenger()
        {
        }
    }
}
