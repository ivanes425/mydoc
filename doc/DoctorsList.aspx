<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/amad.master" AutoEventWireup="true"
    CodeFile="DoctorsList.aspx.cs" Inherits="DoctorsList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content3" ContentPlaceHolderID="dataContent" runat="Server">
    <asp:UpdatePanel ID="updUserProfilePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="innerContentWhite">
                <div class="clear">
                </div>
                <div class="all">
                    <div style="float:left;position: relative; color: #DE4123;">
                        <div style="float:left;font-size:14px;padding:10px 0px 10px 3px;color:#ECAD0B;">
                            Your search results for&nbsp;<asp:Label ID="DepartmentLabel" runat="server"></asp:Label>
                        </div>
                        <asp:DataList ID="dataListDoctors" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Table">
                            <ItemTemplate>
                                <div style="width:355px;height:210px;background-image:url('images/bg_docprofile-trns.png');background-repeat:no-repeat;position:relative">
                                    <div style="width:100px;padding:7px;float:left;position:relative">
                                        <img src="images/docDefPhoto.jpg" />
                                    </div>
                                    <div style="vertical-align:top;width:150px;padding:10px 5px 5px 5px;text-align:left;float:left;position:relative;font-size:14px;font-weight:bold">
                                        Dr. <%#Eval("DocName")%> (<%#Eval("DoctorsDegree")%>)
                                        <br />
                                        <%#Eval("Description")%>
                                        <br />
                                        <%#Eval("DoctorAddress")%>
                                    </div>
                                    <div style="clear:both"></div>
                                    <div style="color:#FEBA29;position:relative;font-weight:bold;vertical-align:baseline;padding:35px 0px 5px 5px;float:left;width:370px">
                                        <div style="width:233px;float:left;padding-top:13px;">
                                            <span style="padding:3px 5px 3px 5px;background-color:#D8322C">Book Appointment</span>&nbsp;
                                            <span style="padding:3px 5px 3px 5px;background-color:#D8322C">View Profile</span>&nbsp;
                                        </div>
                                        <div style="width:130px;float:right;vertical-align:top;padding-right:5px;">
                                            <a href="#" onclick="javascript:openRatingModal(1, 'LIKE')">
                                                <div style="background: url('images/sociallinks.png') no-repeat scroll -7px -6px transparent;display: block;float: left;height: 38px;text-indent: -9999px;width: 34px;"></div>
                                            </a>
                                            <div style="width:45px;float:left;padding:15px 0px 0px 0px">
                                                <span style="background-color:#EFEFEF;padding:3px;font-weight:bold;color:Navy;text-align:center">
                                                    100%
                                                </span>
                                            </div>
                                            <a href="#" onclick="javascript:openRatingModal(1, 'DISLIKE')">
                                                <div style="background: url('images/sociallinks.png') no-repeat scroll -45px -7px transparent;display: block;float: left;margin: 0;height: 38px;text-indent: -9999px;width: 34px;"></div>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="validation" style="padding: 15px 0px 0px 40px;">
                    <asp:Label ID="RegisterLabel" runat="server" Font-Bold="true" Font-Size="Smaller"
                        ForeColor="Red"></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
