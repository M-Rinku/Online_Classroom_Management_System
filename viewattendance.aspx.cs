using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewattendance : System.Web.UI.Page
{
    string val = null;
    string e_key = null;
    string d_key = null;
    string s_id = null;
    string table = null;
    string name = null;
    string roll = null;
    string depertment = null;
    string semester = null;
    public string src = null;
    string msg = null;
    string Filename = "";
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
        val = Session["assignment"] as string;

        e_key = Session["key"] as string;
        d_key = encryptdecrypt.Decrypt(e_key);
        s_id = d_key.Split(',')[0].ToString();
        table = d_key.Split(',')[1].ToString();
        name = d_key.Split(',')[2].ToString();
        roll = d_key.Split(',')[3].ToString();
        depertment = d_key.Split(',')[4].ToString();
        semester = d_key.Split(',')[5].ToString();
        
        btn_back.Visible = false;
        
        //pnl_pdfview.Visible = false;
        if (val == "1")
        {
            assign obj = new assign();
            obj.roll = roll;
            DataTable ds = obj.retrivesemester();
            ddl_semester.DataSource = ds;
            ddl_semester.DataBind();
            ddl_semester.DataTextField = "Semester";
            ddl_semester.DataValueField = "Semester";
            ddl_semester.DataBind();
            Session["assignment"] = 2;
            lbl_subject.Visible = false;
            ddl_subject.Visible = false;

        }
    }

    protected void ddl_semester_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_semester.SelectedValue != "Select")
        {
            assign obj = new assign();
            obj.roll = roll;
            obj.semester = ddl_semester.SelectedValue;
            DataTable dt = obj.retrivesubject();
            ddl_subject.DataSource = dt;
            ddl_subject.DataBind();
            ddl_subject.DataTextField = "Subject";
            ddl_subject.DataValueField = "Subject";
            ddl_subject.DataBind();
            Session["assignment"] = 2;
            lbl_subject.Visible = true;
            ddl_subject.Visible = true;
        }
    }

    protected void ddl_subject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_subject.SelectedValue != "Select")
        {
            assign obj = new assign();
            obj.roll = roll;
            obj.semester = ddl_semester.SelectedValue;
            string sub = ddl_subject.SelectedValue;
            obj.subject = sub.Split(' ')[1].ToString();
            DataTable dt = obj.retriveassignment();
            gv_attendance.DataSource = dt;
            gv_attendance.DataBind();

        }
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Session["assignment"] = "1";
        pnl_viewattendance.Visible = false;
        Response.Redirect("assignments.aspx");
    }
}