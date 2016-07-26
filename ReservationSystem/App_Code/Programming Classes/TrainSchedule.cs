
namespace RailwayReservation
{
    /// <summary>
    /// 
    /// </summary>
    public class TrainSchedule
    {
        /// <summary>
        /// Variable to store toStation
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
        /// Variable to store fromStation
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
        /// variable to store weekday
        /// </summary>
        private string weekDay;

        /// <summary>
        /// WeekDay property
        /// </summary>
        public string WeekDay
        {
            get { return weekDay; }
            set { weekDay = value; }
        }

        public TrainSchedule(string fromStation, string toStation, string weekDay)
        {
            this.fromStation = fromStation;
            this.toStation = toStation;
            this.weekDay = weekDay;
        }
    }
}
