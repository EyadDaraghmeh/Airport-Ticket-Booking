using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Airport_Ticket_Booking.EnumClass.FlightClass;

namespace Airport_Ticket_Booking.Modle
{
    internal class Booking
    {
        public string Id { get; set; }
        public string PassengerId { get; set; }
        public string FlightNo { get; set; }

        public string fligtClass { get; set; }

        public int price { get; set; }

        public Booking(string id, string passengerId, string flightNo, string fligtClass, int price)
        {
            Id = id;
            PassengerId = passengerId;
            FlightNo = flightNo;
            this.fligtClass = fligtClass;
            this.price = price;
        }
    }
}
