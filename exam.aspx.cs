using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class exam : System.Web.UI.Page
{
    string val = null;
    string e_key = null;
    string d_key = null;
    string id = null;
    string table = null;
    string name = null;
    string roll = null;
    string subject_code = null;
    string question_set = null;
    string year = null;
    string department = null;
    string semester = null;
    int obtn_marks;
    int duration = 0;
    string ans = null;
    string msg = null;
    string upid = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["login"] != null)
        {
           // MasterPage obje = Master as MasterPage;
           // obje.visibleimg = true;

        }
        else
        {
            Response.Write("<script>alert('-----Please Login-----');</script>");
            Server.Transfer("Default.aspx");
        }
        pnl_question.Visible = false;
        string btnview = Session["btnstart_view"] as string;
        btn_see.Visible = false;
        if (Request.Cookies["ocsims_ekey"].Value != null)
        {
            string e_key = Request.Cookies["ocsims_ekey"].Value;
            if (e_key != "")
            {
                string d_key = encryptdecrypt.Decrypt(e_key);
                roll = d_key.Split(',')[0].ToString();
                year = d_key.Split(',')[5].ToString();
                department = d_key.Split(',')[6].ToString();
                semester = d_key.Split(',')[7].ToString();
                string qstring = Session["value"] as string;
                subject_code = qstring.Split(',')[0].ToString();
                id = qstring.Split(',')[1].ToString();
                upid = qstring.Split(',')[2].ToString();
                Session["value"] = qstring;
                Session.Timeout = Int32.Parse(lbl_time.Text.Trim()) + 2;
            }
        }
                if (btnview=="1")
        {
            btn_start.Visible = true;
            Session["btnstart_view"] = "2";
        }
    }
    
    


    protected void btn_submit_Click(object sender, EventArgs e)
    {
        pnl_question.Visible = true;
        pnl_time.Visible = false;
        btn_see.Visible = true;
        foreach (RepeaterItem ri in Repeater1.Items)
        {
            // RadioButton opt1 = (RadioButton)ri.FindControl("option1");
            Label sl_no = (Label)ri.FindControl("lbl_slno");
            Label question = (Label)ri.FindControl("lbl_question");
            RadioButton option1 = (RadioButton)ri.FindControl("option1");
            RadioButton option2 = (RadioButton)ri.FindControl("option2");
            RadioButton option3 = (RadioButton)ri.FindControl("option3");
            RadioButton option4 = (RadioButton)ri.FindControl("option4");
            Label lbl_correctans = (Label)ri.FindControl("lbl_ans");
            Label mark = (Label)ri.FindControl("lbl_marks");

            if (option1.Checked == true)
            {
                if (option1.Text.Equals(lbl_correctans.Text))
                {
                    string script = sl_no.Text + "/" + question.Text + "/" + option1.Text + "/" + option2.Text + "/" + option3.Text + "/" + option4.Text + "/" + lbl_correctans.Text + "/" + option1.Text + "/" + mark.Text;
                    ans = ans + "%" + script;
                    obtn_marks = obtn_marks + Convert.ToInt32(mark.Text);
                }
                else
                {
                    string script = sl_no.Text + "/" + question.Text + "/" + option1.Text + "/" + option2.Text + "/" + option3.Text + "/" + option4.Text + "/" + lbl_correctans.Text + "/" + option1.Text + "/" + mark.Text;
                    ans = ans + "%" + script;
                }
            }
            else if (option2.Checked == true)
            {
                if (option2.Text.Equals(lbl_correctans.Text))
                {
                    string script = sl_no.Text + "/" + question.Text + "/" + option1.Text + "/" + option2.Text + "/" + option3.Text + "/" + option4.Text + "/" + lbl_correctans.Text + "/" + option2.Text + "/" + mark.Text;
                    ans = ans + "%" + script;
                    obtn_marks = obtn_marks + Convert.ToInt32(mark.Text);
                }
                else
                {
                    string script = sl_no.Text + "/" + question.Text + "/" + option1.Text + "/" + option2.Text + "/" + option3.Text + "/" + option4.Text + "/" + lbl_correctans.Text + "/" + option2.Text + "/" + mark.Text;
                    ans = ans + "%" + script;
                }
            }
            else if (option3.Checked == true)
            {
                if (option3.Text.Equals(lbl_correctans.Text))
                {
                    string script = sl_no.Text + "/" + question.Text + "/" + option1.Text + "/" + option2.Text + "/" + option3.Text + "/" + option4.Text + "/" + lbl_correctans.Text + "/" + option3.Text + "/" + mark.Text;
                    ans = ans + "%" + script;
                    obtn_marks = obtn_marks + Convert.ToInt32(mark.Text);
                }
                else
                {
                    string script = sl_no.Text + "/" + question.Text + "/" + option1.Text + "/" + option2.Text + "/" + option3.Text + "/" + option4.Text + "/" + lbl_correctans.Text + "/" + option3.Text + "/" + mark.Text;
                    ans = ans + "%" + script;
                }
            }
            else if (option4.Checked == true)
            {
                if (option4.Text.Equals(lbl_correctans.Text))
                {
                    string script = sl_no.Text + "/" + question.Text + "/" + option1.Text + "/" + option2.Text + "/" + option3.Text + "/" + option4.Text + "/" + lbl_correctans.Text + "/" + option4.Text + "/" + mark.Text;
                    ans = ans + "%" + script;
                    obtn_marks = obtn_marks + Convert.ToInt32(mark.Text);
                }
                else
                {
                    string script = sl_no.Text + "/" + question.Text + "/" + option1.Text + "/" + option2.Text + "/" + option3.Text + "/" + option4.Text + "/" + lbl_correctans.Text + "/" + option4.Text + "/" + mark.Text;
                    ans = ans + "%" + script;
                }
            }
            else
            {
                string script = sl_no.Text + "/" + question.Text + "/" + option1.Text + "/" + option2.Text + "/" + option3.Text + "/" + option4.Text + "/" + lbl_correctans.Text + "/@/" + mark.Text;
                ans = ans + "%" + script;
            }
        }
            clsexam obj = new clsexam();
            obj.roll = roll;

        obj.up_id = upid;
        obj.submittime = DateTime.Now.ToString();
            obj.answerpaper = ans;
            obj.marks = obtn_marks.ToString();
            obj.uploadanswerscript();
        
        /*
        foreach (RepeaterItem ri in Repeater1.Items)
        {
            RadioButton opt2 = (RadioButton)ri.FindControl("option2");
            Label mark = (Label)ri.FindControl("lbl_marks");
            Label lbl_correctans = (Label)ri.FindControl("lbl_ans");
            if (opt2.Checked == true)
            {
                if (opt2.Text.Equals(lbl_correctans.Text))
                {
                    
                    obtn_marks = obtn_marks + Convert.ToInt32(mark.Text);
                }
               
            }

        }
        foreach (RepeaterItem ri in Repeater1.Items)
        {

            RadioButton opt3 = (RadioButton)ri.FindControl("option3");
            Label mark = (Label)ri.FindControl("lbl_marks");
            Label lbl_correctans = (Label)ri.FindControl("lbl_ans");
            if (opt3.Checked == true)
            {
                if (opt3.Text.Equals(lbl_correctans.Text))
                {
                   
                    obtn_marks = obtn_marks + Convert.ToInt32(mark.Text);
                }
                
            }
        }
        foreach (RepeaterItem ri in Repeater1.Items)
        {
            RadioButton opt4 = (RadioButton)ri.FindControl("option4");
            Label mark = (Label)ri.FindControl("lbl_marks");
            Label lbl_correctans = (Label)ri.FindControl("lbl_ans");
            if (opt4.Checked == true)
            {
                if (opt4.Text.Equals(lbl_correctans.Text))
                {
                   
                    obtn_marks = obtn_marks + Convert.ToInt32(mark.Text);
                }
                
            }
        }*/
        btn_submit.Visible = false;
        btn_see.Visible = false;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Answer Submitted Your Score is :- " + obtn_marks.ToString() + "');</script>");
    }

    protected void btn_start_Click(object sender, EventArgs e)
    {
       
        
        string ampm = null;
        clsexam obj = new clsexam();
        obj.department = department;
        obj.semester = semester;
        obj.year = year;
        obj.subjectcode = subject_code;
        obj.t_id = id;
        obj.up_id = upid;
        DataTable dt = obj.retrivequestionpaper();
        DataSet schedule = obj.retriveexamheader();
        lbl_qheader.Text = schedule.Tables[0].Rows[0]["questionheader"].ToString();
        duration =int.Parse(schedule.Tables[0].Rows[0]["duration"].ToString());
        string time = schedule.Tables[0].Rows[0]["time"].ToString();
        
        lbl_time.Text = duration.ToString();
        
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        pnl_question.Visible = true;
        btn_start.Visible = false;
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "countdown_clock()", true);
    }



    protected void btn_see_Click(object sender, EventArgs e)
    {
        pnl_question.Visible = true;
        pnl_time.Visible = false;
        foreach (RepeaterItem ri in Repeater1.Items)
        {
            RadioButton opt1 = (RadioButton)ri.FindControl("option1");
            Label mark = (Label)ri.FindControl("lbl_marks");
            Label lbl_correctans = (Label)ri.FindControl("lbl_ans");
            if (opt1.Checked == true)
            {
                if (opt1.Text.Equals(lbl_correctans.Text))
                {

                    opt1.ForeColor = System.Drawing.Color.Green;
                    
                }
                else
                {
                    opt1.ForeColor = System.Drawing.Color.Red;
                    lbl_correctans.Visible = true;
                    lbl_correctans.Text = "Correct answer is :" + lbl_correctans.Text;
                    lbl_correctans.ForeColor = System.Drawing.Color.Green;

                }
            }
        }
        foreach (RepeaterItem ri in Repeater1.Items)
        {
            RadioButton opt2 = (RadioButton)ri.FindControl("option2");
            Label mark = (Label)ri.FindControl("lbl_marks");
            Label lbl_correctans = (Label)ri.FindControl("lbl_ans");
            if (opt2.Checked == true)
            {
                if (opt2.Text.Equals(lbl_correctans.Text))
                {
                    opt2.ForeColor = System.Drawing.Color.Green;
                    
                }
                else
                {
                    opt2.ForeColor = System.Drawing.Color.Red;
                    lbl_correctans.Visible = true;
                    lbl_correctans.Text = "Correct answer is :" + lbl_correctans.Text;
                    lbl_correctans.ForeColor = System.Drawing.Color.Green;

                }
            }

        }
        foreach (RepeaterItem ri in Repeater1.Items)
        {

            RadioButton opt3 = (RadioButton)ri.FindControl("option3");
            Label mark = (Label)ri.FindControl("lbl_marks");
            Label lbl_correctans = (Label)ri.FindControl("lbl_ans");
            if (opt3.Checked == true)
            {
                if (opt3.Text.Equals(lbl_correctans.Text))
                {
                    opt3.ForeColor = System.Drawing.Color.Green;
                    
                }
                else
                {
                    opt3.ForeColor = System.Drawing.Color.Red;
                    lbl_correctans.Visible = true;
                    lbl_correctans.Text = "Correct answer is :" + lbl_correctans.Text;
                    lbl_correctans.ForeColor = System.Drawing.Color.Green;

                }
            }
        }
        foreach (RepeaterItem ri in Repeater1.Items)
        {
            RadioButton opt4 = (RadioButton)ri.FindControl("option4");
            Label mark = (Label)ri.FindControl("lbl_marks");
            Label lbl_correctans = (Label)ri.FindControl("lbl_ans");
            if (opt4.Checked == true)
            {
                if (opt4.Text.Equals(lbl_correctans.Text))
                {
                    opt4.ForeColor = System.Drawing.Color.Green;
                    
                }
                else
                {
                    opt4.ForeColor = System.Drawing.Color.Red;
                    lbl_correctans.Visible = true;
                    lbl_correctans.Text = "Correct answer is :" + lbl_correctans.Text;
                    lbl_correctans.ForeColor = System.Drawing.Color.Green;

                }
            }
        }
        btn_submit.Visible = false;
        btn_see.Visible = false;
    }
}