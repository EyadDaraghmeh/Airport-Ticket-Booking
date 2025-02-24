using Airport_Ticket_Booking.CustomAttribute;
using Airport_Ticket_Booking.EnumClass;
using Airport_Ticket_Booking.ErrorMessage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Airport_Ticket_Booking.EnumClass.FlightClass;

namespace Airport_Ticket_Booking.Modle
{
    internal class Flight
    {
        [Required(ErrorMessage = "Flight number cannot be empty")]
        public string _flightNo { get; set; }

        public Dictionary<_FlightClass, int> price { get; set; }
        [Required(ErrorMessage = "Departure Country cannot be empty")]

        public string departureCountry { get; set; }
        [Required(ErrorMessage = "Destination Country cannot be empty")]
        public string destinationCountry { get; set; }
        [Required(ErrorMessage = "Departure Date cannot be empty")]
        [MinDate]

        public DateTime departureDate { get; set; }
        [Required(ErrorMessage = "Departure Airport cannot be empty")]

        public string departureAirport { get; set; }
        [Required(ErrorMessage = "Arrival  Airport cannot be empty")]

        public string arrivalAirport {  get; set; }


        public Flight(string flightNo, Dictionary<_FlightClass, int> price, string departureCountry, string destinationCountry,
            DateTime departureDate, string departureAirport, string arrivalAirport)
        {
            _flightNo = flightNo;
            this.price = price;
            this.departureCountry = departureCountry;
            this.destinationCountry = destinationCountry;
            this.departureDate = departureDate;
            this.departureAirport = departureAirport;
            this.arrivalAirport = arrivalAirport;
        }

        public override string? ToString()
        {
            string priceDetails = price != null
           ? string.Join(", ", price)
           : "No price details";

            return $"Flight No: {_flightNo}, " +
                   $"Departure: {departureCountry} ({departureAirport}) -> " +
                   $"Destination: {destinationCountry} ({arrivalAirport}), " +
                   $"Date: {departureDate:yyyy-MM-dd HH:mm}, " +
                   $"Prices: {priceDetails}";
        }


       public static void Print(List<Flight> flights)
        {
            foreach(Flight flight in flights)
            {
                Console.WriteLine(flight.ToString());
            }
        }

        public static bool IsValid(Flight flight)
        {
            var errors = new List<ValidationResult>();
            var context=new ValidationContext(flight);
            var valid = Validator.TryValidateObject(flight, context, errors, true);
            if (!valid)
            {
                Console.Write("There is an error in the data for this flight====>");
                Console.WriteLine(flight);
                Console.WriteLine("Errors:");
                foreach (var error in errors)
                {
                    Message.ErrorMessage(error.ErrorMessage);
                }
            }
            return valid;
        }
    }
}
