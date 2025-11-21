using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class show_assignments : System.Web.UI.Page
{
    string e_key = null;
    string d_key = null;
    
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
            Session.Remove("position");
            pnl_assignment.Visible = false;
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
            pnl_assignment.Visible = false;
            cls_teacher obj = new cls_teacher();
            obj.year = ddl_year.SelectedValue.ToString();
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
            pnl_assignment.Visible = false;
            cls_teacher obj = new cls_teacher();
            obj.year = ddl_year.SelectedValue.ToString();
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
            obj.year = ddl_year.SelectedValue.ToString();
            obj.department = ddl_department.SelectedValue;
            obj.semester = ddl_semester.SelectedValue;
            DataTable dt = obj.retrivesubject();
            ddl_subject.DataSource = dt;
            ddl_subject.DataTextField = "Subject";
            ddl_subject.DataValueField = "Subject";
            ddl_subject.DataBind();
        }
    }
    protected void ddl_subject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_department.SelectedValue != "Select")
        {
            Session["position"] = "0";
            see(0);
            pnl_select.Visible = false;
            pnl_assignment.Visible = true;
        }
    }
    protected void see(int pos)
    {
        e_key = Request.Cookies["ocsims_ekey"].Value;            //collect data from cookies
        d_key = encryptdecrypt.Decrypt(e_key);                  //decrypt data by the encryptdycrypt class

        //split data by"," delemeter and store another another variable
        // s_id = d_key.Split(',')[0].ToString();
        cls_teacher obj = new cls_teacher();
        obj.year = ddl_year.SelectedValue;
        obj.department = ddl_department.SelectedValue;
        string sub = ddl_subject.SelectedValue;
        string substring = sub.Split('_')[0].ToString();
        obj.subject_code = substring.Substring(1, substring.Length - 2);
        obj.semester = ddl_semester.SelectedValue;
        obj.id = d_key.Split(',')[0].ToString();
        string res = obj.showassignment(pos);
        if (res == "0")
        {
            Response.Write("<script>alert('No Assignments ...');</script>");
            Server.Transfer("show_assignments.aspx");
        }
        else
        {
            lbl_script_id.Text = res.Split('#')[0].ToString();
            lbl_roll.Text = res.Split('#')[1].ToString();
            iframe.Src = @"assignment_ans\" + res.Split('#')[2].ToString();
            lbl_datetime.Text = res.Split('#')[4].ToString();
            lbl_ip.Text = res.Split('#')[5].ToString();
            string marks= res.Split('#')[3].ToString();
            string obtnmrks = res.Split('#')[6].ToString();
            if(obtnmrks!="")
            {
                txt_marks.Text = obtnmrks.Split('/')[0].ToString();
                txt_marks.Enabled = false;
                btn_checked.Visible = false;
            }
            else
            {
                img_tick.Visible = false;
                txt_marks.Enabled = true;
                btn_checked.Visible = true;
            }
            if (marks != null)
            {
                lbl_totalmarks.Text = marks.Split('/')[1].ToString();
            }
        }
    }
    
    protected void btn_checked_Click(object sender, EventArgs e)
    {
        string position = Session["position"] as string;
         int cnvrt = Int32.Parse(position);
         int add = cnvrt + 1;
         Session["position"] = add.ToString();
        cls_teacher obj = new cls_teacher();
        obj.id = lbl_script_id.Text.Trim();
        obj.marks = txt_marks.Text.Trim() + "/" + lbl_totalmarks.Text;
        obj.submission_action = "0,0,0";
        int res = obj.uploadmarks();
        see(0);
        txt_marks.Text = "";
        txt_marks.Focus();
    }



    protected void btn_next_Click(object sender, EventArgs e)
    {
        string position = Session["position"] as string;
        int cnvrt = Int32.Parse(position);
        int add = cnvrt + 1;
        Session["position"] = add.ToString();
        see(add);
        //txt_marks.Text = "";
        txt_marks.Focus();
    }
}