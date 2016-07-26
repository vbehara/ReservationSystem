<%@ Page Title="Railway Reservation System - Book Tickets" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BookTickets.aspx.cs" Inherits="BookTickets" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            width: 173px;
        }
        .style3
        {
        }
        .style4
        {
            width: 299px;
        }
        .style5
        {
            width: 173px;
            height: 27px;
        }
        .style6
        {
            width: 299px;
            height: 27px;
        }
        .style7
        {
            height: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
<h3>Book Tickets</h3>
<hr />
    <table style="width:100%;">
        <tr>
            <td class="style1" colspan="4">
                Enter Passenger Details</td>
        </tr>
        <tr>
            <td class="style2">
                Name</td>
            <td class="style4">
                <asp:TextBox ID="txtName" runat="server" ValidationGroup="Passenger" 
                    Width="179px"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="Name is a required field" 
                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="Passenger">*</asp:RequiredFieldValidator>
            </td>
            <td rowspan="4">
            <h3>Passengers List</h3>
                <asp:ListBox ID="listPassengers" runat="server" Height="88px" Width="171px">
                </asp:ListBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Age</td>
            <td class="style4">
                <asp:TextBox ID="txtAge" runat="server" ValidationGroup="Passenger" 
                    Width="179px"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:RequiredFieldValidator ID="rfvAge" runat="server" 
                    ControlToValidate="txtAge" ErrorMessage="Age is a required field" 
                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="Passenger">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvAge" runat="server" ControlToValidate="txtAge" 
                    ErrorMessage="Improper Age" ForeColor="Red" MaximumValue="100" MinimumValue="1" 
                    ValidationGroup="Passenger" Type="Integer">*</asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Gender</td>
            <td class="style4">
                <asp:RadioButton ID="rbMale" runat="server" GroupName="Sex" Text="Male" 
                    ValidationGroup="Passenger" />
                <asp:RadioButton ID="rbFeMale" runat="server" GroupName="Sex" Text="FeMale" 
                    ValidationGroup="Passenger" />
            </td>
            <td class="style3">
                <asp:CustomValidator ID="cvGender" runat="server" 
                    ErrorMessage="Please specify your Gender" ForeColor="Red" 
                    SetFocusOnError="True" ValidationGroup="Passenger">*</asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                <asp:Button ID="btnAddPassenger" runat="server" Text="Add Passenger" 
                    ValidationGroup="Passenger" Width="129px" 
                    onclick="btnAddPassenger_Click" />
            </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                </td>
            <td class="style6">
                <asp:ValidationSummary ID="validationSummaryPassenger" runat="server" 
                    ForeColor="Red" ValidationGroup="Passenger" />
            </td>
            <td class="style7">
                <asp:CustomValidator ID="cvNumberOfPassengers" runat="server" 
                    ErrorMessage="Number of Passengers should be at least one." 
                    ValidationGroup="Card" ForeColor="Red" ControlToValidate="listPassengers" 
                    onservervalidate="cvNumberOfPassengers_ServerValidate">*</asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                <asp:ValidationSummary ID="confirmValidationSummary" runat="server" 
                    ForeColor="Red" ValidationGroup="Card" />
            </td>
            <td>
            </td>
            <td class="style3">
                <asp:Button ID="btnConfirmBooking" runat="server" Text="Confirm Booking" 
                    ValidationGroup="Card" Width="143px" CausesValidation="False" 
                    onclick="btnConfirmBooking_Click" />
            </td>
        </tr>
    </table>
    <br />
    
    <br />

</asp:Content>

