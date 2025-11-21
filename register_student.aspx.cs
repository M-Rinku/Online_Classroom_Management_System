using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register_student : System.Web.UI.Page
{
    string msg = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["login"] != null)
        {
            MasterPage obje = Master as MasterPage;
            obje.visibleimg = true;

        }
        else
        {
            Response.Write("<script>alert('-----Please Login-----');</script>");
            Server.Transfer("Default.aspx");
        }
        if (!IsPostBack)
        {
            
            var now = DateTimeOffset.Now;
            var years = Enumerable.Range(0, 6).Select(i => now.AddYears(-i).ToString("yyyy"));
            ddl_year.DataSource = years;
            ddl_year.DataBind();
            ddl_year.Items.Insert(0, "Select");
            

        }
    }
    protected void ddl_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_year.SelectedValue != "Select")
        {
            cls_teacher obj = new cls_teacher();
            obj.year = ddl_year.SelectedValue.ToString();
            DataTable dt = obj.retrivedepartment();
            ddl_depertment.DataSource = dt;
            ddl_depertment.DataTextField = "department";
            ddl_depertment.DataValueField = "department";
            ddl_depertment.DataBind();
        }
    }

    protected void ddl_depertment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_depertment.SelectedValue != "Select")
        {
            
            cls_teacher obj = new cls_teacher();
            obj.year = ddl_year.SelectedValue.ToString();
            obj.department = ddl_depertment.SelectedValue;
            DataTable dt = obj.retrivesemester();
            ddl_semester.DataSource = dt;
            ddl_semester.DataTextField = "Semester";
            ddl_semester.DataValueField = "Semester";
            ddl_semester.DataBind();
        }
    }

    
    

    protected void btn_login_Click(object sender, EventArgs e)
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[8];
        var random = new Random();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        var finalString = new String(stringChars);
        clsadmin obj = new clsadmin();
        obj.password = finalString.ToString();
        obj.name = txt_name.Text.Trim();
        obj.roll = txt_roll.Text.Trim();
        obj.email = txt_email.Text.Trim();
        obj.mob_no = txt_mob.Text.Trim();
        obj.address = txt_address.Text.Trim();
        obj.department = ddl_depertment.SelectedValue;
        obj.semester = ddl_semester.SelectedValue;
        obj.year = ddl_year.SelectedValue;
        obj.profilepicture = "Site_images/default_profilepic.png";
        string result = obj.insertstudent();
        if (result == "0")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Something Wrong Please Try Again.');</script>");
        }
        else if (result == "9")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Student Already Exist');</script>");
        }
        else
        {
            string store = txt_email.Text.Trim();
            clsmail mailobj = new clsmail();
            mailobj.to = store;
            mailobj.Message = "Your ID is :==" + result + ". And your password is :==" + finalString.ToString();
            mailobj.send();
            txt_name.Text = "";
            txt_roll.Text = "";
            txt_email.Text = "";
            txt_mob.Text = "";
            txt_address.Text = "";
            ddl_year.SelectedIndex = 0;
            ddl_depertment.ClearSelection();
            ddl_semester.ClearSelection();
            txt_name.Focus();
        }
    }

}