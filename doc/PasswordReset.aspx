<%@ Page Title="" Language="C#" MasterPageFile="~/amad.master" AutoEventWireup="true" CodeFile="PasswordReset.aspx.cs" Inherits="PasswordReset" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/usercontrols/searchDocs.ascx" TagName="search" TagPrefix="doc" %>
<asp:Content ID="Content3" ContentPlaceHolderID="InnerDataContent" Runat="Server">
<asp:UpdatePanel ID="updUserProfilePanel" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="innerContent">
            <div id="column1">
                <div class="titleleft">
                    
                </div>
                <div class="clear"></div>
                <div class="all">
                    <div style="position:relative;color:#DE4123">
                        <asp:Label ID="LabelText" CssClass="label" Font-Size="Medium" runat="server"></asp:Label>
                        
                        <fieldset>
                            <legend><div style="font-weight:bold;font-size:14px;padding:0px 10px 0px 10px">Reset Password</div></legend>
                            <div style="color:#FEB825;font-size:14px;position:relative;width:450px;vertical-align:top;float:left;padding-left:20px">
                                <p><h3>Reset Password.</h3></p>
                                <div class="clear"></div>
                                <p>
                                    <div style="color:#D8322C;padding:0px 0px 5px 0px;">Email Address</div>
                                    <div class="clear"></div>
                                    <asp:TextBox ID="EmailAddressTextBox" runat="server" ValidationGroup="ResetPass" Width="200px" Enabled="false" Height="22"></asp:TextBox>
                                </p>
                                <div class="clear"></div>
                                <p>
                                    <div style="color:#D8322C;padding:0px 0px 5px 0px;">Enter Your New Password</div>
                                    <div class="clear"></div>
                                    <asp:TextBox ID="PasswordTextBox" runat="server" ValidationGroup="ResetPass" TextMode="Password" Width="200px" Height="22"></asp:TextBox>
                                </p>
                                <div class="clear"></div>
                                <p>
                                    <div style="color:#D8322C;padding:0px 0px 5px 0px;">Confirm New Password</div>
                                    <div class="clear"></div>
                                    <asp:TextBox ID="ConfirmPasswordTextBox" ValidationGroup="ResetPass" runat="server" TextMode="Password" Width="200px" Height="22"></asp:TextBox>
                                </p>
                                <div class="clear"></div>
                                <p>
                                    <asp:ImageButton ID="ResetPasswordButton" runat="server" ValidationGroup="ResetPass" ImageUrl="~/images/finddoctors.png" OnClick="ResetPasswordButton_Click" />
                                </p>
                                <p>&nbsp;</p>
                                <p>
                                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="ResetPass" ID="rfvPassword" ControlToValidate="PasswordTextBox" ErrorMessage="Please enter your new password"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator runat="server" Display="None" ValidationGroup="ResetPass" ID="rfvConfirmPass" ControlToValidate="ConfirmPasswordTextBox" ErrorMessage="Please confirm your new password"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" Display="None" ValidationGroup="ResetPass" ID="revPassword" ControlToValidate="PasswordTextBox" ErrorMessage="Please Enter an Alpha Numeric Combination .Should be more than 6 charachters eg:(minimum 1 uppercase letter,1 lower case letter,1 numeric and one special charachter like @#$%^&+=)" ValidationExpression="^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$"></asp:RegularExpressionValidator>
                                    <asp:CompareValidator runat="server" Display="None" ValidationGroup="ResetPass" ID="cvConfirmpass" ControlToValidate="ConfirmPasswordTextBox" ErrorMessage="Passwords do not match" ControlToCompare="PasswordTextBox"></asp:CompareValidator>
                                    <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" ValidationGroup="ResetPass" DisplayMode="BulletList" />
                                </p>
                                <div class="clear"></div>
                                <div style="color:#FEB825;background:#FDEC9C;padding:10px;font-size:smaller;font-weight:bold;">
                                    Need help? <a href="mailto:support@appointmeadoc.com?Subject=Cannot reset password" style="font-weight:normal;text-decoration:none;color:#D8322C">Please contact AMAD Support.</a>
                                </div>
                            </div>
                        </fieldset>
                        
                    </div>
                    <div class="clear"></div>
                </div>
                <div class="clear"></div>
                <div class="validation" style="padding:15px 0px 0px 40px;">
                    <asp:Label ID="MessageLabel" runat="server" Font-Bold="true" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div id="column2">
                <div>
                    <div class="clear"></div>
                    <br /><br />
                    <img src="images/forgotpass.jpg" />
                    <br /><br /><br />
                    <div class="clear"></div>
                    
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

