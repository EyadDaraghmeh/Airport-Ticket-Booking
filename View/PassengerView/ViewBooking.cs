using Airport_Ticket_Booking.EnumClass;
using Airport_Ticket_Booking.ErrorMessage;
using Airport_Ticket_Booking.Modle;
using Airport_Ticket_Booking.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.View.PassengerView
{
    internal class ViewBooking
    {
        public static void _ViewBooking(Passenger p)
        {
            PassengerServices.ViewYourBooking(p);
            Console.WriteLine("====1-Cancel the booking");
            Console.WriteLine("====2-Modify the booking");
            int op = 0;
            try {
                op = int.Parse(Console.ReadLine());
            }
            catch (Exception ex) {
                Message.ErrorMessage(ex.Message);
                _ViewBooking(p);
            }
            if (op == 1)
            {
                Console.WriteLine("Enter the name of the flight you want to cancel :");
                string flightNo = Console.ReadLine().ToUpper();
                PassengerServices.CancleBooking(flightNo, p);
            }
            else if (op == 2)
            {
                Console.WriteLine("Enter the name of the flight you want to modify  :");
                string flightNo = Console.ReadLine().ToUpper().Trim();
                Console.WriteLine("Enter new booking type (ECONOMY, BUSINESS, FIRSTCLASS)");
                string fligthClass = Console.ReadLine().ToUpper().Trim();
                if(!Enum.IsDefined(typeof(FlightClass._FlightClass),fligthClass))
                {
                    Message.ErrorMessage("Enter valid flight class,Try again");
                    _ViewBooking(p);

                }
                else
                PassengerServices.Modify(flightNo, p,fligthClass);

            }
            else
            {
                Message.ErrorMessage("Valid Option");
                _ViewBooking(p);

            }

            Home._Home(p);
        }
    }
}
