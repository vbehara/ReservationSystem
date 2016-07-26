using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RailwayDataAccessLayer
{
    public class InsertSeatDetails
    {
        private int PNRNum;

        public int PNRNumber
        {
            get { return PNRNum; }
            set { PNRNum = value; }
        }
        private string PName;

        public string PassengerName
        {
            get { return PName; }
            set { PName = value; }
        }
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private char gender;

        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }
    }
}
