<%@ Page Title="Railway Reservation System - Booking History" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BookingHistory.aspx.cs" Inherits="BookingHistory" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>Booking History</h3>
<hr />
    <table class="style1">
        <tr>
            <td>
                Select Status:
                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlStatus_SelectedIndexChanged">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Waiting</asp:ListItem>
                    <asp:ListItem>Cancelled</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
    <asp:GridView ID="gvBookingHistory" runat="server" 
    AutoGenerateColumns="False" AllowPaging="True" 
    onpageindexchanged="gvBookingHistory_PageIndexChanged"
    onpageindexchanging="gvBookingHistory_PageIndexChanging" PageSize="3" 
                    EmptyDataText="No Records Found">
        <Columns>
            <asp:BoundField DataField="TrainId" HeaderText="Train ID" />
            <asp:BoundField DataField="PNRNumber" HeaderText="PNR Number" />
            <asp:BoundField DataField="FromStation" HeaderText="From" />
            <asp:BoundField DataField="ToStation" HeaderText="To" />
            <asp:BoundField DataField="DateofBooking" HeaderText="Date of Booking" />
            <asp:BoundField DataField="DateofCancellation" 
                HeaderText="Date of Cancellation" NullDisplayText="NA" />
            <asp:BoundField DataField="DateofJourney" HeaderText="Date of Journey" />
            <asp:BoundField DataField="NumberofSeats" HeaderText="Number Of Seats" />
            <asp:BoundField DataField="TotalFare" HeaderText="Total Fare" />
            <asp:CommandField ButtonType="Button" SelectText="Print" 
                ShowSelectButton="True" />
        </Columns>
        <HeaderStyle HorizontalAlign="Left" />
    </asp:GridView>
            </td>
        </tr>
    </table>
<br />
</asp:Content>

