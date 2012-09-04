<%@ Page Title="" Language="C#" MasterPageFile="~/amad.master" AutoEventWireup="true" CodeFile="logout.aspx.cs" Inherits="logout" %>
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
                                    You are successfully loged-out
                                </p>
                                <div class="clear">
                                </div>
                                <span>
                                    Click <a href="Login.aspx">here</a> to login again
                                </span>
                            </div>
                            <div class="clear"></div>
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

