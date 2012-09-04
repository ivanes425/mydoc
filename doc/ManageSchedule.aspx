<%@ Page Title="" Language="C#" MasterPageFile="~/amad.master" AutoEventWireup="true" CodeFile="ManageSchedule.aspx.cs" Inherits="ManageSchedule" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/usercontrols/searchDocs.ascx" TagName="search" TagPrefix="doc" %>
<asp:Content ID="Content3" ContentPlaceHolderID="dataContent" Runat="Server">
<asp:UpdatePanel ID="updUserProfilePanel" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <script language="javascript">
            function checkBackDate(sender,args)
            {
                if (sender._selectedDate < new Date()) 
                {
                    alert("You cannot select date older than today!");
                    sender._selectedDate = new Date(); 
                    sender._textbox.set_Value(sender._selectedDate.format(sender._format))
                }
            }

            function checkFromAndToDate() {
                var isvalid = true;
                var fmdate = document.getElementById('<%=ScheduleFromTextBox.ClientID %>').value;
                var todate = document.getElementById('<%=ScheduleToDateTextBox.ClientID %>').value;
                if (fmdate == "") {
                    alert("Schedule from date cannot be blank!");
                    isvalid = false;
                    return false;
                }
                if (todate == "") {
                    alert("Schedule to date cannot be blank!");
                    isvalid = false;
                    return false;
                }
                if (fmdate != "" && todate != "") {
                    var fm = Date.parse(fmdate);
                    var to = Date.parse(todate);
                    if (fm > to) {
                        alert("Schedule from date cannot be greater than schedule to date!");
                        isvalid = false;
                        return false;
                    }
                }
                if (!isvalid)
                    return false;
                else {
                    var avfm = document.getElementById('<%=AvailableFrom.ClientID%>');
                    var avlfm = avfm.options[avfm.selectedIndex].value;
                    var avto = document.getElementById('<%=AvailableTo.ClientID%>');
                    var avlto = avto.options[avto.selectedIndex].value;
                    var conf = confirm('You have selected following schedule:- From Date: ' + fmdate + ' & To Date: ' + todate + ' from ' + avlfm + ':00 hours to ' + avlto + ':00 hours. Click ok to continue else click cancel and change your schedule');
                    if (!conf)
                        return false;
                    else
                        return true;
                }
            }
        </script>
        <div id="innerContent">
            <div id="column1">
                <div class="title">
                    Manage Your Schedule
                </div>
                <div class="clear"></div>
                <div class="fleft">
                    <ul>
                        <li>
                            <span style="color:Red">*&nbsp;</span>Schedule Type<br />
                            <asp:RadioButtonList id="ScheduleTypeRadio" BorderColor="Black" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Single Day" Value="Single"></asp:ListItem>
                                <asp:ListItem Text="Multiple Day" Value="Multiple"></asp:ListItem>
                            </asp:RadioButtonList>
                        </li>
                        <li>
                            <span style="color:Red">*&nbsp;</span>Schedule From Date<br />
                            <asp:TextBox ID="ScheduleFromTextBox" runat="server" MaxLength="20" ValidationGroup="schedule" Width="200px"></asp:TextBox>
                            <img src="images/calgrey.gif" id="fmDate" />
                            <ajaxToolkit:CalendarExtender ID="FromDate" OnClientDateSelectionChanged="checkBackDate" runat="server" TargetControlID="ScheduleFromTextBox" PopupButtonID="fmDate"></ajaxToolkit:CalendarExtender>
                        </li>
                        <li>
                            <span style="color:Red">*&nbsp;</span>Available From (in hours)<br />
                            <asp:DropDownList ID="AvailableFrom" Width="220px" Height="26px" runat="server">
                                <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                <asp:ListItem Text="00" Value="00"></asp:ListItem>
                            </asp:DropDownList>
                        </li>
                        <li>
                            <span style="color:Red;font-size:smaller;float:left">Fields marked with (*) are mandatory</span>
                        </li>
                    </ul>
                </div>
                <div class="fright">
                    <ul>
                        <li>
                            <span style="color:Red">&nbsp;</span>Doctor Code<br />
                            <asp:TextBox ID="DoctorCodeLabel" ReadOnly="true" BorderColor="White" runat="server"></asp:TextBox>
                        </li>
                        <li>
                            <span style="color:Red">*&nbsp;</span>Schedule To Date<br />
                            <asp:TextBox ID="ScheduleToDateTextBox" runat="server" MaxLength="20" ValidationGroup="schedule" Width="200px"></asp:TextBox>
                            <img src="images/calgrey.gif" id="toDt" />
                            <ajaxToolkit:CalendarExtender ID="toDate" runat="server" OnClientDateSelectionChanged="checkBackDate" TargetControlID="ScheduleToDateTextBox" PopupButtonID="toDt"></ajaxToolkit:CalendarExtender>
                        </li>
                        <li>
                            <span style="color:Red">*&nbsp;</span>Available To (in hours)<br />
                            <asp:DropDownList ID="AvailableTo" Width="220px" Height="26px" runat="server">
                                <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                <asp:ListItem Text="00" Value="00"></asp:ListItem>
                            </asp:DropDownList>
                            
                        </li>
                        <li>
                            <asp:ImageButton ID="SubmitButton" runat="server" ImageUrl="~/images/finddoctors.png" OnClientClick="javascript:return checkFromAndToDate();" ValidationGroup="Activate" OnClick="SubmitButton_Click" />
                            <br />
                        </li>
                    </ul>
                </div>
                <div class="clear"></div>
                <div class="all">
                    <div class="validation" style="padding:10px 0px 0px 5px;">
                        <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" ControlToValidate="ScheduleFromTextBox" ErrorMessage="Please Enter Schedule From Date"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvToDate" runat="server" ControlToValidate="ScheduleToDateTextBox" ErrorMessage="Please Enter Schedule To Date"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvFromTime" runat="server" ControlToValidate="AvailableFrom" ErrorMessage="Please Enter Available From Time"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvToTime" runat="server" ControlToValidate="AvailableTo" ErrorMessage="Please Enter Available To Time"></asp:RequiredFieldValidator>
                        
                        <asp:ValidationSummary runat="server" ID="registerValidSummary" DisplayMode="List" ShowSummary="true" />
                        <asp:Label ID="RegisterLabel" runat="server" Font-Bold="true" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="clear"></div>
                <div class="all">
                    <h3>Your existing schedule</h3>
                    <div class="clear"></div>
                    <asp:GridView ID="gvDoctorSchedule" runat="server" AutoGenerateEditButton="True" 
                        OnRowEditing="gvDoctorSchedule_RowEditing" OnRowUpdating="gvDoctorSchedule_RowUpdating" 
                        OnRowCancelingEdit="gvDoctorSchedule_RowCancelling" AutoGenerateColumns="false">
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="gvIdLabel" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="gvDocIdLabel" runat="server" Text='<%#Eval("DoctorId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Schedule From Dt">
                                <ItemTemplate>
                                    <asp:Label ID="gvSFDLabel" runat="server" Text='<%#Eval("ScheduleFromDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Schedule To Dt">
                                <ItemTemplate>
                                    <asp:Label ID="gvSTDLabel" runat="server" Text='<%#Eval("ScheduleToDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Available From">
                                <ItemTemplate>
                                    <asp:Label ID="gvAFLabel" runat="server" Text='<%#Eval("AvailableFrom") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Available To">
                                <ItemTemplate>
                                    <asp:Label ID="gvATLabel" runat="server" Text='<%#Eval("AvailableTo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div id="column2">
                <div>
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

