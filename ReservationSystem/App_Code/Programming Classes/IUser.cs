using System;

namespace RailwayReservation
{
    /// <summary>
    /// Base interface IUser
    /// </summary>
    interface IUser
    {
        /// <summary>
        /// For booking the tickets - abstract method defined in derived class
        /// </summary>
        /// <param name="customerID">ID of the customer</param>
        /// <param name="trainID">TrainID of the train</param>
        /// <param name="serviceType">service type selected by user</param>
        /// <param name="noOfSeats">noofseats to be booked</param>
        /// <param name="ticketStatus">ticket status of booking ticket</param>
        void BookTicket(int customerID, int trainID, string serviceType, int noOfSeats, out string ticketStatus);

        /// <summary>
        /// To cancel the tickets
        /// </summary>
        /// <param name="customerID">ID of the user</param>
        /// <param name="pnrNumber">pnrnumber if the passenger</param>
        void CancelTickets(int customerID, string pnrNumber);

        /// <summary>
        /// To changepassword
        /// </summary>
        /// <param name="userId">userid of the user</param>
        /// <param name="password">password of the user</param>
        /// <param name="role"></param>
        /// <returns>returns passsword change status  as string</returns>
        string ChangePassword(int userId, string password, string role);


        /// <summary>
        /// Abstract method to checks the pnrNumber status 
        /// </summary>
        /// <param name="pnrNumber">pnrNumber is unique for a passenger booking the ticket</param>
        void CheckPNRStatus(string pnrNumber);

        /// <summary>
        /// Abstract method to find trains available
        /// </summary>
        /// <param name="fromStation">Source Station</param>
        /// <param name="toStation">Destination Station</param>
        /// <param name="day">Day on which the train is available</param>
        Train FindTrain(string fromLocation, string toLocation, DateTime day);

        /// <summary>
        /// Accepts TrainID and finds its availability
        /// </summary>
        /// <param name="trainID">TrainID is unique for every train</param>
        Train FindTrain(int trainID);

        /// <summary>
        /// Login Method to check user's username and password
        /// </summary>
        ///  <param name="userName">username of the user</param>
        /// <param name="password">password for the user</param>
        /// <param name="status">Status of user login. If username and password entered are correct then it will be set to true else false</param>
        void Login(int username, string password, out bool status);
    }
}
