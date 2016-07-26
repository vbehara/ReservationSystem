using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using RailwayReservation;
using RailwayDataAccessLayer;

/// <summary>
/// This page is used to add passenger details
/// </summary>
public partial class BookTickets : System.Web.UI.Page
{
   Passenger passenger;
   Tickets_DAL ticketDAL;
   static InsertSeatDetails []SeatDetails=new InsertSeatDetails[10];
   static int passangerCount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsLogin"] == "false")
        {
            Response.Redirect("Login.aspx");
        }
        //creating object for Ticket data access layer
        ticketDAL = new Tickets_DAL();
        
    }
    /// <summary>
    /// This method is used to add Passenger in a Passenger list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddPassenger_Click(object sender, EventArgs e)
    {
        //Fetching passenger information from controls and storing them in a passenger object
        passenger = new Passenger();
        passenger.PassengerName = txtName.Text;
        passenger.PassengerAge =Convert.ToInt32(txtAge.Text);
        if (rbMale.Checked)
        {
            passenger.Gender = 'M';
        }
        else
        {
            passenger.Gender='F';
        }

        // adding seat details of a passenger
        SeatDetails[passangerCount] = new InsertSeatDetails();
        SeatDetails[passangerCount].PassengerName = passenger.PassengerName;
        SeatDetails[passangerCount].Age = passenger.PassengerAge;
        SeatDetails[passangerCount].Gender = passenger.Gender;
        
        //adding passenger name in a list
        listPassengers.Items.Add(passenger.PassengerName);
        
        // clearing textboxes
        txtAge.Text = "";
        txtName.Text = "";

        // increasing passenger count
        passangerCount++;
    }

    /// <summary>
    ///validation for passenger count that it can not be zero
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void cvNumberOfPassengers_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (listPassengers.Items.Count == 0)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false; 
        }
    }

    /// <summary>
    /// This method is used to confirm passenger information for ticket booking and to redirect to Payment page 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnConfirmBooking_Click(object sender, EventArgs e)
    {
        //Fetch BookTicket object from session variable       
        Ticket ticketInfo = (RailwayReservation.Ticket)Session["BookTicket"];
        //getting the count of number of tickets to be booked
        ticketInfo.NumberOfSeats = listPassengers.Items.Count;
        //Fetching FarePerPerson
        decimal fareperperson=Convert.ToDecimal(Session["FarePerPerson"]);
        //Calculating total fare
        ticketInfo.TotalFare =(double)(ticketInfo.NumberOfSeats * fareperperson);
        
        // saving back Ticket information and seat details of passengers in session variables
        Session["BookTicket"] = ticketInfo;
        Session["SeatDetails"] = SeatDetails;

        //Redirect to Payment Page
        Response.Redirect("Payment.aspx");
        
    }
}