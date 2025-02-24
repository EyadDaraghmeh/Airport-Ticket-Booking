using Airport_Ticket_Booking.Modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.CsvOperations
{
    internal class PassengerOperation
    {
        public static void CreatePassengerAccount(Passenger passenger)
        {
            string  filePath= Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "passenger.csv");
            string newLine =$"{passenger.Id},{passenger.Name},{passenger.Email},{passenger.Password}";
            File.AppendAllText(filePath, newLine+Environment.NewLine);
        }

        public static bool CheackExists(Passenger passenger)
        {
            List<Passenger> passengers = LoadPassenger();

            return passengers.Any(pas => pas.Email == passenger.Email);
           
        }

       

        public static List<Passenger> LoadPassenger()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "passenger.csv");

            List<Passenger> passengers = new List<Passenger>();
            string line;
            using(StreamReader reader = new StreamReader(filePath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var coulmns= line.Split(',');
                    var p = new Passenger(coulmns[0], coulmns[1], coulmns[2], coulmns[3]);
                    passengers.Add(p);
                }

            }
            return passengers;


        }

        
    }
}
