using Airport_Ticket_Booking.CsvOperations;
using Airport_Ticket_Booking.Modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.ErrorMessage
{
    internal class Message
    {
        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine($"========================{message}=========================");
            Console.ResetColor();
        }
        public static void SucsessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine($"========================{message}=========================");
            Console.ResetColor();
        }
    }
}
