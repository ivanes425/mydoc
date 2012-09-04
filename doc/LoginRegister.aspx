<%@ Page Title="" Language="C#" MasterPageFile="~/amad.master" AutoEventWireup="true" CodeFile="LoginRegister.aspx.cs" Inherits="LoginRegister" %>

<asp:Content ID="Content3" ContentPlaceHolderID="dataContent" Runat="Server">
<div id="twoColumn-LR">
    <div class="fleft">
        <div class="headertext">
            New User? Register Here<br /><br />
        </div>
        <div class="clear"></div>
        <div class="fleftlabels">
            <ul>
                <li>
                    <span style="color:Red">*&nbsp;</span>First Name
                </li>
                <li>
                    <span style="color:Red">*&nbsp;</span>Last Name
                </li>
                <li>
                    <span style="color:Red">*&nbsp;</span>Email Address
                </li>
                <li>
                    <span style="color:Red">*&nbsp;</span>Mobile Number
                </li>
                <li>
                    <span style="color:Red">*&nbsp;</span>Are you a Patient?
                </li>
            </ul>
        </div>
        <div class="fleftcontent">
            <ul>
                <li>
                    <asp:TextBox ID="FirstNameTextBox" runat="server" MaxLength="100" ValidationGroup="Register" Width="150px"></asp:TextBox>
                </li>
                <li>
                    <asp:TextBox ID="LastNameTextBox" runat="server" MaxLength="100" ValidationGroup="Register" Width="150px"></asp:TextBox>
                </li>
                <li>
                    <asp:TextBox ID="EmailAddressTexBox" runat="server" MaxLength="150" ValidationGroup="Register" Width="150px"></asp:TextBox>&nbsp;
                    <asp:LinkButton ID="CheckAvailabilityButton" runat="server" Text="Check Avail." CausesValidation="false" onclick="CheckAvailabilityButton_Click"></asp:LinkButton>
                    <asp:Image id="emailAvailCheckImg" runat="server" ImageUrl="~/images/valid.jpg" Visible="false" />
                </li>
                <li>
                    <asp:TextBox ID="MobileNumberTextBox" runat="server" MaxLength="10" ValidationGroup="Register" Width="150px"></asp:TextBox>
                </li>
                <li>
                    <asp:RadioButtonList ID="IsPatient" runat="server" ValidationGroup="Register" RepeatDirection="Horizontal">
                        <asp:ListItem Value="true" Text="Yes"></asp:ListItem>
                        <asp:ListItem Value="false" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </li>
                <li>
                    <asp:ImageButton ID="RegisterNewUser" runat="server" ValidationGroup="Register" 
                        ImageUrl="~/images/finddoctors.png" onclick="RegisterNewUser_Click" />
                </li>
            </ul>
        </div>
        <div class="clear"></div>
        <div class="validation">
            <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Register" ID="rfvEmailAddress" ControlToValidate="EmailAddressTexBox" ErrorMessage="Please Enter Email Address"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Register" ID="rfvMobileNumber" ControlToValidate="MobileNumberTextBox" ErrorMessage="Please Enter Mobile Number"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Register" ID="rfvFirstName" ControlToValidate="FirstNameTextBox" ErrorMessage="Please Enter First Name"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Register" ID="rfvLastName" ControlToValidate="LastNameTextBox" ErrorMessage="Please Enter Last Name"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Register" ID="rfvIsPatient" ControlToValidate="IsPatient" ErrorMessage="Are you a Patient? Select Yes or No"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" Display="None" ValidationGroup="Register" ID="revFirstName" ControlToValidate="FirstNameTextBox" ErrorMessage="Please Enter Valid First Name (only letters)" ValidationExpression="^[A-Za-z\s]{3,200}$"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator runat="server" Display="None" ValidationGroup="Register" ID="revLastName" ControlToValidate="LastNameTextBox" ErrorMessage="Please Enter Valid Last Name (only letters)" ValidationExpression="^[A-Za-z\s]{3,200}$"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator runat="server" Display="None" ValidationGroup="Register" ID="revEmailAddress" ControlToValidate="EmailAddressTexBox" ErrorMessage="Please Enter Valid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator runat="server" Display="None" ValidationGroup="Register" ID="revMobileNumber" ControlToValidate="MobileNumberTextBox" ErrorMessage="Please Enter Valid Mobile Number" ValidationExpression="^([7-9]{1})([0-9]{9})$"></asp:RegularExpressionValidator>
            <asp:ValidationSummary runat="server" ID="registerValidSummary" DisplayMode="List" ValidationGroup="Register" ShowSummary="true" />
            <asp:Label ID="RegisterLabel" runat="server" Font-Bold="true" Font-Size="Smaller" ForeColor="Red"></asp:Label>
        </div>
    </div>
    <div class="fright">
        <div class="headertext">
            Already Registered? Login Here<br /><br />
        </div>
        <div class="clear"></div>
        <div class="frightlabels">
            <ul>
                <li>
                    <span style="color:Red">*&nbsp;</span>Username
                </li>
                <li>
                    <span style="color:Red">*&nbsp;</span>Password
                </li>
            </ul>
        </div>
        <div class="frightcontent">
            <ul>
                <li>
                    <asp:TextBox ID="UsernameTextBox" runat="server" ValidationGroup="Login" Width="150px"></asp:TextBox>
                </li>
                <li>
                    <asp:TextBox ID="PasswordTextBox" runat="server" ValidationGroup="Login" Width="150px"></asp:TextBox>
                </li>
                <li>
                    <asp:ImageButton ID="LoginButton" runat="server" ValidationGroup="Login" 
                        ImageUrl="~/images/finddoctors.png" onclick="LoginButton_Click" />
                </li>
            </ul>
        </div>
        <div class="clear"></div>
        <div class="validation">
            <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Login" ID="rfvUsername" ControlToValidate="UsernameTextBox" ErrorMessage="Please Enter Username"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Login" ID="rfvPassword" ControlToValidate="PasswordTextBox" ErrorMessage="Please Enter Password"></asp:RequiredFieldValidator>
            <asp:ValidationSummary runat="server" ID="loginValidSummary" DisplayMode="List" ValidationGroup="Login" ShowSummary="true" />
            <asp:Label ID="LoginLabel" runat="server" Font-Bold="true" Font-Size="Smaller" ForeColor="Red"></asp:Label>
        </div>
    </div>
</div>
</asp:Content>

