<%@ Page Title="Railway Reservation System - PNR Status" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CheckPNRStatus.aspx.cs" Inherits="CheckPNRStatus" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">

        .style3
        {
        }
        .style2
        {
            width: 272px;
        }
        #btnReset
        {
            width: 87px;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
<h3>Check PNR Status</h3>
<hr />
    <table style="width:100%;">
        <tr>
            <td class="style3">
                PNR Number<sup style="color:Red">*</sup></td>
            <td class="style2">
                <asp:TextBox ID="txtPNRNumber" runat="server" Width="217px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvPNRNumber" runat="server" 
                    ControlToValidate="txtPNRNumber" ErrorMessage="PNR Number is a required field" 
                    ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                <asp:Button ID="btnCheckStatus" runat="server" Text="Check Status" 
                    Width="96px" onclick="btnCheckStatus_Click" />
                    &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancelTicket" runat="server" Text="Cancel Ticket" 
                    Width="96px" onclick="btnCancelTicket_Click" />

            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblStatus" runat="server" Text="Your Current PNR Status"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="lblPNRStatus" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" colspan="3">
                <br />
                <asp:GridView ID="gvPNRStatus" runat="server" 
                    EmptyDataText="No Record Found">
                </asp:GridView>
                <asp:ObjectDataSource ID="odsPNRStatus" runat="server" 
                    SelectMethod="FetchPNRStatus" 
                    TypeName="DataAccessLayer.Tickets_DAL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtPNRNumber" DefaultValue="0" 
                            Name="PNRNumnber" PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

