using System;
using System.Collections;

namespace RailwayReservation
{
    /// <summary>
    /// This class inherits User class and implements User class
    /// used to implement the functionalities of Clerk
    /// </summary>
    class BookingClerk : User
    {

        /// <summary>
        /// Readonly property password to retrieve 
        /// </summary>
        public new string Password
        {
            get { return RailwayData.clerkDetails[1].ToString(); }
        }

        /// <summary>
        /// Readonly property ClerkID to retrieve 
        /// </summary>
        public int ClerkID
        {
            get { return (int)RailwayData.clerkDetails[0]; }
        }

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
                    bookTicket.TicketID = rn.Next(100, 1000);
                    bookTicket.CustomerID = customerID;
                    bookTicket.DateOfBooking = DateTime.Now.Date.ToString("dd-mmm-yyyy");
                    Console.Write("\nEnter the dateof journey :");
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

                    RailwayData.ticketDetails.Add(bookTicket.PnrNumber, bookTicket);
                    Console.WriteLine("PNR Number :" + bookTicket.PnrNumber);
                    serializerRef.Serialize("myTicket.xml", bookTicket);
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
        }
    }
}
