using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data;

public partial class ManageSchedule : AMADBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //check if session is not null
            //check is session is of a doctor
            if (Session["UserData"] != null && Session["DoctorData"] != null)
            {
                DataTable dtUsers = (DataTable)(Session["UserData"]);
                DataTable dtDoc = (DataTable)(Session["DoctorData"]);
                Users.DoctorId = dtDoc.Rows[0]["Id"].ToString();
                DoctorCodeLabel.Text = dtDoc.Rows[0]["DoctorCode"].ToString();
                BindDoctorSchedule();
            }
            ScheduleTypeRadio.SelectedValue = "Single";
        }
    }

    protected void SubmitButton_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (ValidateScheduleDates() && ValidateSchedule())
                {
                    Doctors objDoc = new Doctors();
                    objDoc.ScheduleType = ScheduleTypeRadio.SelectedItem.Value;
                    DateTime fmDt = Convert.ToDateTime(ScheduleFromTextBox.Text);
                    DateTime toDt = Convert.ToDateTime(ScheduleToDateTextBox.Text);
                    objDoc.ScheduleFromDate = fmDt.AddHours(double.Parse(AvailableFrom.SelectedItem.Text));
                    objDoc.ScheduleToDate = toDt.AddHours(double.Parse(AvailableTo.SelectedItem.Text)).AddMinutes(59).AddSeconds(59);
                    objDoc.AvailableFrom = AvailableFrom.SelectedItem.Text + ":00";
                    objDoc.AvailableTo = AvailableTo.SelectedItem.Text + ":00";
                    objDoc.DoctorId = 1;
                    objDoc.DoctorCode = DoctorCodeLabel.Text;

                    int result = objDoc.CreateDoctorsSchedule();

                    switch (result)
                    {
                        case 0:
                            RegisterLabel.Text = "Invalid entry, kindly verify the details and try again !!!";
                            break;
                        case 1:
                            RegisterLabel.Text = "Your schedule has been saved successfully. You can view your saved schedule in below table. !!!";
                            break;
                        case 2:
                            RegisterLabel.Text = "Your schedule cannot be saved. It overlaps with existing schedule. !!!";
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
            }
        }
        BindDoctorSchedule();
    }

    private bool ValidateScheduleDates()
    {
        bool isvalid = true;
        DateTime fmDt = Convert.ToDateTime(ScheduleFromTextBox.Text);
        DateTime toDt = Convert.ToDateTime(ScheduleToDateTextBox.Text);
        if(fmDt > toDt)
            isvalid = false;
        return isvalid;
    }

    private bool ValidateSchedule()
    {
        return true;
    }
    void BindDoctorSchedule()
    {
        Doctors objDoc = new Doctors();
        Session["DoctorId"] = 1;
        objDoc.DoctorId = Convert.ToInt32(Session["DoctorId"]);
        DataSet ds = objDoc.GetDoctorScheduleById();
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDoctorSchedule.DataSource = ds;
                gvDoctorSchedule.DataBind();
            }
        }
    }

    public override Dictionary<string, string> BuildListOfValues()
    {
        Dictionary<string, string> listValues = new Dictionary<string, string>();
        //listValues.Add("FirstName", FirstNameTextBox.Text);
        
        return listValues;
    }

    protected void gvDoctorSchedule_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvDoctorSchedule.EditIndex = e.NewEditIndex;
        BindDoctorSchedule();
    }

    protected void gvDoctorSchedule_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            Label id = gvDoctorSchedule.Rows[e.RowIndex].FindControl("gvId") as Label;
            TextBox name = gvDoctorSchedule.Rows[e.RowIndex].FindControl("gvNameTextBox") as TextBox;
            TextBox code = gvDoctorSchedule.Rows[e.RowIndex].FindControl("gvCodeTextBox") as TextBox;
            DropDownList valid = gvDoctorSchedule.Rows[e.RowIndex].FindControl("gvValidDropDown") as DropDownList;
            String UpdateQuery = string.Format("UPDATE T_Country SET Cnt_Name='{0}',Cnt_Code='{1}',Valid='{2}',UPD_BY='{3}',UPD_DT='{4}' WHERE CNT_ID = {5}", name.Text, code.Text, string.Format(valid.Text == "Yes" ? "Y" : "N"), "pankaj", DateTime.Now.ToString(), id.Text);
            //H6Common obj = new H6Common();
            //obj.ExecuteQuery(UpdateQuery);
            gvDoctorSchedule.EditIndex = -1;
            BindDoctorSchedule();
            //MessageLabel.Text = "Record updated successfully";
        }
        catch (Exception ex)
        {
            //MessageLabel.Text = "Record could not be updated. Please try again";
        }
    }

    protected void gvDoctorSchedule_RowCancelling(object sender, GridViewCancelEditEventArgs e)
    {
        gvDoctorSchedule.EditIndex = -1;
        BindDoctorSchedule();
    }
}
