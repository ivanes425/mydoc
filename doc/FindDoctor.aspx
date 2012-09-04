<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/amad.master" AutoEventWireup="true" CodeFile="FindDoctor.aspx.cs" Inherits="FindDoctor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content3" ContentPlaceHolderID="dataContent" Runat="Server">
    <asp:UpdatePanel ID="updUserProfilePanel" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="innerContentFull">
            <div class="clear">
            </div>
            <div class="all" style="float:left;position:relative;">
                <div style="width:610px;float:left;">
                
                <ajaxToolkit:TabContainer ID="DoctorsTabContainer" Width="600px" CssClass="Tab" runat="server" TabStripPlacement="Top">
                    <ajaxToolkit:TabPanel ID="SpecialistTab" runat="server">
                        <HeaderTemplate>
                            <a href="#" style="color:White;text-decoration:none;">Find Doctor By Specialist</a>
                        </HeaderTemplate>
                        <ContentTemplate>
                            <div style="background-image:url('images/tab/speciality.png');background-repeat:no-repeat;width:600px;height:274px;position:relative;vertical-align:top;float:left">
                                <div style="width:380px;float:left;margin:5px 0px 0px 150px">
                                    <div class="tabHead">&nbsp;</div>
                                    <div style="clear:both"></div>
                                    <div class="textLabels">
                                        Select Department
                                    </div>
                                    <div class="searchControls">
                                        <asp:DropDownList ID="DepartmentList" Width="200px" Height="23px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div style="clear:both"></div>
                                    <div class="textLabels">
                                        Select City
                                    </div>
                                    <div class="searchControls">
                                        <asp:DropDownList ID="CityList" Width="200px" Height="23px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="clear">
                                    </div>
                                    <div class="textLabels">
                                        Select Area
                                    </div>
                                    <div class="searchControls">
                                        <asp:DropDownList ID="AreaList" Width="200px" Height="23px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="tabButton">
                                    <asp:ImageButton ID="FindDoctorsButton" runat="server" ImageUrl="images/finddoctors.png"
                                        Width="117px" Height="29px" ValidationGroup="Tab1" 
                                        onclick="FindDoctorsButton_Click" />
                                </div>
                                <div style="clear:both"></div>
                                <div style="width:450px;margin:10px 0px 0px 145px;float:left;text-align:left;">
                                    Now find the best specialist doctors available and book an appointment online now! Its easy, convenient and never need to wait in queue.<br />
                                    <b>You can conveniently track your medical history, access medical reports anywhere, anytime.</b>
                                    <uc:HighlightRequiredValidator ID="rfvDepartment" runat="server" Display="None" 
                                        ControlToValidate="DepartmentList" InitialValue="Select" ErrorCssClass="validationErrorBorder" 
                                        ErrorMessage="Please Select Department" ValidationGroup="Tab1"></uc:HighlightRequiredValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="vceDeptListTab1" runat="server" 
                                        TargetControlID="rfvDepartment" Enabled="True"></ajaxToolkit:ValidatorCalloutExtender>
                                    
                                    <uc:HighlightRequiredValidator ID="rfvCityTab1" runat="server" Display="None" 
                                        ControlToValidate="CityList" InitialValue="Select" ErrorCssClass="validationErrorBorder"
                                        ErrorMessage="Please Select City" ValidationGroup="Tab1"></uc:HighlightRequiredValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="vceCityListTab1" runat="server" 
                                        TargetControlID="rfvCityTab1" Enabled="True"></ajaxToolkit:ValidatorCalloutExtender>
                                    
                                    <uc:HighlightRequiredValidator ID="rfvAreaTab1" runat="server" Display="None" 
                                        ControlToValidate="AreaList" InitialValue="Select" ErrorCssClass="validationErrorBorder" 
                                        ErrorMessage="Please Select Area" ValidationGroup="Tab1"></uc:HighlightRequiredValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="vceAreaListTab1" runat="server" 
                                        TargetControlID="rfvAreaTab1" Enabled="True"></ajaxToolkit:ValidatorCalloutExtender>
                                </div>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="HospitalTab" runat="server">
                        <HeaderTemplate>
                            <a href="#" style="color:White;text-decoration:none;">Find Doctor By Hospital/Clinic</a>
                        </HeaderTemplate>
                        <ContentTemplate>
                            <div style="background-image:url('images/tab/clinic.png');background-repeat:no-repeat;width:600px;height:274px;position:relative;vertical-align:top;float:left">
                                <div style="width:380px;float:left;margin:5px 0px 0px 150px">
                                    <div class="tabHead">&nbsp;</div>
                                    <div style="clear:both"></div>
                                    <div class="textLabels">
                                        Select City
                                    </div>
                                    <div class="searchControls">
                                        <asp:DropDownList ID="HospitalCityList" Width="200px" Height="23px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="textLabels">
                                        Select Area
                                    </div>
                                    <div class="searchControls">
                                        <asp:DropDownList ID="HospitalAreaList" Width="200px" Height="23px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div style="clear:both"></div>
                                    <div class="textLabels">
                                        Select Hospital/Clinic
                                    </div>
                                    <div class="searchControls">
                                        <asp:DropDownList ID="HospitalList" Width="200px" Height="23px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="tabButton">
                                    <asp:ImageButton ID="SearchHospitalImageButton" runat="server" ImageUrl="images/finddoctors.png"
                                        Width="117px" Height="29px" ValidationGroup="Tab2" onclick="FindDoctorsButton_Click" /></div>
                                <div style="clear:both"></div>
                                <div style="width:450px;margin:5px 0px 0px 145px;float:left;text-align:left;">
                                    Now find the best doctors available in your preferred Hospital/clinic and book an appointment online now! Its easy, convenient and never need to wait in queue.<br />
                                    <b>You can conveniently track your medical history, access medical reports anywhere, anytime.</b>
                                    
                                    <uc:HighlightRequiredValidator ID="rfvHospitalListTab2" runat="server" Display="None" 
                                        ControlToValidate="HospitalList" InitialValue="Select" ErrorCssClass="validationErrorBorder" 
                                        ErrorMessage="Please Select Hospital" ValidationGroup="Tab2"></uc:HighlightRequiredValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="vceHospitalListTab2" runat="server" TargetControlID="rfvHospitalListTab2" PopupPosition="Right"></ajaxToolkit:ValidatorCalloutExtender>
                                    
                                    <uc:HighlightRequiredValidator ID="rfvCityListTab2" runat="server" Display="None" 
                                        ControlToValidate="HospitalCityList" InitialValue="Select" ErrorCssClass="validationErrorBorder"
                                        ErrorMessage="Please Select City" ValidationGroup="Tab2"></uc:HighlightRequiredValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="vceCityListTab2" runat="server" TargetControlID="rfvCityListTab2" PopupPosition="Right"></ajaxToolkit:ValidatorCalloutExtender>
                                    
                                    <uc:HighlightRequiredValidator ID="rfvAreaListTab2" runat="server" Display="None" 
                                        ControlToValidate="HospitalAreaList" InitialValue="Select" ErrorCssClass="validationErrorBorder" 
                                        ErrorMessage="Please Select Area" ValidationGroup="Tab2"></uc:HighlightRequiredValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="vceAreaListTab2" runat="server" TargetControlID="rfvAreaListTab2" PopupPosition="Right"></ajaxToolkit:ValidatorCalloutExtender>
                                    
                                </div>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="LabTab" runat="server">
                        <HeaderTemplate>
                            <a href="#" style="color:White;text-decoration:none;">Find Labs</a>
                        </HeaderTemplate>
                        <ContentTemplate>
                            <div style="background-image:url('images/tab/labs.png');background-repeat:no-repeat;width:600px;height:274px;position:relative;vertical-align:top;float:left">
                                <div style="width:380px;float:left;margin:5px 0px 0px 150px">
                                    <div class="tabHead">&nbsp;</div>
                                    <div style="clear:both"></div>
                                    <div class="textLabels">
                                        Select City
                                    </div>
                                    <div class="searchControls">
                                        <asp:DropDownList ID="LabCityList" Width="200px" Height="23px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="textLabels">
                                        Select Area
                                    </div>
                                    <div class="searchControls">
                                        <asp:DropDownList ID="LabAreaList" Width="200px" Height="23px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div style="clear:both"></div>
                                    <div class="textLabels">
                                        Enter Lab/ Pathology Name
                                    </div>
                                    <div class="searchControls">
                                        <asp:TextBox ID="LabNameTextBox" Width="195px" Height="20px" runat="server">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="tabButton">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/finddoctors.png"
                                        Width="117px" Height="29px" ValidationGroup="Tab3" onclick="FindDoctorsButton_Click" /></div>
                                <div style="clear:both"></div>
                                <div style="width:450px;margin:10px 0px 0px 145px;float:left;text-align:left;">
                                    Finding the Lab/Pathology centre was never so easy. Now find the best Pathology centre available close to you.<br />
                                    <b>You can conveniently track your medical history, access medical reports anywhere, anytime.</b>
                                    
                                    <uc:HighlightRequiredValidator ID="rfvCityListTab3" runat="server" Display="None" 
                                        ControlToValidate="LabCityList" InitialValue="Select" ErrorCssClass="validationErrorBorder" 
                                        ErrorMessage="Please Select City" ValidationGroup="Tab3"></uc:HighlightRequiredValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="vceCityListTab3" runat="server" TargetControlID="rfvCityListTab3" PopupPosition="Right"></ajaxToolkit:ValidatorCalloutExtender>
                                    
                                    <uc:HighlightRequiredValidator ID="rfvAreaListTab3" runat="server" Display="None" 
                                        ControlToValidate="LabAreaList" InitialValue="Select" ErrorCssClass="validationErrorBorder"
                                        ErrorMessage="Please Select Area" ValidationGroup="Tab3"></uc:HighlightRequiredValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="vceAreaListTab3" runat="server" TargetControlID="rfvAreaListTab3" PopupPosition="Right"></ajaxToolkit:ValidatorCalloutExtender>
                                    
                                    <uc:HighlightRequiredValidator ID="rfvLabName" runat="server" Display="None" 
                                        ControlToValidate="LabNameTextBox" ErrorCssClass="validationErrorBorder" 
                                        ErrorMessage="Please Enter Lab Name" ValidationGroup="Tab3"></uc:HighlightRequiredValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="vceLabName" runat="server" TargetControlID="rfvLabName" PopupPosition="Right"></ajaxToolkit:ValidatorCalloutExtender>
                                    
                                </div>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>
                </div>
                <div style="width:300px;float:right;vertical-align:top;margin-top:20px;">
                    <div style="background-image:url(images/bg-red.png);background-repeat:repeat-x;float:left;border:solid 0px black;width:330px;height:275px;">
                       <center>
                            <asp:Literal ID="LiteralImageSlider" runat="server"></asp:Literal>
                       </center>
                    </div>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
 
</asp:Content>

