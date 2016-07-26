using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class BookingStatus : System.Web.UI.Page
{
    Ticket bookedTicket;
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sbPassengers = new StringBuilder();
        if (Session["IsLogin"] == "false")
        {
            Response.Redirect("Login.aspx");
        }
        bookedTicket = (Ticket)Session["BookTicket"];
        lblPNRNumber.Text = bookedTicket.PnrNumber;
        lblFromStation.Text = bookedTicket.FromStation;
        lblToStatus.Text = bookedTicket.ToStation;
        lblTicketStatus.Text = bookedTicket.TicketStatus;
        lblTotalFare.Text = bookedTicket.TotalFare.ToString();
        InsertSeatDetails[] SeatDetails = (InsertSeatDetails[])Session["SeatDetails"];
        foreach (InsertSeatDetails p in SeatDetails)
        {
            if (p!=null)
            {
                sbPassengers.Append(p.PassengerName);
                sbPassengers.Append(";");
            }
        }
        lblPassenger.Text =sbPassengers.ToString();
    }
}