
namespace RailwayReservation
{

    /// This class inherits User class and implements IAdministrator interface
    /// used to implement the functionalities of Administrator
    class Administrator : User, IAdmin
    {
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
            foreach (object item in RailwayData.seats)
            {
                Seats searchSeat = (Seats)item;
                if (searchSeat.TrainID == trainID && searchSeat.ServiceType == serviceType)
                {
                    if (searchSeat.NumberOfSeats < noOfSeats)
                    {
                        RailwayData.seats.Remove(searchSeat);
                        ticketStatus = "Booked";
                        searchSeat.NumberOfSeats = searchSeat.NumberOfSeats - noOfSeats;
                        RailwayData.seats.Add(searchSeat);
                        break;
                    }
                    else
                    {
                        RailwayData.seats.Remove(searchSeat);
                        ticketStatus = "WaitingList";
                        searchSeat.NumberOfSeats = searchSeat.NumberOfSeats - noOfSeats;
                        RailwayData.seats.Add(searchSeat);
                    }
                }
            }
        }

        /// <summary>
        /// To cancel the tickets - Abstract method defined in derived class
        /// </summary>
        /// <param name="customerID">ID of the user</param>
        /// <param name="pnrNumber">pnrnumber if the passenger</param>
        public override void CancelTickets(int customerID, string pnrNumber)
        {
            //Implementation goes here
        }

        /// <summary>
        /// To add a booking clerks
        /// </summary>
        public void AddBookingClerk()
        {
            //Implementation goes here
        }

        /// <summary>
        /// To add a train details
        /// </summary>
        public void AddTrainDetails()
        {
            //Implementation goes here

        }
    }
}
