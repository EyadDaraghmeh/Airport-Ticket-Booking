using Airport_Ticket_Booking.CsvOperations;
using Airport_Ticket_Booking.ErrorMessage;
using Airport_Ticket_Booking.Modle;
using Airport_Ticket_Booking.View;
using Airport_Ticket_Booking.View.ManagerView;
using Airport_Ticket_Booking.View.PassengerView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.AuthServices
{
    internal class Authontaction
    {
        public static void SignUp(string name, string email, string password)
        {


            string id = Guid.NewGuid().ToString();
            Passenger passenger = new Passenger(id, name, email, password);
            if(PassengerOperation.CheackExists(passenger))
            {
               
                Message.ErrorMessage("========================This email already exists.=================================");
                Welcome._Welcome();
            }
            else
            {
                
                PassengerOperation.CreatePassengerAccount(passenger);
                
                Message.SucsessMessage("========================Account created successfully. Now log in.=========================");
                Welcome._Welcome();


            }
        }

        public static void LogIn(string email,string password)
        {
            if (email == "manager@gmail.com"&&password=="1234")
            {
                View.ManagerView.Home._Home();
            }
            else
            {
                List<Passenger> passengers = PassengerOperation.LoadPassenger();
                var p = (from pas in passengers select pas).FirstOrDefault(p => (p.Email == email) && (p.Password == password));
                if (p == null)
                {

                    Message.ErrorMessage("==========================You have entered incorrect data. Try again.============================");
                    Welcome._Welcome();
                }
                else
                {

                    View.PassengerView.Home._Home(p);
                }
            }
        }
    }
}
