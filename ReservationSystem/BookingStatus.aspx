<%@ Page Title="Railway Reservation System - Booking Status" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BookingStatus.aspx.cs" Inherits="BookingStatus" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
        }
        .style3
        {
            width: 117px;
        }
        #Button1
        {
            width: 117px;
        }
        #btnPrint
        {
            width: 93px;
        }
        .style4
        {
            font-weight: bold;
        }
    </style>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function btnPrint_onclick() {

        }

// ]]>
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>Booking Status</h3>
<hr />
    <table style="width:100%;">
        <tr>
            <td class="style1">
                <strong>PNR Number</strong></td>
            <td class="style2">
                <asp:Label ID="lblPNRNumber" runat="server">PNR2000</asp:Label>
            </td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <strong>From Station</strong></td>
            <td class="style2">
                <asp:Label ID="lblFromStation" runat="server">Mysore</asp:Label>
            </td>
            <td class="style3">
                <strong>To Station</strong></td>
            <td>
                <asp:Label ID="lblToStatus" runat="server">Bangalore</asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <strong>Ticket Status</strong></td>
            <td class="style2">
                <asp:Label ID="lblTicketStatus" runat="server">Confirmed</asp:Label>
            </td>
            <td class="style3">
                <strong>Total Fare</strong></td>
            <td>
                <asp:Label ID="lblTotalFare" runat="server">120 Rs.</asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Passenger</td>
            <td class="style2" colspan="3">
                <asp:Label ID="lblPassenger" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <input id="btnPrint" type="button" value="Print Ticket" onclick="return btnPrint_onclick()" /></td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

