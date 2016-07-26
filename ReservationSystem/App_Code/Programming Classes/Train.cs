
namespace RailwayReservation
{
    /// <summary>
    /// The class exposes attributes and methods for Train
    /// </summary>
    public class Train
    {
        /// <summary>
        /// Variable to store serviceDays
        /// </summary>
        private string serviceDays;

        /// <summary>
        /// ServiceDays property
        /// </summary>
        public string ServiceDays
        {
            get { return serviceDays; }
            set { serviceDays = value; }
        }

        /// <summary>
        /// Variable to store train type
        /// </summary>
        private string trainType;

        /// <summary>
        /// TrainType property
        /// </summary>
        public string TrainType
        {
            get { return trainType; }
            set { trainType = value; }
        }

        /// <summary>
        /// Variable to store train name
        /// </summary>
        private string trainName;

        /// <summary>
        /// TrainName project
        /// </summary>
        public string TrainName
        {
            get { return trainName; }
            set { trainName = value; }
        }

        /// <summary>
        /// Variable to store the trainID
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
        /// Default constructor of the train
        /// </summary>
        public Train()
        { }

        /// <summary>
        /// Parameterised constructor to intialize trainID, TrainType and, serviceDays
        /// </summary>
        /// <param name="trainID">Trainid of the train</param>
        /// <param name="trainName">name of the train</param>
        /// <param name="trainType">traintype of the train</param>
        /// <param name="serviceDays">service days of the train</param>
        public Train(int trainID, string trainName, string trainType, string serviceDays)
        {
            TrainID = trainID;
            TrainName = trainName;
            TrainType = trainType;
            ServiceDays = serviceDays;
        }

        /// <summary>
        /// to check for avaliable seats based on service type
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns>returns avaliable seats based on service type</returns>
        public Seats GetAvailableSeats(string serviceType)
        {
            Seats seatsInfo = new Seats();
            foreach (object item in RailwayData.seats)
            {
		        Seats seat=(Seats)item;
                if(TrainID==seat.TrainID & serviceType==seat.ServiceType)
                {
                     seatsInfo=seat;
                    break;
                }
            }
            return seatsInfo;
        }
    }

}
