using System;

namespace RailwayReservation
{
    [Serializable]
    public class Passenger
    {
        private string passengerName;
        private int passengerAge;
        private string pnrNumber;
        private string seatNumber;
        private char gender;

        public string PassengerName
        {
            get { return passengerName; }
            set { passengerName = value; }
        }

        public int PassengerAge
        {
            get { return passengerAge; }
            set { passengerAge = value; }
        }

        public string PnrNumber
        {
            get { return pnrNumber; }
            set { pnrNumber = value; }
        }

        public string SeatNumber
        {
            get { return seatNumber; }
            set { seatNumber = value; }
        }
        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }
    }
}
