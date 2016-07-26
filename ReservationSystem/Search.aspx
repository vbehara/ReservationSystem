<%@ Page Title="Railway Reservation System - Home" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
        .style7
        {
            width: 276px;
        }
        .style8
        {
            width: 188px;
        }
        .style16
        {
        }
        .style22
        {
            width: 98px;
        }
        .style27
        {
            width: 35px;
        }
        .style29
        {
            width: 149px;
        }
        .style30
        {
            width: 149px;
            height: 30px;
        }
        .style31
        {
            width: 188px;
            height: 30px;
        }
        .style32
        {
            width: 35px;
            height: 30px;
        }
        .style33
        {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h3>Find Trains</h3>
    <hr />
    <table style="width:100%;">
        <tr>
            <td class="style22">
                Search by</td>
            <td class="style2">
                <asp:RadioButton ID="rbTrainID" runat="server" AutoPostBack="True" 
                    GroupName="SearchCriteria" Text="Train ID" 
                    oncheckedchanged="rbTrainID_CheckedChanged" />
                <asp:RadioButton ID="rbSourceDestination" runat="server" AutoPostBack="True" 
                    GroupName="SearchCriteria" Text="Source &amp; Destination" 
                    oncheckedchanged="rbSourceDestination_CheckedChanged" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" colspan="3">
                <asp:Panel ID="panelTrainID" runat="server" Visible="False">
                    <table style="width:100%;">
                        <tr>
                            <td class="style29">
                                Train ID<sup style="color:Red">*</sup></td>
                            <td class="style7">
                                <asp:TextBox ID="txtTrainID" runat="server" ValidationGroup="ByTrainID" 
                                    Width="215px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="TrainID" runat="server" 
                                    ControlToValidate="txtTrainID" ErrorMessage="Train ID is a required field" 
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="ByTrainID"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style29">
                                &nbsp;</td>
                            <td class="style7">
                                <asp:Button ID="btnGetTrainByID" runat="server" Text="Get Train Details" 
                                    ValidationGroup="ByTrainID" Width="119px" 
                                    onclick="btnGetTrainByID_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="3">
                <asp:Panel ID="panelSourceDestination" runat="server" Visible="False">
                    <table style="width:100%;">
                        <tr>
                            <td class="style29">
                                From<sup style="color:Red">*</sup>
                            </td>
                            <td class="style8">
                                <asp:DropDownList ID="ddlFromStation" runat="server" 
                                    ValidationGroup="ByLocation" Width="133px" DataSourceID="odsStationName" 
                                    DataTextField="StationName" DataValueField="StationCode" 
                                    AppendDataBoundItems="True">
                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsStationName" runat="server" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetStation" 
                                    TypeName="DataAccessLayer.Station_DAL"></asp:ObjectDataSource>
                            </td>
                            <td class="style27">
                                <asp:RequiredFieldValidator ID="rfvFromStation0" runat="server" 
                                    ControlToValidate="ddlFromStation" 
                                    ErrorMessage="From Station is a required field" ForeColor="Red" 
                                    SetFocusOnError="True" ValidationGroup="ByLocation">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                To<sup style="color:Red">*</sup></td>
                            <td class="style8">
                                <asp:DropDownList ID="ddlToStation" runat="server" ValidationGroup="ByLocation" 
                                    Width="133px" DataSourceID="odsStationName" DataTextField="StationName" 
                                    DataValueField="StationCode" AppendDataBoundItems="True">
                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="style27">
                                <asp:RequiredFieldValidator ID="rfvToStation" runat="server" 
                                    ControlToValidate="ddlToStation" ErrorMessage="To Station is a required field" 
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="ByLocation">*</asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvFromTo" OnServerValidate="station_from_to" 
                                    runat="server" ErrorMessage="From and To stations can not be same" 
                                    ForeColor="Red" ValidationGroup="ByLocation" 
                                    ClientValidationFunction="station_from_to" ControlToValidate="ddlToStation" 
                                    Visible="False">*</asp:CustomValidator>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                Date of Journey<sup style="color:Red">*</sup></td>
                            <td class="style8">
                                <asp:TextBox ID="txtDateOfJourney" runat="server" Width="132px"></asp:TextBox>
                                <asp:Button ID="btnCalendar" runat="server" Text="&gt;&gt;" 
                                    onclick="btnCalendar_Click" CausesValidation="False" />
                            </td>
                            <td class="style27">
                                <asp:RequiredFieldValidator ID="rfvDateOfJourney" runat="server" 
                                    ControlToValidate="txtDateOfJourney" 
                                    ErrorMessage="Date of Journey is a required field" ForeColor="Red" 
                                    SetFocusOnError="True" ValidationGroup="ByLocation">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Calendar ID="calDateOfJourney" runat="server" 
                                    onselectionchanged="calDateOfJourney_SelectionChanged" 
                                    onvisiblemonthchanged="calDateOfJourney_VisibleMonthChanged" Visible="False"></asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td class="style30">
                                </td>
                            <td class="style31">
                                <asp:Button ID="btnFindTrains" runat="server" Text="Find Trains" 
                                    ValidationGroup="ByLocation" Width="111px" onclick="btnFindTrains_Click" />
                            </td>
                            <td class="style32">
                                </td>
                            <td class="style33">
                                </td>
                        </tr>
                        <tr>
                            <td class="style16" colspan="4">
                                <asp:ValidationSummary ID="validationSummary" runat="server" ForeColor="Red" 
                                    ValidationGroup="ByLocation" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    
</asp:Content>
