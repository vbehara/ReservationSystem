using System;
using System.Collections;
using System.Xml.Serialization;

namespace RailwayReservation
{

    /// <summary>
    /// Class to maintain the ticket's details
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// Variable to store the pnrNumber
        /// </summary>
        private string pnrNumber;

        /// <summary>
        /// PnRNumber property
        /// </summary>
        
        public string PnrNumber
        {
            get { return pnrNumber; }
            set { pnrNumber = value; }
        }

        /// <summary>
        /// Variable to store the customerID
        /// </summary>
        private int customerID;

        /// <summary>
        /// CustomerID property
        /// </summary>
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        /// <summary>
        /// Variable to store the customerID
        /// </summary>
        private int ticketID;

        /// <summary>
        /// CustomerID property
        /// </summary>
        public int TicketID
        {
            get { return ticketID; }
            set { ticketID = value; }
        }

        /// <summary>
        /// Variable to store date of booking
        /// </summary>
        private string dateOfBooking;

        /// <summary>
        /// Date of booking property
        /// </summary>
        public string DateOfBooking
        {
            get { return dateOfBooking; }
            set { dateOfBooking = value; }
        }

        /// <summary>
        /// Variable to store date of ticket cancellation
        /// </summary>
        private string dateOfCancellation;

        /// <summary>
        /// DateOfCancellation property
        /// </summary>
        public string DateOfCancellation
        {
            get { return dateOfCancellation; }
            set { dateOfCancellation = value; }
        }

        /// <summary>
        /// Variable to store date of journey
        /// </summary>
        private string dateOfJourney;

        /// <summary>
        /// DateOfJourney property
        /// </summary>
        public string DateOfJourney
        {
            get { return dateOfJourney; }
            set { dateOfJourney = value; }
        }

        /// <summary>
        /// Variable to store trainID
        /// </summary>
        private int trainID;

        /// <summary>
        /// TrainID property
        /// </summary>
        public int TrainID
        {
            get { return trainID; }
            set { trainID = value; }
        }

        /// <summary>
        /// Variable to store service type
        /// </summary>
        private string serviceType;

        /// <summary>
        /// ServiceType property
        /// </summary>
        public string ServiceType
        {
            get { return serviceType; }
            set { serviceType = value; }
        }

        /// <summary>
        /// Variable to store number of seats booked
        /// </summary>
        private int numberOfSeats;

        /// <summary>
        /// NumberOfSeats property
        /// </summary>
        public int NumberOfSeats
        {
            get { return numberOfSeats; }
            set { numberOfSeats = value; }
        }

        /// <summary>
        /// Variable to store source station
        /// </summary>
        private string fromStation;

        /// <summary>
        /// FromStation property
        /// </summary>
        public string FromStation
        {
            get { return fromStation; }
            set { fromStation = value; }
        }

        /// <summary>
        /// Variable to store destination station
        /// </summary>
        private string toStation;

        /// <summary>
        /// ToStation property
        /// </summary>
        public string ToStation
        {
            get { return toStation; }
            set { toStation = value; }
        }

        /// <summary>
        /// Variable to store credit card number
        /// </summary>
        private long creditCardNumber;

        /// <summary>
        /// CreditCardNumber property
        /// </summary>
        public long CreditCardNumber
        {
            get { return creditCardNumber; }
            set { creditCardNumber = value; }
        }

        /// <summary>
        /// Variable to store ticket status
        /// </summary>
        private string ticketStatus;

        /// <summary>
        /// TicketStatus property
        /// </summary>
        
        public string TicketStatus
        {
            get { return ticketStatus; }
            set { ticketStatus = value; }
        }

        /// <summary>
        /// Variable to store total fare
        /// </summary>
        private double totalFare;

        /// <summary>
        /// TotalFare property
        /// </summary>
        public double TotalFare
        {
            get { return totalFare; }
            set { totalFare = value; }
        }
        private int classId;
        /// <summary>
        /// Variable for Class types
        /// </summary>
        public int ClassId
        {
            get { return classId; }
            set { classId = value; }
        }

        /// <summary>
        /// Variable to store the passengers
        /// </summary>
        [NonSerialized]
        private ArrayList passengers;

        /// <summary>
        /// Passengers property
        /// </summary>
         [XmlElement(Type=typeof(Passenger))]
        public ArrayList Passengers
        {
            get { return passengers; }
            set { passengers = value; }
        }
    }
}
