using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// This page is used to CheckPNR status and cancel booked ticket
/// </summary>
public partial class CheckPNRStatus : System.Web.UI.Page
{
    Tickets_DAL ticketDAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsLogin"] == "false")
        {
            Response.Redirect("Login.aspx"); 
        }
        ticketDAL = new Tickets_DAL();
    }

    /// <summary>
    /// This method will bind PNRStatus gridview with ObjectDataSource
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCheckStatus_Click(object sender, EventArgs e)
    {
        gvPNRStatus.DataSource = odsPNRStatus;
        gvPNRStatus.DataBind();
    }

    /// <summary>
    /// This method is used to cancle already booked ticket
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelTicket_Click(object sender, EventArgs e)
    {
       
        decimal refund;
        int ret;
        ret = ticketDAL.CancelTicket(Convert.ToInt32(txtPNRNumber.Text), out refund);

        //Check status
        if (ret == 0)
        {
            Response.Write("<script>alert('Ticket Cancelled, Refund amount is '"+refund+")</script>");
        }
        else if(ret==-2)
        {
            Response.Write("<script>alert('Date of journey is passed')</scrript>");
        }
        else if (ret == -1)
        {
            Response.Write("<script>alert('PNR number is not valid')</scrript>");
        }
        else if (ret == -3)
        {
            Response.Write("<script>alert('Cancellation failed')</scrript>");
        }
    }
}