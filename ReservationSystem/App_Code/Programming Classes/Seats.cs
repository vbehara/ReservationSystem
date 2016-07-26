
namespace RailwayReservation
{
    /// <summary>
    /// This class maintains information of Seats booked 
    /// </summary>
    public class Seats
    {

        public Seats()
        { }
        public Seats(int trainID, string serviceType, int noOfSeats, int farePerPerson)
        {
            TrainID = trainID;
            ServiceType = serviceType;
            NumberOfSeats = noOfSeats;
            FarePerPerson = farePerPerson;
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
        /// Variable to store fare per Person
        /// </summary>
        private double farePerPerson;

        /// <summary>
        /// FarePerPerson property
        /// </summary>
        public double FarePerPerson
        {
            get { return farePerPerson; }
            set { farePerPerson = value; }
        }
    }
}
