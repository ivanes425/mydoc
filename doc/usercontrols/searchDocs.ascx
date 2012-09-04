<%@ Control Language="C#" AutoEventWireup="true" CodeFile="searchDocs.ascx.cs" Inherits="usercontrols_searchDocs" %>
<div id="searchform">
    <div class="textser">
        Select Department
    </div>
    <div class="searchfield">
        <asp:DropDownList ID="DepartmentList" Width="120px" runat="server" CssClass="nonExpandableDropdown">
        </asp:DropDownList>
    </div>
    <div class="textser">
        Select City
    </div>
    <div class="searchfield">
        <asp:DropDownList ID="CityList" Width="120px" runat="server">
        </asp:DropDownList>
    </div>
    <div class="clear">
    </div>
    <div class="textser">
        Select Area
    </div>
    <div class="searchfield">
        <asp:DropDownList ID="AreaList" Width="120px" runat="server">
        </asp:DropDownList>
    </div>
    <div class="textser">
        Do you have Health
        <br />
        Insurance?
    </div>
    <div class="searchfield">
        <asp:RadioButtonList ID="InsuranceRadio" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
            <asp:ListItem Value="NO" Text="No"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
</div>
<div class="btn">
    <asp:ImageButton ID="FindDoctorsButton" runat="server" ImageUrl="images/finddoctors.png"
        Width="117" Height="29" title="" AlternateText="" OnClick="FindDoctorsButton_Click" />
</div>
