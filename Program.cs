using Airport_Ticket_Booking.AuthServices;
using Airport_Ticket_Booking.CsvOperations;
using Airport_Ticket_Booking.EnumClass;
using Airport_Ticket_Booking.Modle;
using Airport_Ticket_Booking.services;
using Airport_Ticket_Booking.Services;
using Airport_Ticket_Booking.View;
using static Airport_Ticket_Booking.EnumClass.FlightClass;

namespace Airport_Ticket_Booking
{
    internal class Program
    {
        static void Main(string[] args)
        {
           InitializeData.InitializeFligtsData();
           InitializeData.CreateBookingTable();
            InitializeData.CreatePassenegrTable();
           

            Welcome._Welcome();

            
       

            
            








        }
    }
}
