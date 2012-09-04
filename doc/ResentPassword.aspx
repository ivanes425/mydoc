<%@ Page Title="" Language="C#" MasterPageFile="~/amad.master" AutoEventWireup="true" CodeFile="ResentPassword.aspx.cs" Inherits="ResentPassword" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content3" ContentPlaceHolderID="dataContent" Runat="Server">
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
                            <legend><div style="font-weight:bold;font-size:14px;padding:0px 10px 0px 10px">Identify Your Account</div></legend>
                            <div style="color:#FEB825;font-size:14px;position:relative;width:450px;vertical-align:top;float:left;padding-left:20px">
                                <p>To reset your password, please first identify your account.</p>
                                <div class="clear"></div>
                                <p>
                                    <div style="color:#D8322C;padding:0px 0px 5px 0px;">Enter Your Email Address</div>
                                    <div class="clear"></div>
                                    <asp:TextBox ID="EmailAddressTextBox" runat="server" Width="200px" Height="22"></asp:TextBox>
                                </p>
                                <div class="clear"></div>
                                <div style="color:#BF0426;font-weight:bold;">
                                    ------------- OR -------------
                                </div>
                                <div class="clear"></div>
                                <p>
                                    <div style="color:#D8322C;padding:0px 0px 5px 0px;">Enter Your Username</div>
                                    <div class="clear"></div>
                                    <asp:TextBox ID="UsernameTextBox" runat="server" Width="200px" Height="22"></asp:TextBox>
                                </p>
                                <div class="clear"></div>
                                <p>
                                    <asp:ImageButton ID="GetPasswordButton" runat="server" CausesValidation="false" ImageUrl="~/images/finddoctors.png" OnClick="GetPasswordButton_Click" />
                                </p>
                                <p>&nbsp;</p>
                                <div class="clear"></div>
                                <div style="color:#FEB825;background:#FDEC9C;padding:10px;font-size:smaller;font-weight:bold;">
                                    Need help? <a href="mailto:support@appointmeadoc.com?Subject=Cannot identify my account" style="font-weight:normal;text-decoration:none;color:#D8322C">Please contact AMAD Support.</a>
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

