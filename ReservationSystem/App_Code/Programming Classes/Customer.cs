using System;
using System.Collections;

namespace RailwayReservation
{
    /// <summary>
    /// This class inherits User class and implements ICustomer interface
    /// used to implement the functionalities of Customer
    /// </summary>
    public class Customer : User, ICustomer
    {
        /// <summary>
        /// Instance of paymnetGateway class
        /// </summary>
        PaymentGateway gatewayRef = new PaymentGateway();

        /// <summary>
        ///  To register the user
        /// </summary>
        public bool Register()
        {
            Customer newCustomer = new Customer();
            newCustomer.CustomerID = CustomerID;
            newCustomer.Password = Password;
            newCustomer.CustomerName = CustomerName;
            newCustomer.Age = Age;
            newCustomer.Gender = Gender;
            RailwayData.userDetails.Add(CustomerID, newCustomer);
            userCount++;
            return true;
        }
        /// <summary>
        ///  MoneyTransaction delegate instance
        /// </summary>
        MoneyTransaction transactionDele;

        /// <summary>
        /// For booking the tickets - abstract method defined in derived class
        /// </summary>
        /// <param name="customerID">ID of the customer</param>
        /// <param name="trainID">TrainID of the train</param>
        /// <param name="serviceType">service type selected by user</param>
        /// <param name="noOfSeats">noofseats to be booked</param>
        /// <param name="ticketStatus">ticket status of booking ticket</param>
        public override void BookTicket(int customerID, int trainID, string serviceType, int noOfSeats, out string ticketStatus)
        {
            //delegate instance pointing to purchaseTicket method
            transactionDele += new MoneyTransaction(gatewayRef.PurchaseTickets);
            ticketStatus = "WaitingList";
            int index = 0;
            Ticket bookTicket = new Ticket();
            foreach (Seats item in RailwayData.seats)
            {
                index = RailwayData.seats.IndexOf(item);
                Seats searchSeat = (Seats)item;
                if (searchSeat.TrainID == trainID && searchSeat.ServiceType == serviceType)
                {
                    RailwayData.seats.Remove(searchSeat);
                    searchSeat.NumberOfSeats = searchSeat.NumberOfSeats - noOfSeats;
                    RailwayData.seats.Insert(index, searchSeat);
                    bookTicket.CustomerID = customerID;
                    bookTicket.DateOfBooking = DateTime.Now.Date.ToString();
                    Console.Write("\nEnter the date of journey :");
                    bookTicket.DateOfJourney = Console.ReadLine();
                    bookTicket.FromStation = ((TrainSchedule)RailwayData.trainSchedule[trainID]).FromStation;
                    bookTicket.ToStation = ((TrainSchedule)RailwayData.trainSchedule[trainID]).ToStation;
                    bookTicket.TotalFare = searchSeat.FarePerPerson * noOfSeats;
                    bookTicket.TrainID = trainID;
                    bookTicket.ServiceType = serviceType;
                    bookTicket.NumberOfSeats = noOfSeats;
                    bookTicket.PnrNumber = rn.Next(1000, 2000).ToString();
              
                    if (searchSeat.NumberOfSeats > noOfSeats)
                    {
                        ticketStatus = "Booked";
                    }
                    else
                    {
                        ticketStatus = "Waiting";
                    }
                    bookTicket.TicketStatus = ticketStatus;
               
                    bookTicket.Passengers = new ArrayList();
                    for (int count = 0; count < noOfSeats; count++)
                    {
                        Console.WriteLine("\nEnter the passenger details \n");
                        Passenger passenger = AddPassengerDetails(bookTicket.PnrNumber, count);
                        bookTicket.Passengers.Add(passenger);
                    }
                    Console.WriteLine("\nEnter the payment Details\n");
                    Console.Write("Enter the credit Card Number:");
                    bookTicket.CreditCardNumber = long.Parse(Console.ReadLine());

                    //Invoking purchaseTicket method through delegate
                    transactionDele(bookTicket.CreditCardNumber, bookTicket.TotalFare);

                    RailwayData.ticketDetails.Add(bookTicket.PnrNumber, bookTicket);
                    serializerRef.Serialize("myTicket.xml", bookTicket);
                    Console.WriteLine("PNR Number  : " + bookTicket.PnrNumber);
                    break;
                }
            }
        }

        /// <summary>
        /// To cancel the tickets
        /// </summary>
        /// <param name="customerID">ID of the user</param>
        /// <param name="pnrNumber">pnrnumber if the passenger</param>
        public override void CancelTickets(int customerID, string pnrNumber)
        {
            ((Ticket)RailwayData.ticketDetails[pnrNumber]).TicketStatus = "Cancelled";
            int index = 0;
            Ticket cancelTicket = (Ticket)RailwayData.ticketDetails[pnrNumber];
            //delegate instance pointing to purchaseTicket method
            transactionDele += new MoneyTransaction(gatewayRef.CancelTickets);
            foreach (Seats item in RailwayData.seats)
            {
                index = RailwayData.seats.IndexOf(item);
                Seats searchSeat = (Seats)item;
                if (searchSeat.TrainID == cancelTicket.TrainID && searchSeat.ServiceType == cancelTicket.ServiceType)
                {
                    RailwayData.seats.Remove(searchSeat);
                    searchSeat.NumberOfSeats = searchSeat.NumberOfSeats + cancelTicket.NumberOfSeats;
                    RailwayData.seats.Insert(index, searchSeat);
                }
            }
            transactionDele(cancelTicket.CreditCardNumber, cancelTicket.TotalFare);
        }
    }
}
