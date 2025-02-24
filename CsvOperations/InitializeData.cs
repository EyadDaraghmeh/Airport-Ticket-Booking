using Airport_Ticket_Booking.EnumClass;
using Airport_Ticket_Booking.Modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Airport_Ticket_Booking.EnumClass.FlightClass;

namespace Airport_Ticket_Booking.CsvOperations
{
    internal class InitializeData
    {
        public static void InitializeFligtsData()
        {

            List<Flight> flights = new List<Flight>
                                                      {
                                                      new Flight("FL001", new Dictionary<_FlightClass, int> {
                                                            { _FlightClass.ECONOMY, 200 },
                                                            { _FlightClass.BUSINESS, 500 },
                                                            { _FlightClass.FIRSTCLASS, 1000 }
                                                        },
                                                        "USA", "UK", new DateTime(2025, 3, 15, 10, 30, 0), "JFK", "LHR"),

                                                        new Flight("FL002", new Dictionary<_FlightClass, int> {
                                                            { _FlightClass.ECONOMY, 150 },
                                                            { _FlightClass.BUSINESS, 400 },
                                                            { _FlightClass.FIRSTCLASS, 900 }
                                                        }, "Germany", "France", new DateTime(2025, 4, 10, 14, 0, 0), "FRA", "CDG"),

                                                        new Flight("FL003", new Dictionary<_FlightClass, int> {
                                                            { _FlightClass.ECONOMY, 250 },
                                                            { _FlightClass.BUSINESS, 550 },
                                                            { _FlightClass.FIRSTCLASS, 1200 }
                                                        }, "Japan", "Australia", new DateTime(2025, 5, 20, 8, 45, 0), "NRT", "SYD"),

                                                        new Flight("FL004", new Dictionary<_FlightClass, int> {
                                                            { _FlightClass.ECONOMY, 180 },
                                                            { _FlightClass.BUSINESS, 450 },
                                                            { _FlightClass.FIRSTCLASS, 950 }
                                                        }, "Canada", "Mexico", new DateTime(2025, 6, 5, 12, 15, 0), "YYZ", "MEX"),

                                                        new Flight("FL005", new Dictionary<_FlightClass, int> {
                                                            { _FlightClass.ECONOMY, 300 },
                                                            { _FlightClass.BUSINESS, 700 },
                                                            { _FlightClass.FIRSTCLASS, 1500 }
                                                        }, "UAE", "India", new DateTime(2025, 7, 18, 16, 30, 0), "DXB", "DEL")
                                                    };

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "flights.csv");
            if(!File.Exists(filePath)){
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                   
                    foreach (var f in flights)
                    {
                        writer.WriteLine($"{f._flightNo},{f.price[_FlightClass.ECONOMY]},{f.price[_FlightClass.BUSINESS]},{f.price[_FlightClass.FIRSTCLASS]},{f.departureCountry}," +
                            $"{f.destinationCountry},{f.departureDate.Date},{f.departureAirport},{f.arrivalAirport}");
                    }
                }

               
            }
        }

        public static void CreateBookingTable()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Booking.csv");
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }
            }

        }
        public static void CreatePassenegrTable()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "passenger.csv");
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }
            }

        }
    }
}
