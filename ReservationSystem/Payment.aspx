<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
<table style="width:100%;">
        <tr>
            <td class="style7">
                Credit Card Number</td>
            <td class="style6">
                <asp:TextBox ID="txtCreditCardNumber" runat="server" ValidationGroup="Card" 
                    Width="179px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvCreditCardNumber" runat="server" 
                    ControlToValidate="txtCreditCardNumber" ErrorMessage="Credit Card Number is a required field" 
                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="Card">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style6">
                <asp:Button ID="btnPayOnline" runat="server" Text="Pay Online" 
                    ValidationGroup="Card" Width="129px" onclick="btnPayOnline_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style6">
                <asp:ValidationSummary ID="validationSummaryCard" runat="server" 
                    ForeColor="Red" ValidationGroup="Card" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

