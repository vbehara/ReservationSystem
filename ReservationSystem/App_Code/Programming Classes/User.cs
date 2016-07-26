using System;

namespace RailwayReservation
{
    /// <summary>
    ///This class maintains user information and implements IUser interfcae
    /// </summary>
  public abstract class User:IUser
    {
        /// <summary>
        /// usercount variable to keep track of user registration
        /// </summary>
        public static int userCount = 0;

        /// <summary>
        /// Variable to store the Role
        /// </summary>
        private string role;

        /// <summary>
        /// This method is used for changing the user's password 
        /// </summary>
        public string Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
            }
        }

        public Random rn = new Random();

        /// <summary>
        /// Variable to store the CustomerID 
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
        /// Variable to store the CustomerName 
        /// </summary>
        private string customerName;

        /// <summary>
        /// CustomerName property
        /// </summary>
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        /// <summary>
        /// Variable to store the Age 
        /// </summary>
        private int age;

        /// <summary>
        /// Age property
        /// </summary>
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        /// <summary>
        /// Variable to store the Gender 
        /// </summary>
        private char gender;

        /// <summary>
        /// Gender property
        /// </summary>
        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        /// <summary>
        /// Variable to store the password
        /// </summary>
        private string password;

        /// <summary>
        /// Password property
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

     /// <summary>
     ///  ReservationSerializer reference
     /// </summary>
     public ReservationSerializer serializerRef;

      /// <summary>
      /// User constructor
      /// </summary>
        public User()
        {
            serializerRef = new ReservationSerializer();
        }

        /// <summary>
        /// Login Method to check user's username and password
        /// </summary>
        ///  <param name="userName">username of the user</param>
        /// <param name="password">password for the user</param>
        /// <param name="status">Status of user login. If username and password entered are correct then it will be set to true else false</param>
        public void Login(int userName, string password, out bool status)
        {
            status = false;

            if (userName == (int)RailwayData.clerkDetails[0]  && password == RailwayData.clerkDetails[1].ToString())
            {
                status = true;
                Role = "Clerk";
            }
            else
            {
                foreach (object cust in RailwayData.userDetails.Values)
                {
                    Customer loginCustomerData = (Customer)cust;
                    if (userName == loginCustomerData.CustomerID && password == loginCustomerData.Password)
                    {
                        status = true;
                        Role = "Customer";
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// To changepassword
        /// </summary>
        /// <param name="userid">userid of the user</param>
      /// <param name="password">password of the user</param>
      /// <param name="role"></param>
        /// <returns>returns passsword change status  as string</returns>
        public string ChangePassword(int userId, string password, string role)
        {
            string passwordChangeMsg = "Changed";
            if (role == "Clerk")
            {
                if (Convert.ToInt32(RailwayData.clerkDetails[0]) == userId && password == RailwayData.clerkDetails[1].ToString())
                {
                    Console.Write("\nEnter a newpassword:");
                    RailwayData.clerkDetails[1] = Console.ReadLine();
                    passwordChangeMsg = "Password changed successfully";
                }
                else
                {
                    passwordChangeMsg = "Entered password is not maching to current password";
                }
            }
            else if (role == "Customer")
            {
                foreach (object cust in RailwayData.userDetails.Values)
                {
                    Customer loginCustomerData = (Customer)cust;
                    if (userId == loginCustomerData.CustomerID && password == loginCustomerData.Password)
                    {
                        Console.Write("\nEnter a newpassword:");
                        ((Customer)cust).Password = Console.ReadLine(); ;
                        passwordChangeMsg = "Password changed successfully";
                        break;
                    }
                    else
                    {
                        passwordChangeMsg = "Entered password is not maching to current password";
                    }
                }
            }
            return passwordChangeMsg;
        }

        /* overloading of methods - static polymorphism*/
        /// <summary>
        /// FindTrain method which takes fromlocation,tolocation and date , then return Train object
        /// </summary>
        /// <param name="fromLocation">From station paramater</param>
        /// <param name="toLocation">Tostaion parameter</param>
        /// <param name="day">day parameter on which day train to be search </param>
        /// <returns>Train object</returns>
        public Train FindTrain(string fromLocation, string toLocation, DateTime day)
        {
            Train searchTrain = new Train();
             foreach (object schedule in RailwayData.trainSchedule.Keys)
            {
                   TrainSchedule trainSchedule =(TrainSchedule)  RailwayData.trainSchedule[schedule];
                if (trainSchedule.FromStation == fromLocation && trainSchedule.ToStation == toLocation && trainSchedule.WeekDay == day.DayOfWeek.ToString())
                {
                    searchTrain = (Train)RailwayData.trains[schedule];
                    break;
                }
            }
             if (searchTrain.TrainID == 0)
             {
                 TrainNotFoundException notFound = new TrainNotFoundException("The train you are searching is not found");
                 throw notFound;
             }
           return searchTrain;
        }

        /// <summary>
        /// FindTrain method which takes trainID, then return Train object
        /// </summary>
        /// <param name="trainID">TrainID of the train to be searched</param>
        /// <returns>Train object</returns>
        public Train FindTrain(int trainID)
        {
            Train searchTrain = new Train();
            foreach (object item in RailwayData.trains.Keys)
            {
                if (Convert.ToInt32(item) == trainID)
                {
                    searchTrain = (Train)RailwayData.trains[item];
                    break;
                }
            }
            if (searchTrain.TrainID == 0)
            {
                TrainNotFoundException notFound = new TrainNotFoundException("The train you are searching is not found");
                throw notFound;
            }
            return searchTrain;
        }

        /// <summary>
        /// For booking the tickets - abstract method defined in derived class
        /// </summary>
        /// <param name="customerID">ID of the customer</param>
        /// <param name="trainID">TrainID of the train</param>
        /// <param name="serviceType">service type selected by user</param>
        /// <param name="noOfSeats">noofseats to be booked</param>
        /// <param name="ticketStatus">ticket status of booking ticket</param>
        public abstract void BookTicket(int customerID, int trainID, string serviceType, int noOfSeats, out string ticketStatus);
    
      /// <summary>
        /// For cancellation of tickets - abstract method defined in derived class
        /// </summary>
        public abstract void CancelTickets(int customerID, string pnrNumber);

      /// <summary>
        /// method to check the pnrNumber status 
        /// </summary>
        /// <param name="pnrNumber">pnrNumber is unique for a passenger booking the ticket</param>
        public void CheckPNRStatus(string pnrNumber)
        {
            throw new NotImplementedException();
        }

      /// <summary>
      /// To add passengers to passenger list
      /// </summary>
      /// <param name="pnrNumber">pnr number for the ticket</param>
      /// <param name="count">no of passengers</param>
      /// <returns>Returns passenger object with data intialized</returns>
        public Passenger AddPassengerDetails(string pnrNumber, int count)
        {
            Passenger newPassenger = new Passenger();
            Console.Write("Enter the passenger Name :");
            newPassenger.PassengerName = Console.ReadLine();
            Console.Write("Enter the passenger Age :");
            newPassenger.PassengerAge = int.Parse(Console.ReadLine());
            newPassenger.SeatNumber = count.ToString();
            Console.Write("Enter the Gender as F for Female and M for Male :");
            newPassenger.Gender = char.Parse(Console.ReadLine());
            newPassenger.PnrNumber = pnrNumber;

            return newPassenger;
        }  
    }
}
