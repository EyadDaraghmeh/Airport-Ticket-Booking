using Airport_Ticket_Booking.EnumClass;
using Airport_Ticket_Booking.ErrorMessage;
using Airport_Ticket_Booking.Modle;
using Airport_Ticket_Booking.services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.View.PassengerView
{
    internal class BookAflight
    {
        public static void _BookAflight(Passenger p)
        {
            Console.WriteLine("====1-View all available flights");
            Console.WriteLine("====2-Search for available flight");
            int op = 0;
            try
            {
                op = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Message.ErrorMessage(ex.Message);
                _BookAflight(p);
            }
            if (op == 1)
            {
                PassengerServices.ViewAllFligts();
                PassengerServices.Booking(p);

            }
            else
            if (op == 2)
            {
                DateTime? departureDate = null;
                Console.Write("Enter Minimum Price (or press Enter to skip): ");
                string inputPrice = Console.ReadLine();
                int? minPrice = null;
                if (!string.IsNullOrEmpty(inputPrice) && int.TryParse(inputPrice, out int parsedPrice))
                {
                    minPrice = parsedPrice;
                }
                Console.Write("Enter Departure Country (or press Enter to skip): ");
                string departureCountry = Console.ReadLine();
                Console.Write("Enter Destination Country (or press Enter to skip): ");
                string destinationCountry = Console.ReadLine();
                Console.Write("Enter Departure Date (yyyy-MM-dd) or press Enter to skip: ");
                string inputDate = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputDate) && DateTime.TryParse(inputDate, out DateTime parsedDate))
                {
                    departureDate = parsedDate;
                }
                Console.Write("Enter Departure Airport (or press Enter to skip): ");
                string departureAirport = Console.ReadLine();

                Console.Write("Enter Arrival Airport (or press Enter to skip): ");
                string arrivalAirport = Console.ReadLine();

                bool hasFilter = !string.IsNullOrEmpty(departureCountry) || !string.IsNullOrEmpty(destinationCountry) ||
               !string.IsNullOrEmpty(departureDate.ToString()) || !string.IsNullOrEmpty(departureAirport) ||
               !string.IsNullOrEmpty(departureAirport) || !string.IsNullOrEmpty(arrivalAirport) ||
                !string.IsNullOrEmpty(arrivalAirport) || minPrice.HasValue;

                if (hasFilter) { 
                var flights = PassengerServices.SearchFlights(f => ((f.price.Values.Any(p => p >= minPrice) || !minPrice.HasValue)) &&
                   ((f.departureCountry == departureCountry.ToUpper()) || string.IsNullOrEmpty(departureCountry)) &&
                   ((f.destinationCountry == destinationCountry.ToUpper()) || string.IsNullOrEmpty(destinationCountry)) &&
                   ((f.departureDate == departureDate) || !departureDate.HasValue) &&
                   ((f.departureAirport == departureAirport.ToUpper()) || string.IsNullOrEmpty(departureAirport)) &&
                   ((f.departureAirport == arrivalAirport.ToUpper()) || string.IsNullOrEmpty(arrivalAirport))
                   );
                    Flight.Print(flights);
                    PassengerServices.Booking(p);


                }
                else
                {
                    Message.ErrorMessage("Please enter at least one input");
                    _BookAflight(p);
                }
            }
        }
    }
}
