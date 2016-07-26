using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.Diagnostics;
public partial class Login : System.Web.UI.Page
{
    User_DAL dal;
    protected void Page_Load(object sender, EventArgs e)
    {
        // creating object of User_DAL class
        dal = new User_DAL();
        // control will go inside if block when postback happens for the 1st time 
        if (!IsPostBack)
        {
            if (Request.Cookies["UserID"] != null)
            {
                txtUserID.Text = Request.Cookies["UserID"].Value;
                chkRememberMe.Checked = true;
            }
        }

    }
    /// <summary>
    /// On login button click validation user
    ///// </summary>
    ///// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        
        int count=0;
        //calling validate user method
        count = dal.ValidateUser(txtUserID.Text, txtPassword.Text);
       if (count == 1)
       {
           // use of session variables
           Session["IsLogin"] = "true";
           Session["UserID"] = txtUserID.Text;
           Response.Redirect("Search.aspx");
       }
       else
       {
           Session["IsLogin"] = "false";
           lblMessage.Text = "Invalid Id or Password";
       }
    }
    /// <summary>
    /// Adding userId and password in cookie when Remember Me checkbox is checked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkRememberMe_CheckedChanged(object sender, EventArgs e)
    {
        if (chkRememberMe.Checked)
        {
            //assigning values to cookie
            Response.Cookies["UserID"].Value = txtUserID.Text;
        }
        else
        {
            Response.Cookies["UserID"].Expires = DateTime.Now.AddMonths(-1);
            
        }
    }
}