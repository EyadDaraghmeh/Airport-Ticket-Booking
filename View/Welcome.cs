using Airport_Ticket_Booking.AuthServices;
using Airport_Ticket_Booking.ErrorMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.View
{
    internal class Welcome
    {
        public static void _Welcome()
        {
            Console.WriteLine("==============================Welcome To Airport Ticket Booking System===============================");
            Console.WriteLine("1-LogIn");
            Console.WriteLine("2-SignUp");
            int ch = 0;

            try
            {
                ch = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Message.ErrorMessage(ex.Message);
                _Welcome();
            }
            if (ch == 1)
            {
                Console.WriteLine("Enter Your Email :");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Your Password :");
                string password= Console.ReadLine();
                Authontaction.LogIn(email, password);
             
            }
            else if(ch == 2)
            {
                Console.WriteLine("Enter Your Name :");
                string name=Console.ReadLine();
                Console.WriteLine("Enter Your Email :");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Your Password :");
                string password = Console.ReadLine();
                Authontaction.SignUp(name,email ,password);

            }
            else
            {

                Message.ErrorMessage("===================Invalid Option===========================");
                _Welcome();
            }

        }
    }
}
