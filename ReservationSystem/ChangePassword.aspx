<%@ Page Title="Railway Reservation System - Change Password" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">

        .style2
        {
            width: 305px;
        }
        #btnReset
        {
            width: 87px;
        }
        .style3
        {
            width: 168px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
<h3>Change Password</h3>
<hr />
    <table style="width:100%;">
        <tr>
            <td class="style3">
                Old Password<sup style="color:Red">*</sup></td>
            <td class="style2">
                <asp:TextBox ID="txtOldPassword" runat="server" Width="217px" 
                    TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" 
                    ControlToValidate="txtOldPassword" ErrorMessage="Old Password is a required field" 
                    ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                New Password<sup style="color:Red">*</sup></td>
            <td class="style2">
                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" 
                    Width="217px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" 
                    ControlToValidate="txtNewPassword" ErrorMessage="New Password is a required field" 
                    ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvNewPassword" runat="server" 
                    ControlToCompare="txtNewPassword" ControlToValidate="txtReTypeNewPassword" 
                    ErrorMessage="New Passwords dint match" ForeColor="Red" SetFocusOnError="True">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Re-type New Password<sup style="color:Red">*</sup></td>
            <td class="style2">
                <asp:TextBox ID="txtReTypeNewPassword" runat="server" TextMode="Password" 
                    Width="217px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvNewReTypePassword" runat="server" 
                    ControlToValidate="txtReTypeNewPassword" ErrorMessage="Re-Type New Password is a required field" 
                    ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" 
                    Width="124px" onclick="btnChangePassword_Click" />
                &nbsp;&nbsp;&nbsp;
                <input id="btnReset" type="reset" value="Reset" /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                <asp:ValidationSummary ID="validationSummary" runat="server" ForeColor="Red" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

