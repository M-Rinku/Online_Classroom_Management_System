using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class startexam : System.Web.UI.Page
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
    int obtn_marks;
    int duration = 0;
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
        e_key = Request.Cookies["ocsims_ekey"].Value;            //collect data from cookies
        d_key = encryptdecrypt.Decrypt(e_key);                  //decrypt data by the encryptdycrypt class
        

        //split data by"," delemeter and store another variable
       
        table = d_key.Split(',')[1].ToString();
        roll = d_key.Split(',')[0].ToString();
        depertment = d_key.Split(',')[6].ToString();
        semester = d_key.Split(',')[7].ToString();
        //string ampm = null;
        clsexam obj = new clsexam();
        obj.department = depertment;
        obj.semester = semester;
        obj.year= d_key.Split(',')[5].ToString();
       // obj.subjectcode = "mca101";
        DataTable schedule = obj.schedule();
        //string teachercode=
        gv_exam.DataSource = schedule;
        gv_exam.DataBind();
        
    }

    protected void gv_exam_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["btnstart_view"] = "1";
        
        string select = gv_exam.SelectedRow.Cells[2].Text;
        string teacher = gv_exam.SelectedRow.Cells[3].Text;
        string t_id_withbkt = teacher.Split('-')[1].ToString();
        string t_id=t_id_withbkt.Substring(1, t_id_withbkt.Length - 2);
        string upid = gv_exam.SelectedRow.Cells[1].Text;
        clsexam obb = new clsexam();
        obb.up_id = upid;
        obb.roll = roll;
        int result = obb.checkanswerscript();
        if (result == 0)
        {
            Session["value"] = select + "," + t_id + "," + upid;
            Session.Timeout = Int32.Parse(gv_exam.SelectedRow.Cells[6].Text.Trim());
            //System.Diagnostics.Process.Start("notepad.exe");
            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1024);var Mtop = (screen.height/2)-(1024);window.open( 'exam.aspx?subcode=" + select+ "', null, 'status=no,resizable=no,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
            //Response.Write("<script>window.open ('exam.aspx?subcode=" + select + "','_blank');</script>");
            Response.Redirect("exam.aspx");
        }
        else
        {
            //view button;
            Response.Write("<script>alert('-----You have already Submitted Your Paper-----');</script>");
            Server.Transfer("startexam.aspx");
        }
    }


}