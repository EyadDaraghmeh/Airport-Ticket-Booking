using Airport_Ticket_Booking.ErrorMessage;
using Airport_Ticket_Booking.Modle;
using Airport_Ticket_Booking.View.ManagerView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Airport_Ticket_Booking.EnumClass.FlightClass;

namespace Airport_Ticket_Booking.CsvOperations
{
    internal class FlightOperation
    {
        public static void CreateFlights(Flight flight)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "flights.csv");
            string newLine = $"{flight._flightNo},{flight.price[_FlightClass.ECONOMY]},{flight.price[_FlightClass.BUSINESS]}," +
                $"{flight.price[_FlightClass.FIRSTCLASS]},{flight.departureCountry},{flight.destinationCountry}," +
                $"{flight.departureDate.ToString("yyyy-MM-dd")},{flight.departureAirport},{flight.arrivalAirport}";
            try
            {
                File.AppendAllText(filePath, newLine + Environment.NewLine);
            }
            catch(Exception e) {
                Message.ErrorMessage(newLine + " "+ e.Message);
                Home._Home();
            }
        }

        public static void CreateFlights(List<Flight> flights)
        {
            foreach(var flight in flights)
            {
                CreateFlights(flight);
            }
            Message.SucsessMessage("Flights added successfully");
            Home._Home();
        }
        public static List<Flight> LoadFligths()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "flights.csv");
            List<Flight> flights = new List<Flight>();
            string line;
            using(StreamReader reader = new StreamReader(filePath))
            {
                while ((line=reader.ReadLine())!=null)
                {
                    var coulmns=line.Split(',');
                    var f=new Flight(coulmns[0], new Dictionary<_FlightClass, int> {
                                                            { _FlightClass.ECONOMY,int.Parse( coulmns[1]) },
                                                            { _FlightClass.BUSINESS,int.Parse( coulmns[2]) },
                                                            { _FlightClass.FIRSTCLASS,int.Parse( coulmns[3]) }
                                                        }, coulmns[4], coulmns[5], DateTime.Parse( coulmns[6]), coulmns[7], coulmns[8]  );
                    flights.Add( f );
                }
            }

            return flights;
        }
        public static List<Flight> LoadFligths(string filePath)
        {
           // string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "flights.csv");
            List<Flight> flights = new List<Flight>();
            string line;
            try {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        var coulmns = line.Split(',');
                        var f = new Flight(coulmns[0], new Dictionary<_FlightClass, int> {
                                                            { _FlightClass.ECONOMY,int.Parse( coulmns[1]) },
                                                            { _FlightClass.BUSINESS,int.Parse( coulmns[2]) },
                                                            { _FlightClass.FIRSTCLASS,int.Parse( coulmns[3]) }
                                                        }, coulmns[4], coulmns[5], DateTime.Parse(coulmns[6]), coulmns[7], coulmns[8]);

                        if (Flight.IsValid(f))
                        {
                            flights.Add(f);

                        }
                    }
                }
            }
            catch(Exception e)
            {
                Message.ErrorMessage(e.Message);
                Home._Home();
            }
           

            return flights;
        }
    }

}
