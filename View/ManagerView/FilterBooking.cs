using Airport_Ticket_Booking.ErrorMessage;
using Airport_Ticket_Booking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.View.ManagerView
{
    internal class FilterBooking
    {
        public static void _FilterBooking()
        {
            Console.Write("Enter The Passenger Name (or press Enter to skip): ");
            string passengerName = Console.ReadLine().ToLower().Trim();

            Console.Write("Enter The Flight Number (or press Enter to skip): ");
            string flightNo = Console.ReadLine().ToLower().Trim();

            Console.Write("Enter The Price (or press Enter to skip): ");
            string inputPrice = Console.ReadLine();
            int? Price = null;
            if (!string.IsNullOrEmpty(inputPrice) && int.TryParse(inputPrice, out int parsedPrice))
            {
                Price = parsedPrice;
            }

            Console.Write("Enter The Departure Country (or press Enter to skip): ");
            string departureCountry = Console.ReadLine().ToLower().Trim();

            Console.Write("Enter The Destination Country (or press Enter to skip): ");
            string destinationCountry = Console.ReadLine().ToLower().Trim();

            Console.Write("Enter The Departure Date (yyyy-mm-dd)(or press Enter to skip): ");
            string departureDate = Console.ReadLine().Trim();
            DateTime? date = null;
            if(!string.IsNullOrEmpty(departureDate))
            {
                try
                {
                    date = DateTime.Parse(departureDate);

                }
                catch
                {
                    Message.ErrorMessage("Enter Valid Date");
                    _FilterBooking();

                }
            }
           

            Console.Write("Enter The Departure Airport (or press Enter to skip): ");
            string departureAirport = Console.ReadLine().ToLower().Trim();

            Console.Write("Enter The Arrival Airport (or press Enter to skip): ");
            string arrivalAirport = Console.ReadLine().ToLower().Trim();

            Console.Write("Enter The Flight Class (or press Enter to skip): ");
            string flightClass = Console.ReadLine().ToLower().Trim();



            bool hasFilter = !string.IsNullOrEmpty(flightNo) || !string.IsNullOrEmpty(departureCountry) ||
                !string.IsNullOrEmpty(destinationCountry) || !string.IsNullOrEmpty(departureDate) ||
                !string.IsNullOrEmpty(departureAirport) || !string.IsNullOrEmpty(arrivalAirport) ||
                !string.IsNullOrEmpty(passengerName) || !string.IsNullOrEmpty(flightClass) || Price.HasValue;
                

            if (hasFilter)
            {
                ManagerServices.FliterBooking(filter => ((filter.FlightNo.ToLower().Trim() == flightNo) || string.IsNullOrEmpty(flightNo)) &&
                ((filter.DepartureCountry.ToLower().Trim() == departureCountry) || string.IsNullOrEmpty(departureCountry)) &&
                ((filter.DestinationCountry.ToLower().Trim() == destinationCountry) || string.IsNullOrEmpty(departureCountry)) &&
                ((DateTime.Parse(filter.DepartureDate) == date) || string.IsNullOrEmpty(departureDate)) &&
                ((filter.DepartureAirport.ToLower().Trim() == departureAirport) || string.IsNullOrEmpty(departureAirport)) &&
                ((filter.ArrivalAirport.ToLower().Trim() == arrivalAirport) || string.IsNullOrEmpty(arrivalAirport)) &&
                ((filter.PassengerName.ToLower().Trim() == passengerName) || string.IsNullOrEmpty(passengerName)) &&
                ((filter.FlightClass.ToLower().Trim() == flightClass) || string.IsNullOrEmpty(flightClass)) &&
                ((filter.Price == Price) || !Price.HasValue)
                );
            }

            else
            {
                Message.ErrorMessage("Please enter at least one input");
                _FilterBooking();
            }







        }
    }
}
