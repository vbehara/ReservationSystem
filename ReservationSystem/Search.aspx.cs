using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
 
    protected void Page_Load(object sender, EventArgs e)
    {
        // user can not directly open this page
        if (Session["IsLogin"] == "false")
        {
            Response.Redirect("Login.aspx");
        }
       
    }

    /// <summary>
    /// to make TrainID panel visible and and sourcedestination panel invisible
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rbTrainID_CheckedChanged(object sender, EventArgs e)
    {
        panelTrainID.Visible = true;
        panelSourceDestination.Visible = false;
    }

    /// <summary>
    /// to make sourcedestination panel visible and TrainID panel invisible
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rbSourceDestination_CheckedChanged(object sender, EventArgs e)
    {
        panelSourceDestination.Visible = true;
        panelTrainID.Visible = false;
    }

    /// <summary>
    /// on >> button click make calender visible
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCalendar_Click(object sender, EventArgs e)
    {
        calDateOfJourney.Visible = true;
    }

    /// <summary>
    /// assigning selected date from calender to textbox
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void calDateOfJourney_SelectionChanged(object sender, EventArgs e)
    {
        txtDateOfJourney.Text = calDateOfJourney.SelectedDate.ToShortDateString();
        calDateOfJourney.Visible = false;
    }


    protected void calDateOfJourney_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        calDateOfJourney.Visible = true;
    }

    /// <summary>
    /// On click of this button redirect to Train details page, use of querystring to store TrainID
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>y stringf
    protected void btnGetTrainByID_Click(object sender, EventArgs e)
    {
       //use of query string
        Response.Redirect("TrainDetailsByID.aspx?ID="+txtTrainID.Text);
    }


    protected void station_from_to(object source, ServerValidateEventArgs args)
    {
        if (ddlFromStation.SelectedItem.Text == ddlToStation.SelectedItem.Text)
            args.IsValid = true;
        else
            args.IsValid = false;
    }

    /// <summary>
    /// On click of this button page should redirect to TrainDetails Page, but this page is not available in solution. For this case , custom error handling is implemented, page 
    /// will redirect to PageNotFound.htm page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFindTrains_Click(object sender, EventArgs e)
    {
       Response.Redirect("TrainDetails.aspx?From="+ddlFromStation.SelectedValue+"&To="+ddlToStation.SelectedValue+"&DOJ="+calDateOfJourney.SelectedDate);
    }
}
