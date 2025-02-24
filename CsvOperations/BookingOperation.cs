using Airport_Ticket_Booking.EnumClass;
using Airport_Ticket_Booking.Modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.CsvOperations
{
    internal class BookingOperation
    {
        public static List<Booking> LoadBooking()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Booking.csv");
            string line;
            List<Booking> bookings = new List<Booking>();
            using(StreamReader  reader = new StreamReader(filePath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var coulmns = line.Split(',');
                    var b = new Booking(coulmns[0], coulmns[1], coulmns[2], coulmns[3],int.Parse(coulmns[4]));
                    bookings.Add(b);
                }
            }
            return bookings;
        }

        public static bool CheckBooking(string passengerId,string fligtNo)
        {
            var booking=LoadBooking();
            return booking.Any(b=>b.PassengerId==passengerId&&b.FlightNo==fligtNo);
        }
        public static void SaveDataIntoBooking(Passenger passenger, Flight flight,string fligtClass)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Booking.csv");
            string Id=Guid.NewGuid().ToString();
            
            var f = Enum.Parse<FlightClass._FlightClass>(fligtClass.ToUpper());
            var price = flight.price[f];
            string newLine = $"{Id},{passenger.Id},{flight._flightNo},{fligtClass},{price}";
            File.AppendAllText(filePath, newLine + Environment.NewLine);
        }
    }
}
