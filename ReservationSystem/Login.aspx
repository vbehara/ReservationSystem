<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 272px;
        }
        #Reset1
        {
            width: 84px;
        }
        #btnReset
        {
            width: 87px;
        }
        .style3
        {
            width: 151px;
        }
    .style4
    {
        width: 151px;
        height: 24px;
    }
    .style5
    {
        width: 272px;
        height: 24px;
    }
    .style6
    {
        height: 24px;
    }
    </style>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function btnReset_onclick() {
        
        }

// ]]>
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>Login</h3>
<hr />
    <table style="width:100%;">
        <tr>
            <td class="style3">
                UserID<sup style="color:Red">*</sup></td>
            <td class="style2">
                <asp:TextBox ID="txtUserID" runat="server" Width="217px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
                    ControlToValidate="txtUserID" ErrorMessage="User Name is a required field" 
                    ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Password<sup style="color:Red">*</sup></td>
            <td class="style2">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="217px" 
                    style="margin-left: 0px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                    ControlToValidate="txtPassword" ErrorMessage="Password is a required field" 
                    ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                </td>
            <td class="style5">
                <asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember me" 
                    oncheckedchanged="chkRememberMe_CheckedChanged" />
            </td>
            <td class="style6">
                </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                <asp:Button ID="btnLogin" runat="server" Text="Login" Width="96px" 
                    onclick="btnLogin_Click" />
                &nbsp;&nbsp;&nbsp;
                <input id="btnReset" type="reset" value="Reset" onclick="return btnReset_onclick()" /></td>

            <td>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" colspan="3">
                New user <a href="Register.aspx">Click here</a> to sign up</td>
        </tr>
    </table>

</asp:Content>

