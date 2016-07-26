<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">

        .style2
        {
            width: 347px;
        }
        #btnReset
        {
            width: 87px;
        }
        .style3
        {
            width: 178px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>New Registration</h3>
<hr />
    <table style="width:100%;">
        <tr>
            <td class="style3">
                User ID</td>
            <td class="style2">
                <asp:TextBox ID="txtUserID" runat="server" Width="218px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtUserID" ErrorMessage="User id is required" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                User Name<sup style="color:Red">*</sup></td>
            <td class="style2">
                <asp:TextBox ID="txtUserName" runat="server" Width="217px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
                    ControlToValidate="txtUserName" ErrorMessage="User Name is  required field" 
                    ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
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
                    ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvPassword" runat="server" 
                    ControlToCompare="txtPassword" ControlToValidate="txtReTypePassword" 
                    ErrorMessage="Passwords dint match" ForeColor="Red" SetFocusOnError="True">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Re-type Password<sup style="color:Red">*</sup></td>
            <td class="style2">
                <asp:TextBox ID="txtReTypePassword" runat="server" TextMode="Password" 
                    Width="217px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvReTypePassword" runat="server" 
                    ControlToValidate="txtReTypePassword" ErrorMessage="Re-type Password is a required field" 
                    ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Age<sup style="color:Red">*</sup></td>
            <td class="style2">
                <asp:TextBox ID="txtAge" runat="server" Width="217px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvAge" runat="server" 
                    ControlToValidate="txtAge" ErrorMessage="Age is a required field" 
                    ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvAge" runat="server" ControlToValidate="txtAge" 
                    ErrorMessage="Age should be above 18 years" ForeColor="Red" MaximumValue="120" 
                    MinimumValue="18" SetFocusOnError="True" Type="Integer">*</asp:RangeValidator>
                <asp:RegularExpressionValidator ID="revAge" runat="server" 
                    ControlToValidate="txtAge" ErrorMessage="Age should contain only digits" 
                    ForeColor="Red" SetFocusOnError="True" ValidationExpression="\d+">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Gender<sup style="color:Red">*</sup></td>
            <td class="style2">
                <asp:RadioButton ID="rbMale" runat="server" GroupName="Sex" Text="Male" />
                <asp:RadioButton ID="rbFeMale" runat="server" GroupName="Sex" Text="FeMale" />
            </td>
            <td>
                <asp:CustomValidator ID="cvGender" runat="server" 
                    ErrorMessage="Please choose your gender" ForeColor="Red" SetFocusOnError="True">*</asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                <asp:Button ID="btnRegister" runat="server" Text="Register" Width="96px" 
                    onclick="btnRegister_Click" />
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

