<%@ Page Title="Railway Reservation System - Train Details" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TrainDetailsByID.aspx.cs" Inherits="TrainDetailsByID" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            text-align: left;
            }
        .style4
        {
            width: 362px;
            height: 54px;
        }
        .style5
        {
            text-align: left;
            height: 21px;
        }
        .style7
        {
            text-align: left;
            height: 21px;
            }
        .style8
        {
            text-align: left;
        }
        .style9
        {
            text-align: left;
            height: 54px;
        }
        .style10
        {
            text-align: left;
            width: 353px;
        }
        .style11
        {
            text-align: left;
            height: 54px;
            width: 353px;
        }
        .style13
        {
            width: 206px;
            font-weight: bold;
            text-align: left;
        }
        .style14
        {
            width: 66px;
        }
        .style15
        {
            width: 85px;
        }
        .style16
        {
            width: 70px;
        }
        .style17
        {
            width: 72px;
        }
        .style18
        {
            width: 79px;
        }
        .style20
        {
            width: 206px;
        }
        .style21
        {
            width: 67px;
        }
        .style22
        {
            width: 67px;
            font-weight: bold;
            text-align: left;
        }
        .style23
        {
            width: 79px;
            font-weight: bold;
            text-align: left;
        }
        .style24
        {
            width: 72px;
            font-weight: bold;
            text-align: left;
        }
        .style25
        {
            width: 70px;
            font-weight: bold;
            text-align: left;
        }
        .style26
        {
            width: 85px;
            font-weight: bold;
            text-align: left;
        }
        .style27
        {
            width: 66px;
            font-weight: bold;
            text-align: left;
        }
        .style28
        {
            text-align: left;
            width: 353px;
            height: 26px;
        }
        .style29
        {
            text-align: left;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
<h3>TRAIN SCHEDULE</h3>
<hr />
&nbsp;&nbsp;<table class="style1">
        <tr>
            <td class="style3" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7" colspan="3">
                <table class="style1">
                    <tr>
                        <td class="style27">
                            Sun</td>
                        <td class="style26">
                            Mon</td>
                        <td class="style25">
                            Tues</td>
                        <td class="style24">
                            Wed</td>
                        <td class="style23">
                            Thurs</td>
                        <td class="style22">
                            Fri</td>
                        <td class="style13">
                            Sat</td>
                    </tr>
                    <tr>
                        <td class="style14">
                            <asp:CheckBox ID="cbSun" runat="server" Enabled="False" />
                        </td>
                        <td class="style15">
                            <asp:CheckBox ID="cbMon" runat="server" Enabled="False" 
                                oncheckedchanged="cbMonday_CheckedChanged" />
                        </td>
                        <td class="style16">
                            <asp:CheckBox ID="cbTues" runat="server" Enabled="False" />
                        </td>
                        <td class="style17">
                            <asp:CheckBox ID="cbWed" runat="server" Enabled="False" />
                        </td>
                        <td class="style18">
                            <asp:CheckBox ID="cbThurs" runat="server" Enabled="False" />
                        </td>
                        <td class="style21">
                            <asp:CheckBox ID="cbFri" runat="server" Enabled="False" />
                        </td>
                        <td class="style20">
                            <asp:CheckBox ID="cbSat" runat="server" Enabled="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style5" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                Train Name: </td>
            <td class="style3">
                <asp:TextBox ID="txtTrainName" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                From Station:</td>
            <td class="style3">
                <asp:TextBox ID="txtFromStation" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                To Station: </td>
            <td class="style3">
                <asp:TextBox ID="txtToStation" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                From Departure Time:</td>
            <td class="style3">
                <asp:TextBox ID="txtFrmDepTime" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style3">
                `</td>
        </tr>
        <tr>
            <td class="style28">
                To Arrival Time: </td>
            <td class="style29">
                <asp:TextBox ID="txtToArrTime" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style29">
                </td>
        </tr>
        <tr>
            <td class="style10">
                Days:</td>
            <td class="style3">
                <asp:TextBox ID="txtDay" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
    Date Of Journey :
    <asp:TextBox ID="txtDateOfJourney" runat="server" Height="19px" Width="101px" 
                    style="text-align: left"></asp:TextBox>
&nbsp;&nbsp; <asp:Button ID="btnCal" runat="server" CausesValidation="False" 
        onclick="btnCal_Click" Text="&gt;&gt;" style="text-align: left" />
&nbsp;&nbsp;</td>
            <td class="style9">
                <asp:RequiredFieldValidator ID="rfvDOJ" runat="server" 
                    ControlToValidate="txtDateOfJourney" ErrorMessage="Select Date" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:CompareValidator ID="cvDOJ" runat="server" 
                    ControlToValidate="txtDateOfJourney" 
                    ErrorMessage="Date of journey should be a future date" ForeColor="Red" 
                    Operator="GreaterThan" Type="Date"></asp:CompareValidator>
            </td>
            <td class="style4">
                <asp:Calendar ID="calDateOfJourney" runat="server" NextMonthText="&amp;gt" 
        onselectionchanged="calDateOfJourney_SelectionChanged" Visible="False">
    </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                Select Class :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlClassofatrain" runat="server" 
        DataSourceID="odsClassesOfaTrain" DataTextField="ClassName" 
        DataValueField="ClassId" AppendDataBoundItems="True">
        <asp:ListItem Value="-1">--Select--</asp:ListItem>
    </asp:DropDownList>
            </td>
            <td class="style3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="ddlClassofatrain" ErrorMessage="Select Class" 
                    ForeColor="Red" InitialValue="--Select--"></asp:RequiredFieldValidator>
            </td>
            <td class="style3">
                <asp:ObjectDataSource ID="odsClassesOfaTrain" runat="server" 
        SelectMethod="GetClassBasedOnTrain" 
        TypeName="DataAccessLayer.Train_DAL">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="-1" Name="trainId" 
                QueryStringField="ID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                <asp:Button ID="btnChkAvailability" runat="server" 
                    onclick="btnChkAvailability_Click" Text="Check Availability" />
            </td>
            <td class="style3">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                <br />
                Available Seats :</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8" colspan="3">
    <asp:GridView ID="gvClassDetails" runat="server" 
        onselectedindexchanged="gvClassDetails_SelectedIndexChanged">
        <Columns>
            <asp:CommandField SelectText="Book" ShowSelectButton="True" />
        </Columns>
        <HeaderStyle HorizontalAlign="Left" />
    </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <br />
&nbsp;<br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

