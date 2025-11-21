using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class question_upload : System.Web.UI.Page
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
        pnl_select.Visible = false;
        pnl_upload.Visible = false;
        if(!IsPostBack)
        {
            pnl_select.Visible = true;
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
            // btn_select.Visible = false;
            pnl_select.Visible = true;
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
            // btn_select.Visible = false;
            pnl_select.Visible = true;
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
            // btn_select.Visible = false;
            pnl_select.Visible = true;
            cls_teacher obj = new cls_teacher();
            obj.year = ddl_year.SelectedValue.ToString();
            obj.department = ddl_department.SelectedValue;
            obj.semester = ddl_semester.SelectedValue;
            DataTable dt = obj.retrivesubject();
            ddl_subject_code.DataSource = dt;
            ddl_subject_code.DataTextField = "Subject";
            ddl_subject_code.DataValueField = "Subject";
            ddl_subject_code.DataBind();
        }
    }

    protected void ddl_subject_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_department.SelectedValue != "Select")
        {
            string subject = ddl_subject_code.SelectedValue;
            string substring = subject.Split('_')[0].ToString();
            hdn_subcode.Value = substring.Substring(1, substring.Length - 2);
            cls_teacher obj = new cls_teacher();
            obj.year = ddl_year.SelectedValue.ToString();
            obj.department = ddl_department.SelectedValue;
            obj.semester = ddl_semester.SelectedValue;
            obj.subject_code = hdn_subcode.Value;
            int courseid = obj.retrivecourseid();
            hdn_subcode.Value = courseid.ToString();
            pnl_select.Visible = true;
            pnl_upload.Visible = false;
            ddl_questiona_set.Focus();
        }
    }




    protected void ddl_questiona_set_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_department.SelectedValue != "--choose set--")
        {
            pnl_select.Visible = false;
            pnl_upload.Visible = true;
            gvbind();
        }
    }
    protected void btn_addquestion_Click(object sender, EventArgs e)
    {
        cls_teacher obj = new cls_teacher();
        obj.id = hdn_subcode.Value;
        obj.question_set = ddl_questiona_set.SelectedValue;
        //obj.year = ddl_year.SelectedValue;
        e_key = Request.Cookies["ocsims_ekey"].Value;            //collect data from cookies
        d_key = encryptdecrypt.Decrypt(e_key);                  //decrypt data by the encryptdycrypt class


        //split data by"," delemeter and store another another variable
        
        
        obj.teacher = d_key.Split(',')[0].ToString();
        string question = txt_questiontype.Text.Trim();
        string opt1= txt_opt_a.Text.Trim();
        string opt2= txt_opt_b.Text.Trim();
        string opt3= txt_opt_c.Text.Trim();
        string opt4= txt_opt_d.Text.Trim();
        obj.question = question.Replace("'","''");
        obj.opt_a = opt1.Replace("'", "''");
        obj.opt_b = opt2.Replace("'", "''");
        obj.opt_c = opt3.Replace("'", "''");
        obj.opt_d = opt4.Replace("'", "''");
        int ans = int.Parse(rdbtn_correctans.SelectedValue);
        if(ans==1)
        {
            obj.correct_answer = opt1.Replace("'", "''");
        }
        else if(ans==2)
        {
            obj.correct_answer = opt2.Replace("'", "''");
        }
        else if(ans==3)
        {
            obj.correct_answer = opt3.Replace("'", "''");
        }
        else
        {
            obj.correct_answer = opt4.Replace("'", "''");
        }
        obj.marks = txt_marks.Text.Trim();
        int result = obj.add_question();
        if (result == 1)
        {
            gvbind();
            txt_questiontype.Text = "";
            txt_opt_a.Text = "";
            txt_opt_b.Text = "";
            txt_opt_c.Text = "";
            txt_opt_d.Text = "";
            rdbtn_correctans.ClearSelection();
            pnl_select.Visible = false;
            pnl_upload.Visible = true;
            txt_questiontype.Focus();
        }
    }

    

    


        protected void gvbind()
        {
            cls_teacher obj = new cls_teacher();
            obj.department = ddl_department.SelectedValue;
            obj.semester = ddl_semester.SelectedValue;
        obj.year = ddl_year.SelectedValue;
            string subject = ddl_subject_code.SelectedValue;
            string substring = subject.Split('_')[0].ToString();
            obj.subject_code = substring.Substring(1, substring.Length - 2);
            DataTable dt = obj.gvbindingforquestion();
            GridView1.DataSource = dt;
            GridView1.DataBind();
       // Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "scrollWin()", true);
       
    }
    




    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        gvbind();
        pnl_select.Visible = false;
        pnl_upload.Visible = true;
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        gvbind();
        pnl_select.Visible = false;
        pnl_upload.Visible = true;
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_Id") as Label;
        
        cls_teacher obj = new cls_teacher();
        obj.id = id.Text.Trim();
        int result = obj.delete_question();
        if (result == 1)
        {
            pnl_select.Visible = false;
            pnl_upload.Visible = true;
            gvbind();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Deleted successfully.');</script>");

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Error occured!!!.');</script>");
        }
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
        TextBox qset = GridView1.Rows[e.RowIndex].FindControl("txt_qset") as TextBox;
        TextBox question = GridView1.Rows[e.RowIndex].FindControl("txt_question") as TextBox;
        TextBox opta = GridView1.Rows[e.RowIndex].FindControl("txt_optna") as TextBox;
        TextBox optb = GridView1.Rows[e.RowIndex].FindControl("txt_optnb") as TextBox;
        TextBox optc = GridView1.Rows[e.RowIndex].FindControl("txt_optnc") as TextBox;
        TextBox optd = GridView1.Rows[e.RowIndex].FindControl("txt_optnd") as TextBox;
        TextBox ans = GridView1.Rows[e.RowIndex].FindControl("txt_ans") as TextBox;
        TextBox marks = GridView1.Rows[e.RowIndex].FindControl("txt_marks") as TextBox;
        cls_teacher obj = new cls_teacher();
        obj.id = id.Text;
        obj.question_set = qset.Text;
        obj.question = question.Text;
        obj.opt_a = opta.Text;
        obj.opt_b = optb.Text;
        obj.opt_c = optc.Text;
        obj.opt_d = optd.Text;
        obj.correct_answer = ans.Text;
        obj.marks = marks.Text;
        int result = obj.update_question();
        if (result == 1)
        {
            pnl_select.Visible = false;
            pnl_upload.Visible = true;
            gvbind();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Updated successfully.');</script>");

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Error occured!!!.');</script>");
        }


        GridView1.EditIndex = -1;
        gvbind();
        pnl_select.Visible = false;
        pnl_upload.Visible = true;
    }
}