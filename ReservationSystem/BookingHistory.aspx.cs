using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccessLayer;


/// <summary>
/// This page is used to see booking history
/// </summary>
public partial class BookingHistory : System.Web.UI.Page
{
    Tickets_DAL bookedTickets;
    DataTable dtBookingHistory;
    string status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsLogin"] == "false")
        {
            Response.Redirect("Login.aspx");
        }
        bookedTickets = new Tickets_DAL();
        dtBookingHistory = new DataTable();

    }
    protected void gvBookingHistory_PageIndexChanged(object sender, EventArgs e)
    {
        //    if (Cache["BookingHistory"] == null)
        //    {
        //        dtBookingHistory = bookedTickets.getBookingHistory(Session["userID"].ToString());
        //        Cache["BookingHistory"] = dtBookingHistory;
        //    }
        //    else
        //    {
        //        dtBookingHistory = (DataTable)Cache["BookingHistory"];
        //    }
        //    gvBookingHistory.DataSource = dtBookingHistory;
        //    gvBookingHistory.DataBind();
    }

    /// <summary>
    /// Implemeting paging in gridview and data caching
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBookingHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        //changing page index
        gvBookingHistory.PageIndex = e.NewPageIndex;
        //If Cache object is null
        if (Cache["BookingHistory"] == null)
        {
            dtBookingHistory = bookedTickets.getBookingHistory(Session["userID"].ToString(),Session["status"].ToString());
            Cache["BookingHistory"] = dtBookingHistory;
        }
        else
        {
            //If Cache objecting is not null, retrieve values from it
            dtBookingHistory = (DataTable)Cache["BookingHistory"];
        }

        //Binding gridview with datasource
        gvBookingHistory.DataSource = dtBookingHistory;
        gvBookingHistory.DataBind();
    }

    /// <summary>
    /// Display booking history in gridview based on selected values from dropdownlist
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["status"] = ddlStatus.SelectedItem.Text;
        dtBookingHistory = bookedTickets.getBookingHistory(Session["userID"].ToString(),Session["status"].ToString());
        gvBookingHistory.DataSource = dtBookingHistory;
        gvBookingHistory.DataBind();
    }
}