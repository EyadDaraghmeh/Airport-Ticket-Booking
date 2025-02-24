using Airport_Ticket_Booking.CsvOperations;
using Airport_Ticket_Booking.EnumClass;
using Airport_Ticket_Booking.ErrorMessage;
using Airport_Ticket_Booking.Modle;
using Airport_Ticket_Booking.services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.View.PassengerView
{
    internal class Home
    {
        public static void _Home(Passenger p)
        {
            Console.WriteLine("===========================================================================================");
            Console.WriteLine();
            Console.WriteLine($"Hi "+p.Name);
            Console.WriteLine("1-Book a flight");
            Console.WriteLine("2-View your bookings");
            Console.WriteLine("3-LogOut");
            int ch = 0;
            try
            {
                ch = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            { 
                Message.ErrorMessage(ex.Message);
                _Home(p);
            }
            if(ch==1)
            {
               
                BookAflight._BookAflight(p);
                
            }
            else if(ch==2)
            {
               ViewBooking._ViewBooking(p);
                

            }
            else if(ch==3)
            {
                Welcome._Welcome();
            }
            else
            {           
                Message.ErrorMessage("Valid Option");
                _Home(p);
            }
        }


        

        
    }
}
