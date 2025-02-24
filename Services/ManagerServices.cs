using Airport_Ticket_Booking.CsvOperations;
using Airport_Ticket_Booking.ErrorMessage;
using Airport_Ticket_Booking.Modle;
using Airport_Ticket_Booking.View.ManagerView;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Airport_Ticket_Booking.Services
{
    internal class ManagerServices
    {
        public static void ViewAllBookings()
        {
            var flights=FlightOperation.LoadFligths();
            var passengers=PassengerOperation.LoadPassenger();
            var bookings=BookingOperation.LoadBooking();


            var allBookingPassengers = JoinBookingFlightPassenger();

            if (allBookingPassengers.Count == 0)
            {
                Message.ErrorMessage("No Data Found");
            }
            else
                PrintBooking(allBookingPassengers);

            Home._Home();



        }

        private static List<dynamic> JoinBookingFlightPassenger()
        {
            var flights = FlightOperation.LoadFligths();
            var passengers = PassengerOperation.LoadPassenger();
            var bookings = BookingOperation.LoadBooking();
            var allBookingPassengers = from booking in bookings
                                       join passenger in passengers on booking.PassengerId equals passenger.Id
                                       join flight in flights on booking.FlightNo equals flight._flightNo
                                       select new
                                       {
                                           FlightNo = booking.FlightNo,
                                           Price = booking.price,
                                           DepartureCountry = flight.departureCountry,
                                           DestinationCountry = flight.destinationCountry,
                                           DepartureDate = flight.departureDate.ToString("yyyy-MM-dd"),
                                           DepartureAirport = flight.departureAirport,
                                           ArrivalAirport = flight.arrivalAirport,
                                           PassengerName = passenger.Name,
                                           FlightClass = booking.fligtClass,

                                       };

            return allBookingPassengers.Cast<dynamic>().ToList();
        }

        public static void FliterBooking(Func<dynamic, bool> criteria)
        {
          var  allBookingPassengers = JoinBookingFlightPassenger();
          var filterAllBookingPassengers =allBookingPassengers.Where(criteria).ToList();
            if (filterAllBookingPassengers.Count== 0)
            {
                Message.ErrorMessage("No Data Found");
            }
            else
            PrintBooking(filterAllBookingPassengers);

            Home._Home();
         
        }


        private static void PrintBooking(List<dynamic> BookingPassengers)
        {
            Console.WriteLine("=========================================");
            foreach (var filter in BookingPassengers)
            {
                Console.WriteLine($"Passenger Name: {filter.PassengerName}\n" +
                    $"Flight Number: {filter.FlightNo}\n" +
                    $"Price: {filter.Price}\n" +
                     $"Flight Class: {filter.FlightClass}\n" +
                    $"Departure Country: {filter.DepartureCountry}\n" +
                    $"Destination Country: {filter.DestinationCountry}\n" +
                    $"Departure Date: {filter.DepartureDate}\n" +
                    $"Departure Airport: {filter.DepartureAirport}\n" +
                    $"Arrival Airport: {filter.ArrivalAirport}\n" +
                    $"Flight Class :{filter.FlightClass}");
                Console.WriteLine("=========================================");
            }
        }

        public static void LoadFlightsFromCsv(string filePath)
        {
            var flights=FlightOperation.LoadFligths(filePath);
            if (flights.Count==0)
            {
                Message.ErrorMessage($"There is no valid data in this file {filePath}.");
                Home._Home();
            }
            else
            {
                Console.WriteLine("=================================================");
                Message.SucsessMessage("The valid flights :");
                foreach (var flight in flights)
                {
                    Console.WriteLine(flight);
                }
                Console.Write("Do you want to store valid flights?(y/n)");
                string q=Console.ReadLine().ToLower().Trim();
                if(q=="y")
                {
                    FlightOperation.CreateFlights(flights);
                }
                else if(q=="n") 
                {
                    Home._Home();
                }
                else
                {
                    Message.ErrorMessage("Valid Option!!");
                    LoadFlightsFromCsv(filePath);
                }

            }
        }

    }
}
