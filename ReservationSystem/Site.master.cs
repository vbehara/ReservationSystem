﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangePassword.aspx");
    }
    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        if (Session["IsLogin"] == "true")
        {
            Response.Redirect("Login.aspx");
        }
    }
}
