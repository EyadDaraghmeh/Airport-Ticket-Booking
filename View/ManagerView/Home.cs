using Airport_Ticket_Booking.ErrorMessage;
using Airport_Ticket_Booking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.View.ManagerView
{
    internal class Home
    {
        public static void _Home()
        {
            Console.WriteLine("===================================================");
            Console.WriteLine();
            Console.WriteLine("1-View all bookings");
            Console.WriteLine("2-filter the bookings");
            Console.WriteLine("3-Load a flights from csv");
            Console.WriteLine("4-LogOut");
            int ch = 0;
            try {
                ch = int.Parse(Console.ReadLine());
            }catch(Exception ex) {
                Message.ErrorMessage(ex.Message);
                _Home(); 
            }

            if(ch == 1)
            { 
                ManagerServices.ViewAllBookings();
            }
            else if(ch == 2) 
            {
                FilterBooking._FilterBooking();
            }
            else if(ch==3)
            {
                Console.Write("Enter the file path :");
                string filePath=Console.ReadLine().Trim();
                ManagerServices.LoadFlightsFromCsv(filePath);
            }
            else if(ch==4)
            {
                Welcome._Welcome();
            }
            else
            {
                Message.ErrorMessage("Valid Option");
                _Home();
            }
        }
    }
}
