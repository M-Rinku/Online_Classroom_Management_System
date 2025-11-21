using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class exam_schedule : System.Web.UI.Page
{
    string msg = null;
    string e_key = null;
    string d_key = null;
    private String upload(String Filename)
    {
        string val = null;
        try
        {
            //  Server.MapPath() it will return the server current path
            string ext = Filename.Substring(Filename.LastIndexOf("."));
            String newfilename = DateTime.Now.Ticks + ext;
            String fileserverpath = Server.MapPath("~/assignments/" + newfilename);
            //saving the file to the server
            file_question.PostedFile.SaveAs(fileserverpath);
            val = newfilename;
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
        return val;
    }
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
        if (Session["refresh"] == null)
        {
            var now = DateTimeOffset.Now;
            var years = Enumerable.Range(1, 6).Select(i => now.AddYears(-i).ToString("yyyy"));
            ddl_year.DataSource = years;
            ddl_year.DataBind();
            ddl_year.Items.Insert(0, "Select");
            Session["refresh"] = 1;
        }
    }

    protected void ddl_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_year.SelectedValue != "Select")
        {
            cls_teacher obj = new cls_teacher();
            DataTable dt = obj.retrivedepartment();
            ddl_department.DataSource = dt;
            ddl_department.DataTextField = "department";
            ddl_department.DataValueField = "department";
            ddl_department.DataBind();
        }
    }
    protected void ddl_department_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_department.SelectedValue != "Select")
        {

            cls_teacher obj = new cls_teacher();
            obj.department = ddl_department.SelectedValue;
            DataTable dt = obj.retrivesemester();
            ddl_semester.DataSource = dt;
            ddl_semester.DataTextField = "Semester";
            ddl_semester.DataValueField = "Semester";
            ddl_semester.DataBind();
        }
    }

    protected void ddl_semester_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_department.SelectedValue != "Select")
        {
            cls_teacher obj = new cls_teacher();
            obj.department = ddl_department.SelectedValue;
            obj.semester = ddl_semester.SelectedValue;
            DataTable dt = obj.retrivesubject();
            ddl_subject_code.DataSource = dt;
            ddl_subject_code.DataTextField = "Subject";
            ddl_subject_code.DataValueField = "Subject";
            ddl_subject_code.DataBind();
        }
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {

        cls_teacher obj = new cls_teacher();
        obj.department = ddl_department.SelectedValue;
        obj.semester = ddl_semester.SelectedValue;
        string sub = ddl_subject_code.SelectedValue;
        string substring = sub.Split('_')[0].ToString();
        obj.subject_code = substring.Substring(1, substring.Length - 2);
        obj.subject = sub.Split('_')[1].ToString();
        obj.title = txt_title.Text.Trim();
        obj.fromdate = DateTime.Now.ToString();
        obj.year = ddl_year.SelectedValue;
        string date = txt_todate.Text;
        string day = date.Split('-')[2].ToString();
        string month = date.Split('-')[1].ToString();
        string year = date.Split('-')[0].ToString();
        obj.todate = month + "/" + day + "/" + year + " 11:59:59 PM";
        if (file_question.HasFile)
        {
            string filename = upload(file_question.PostedFile.FileName);
            obj.questionfilepath = "assignments/" + filename;
        }
        else
        {
            obj.questionfilepath = null;
        }
        obj.submission_action = "1,0,0";
        e_key = Request.Cookies["ocsims_ekey"].Value;            //collect data from cookies
        d_key = encryptdecrypt.Decrypt(e_key);                  //decrypt data by the encryptdycrypt class


        //split data by"," delemeter and store another another variable


        obj.id = d_key.Split(',')[0].ToString();
        obj.marks = "0/" + txt_marks.Text.Trim();
        int result = obj.uploadassignment();
        if (result == 1)
        {
            Response.Redirect("teachermainmenu.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Internal Error ! Please try again...');</script>");

        }

    }
}