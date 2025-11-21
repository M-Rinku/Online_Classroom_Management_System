using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class assignments : System.Web.UI.Page
{
    string val = null;
    string e_key = null;
    string d_key = null;
    string year = null;
    string table = null;
    string name = null;
    string t_id = null;
    string roll = null;
    string depertment = null;
    string semester = null;
    public string src = null;
    string msg = null;
    string Filename = "";
    string assignment_id = null;
    string script_id = null;
    string subjectcode = null;
    string subject = null;
    string title = null;
    DateTime fromdate;
    DateTime todate;
    string questionfilepath = null;
    string submission_action = null;


    /// <summary>
    /// upload pdf file to temppdf folder
    /// </summary>
    /// <param name="Filename"></param>
    /// <returns>return new file name</returns>
    /// 


    private String upload(String Filename)
    {
        string val = null;
        try
        {
            //  Server.MapPath() it will return the server current path
            string ext = Filename.Substring(Filename.LastIndexOf("."));
            String newfilename = DateTime.Now.Ticks + ext;
            String fileserverpath = Server.MapPath("~/temp_pdf/" + newfilename);
            //saving the file to the server
            file_assignment.PostedFile.SaveAs(fileserverpath);
            val = newfilename;
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
        return val;
    }





    /// <summary>
    /// move pdf file from temp_pfd folder to assignment_ans folder
    /// </summary>
    /// <param name="Filename"></param>
    /// <returns>return 1</returns>
    /// 



    private String move(String Filename)
    {
        string val = null;
        try
        {
            
            String fileserversourcepath = Server.MapPath("~/temp_pdf/" + Filename);
            string fileserverdestinationpath = Server.MapPath("~/assignment_ans/" + Filename);
            //saving the file to the server
            System.IO.File.Move(fileserversourcepath, fileserverdestinationpath);
            val = Filename;
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
        return val;
    }




    /// <summary>
    /// delete pdf file from temp_pdf folder
    /// </summary>
    /// <param name="Filename"></param>
    /// <returns>return 1</returns>
    /// 


    private String delete(String Filename)
    {
        string val = null;
        try
        {

            String fileserverpath = Server.MapPath(Filename);
            
            //saving the file to the server
            System.IO.File.Delete(fileserverpath);
            val = "1";
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
        return val;
    }

    /// <summary>
    /// this code will run all time when this page load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ///visible profile picture which located in masterpage
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

            //hide another parts of the page
            pnl_submitassignment.Visible = false;
            pnl_upload.Visible = false;
            pnl_pdfview.Visible = false;
            lbl_subject.Visible = false;
            ddl_subject.Visible = false;

            assignment_id = Session["assignment_id"] as string;
            script_id = Session["script_id"] as string;
            e_key = Request.Cookies["ocsims_ekey"].Value;            //collect data from cookies
            d_key = encryptdecrypt.Decrypt(e_key);                  //decrypt data by the encryptdycrypt class


             //split data by"," delemeter and store another another variable
           // s_id = d_key.Split(',')[0].ToString();
            table = d_key.Split(',')[1].ToString();
            roll = d_key.Split(',')[0].ToString();
            year = d_key.Split(',')[5].ToString();
            depertment = d_key.Split(',')[6].ToString();
            semester = d_key.Split(',')[7].ToString();
            string refresh = Session["assign_refresh"] as string;
            if (!IsPostBack)
            {
                //btn_refresh.Visible = false;
                cls_teacher obj = new cls_teacher();          //create object of assign class
                obj.year = year;
                obj.department = depertment;                   //pass the value through obj object of class assign
                
                DataTable ds = obj.retrivesemester();//retrive all semester values by calling user defined function; this function located in assign class.

                //bind the data to semester dropdownlist
                ddl_semester.DataSource = ds;
                ddl_semester.DataBind();
                ddl_semester.DataTextField = "Semester";
                ddl_semester.DataValueField = "Semester";
                ddl_semester.DataBind();
                //Session["assign_refresh"] = "2";
                gv_assignments.Columns[6].Visible = true;
            }
            
            
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
    }
    protected void ddl_semester_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_semester.SelectedValue != "Select")
            {
                cls_teacher obj = new cls_teacher();          //create object of assign class
                obj.year = year;
                obj.department = depertment;                   //pass the value through obj object of class assign
                obj.semester = ddl_semester.SelectedValue;
                DataTable dt = obj.retrivesubject();
                ddl_subject.DataSource = dt;
                ddl_subject.DataBind();
                ddl_subject.DataTextField = "Subject";
                ddl_subject.DataValueField = "Subject";
                ddl_subject.DataBind();
                lbl_subject.Visible = true;
                ddl_subject.Visible = true;



            }
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
    }
    protected void ddl_subject_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_subject.SelectedValue != "Select")
            {
                assign obj = new assign();
                obj.stream = depertment;
                obj.year = year;
                obj.semester = ddl_semester.SelectedValue;     //obj calls semester droplist
                string sub = ddl_subject.SelectedValue;
                string substring = sub.Split('_')[0].ToString();
                obj.subjectcode = substring.Substring(1, substring.Length - 2);
                DataTable dt = obj.retriveassignment();
                gv_assignments.Visible = true;
                gv_assignments.DataSource = dt;
                gv_assignments.DataBind();
                pnl_select.Visible = false;
                btn_back.Visible = true;

            }
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
    }

    protected void gv_assignments_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //assignment_id = gv_assignments.SelectedRow.Cells[1].Text;
            Session["assignment_id"] = gv_assignments.SelectedRow.Cells[1].Text;
            assign obj = new assign();
            obj.roll = roll;
            obj.assignment_id = gv_assignments.SelectedRow.Cells[1].Text;
            string deadline = obj.assignment_deadline();
            CultureInfo culture = new CultureInfo("en-US");
            DateTime todate = Convert.ToDateTime(deadline, culture);
            DateTime currentdate = DateTime.Now;
            string res = obj.check_assignment();
            if (res == "0")
            {
                if (currentdate <= todate)
                {
                    pnl_searchassignment.Visible = false;
                    pnl_submitassignment.Visible = true;
                    pnl_upload.Visible = true;
                    lbl_sfn.Visible = false;
                    lbl_filename.Visible = false;
                    btn_submit.Visible = false;

                    lbl_ip.Text = HttpContext.Current.Request.UserHostAddress.ToString();
                    
                }
                else
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Deadline Over !!!!');</script>");
                }
            }
            else
            {
                Session["script_id"] = res;
                assign obj2 = new assign();
                obj2.ansscript = res;
                string action = obj2.retriveaction();
                string upload = action.Split(',')[0].ToString();
                string edit = action.Split(',')[1].ToString();
                string delete = action.Split(',')[2].ToString();

                if (upload == "0" && edit == "1" && delete == "1")
                {
                    if (currentdate <= todate)
                    {

                        pnl_searchassignment.Visible = false;
                        pnl_submitassignment.Visible = true;
                        pnl_upload.Visible = true;
                        lbl_sfn.Visible = false;
                        lbl_filename.Visible = false;
                        btn_submit.Visible = false;
                        btn_upload.Text = "Re-Upload";
                        btn_view.Visible = true;
                        btn_cncl.Visible = false;
                        lbl_ip.Text = HttpContext.Current.Request.UserHostAddress.ToString();
                        
                    }
                    else
                    {

                        pnl_searchassignment.Visible = false;
                        pnl_submitassignment.Visible = true;
                        pnl_upload.Visible = true;
                        lbl_sfn.Visible = false;
                        lbl_filename.Visible = false;
                        btn_submit.Visible = false;
                        btn_upload.Visible = false;
                        btn_view.Visible = true;
                        btn_cncl.Visible = false;
                        file_assignment.Visible = false;
                        lbl_uploadfile.Text = "View Your Assignment";
                        lbl_ip.Text = HttpContext.Current.Request.UserHostAddress.ToString();
                        
                    }
                }
                else if (upload == "2" && edit == "0" && delete == "0")
                {
                    pnl_searchassignment.Visible = false;
                    pnl_submitassignment.Visible = true;
                    pnl_upload.Visible = true;
                    lbl_sfn.Visible = false;
                    lbl_filename.Visible = false;
                    btn_submit.Visible = false;

                    lbl_ip.Text = HttpContext.Current.Request.UserHostAddress.ToString();
                    
                }
                else
                {
                    pnl_searchassignment.Visible = false;
                    pnl_submitassignment.Visible = true;
                    pnl_upload.Visible = true;
                    lbl_sfn.Visible = false;
                    lbl_filename.Visible = false;
                    btn_submit.Visible = false;
                    btn_cncl.Visible = false;
                    btn_upload.Visible = false;
                    file_assignment.Visible = false;
                    btn_view.Visible = true;
                    lbl_uploadfile.Text = "View Your Assignment";
                    lbl_ip.Text = HttpContext.Current.Request.UserHostAddress.ToString();
                    
                }
            }
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
    }
    protected void btn_upload_Click(object sender, EventArgs e)
    {
        try
        {

            if (lbl_filename.Text != "")
            {
                delete("~/temp_pdf/" + lbl_filename.Text);
            }

            if (file_assignment.HasFile)
            {
                FileInfo fi = new FileInfo(file_assignment.PostedFile.FileName);
                string extn = fi.Extension;
                if (extn == ".pdf")
                {
                    Filename = System.IO.Path.GetFileName(file_assignment.PostedFile.FileName);
                    Filename = upload(Filename);
                    iframe.Src = @"temp_pdf\" + Filename;
                    lbl_filename.Text = Filename;
                    btn_submit.Visible = true;
                    btn_upload.Text = "Re-Upload";
                    btn_cncl.Visible = true;
                    lbl_ip.Visible = true;
                    lbl_tip.Visible = true;
                    lbl_ip.Text = HttpContext.Current.Request.UserHostAddress.ToString();
                    pnl_searchassignment.Visible = false;
                    pnl_submitassignment.Visible = true;
                    pnl_upload.Visible = true;
                    lbl_sfn.Visible = true;
                    lbl_filename.Visible = true;
                    pnl_pdfview.Visible = true;


                }
                else
                {
                    file_assignment.Focus();
                }
            }
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            pnl_searchassignment.Visible = false;
            pnl_submitassignment.Visible = true;

            string iframepath = iframe.Src.ToString();

            if (iframepath != null)
            {
                FileInfo fi = new FileInfo(iframepath);
                string extn = fi.Extension;
                if (extn == ".pdf")
                {
                    if (script_id != null)
                    {
                        string result = move(lbl_filename.Text);
                        assign obj = new assign();
                        obj.ansscript = script_id;
                        string filename = obj.retriveansfilepath();
                        delete("~/assignment_ans/" + filename);
                        if (result != null)
                        {
                            assign ob = new assign();
                            ob.ansscript = script_id;
                            ob.answerfilepath = result;
                            ob.datetime = DateTime.Now.ToString();
                            ob.ip_address = HttpContext.Current.Request.UserHostAddress.ToString();
                            int res = ob.update_assign_answer_path();
                            //Session["assign_refresh"] = "1";
                            pnl_pdfview.Visible = false;
                            Response.Redirect("assignments.aspx");
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('upload successfully');</script>");
                        }
                        else
                        {
                            file_assignment.Focus();
                        }
                    }
                    else
                    {
                        string result = move(lbl_filename.Text);
                        if (result != null)
                        {
                            assign obj = new assign();
                            obj.assignment_id = assignment_id;
                           // DataSet ds = obj.retriveassignmentdetails();
                            obj.roll = roll;
                           // obj.subject = ds.Tables[0].Rows[0]["subject"].ToString();
                           // obj.subjectcode = ds.Tables[0].Rows[0]["subjectcode"].ToString();
                           // obj.title = ds.Tables[0].Rows[0]["title"].ToString();
                            //obj.fromdate = ds.Tables[0].Rows[0]["fromdate"].ToString();
                           // obj.todate = ds.Tables[0].Rows[0]["todate"].ToString();
                           // obj.questionfilepath = ds.Tables[0].Rows[0]["questionfilepath"].ToString();
                           // obj.year = ds.Tables[0].Rows[0]["year"].ToString();
                            obj.answerfilepath = result;
                           // obj.stream = ds.Tables[0].Rows[0]["stream"].ToString();
                           // obj.semester = ds.Tables[0].Rows[0]["semester"].ToString();
                            obj.submissionaction = "0,1,1";
                            //obj.t_id = ds.Tables[0].Rows[0]["t_id"].ToString();
                            // obj.marks = ds.Tables[0].Rows[0]["marks"].ToString();
                            //obj.update_action();
                            obj.datetime = DateTime.Now.ToString();
                            obj.ip_address = HttpContext.Current.Request.UserHostAddress.ToString();
                            obj.insert_assign_answer_path();
                           // Session["assign_refresh"] = "1";
                            pnl_pdfview.Visible = false;
                            Response.Write("<script>alert('upload successfully');</script>");
                            Server.Transfer("assignments.aspx");
                           
                        }
                    }

                }
                else
                {
                    file_assignment.Focus();
                }
            }
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
    }
    protected void btn_cncl_Click(object sender, EventArgs e)
    {
        try
        {
            delete("~/temp_pdf/" + lbl_filename.Text);
           // Session["assign_refresh"] = "1";
            pnl_pdfview.Visible = false;
            Response.Redirect("assignments.aspx");
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
    }
    
    protected void btn_back_Click(object sender, EventArgs e)
    {
        try
        {
            pnl_select.Visible = true;
            pnl_searchassignment.Visible = true;
            gv_assignments.Visible = false;
            btn_back.Visible = false;
            ddl_semester.SelectedIndex = 0;
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
    }
    protected void btn_view_Click(object sender, EventArgs e)
    {
        try
        {
            assign obj = new assign();
            obj.ansscript = script_id;
            string result = obj.retriveansfilepath();
            if (result != null)
            {
                pnl_pdfview.Visible = true;
                iframe.Src = @"assignment_ans\" + result;
                pnl_submitassignment.Visible = true;
            }
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
    }
}