using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

public partial class Register : System.Web.UI.Page
{
    User_DAL dal;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["IsLogin"] == "false")
        //{
        //    Response.Redirect("Login.aspx");
        //}

        dal = new User_DAL();
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        int status;
        char gender='M';// default gender
        if (rbMale.Checked)
        {
            gender = 'M';
        }
        else if (rbFeMale.Checked)
        {
            gender='F';
        }
       
         status=   dal.AddUser(txtUserID.Text, txtUserName.Text, gender, Convert.ToInt32(txtAge.Text), txtPassword.Text, 2);
         if (status == 1)
         {
             Response.Write("Registered Successfully");
             Response.Redirect("Search.aspx");
         }
         else
         {
             Response.Write("Some error occured");
         }
    }
}