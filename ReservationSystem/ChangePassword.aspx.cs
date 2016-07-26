using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
public partial class ChangePassword : System.Web.UI.Page
{
    User_DAL userDAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsLogin"] == "false")
        {
            Response.Redirect("Login.aspx");
        }
       
        userDAL = new User_DAL();
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        int status=0;
        status = userDAL.UpdatePassword(Session["UserID"].ToString(), txtOldPassword.Text, txtNewPassword.Text);
if (status == 1)
{
    System.Web.HttpContext.Current.Response.Write("<script>alert('Password changed suceessfully')</script>");
   
}
else
{
    System.Web.HttpContext.Current.Response.Write("<script>alert('Some error occurred')</script>");
}
    }
}