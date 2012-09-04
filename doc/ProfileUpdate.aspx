<%@ Page Title="" Language="C#" MasterPageFile="~/amad.master" AutoEventWireup="true" CodeFile="ProfileUpdate.aspx.cs" Inherits="ProfileUpdate" %>
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
                        <div style="width:170px;float:left;padding-top:15px;vertical-align:top">
                            <img src="images/success.jpg" />&nbsp
                        </div>
                        <div style="width:420px;float:left;vertical-align:top;">
                            <span><h3>Congratulations !!!</h3></span><br />
                            <asp:Label ID="LabelText" CssClass="label" Font-Size="Medium" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="clear"></div>
                    <div style="text-align:left;padding-top:30px;"><br />
                        <span style="font-size:medium;color:#DE4123">
                            You enjoy staying in touch through your favourite networking sites such as Facebook and Twitter. 
                            You can now connect with us here as well!
                        </span>
                    </div>
                    <div class="clear"></div>
                    <div>
                        <br />
                        <span><b>Connect with us</b></span><br /><br />
                        <img src="images/fb-btn.png" width="149" /><img src="images/tw-btn.png" width="149" />
                        <img src="images/lk-btn.png" width="149"/><img src="images/rss-btn.png" width="149" />
                        
                    </div>
                </div>
                <div class="clear"></div>
                <div class="validation" style="padding:15px 0px 0px 40px;">
                    <asp:Label ID="RegisterLabel" runat="server" Font-Bold="true" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div id="column2">
                <div>
                    <div style="float:left;border:solid 0px #DE4221;text-align:left">
                        <h3>What Next?<h3>
                        <ul>
                            <li>Book an appointment with doctor</li>
                            <li>access your personal health history anytime, from anywhere</li>
                            <li>buy health care products at very discounted rates</li>
                            <li>get you queries answered by our expert panel of doctors</li>
                            <li>and lots more...</li>
                        </ul>
                    </div>
                    <div class="clear"></div>
                    <br />
                    <div id="search">
                        <doc:search ID="searchDoc" runat="server" />
                    </div>
                    <div class="clear"></div>
                    
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

