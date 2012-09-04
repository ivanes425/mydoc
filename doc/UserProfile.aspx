<%@ Page Title="" Language="C#" MasterPageFile="~/amad.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/usercontrols/searchDocs.ascx" TagName="search" TagPrefix="doc" %>
<asp:Content ID="Content3" ContentPlaceHolderID="InnerDataContent" Runat="Server">
<asp:UpdatePanel ID="updUserProfilePanel" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="innerContent">
            <div id="column1">
                <div class="title">
                    Activate Your Account
                </div>
                <div class="clear"></div>
                <div class="fleft">
                    <ul>
                        <li>
                            <span style="color:Red">*&nbsp;</span>Enter Login Name<br />
                            <asp:TextBox ID="LoginNameTextBox" runat="server" MaxLength="20" ValidationGroup="Activate" Width="200px"></asp:TextBox>
                            &nbsp;<asp:LinkButton ID="CheckAvailabilityButton" runat="server" CausesValidation="false" Text="Check Avail." onclick="CheckAvailabilityButton_Click"></asp:LinkButton>
                        </li>
                        <li>
                            <span style="color:Red">*&nbsp;</span>First Name<br />
                            <asp:TextBox ID="FirstNameTextBox" runat="server" MaxLength="100" ValidationGroup="Activate" Width="200px"></asp:TextBox>
                        </li>
                        <li>
                            <span style="color:Red">*&nbsp;</span>Email Address<br />
                            <asp:TextBox ID="EmailAddressTexBox" runat="server" MaxLength="150" ValidationGroup="Activate" Width="200px"></asp:TextBox>
                        </li>
                        <li>
                            <span style="color:Red">*&nbsp;</span>Gender<br />
                            <asp:RadioButtonList ID="GenderList" runat="server" BorderWidth="1px" Width="200px" BorderColor="#9a9a9a" Height="26px" ValidationGroup="Activate" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                                <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                            </asp:RadioButtonList>
                        </li>
                        <li>
                            <span style="color:Red">&nbsp;</span>City<br />
                            <asp:TextBox ID="CityTextBox" runat="server" MaxLength="150" ValidationGroup="Activate" Width="200px"></asp:TextBox>
                        </li>
                        <li>
                            <span style="color:Red">&nbsp;</span>Relationship with Patient<br />
                            <asp:TextBox ID="RelationshipTextBox" runat="server" MaxLength="150" ValidationGroup="Activate" Width="200px"></asp:TextBox>
                        </li>
                        <li>
                            <span style="color:Red">&nbsp;</span>Address<br />
                            <asp:TextBox ID="AddressTextBox" runat="server" MaxLength="150" TextMode="MultiLine" ValidationGroup="Activate" Width="200px"></asp:TextBox>
                        </li>
                    </ul>
                </div>
                <div class="fright">
                    <ul>
                        <li>
                            <span style="color:Red">*&nbsp;</span>Enter Password<br />
                            <asp:TextBox ID="PasswordTextBox" runat="server" MaxLength="20" TextMode="Password" ValidationGroup="Activate" Width="200px"></asp:TextBox>
                        </li>
                        <li>
                            <span style="color:Red">*&nbsp;</span>Last Name<br />
                            <asp:TextBox ID="LastNameTextBox" runat="server" MaxLength="100" ValidationGroup="Activate" Width="200px"></asp:TextBox>
                        </li>
                        <li>
                            <span style="color:Red">*&nbsp;</span>Mobile Number<br />
                            <asp:TextBox ID="MobileNumberTextBox" runat="server" MaxLength="10" ValidationGroup="Activate" Width="200px"></asp:TextBox>
                        </li>
                        <li>
                            <span style="color:Red">*&nbsp;</span>Are you a Patient?<br />
                            <asp:RadioButtonList ID="IsPatient" runat="server" ValidationGroup="Activate" BorderWidth="1px" Width="200px" BorderColor="#9a9a9a" Height="26px" RepeatDirection="Horizontal">
                                <asp:ListItem Value="true" Text="Yes"></asp:ListItem>
                                <asp:ListItem Value="false" Text="No"></asp:ListItem>
                            </asp:RadioButtonList>
                        </li>
                        <li>
                            <span style="color:Red">&nbsp;</span>Home / Office Phone Number<br />
                            <asp:TextBox ID="AreaCodeTextBox" runat="server" MaxLength="6" ValidationGroup="Activate" Text="Area code" Width="60px"></asp:TextBox>
                            <asp:TextBox ID="PhoneNumberTextBox" runat="server" MaxLength="6" ValidationGroup="Activate" Width="130px"></asp:TextBox>
                        </li>
                        <li>
                            <span style="color:Red">&nbsp;</span>Emergency Contact Number<br />
                            <asp:TextBox ID="EmergencyNumberTextBox" runat="server" MaxLength="150" ValidationGroup="Activate" Width="200px"></asp:TextBox>
                        </li>
                        <li>
                            <asp:ImageButton ID="SubmitButton" runat="server" ImageUrl="~/images/finddoctors.png" ValidationGroup="Activate" OnClick="SubmitButton_Click" />
                            <br />
                            <span style="color:Red;font-size:smaller">Fields marked with (*) are mandatory</span>
                        </li>
                    </ul>
                </div>
                <div class="clear"></div>
                <div class="validation" style="padding:15px 0px 0px 40px;">
                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Activate" ID="rfvLoginName" ControlToValidate="LoginNameTextBox" ErrorMessage="Please Enter Login Name"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Activate" ID="rfvPassword" ControlToValidate="PasswordTextBox" ErrorMessage="Please Enter Password"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Activate" ID="rfvFirstName" ControlToValidate="FirstNameTextBox" ErrorMessage="Please Enter First Name"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Activate" ID="rfvLastName" ControlToValidate="LastNameTextBox" ErrorMessage="Please Enter Last Name"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Activate" ID="rfvEmailAddress" ControlToValidate="EmailAddressTexBox" ErrorMessage="Please Enter Email Address"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Activate" ID="rfvMobileNumber" ControlToValidate="MobileNumberTextBox" ErrorMessage="Please Enter Mobile Number"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Activate" ID="rfvGender" ControlToValidate="GenderList" ErrorMessage="Please Select Gender"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Activate" ID="rfvIsPatient" ControlToValidate="IsPatient" ErrorMessage="Are you a Patient? Select Yes or No"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Activate" ID="rfvCity" ControlToValidate="CityTextBox" Enabled="false" ErrorMessage="Please Enter City"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Activate" ID="rfvAreaCode" ControlToValidate="AreaCodeTextBox" Enabled="false" ErrorMessage="Please Enter Area Code"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Activate" ID="rfvPhone" ControlToValidate="PhoneNumberTextBox" Enabled="false" ErrorMessage="Please Enter Home/Office Phone Number"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Activate" ID="rfvRelationship" ControlToValidate="RelationshipTextBox" Enabled="false" ErrorMessage="Please Enter Relationship with Patient"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Activate" ID="rfvEmergency" ControlToValidate="EmergencyNumberTextBox" Enabled="false" ErrorMessage="Please Enter Emergency Contact Number"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="Activate" ID="rfvAddress" ControlToValidate="AddressTextBox" Enabled="false" ErrorMessage="Please Enter Address"></asp:RequiredFieldValidator>
                    
                    <asp:RegularExpressionValidator runat="server" Display="None" ValidationGroup="Activate" ID="revLoginName" ControlToValidate="LoginNameTextBox" ErrorMessage="Please Enter an Alpha Numeric combination. Should be more tan 8 characters and should not contain special characters like (,),%,$,&,{,[}" ValidationExpression="^[A-Za-z0-9*#@$-_]{8,20}$"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator runat="server" Display="None" ValidationGroup="Activate" ID="revPassword" ControlToValidate="PasswordTextBox" ErrorMessage="Please Enter an Alpha Numeric Combination .Should be more than 6 charachters eg:(minimum 1 uppercase letter,1 lower case letter,1 numeric and one special charachter like @#$%^&+=)"  ValidationExpression="^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator runat="server" Display="None" ValidationGroup="Activate" ID="revFirstName" ControlToValidate="FirstNameTextBox" ErrorMessage="Please Enter Valid First Name (only letters)" ValidationExpression="^[A-Za-z\s]{3,200}$"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator runat="server" Display="None" ValidationGroup="Activate" ID="revLastName" ControlToValidate="LastNameTextBox" ErrorMessage="Please Enter Valid Last Name (only letters)" ValidationExpression="^[A-Za-z\s]{3,200}$"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator runat="server" Display="None" ValidationGroup="Activate" ID="revEmailAddress" ControlToValidate="EmailAddressTexBox" ErrorMessage="Please Enter Valid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator runat="server" Display="None" ValidationGroup="Activate" ID="revMobileNumber" ControlToValidate="MobileNumberTextBox" ErrorMessage="Please Enter Valid Mobile Number" ValidationExpression="^([7-9]{1})([0-9]{9})$"></asp:RegularExpressionValidator>
                    <asp:ValidationSummary runat="server" ID="registerValidSummary" DisplayMode="List" ValidationGroup="Activate" ShowSummary="true" />
                    <asp:Label ID="RegisterLabel" runat="server" Font-Bold="true" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div id="column2">
                <div>
                    <br />
                    <div id="search">
                        <doc:search ID="searchDoc" runat="server" />
                    </div>
                    <div class="clear"></div>
                    <br />
                    <div style="height:100px;background-color:#FFD33E;border:solid 1px #DE4221;width:200px;">
                        <span style="padding:5px;">Facebook Plugin and other social media links</span>
                    </div>
                    <div class="clear"></div>
                    <br />
                </div>
            </div>

        </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

