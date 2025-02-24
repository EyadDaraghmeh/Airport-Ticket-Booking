using Airport_Ticket_Booking.CsvOperations;
using Airport_Ticket_Booking.EnumClass;
using Airport_Ticket_Booking.ErrorMessage;
using Airport_Ticket_Booking.Modle;
using Airport_Ticket_Booking.View.PassengerView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Airport_Ticket_Booking.EnumClass.FlightClass;

namespace Airport_Ticket_Booking.services
{
    internal class PassengerServices
    {
        
        public static void ViewAllFligts()
        {
            List<Flight> flights=FlightOperation.LoadFligths();

            Flight.Print(flights);

        }

        public static List<Flight> SearchFlights(Func<Flight, bool> criteria)
        {
            var fligts=FlightOperation.LoadFligths();
            return fligts.Where(criteria).ToList();
        }


        public static void BookAtrip(Passenger p, Flight f,string fligtClass)
        {
            if (BookingOperation.CheckBooking(p.Id, f._flightNo))
            {
                Message.ErrorMessage("You have already booked this flight.");
                Home._Home(p);

            }
            else
            {
                BookingOperation.SaveDataIntoBooking(p, f, fligtClass);
                Message.SucsessMessage("Booking has been completed successfully");
                Home._Home(p);

            }
        }

        public static void ViewYourBooking(Passenger p)
        {
            var allBooking=BookingOperation.LoadBooking();
            var flights = FlightOperation.LoadFligths();
            var booking = (from bo in allBooking
                           where p.Id == bo.PassengerId
                     select bo
                     );

            var fligtBooking = from fligt in flights
                               join book in booking
                               on fligt._flightNo equals book.FlightNo
                               select new {
                                   FlightNo=fligt._flightNo,
                                   departureCountry=fligt.departureCountry,
                                   destinationCountry=fligt.destinationCountry,
                                   departureDate=fligt.departureDate,
                                   departureAirport=fligt.departureAirport,
                                   arrivalAirport=fligt.arrivalAirport,
                                   price=book.price,
                                   fligtClass=book.fligtClass,

                               };
            if (booking.Count()==0)
            {
                Message.ErrorMessage("You have not booked any flight.");
                Home._Home(p);
            }
            else
            {
                foreach (var flight in fligtBooking)
                {
                    Console.WriteLine($"Flight Number => {flight.FlightNo}");
                    Console.WriteLine($"From {flight.departureCountry} to {flight.destinationCountry}, departing from {flight.departureAirport} Airport to {flight.arrivalAirport}" +
                        $" Airport, dated {flight.departureDate.ToString("yyyy-MM-dd")}, type {flight.fligtClass}, at a price of {flight.price}");
                    Console.WriteLine();
                }
            }
        }

        public static void Booking(Passenger passenger)
        {
            List<Flight> flights = FlightOperation.LoadFligths();
            Console.WriteLine("Enter the name of the flight :");
            string fligthNo = Console.ReadLine().ToUpper().Trim();
            var f = flights.FirstOrDefault(f => f._flightNo == fligthNo);
            if (f == null)
            {

                Message.ErrorMessage("Enter valid name,Try again");
                Booking(passenger);
            }
            else
            {
                Console.WriteLine("Enter the fligth class (ECONOMY, BUSINESS, IRSTCLASS)");
                string fligtClass = Console.ReadLine().ToUpper().Trim();
                if (!Enum.IsDefined(typeof(FlightClass._FlightClass), fligtClass))
                {
                    Message.ErrorMessage("Enter valid flight class,Try again");
                    Booking(passenger);
                }
                else
                {
                    BookAtrip(passenger, f, fligtClass);
                    


                }
            }

        }

        public static void Modify(string flightNo,Passenger p,string fligtClass)

        {
           
            var booking = BookingOperation.LoadBooking();
            var fligts = FlightOperation.LoadFligths();
            var flight = fligts.SingleOrDefault(f => f._flightNo == flightNo);


            var bookingToUpdate = booking.FirstOrDefault(b => b.FlightNo == flightNo && b.PassengerId == p.Id);
            if (bookingToUpdate == null)
            {
                Message.ErrorMessage("You do not have a reservation for this flight name.");
                ViewBooking._ViewBooking(p);
            }
            else
            {
                var f = Enum.Parse<FlightClass._FlightClass>(fligtClass.ToUpper());


                    bookingToUpdate.fligtClass = fligtClass;
                    bookingToUpdate.price = flight.price[f];
                



                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Booking.csv");
                var lines = booking.Select(b => $"{b.Id},{b.PassengerId},{b.FlightNo},{b.fligtClass},{b.price}");
                File.WriteAllLines(filePath, lines);
                Message.SucsessMessage("The flight type has been successfully modified.");
                Home._Home(p);
            }

        }


        public static void CancleBooking(string flightNo,Passenger p)
        {
            var booking = BookingOperation.LoadBooking();
            var updatedBookings = booking
                                 .Where(b => !(b.FlightNo == flightNo && p.Id == b.PassengerId)) 
                                 .ToList();
            if (booking.Count() == updatedBookings.Count())
            {
                Message.ErrorMessage("Enter valid flight number");
                ViewBooking._ViewBooking(p);
                
            }
            else
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Booking.csv");
                var lines = updatedBookings.Select(b => $"{b.Id},{b.PassengerId},{b.FlightNo},{b.fligtClass},{b.price}");
                File.WriteAllLines(filePath, lines);
                Message.SucsessMessage("The flight has been cancelled.");
                Home._Home(p);
            }

        }





    }
}
