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
/// This page is used to book tickets after payment
/// </summary>

public partial class Payment : System.Web.UI.Page
{
    DataAccessLayer.Tickets_DAL payTicket;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsLogin"] == "false")
        {
            Response.Redirect("Login.aspx");
        }
        payTicket = new Tickets_DAL();
    }
  
   /// <summary>
   /// This method is used to book tickets based on credit card number
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    
    protected void btnPayOnline_Click(object sender, EventArgs e)
    {
        int retVal,PNRNumber;
        string status;
        Ticket ticketInfo = (Ticket)Session["BookTicket"];
        string userID = Session["UserID"].ToString();
        InsertSeatDetails[] SeatDetails=(InsertSeatDetails[])Session["SeatDetails"];
        //Calling method for payment and booking tickets       
        retVal = payTicket.PayForTickets(txtCreditCardNumber.Text, ticketInfo, userID, SeatDetails, out PNRNumber,out status);
       
        //Check the status of Booking    
       
        if (retVal == 1 || retVal == 2)
        {
           ticketInfo.PnrNumber = PNRNumber.ToString();
           ticketInfo.TicketStatus = status;
           Response.Redirect("BookingStatus.aspx");
        }
        else if (retVal == -1)
        {
          
             Response.Write("<script>alert('Train not available')</script>");
        }
        else if(retVal==-2)
        {
           
            Response.Write("<script>alert('Booking failed')</script>");
        }
        //clearing textbox
        txtCreditCardNumber.Text = "";

        Session["BookTicket"] = ticketInfo;
    }
}