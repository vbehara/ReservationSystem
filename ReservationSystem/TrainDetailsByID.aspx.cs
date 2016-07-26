using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using DataAccessLayer;
using RailwayReservation;
/// <summary>
/// This page displays train details,seat availability and fareper person 
/// </summary>
public partial class TrainDetailsByID : System.Web.UI.Page
{
   Train_DAL dalTrain;
   TrainFareDetails_DAL dalClass;
   Ticket bookTicket ;
    protected void Page_Load(object sender, EventArgs e)
    {
        //user can not open this page directly
        if (Session["IsLogin"].ToString() == "false")
        {
            Response.Redirect("Login.aspx");
        }
        
        // creating objects for data access layer classes
        dalTrain = new Train_DAL();
        dalClass = new TrainFareDetails_DAL();
        bookTicket = new Ticket();
       
        //Compare validation for date
        cvDOJ.ValueToCompare = DateTime.Now.ToShortDateString();
        
        //Fetching value of TrainID from QueryString
        bookTicket.TrainID = Convert.ToInt32(Request.QueryString["ID"]);
        // Displaying TrainDetails 
        DataTable dtTrainSchedule = null;
        // calling method to get train details based on train ID
        DataRow drTrainSchedule = dalTrain.GetTrainSchedule(bookTicket.TrainID);
        if (!IsPostBack)
        {
            if (drTrainSchedule != null)
            {
                dtTrainSchedule = drTrainSchedule.Table;
                //Availabilty of train based on days
                if (Convert.ToBoolean(dtTrainSchedule.Rows[0]["Sunday"]))
                {
                    cbSun.Checked = true;
                }
                if (Convert.ToBoolean(dtTrainSchedule.Rows[0]["Monday"]))
                {
                   cbMon.Checked = true;
                }
                if (Convert.ToBoolean(dtTrainSchedule.Rows[0]["Tuesday"]))
                {
                    cbTues.Checked = true;
                }
                if (Convert.ToBoolean(dtTrainSchedule.Rows[0]["Wednesday"]))
                {
                    cbWed.Checked = true;
                }
                if (Convert.ToBoolean(dtTrainSchedule.Rows[0]["Thursday"]))
                {
                    cbThurs.Checked = true;
                }
                if (Convert.ToBoolean(dtTrainSchedule.Rows[0]["Friday"]))
                {
                    cbFri.Checked = true;
                }
                if (Convert.ToBoolean(dtTrainSchedule.Rows[0]["Saturday"]))
                {
                    cbSat.Checked = true;
                }
               // assigning train details into textboxes using simple data binding
                txtTrainName.Text = dtTrainSchedule.Rows[0]["TrainName"].ToString();
                txtFromStation.Text = dtTrainSchedule.Rows[0]["FromStation"].ToString();
                txtToStation.Text = dtTrainSchedule.Rows[0]["ToStation"].ToString();
                txtFrmDepTime.Text = dtTrainSchedule.Rows[0]["FromDepartureTime"].ToString();
                txtToArrTime.Text = dtTrainSchedule.Rows[0]["ToArrivalTime"].ToString();
                txtDay.Text = dtTrainSchedule.Rows[0]["Day"].ToString();
               //binds all the controls on the page to its data source
                Page.DataBind();
          
            }
        }

    }
   
    /// <summary>
    /// making calender visible
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCal_Click(object sender, EventArgs e)
    {
        calDateOfJourney.Visible=true;
    }

    /// <summary>
    /// assigning selected date from calender control to textbox
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void calDateOfJourney_SelectionChanged(object sender, EventArgs e)
    {
        txtDateOfJourney.Text = calDateOfJourney.SelectedDate.ToShortDateString();
        calDateOfJourney.Visible = false;
    }


    /// <summary>
    ///  This method will show available seats, fare perperson in gridview based on trainID,classID, source ,destination and dateofjourney
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnChkAvailability_Click(object sender, EventArgs e)
    {
        // storing train details in bookticket object of Ticket class
        
        //Fetching classId, from station ,toStatiob and dateofjourney
        bookTicket.ClassId = Convert.ToInt32(ddlClassofatrain.SelectedValue);
        bookTicket.FromStation = txtFromStation.Text;
        bookTicket.ToStation = txtToStation.Text;
        bookTicket.DateOfJourney = txtDateOfJourney.Text;
       
        //Poulating classDetails gridview
        DataTable dtClassDetail = null;
        DataRow drClassDetail = dalTrain.GetClassDetails(bookTicket.TrainID, bookTicket.ClassId, Convert.ToDateTime(bookTicket.DateOfJourney), bookTicket.FromStation, bookTicket.ToStation);
        if (drClassDetail != null)
        {
            dtClassDetail = drClassDetail.Table;
            gvClassDetails.DataSource = dtClassDetail;
            gvClassDetails.DataBind();
        }

        //Storing ticket object in a session variable
        Session["BookTicket"] = bookTicket;
        
    }

    /// <summary>
    /// On clicking Book button, in classDetails gridview, store the FarePerPerson in session variable and redirect to BookTicket Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClassDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["FarePerPerson"] = gvClassDetails.SelectedRow.Cells[3].Text;
        Response.Redirect("BookTickets.aspx");
    }
    protected void cbMonday_CheckedChanged(object sender, EventArgs e)
    {

    }
}