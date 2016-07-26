using System.Collections;
using System.Xml.Serialization;

namespace RailwayReservation
{
    /// <summary>
    /// This class is used to initialize the Railway data
    /// </summary>
    public class RailwayData
    {
        /// <summary>
        /// Trains collection to store Train information like TrainNo, TrainName, trainType,servicedays
        /// </summary>
        public  static SortedList trains = new SortedList();

        /// <summary>
        /// trainschedule collection to store trainschdle information like fromstation, tostation and weekday
        /// </summary>
        public static SortedList trainSchedule = new SortedList();

        /// <summary>
        /// Seats arratlist collection to store Seats  information like trainNo, serviceType,noOfSeats and farePerPerson
        /// </summary>
        public static ArrayList seats = new ArrayList();

         static RailwayData()
        { 
            trains.Add(101, new Train(101, "Bangalore Express", "Express", "Monday"));
            trains.Add(201, new Train(201, "Highway express", "Express", "Tuesday"));
            trains.Add(301, new Train(301, "Rajdhani", "Passenger", "Sunday"));
            trains.Add(401, new Train(401, "City Express", "Expree", "Thursday"));
            trains.Add(501, new Train(501, "Krishna", "Passenger", "Friday"));

            trainSchedule.Add(101, new TrainSchedule("Bangalore", "Chennai", "Monday"));
            trainSchedule.Add(201, new TrainSchedule("Chennai"   ,"Bangalore", "Tuesday"));
            trainSchedule.Add(301, new TrainSchedule("Delhi", "Bangalore", "Sunday"));
            trainSchedule.Add(401, new TrainSchedule("Bangalore", "Hyderabad", "Thursday"));
            trainSchedule.Add(501, new TrainSchedule("Mysore", "Bangalore", "Friday"));

            seats.Add(new Seats(101, "AC", 20, 50));
            seats.Add(new Seats(101, "FC", 20, 40));
            seats.Add(new Seats(101, "SC", 14, 35));
            seats.Add(new Seats(201, "AC", 19, 50));
            seats.Add(new Seats(201, "FC", 16, 40));
            seats.Add(new Seats(201, "SC", 13, 35));
            seats.Add(new Seats(301, "AC", 28, 50));
            seats.Add(new Seats(301, "FC", 22, 40));
            seats.Add(new Seats(301, "SC", 19, 35));
            seats.Add(new Seats(401, "AC", 20, 50));
            seats.Add(new Seats(401, "FC", 23, 40));
            seats.Add(new Seats(401, "SC", 15, 35));
            seats.Add(new Seats(501, "AC", 30, 50));
            seats.Add(new Seats(501, "FC", 17, 40));
            seats.Add(new Seats(501, "SC", 20, 35));

            clerkDetails.Add(156);
            clerkDetails.Add("pwd");
            clerkDetails.Add("Ram");
            clerkDetails.Add("M");
            clerkDetails.Add(34);
            clerkDetails.Add("Clerk");
         }

        /// <summary>
        ///  Static array to store to store userDetails like username,pwd,age
        /// </summary>
        public static SortedList userDetails = new SortedList  ();
        
        /// <summary>
        /// Clerk information like clerkID,password,name, gender, age and usertype
        /// </summary>
        public static ArrayList clerkDetails = new ArrayList();
        
        /// <summary>
        ///  Storing ticket details in collection
        /// </summary>
        [XmlElement(Type=typeof(Ticket))]
        public static SortedList ticketDetails = new SortedList();

    }
}