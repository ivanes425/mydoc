<%@ Page Title="" Language="C#" MasterPageFile="~/amad.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content3" ContentPlaceHolderID="dataContent" Runat="Server">
<asp:UpdatePanel ID="updUserProfilePanel" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="innerContentWhite">
                <div class="clear"></div>
                <div class="all">
                    <div style="position:relative;color:#DE4123;">
                        <div id="loginPage">
                            <div class="loginControls">
                                <p>
                                    <label>
                                        <b>Username</b>
                                    </label>
                                    <span>
                                        <asp:TextBox ID="UserNameTextBox" CssClass="loginPageTextBox" Text="Username" ValidationGroup="login"
                                            runat="server"></asp:TextBox></span>
                                </p>
                                <div class="clear">
                                </div>
                                <p>
                                    <label>
                                        <b>Password</b></label>
                                </p>
                                <span>
                                    <asp:TextBox ID="PasswordTextBox" CssClass="loginPageTextBox" Text="Password" ValidationGroup="login"
                                        runat="server"></asp:TextBox>
                                </span>
                            </div>
                            <div class="clear"></div>
                            <div class="links">
                                <dl>
                                    <dt>
                                        <asp:HyperLink ID="ForgotPassLink" CssClass="link" runat="server" Text="Forgot Password?"></asp:HyperLink>
                                    </dt>
                                    <dd>
                                        <asp:HyperLink ID="RegisterLink" CssClass="link" runat="server" Text="New User?"></asp:HyperLink>
                                    </dd>
                                </dl>
                                <asp:ImageButton ID="LoginButton" runat="server" ValidationGroup="login" ImageUrl="images/finddoctors.png" class="img" AlternateText="Login" OnClick="LoginButton_Click" />
                            </div>
                        </div>
                        
                    </div>
                </div>
                <div class="clear"></div>
                <div class="validation" style="padding:15px 0px 0px 40px;">
                    <asp:Label ID="RegisterLabel" runat="server" Font-Bold="true" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                </div>
 
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

