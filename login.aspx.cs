using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    string msg = null;
    string id_name = null;
    string tbl = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        { 
        string q = Request.QueryString["who"];//it collect data from url querystring who try to login,this data refer from default html page.
        
        if(q=="std")
        {
            id_name = "roll";
            tbl = "student";
        }
        else if(q=="tchr")
        {
            id_name = "t_id";
            tbl = "teacher";
        }
        else
        {
            id_name = "admin_id";
            tbl = "admin";
        }
        
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }

    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
        try
        {
            clslogin obj = new clslogin();
            obj.id = txt_id.Text.Trim();
            obj.password = txt_pass.Value.Trim();
            obj.idname = id_name;
            obj.tablename = tbl;
            int result = obj.login();
            if (result == 1 && tbl == "student")
            {
                student obj2 = new student();
                obj2.roll = txt_id.Text.Trim();
                DataSet dtl = obj2.getallstddetail();
               
                string table = tbl;
                string name = dtl.Tables[0].Rows[0]["name"].ToString();
                string roll = dtl.Tables[0].Rows[0]["roll"].ToString();
                string email = dtl.Tables[0].Rows[0]["email"].ToString();
                string phone = dtl.Tables[0].Rows[0]["mob_no"].ToString();
                string year = dtl.Tables[0].Rows[0]["year"].ToString();
                string depertment = dtl.Tables[0].Rows[0]["department"].ToString();
                string semester = dtl.Tables[0].Rows[0]["semester"].ToString();
                string profilepic = dtl.Tables[0].Rows[0]["profilepicture"].ToString();
                string extend = null;
                string e_key = encryptdecrypt.encrypt(roll + "," + table + "," + name + "," + email + "," + phone + "," + year + "," + depertment + "," + semester + "," + profilepic + "," + extend);
                Response.Cookies["ocsims_ekey"].Value = e_key;
                Session["login"] = roll;
                Session.Timeout = 60;
                Response.Redirect("mainmenu.aspx");
            }
            else if (result == 1 && tbl == "teacher")
            {
                cls_teacher obj2 = new cls_teacher();
                obj2.id = txt_id.Text.Trim();
                DataSet dtl = obj2.getteacherdetail();
                string table = tbl;
                string name = dtl.Tables[0].Rows[0]["name"].ToString();
                string id = dtl.Tables[0].Rows[0]["t_id"].ToString();
                string email = dtl.Tables[0].Rows[0]["email"].ToString();
                string phone = dtl.Tables[0].Rows[0]["mob_no"].ToString();
                string regno = dtl.Tables[0].Rows[0]["registration_no"].ToString();
                string depertment = null;
                string semester = null;
                string profilepic = dtl.Tables[0].Rows[0]["profilepicture"].ToString();
                string extend = null;
                string e_key = encryptdecrypt.encrypt(id + "," + table + "," + name + "," + email + "," + phone + "," + regno + "," + depertment + "," + semester + "," + profilepic + "," + extend);
                Response.Cookies["ocsims_ekey"].Value = e_key;
                Session["login"] = txt_id.Text.Trim();
                Response.Redirect("teachermainmenu.aspx");
            }
            else if (result == 1 && tbl == "admin")
            {
                clsadmin obj2 = new clsadmin();
                obj2.id = txt_id.Text.Trim();
                DataSet dtl = obj2.getalladmindetail();
                string table = tbl;
                string name = dtl.Tables[0].Rows[0]["name"].ToString();
                string id = dtl.Tables[0].Rows[0]["admin_id"].ToString();
                string email = null;
                string phone = null;
                string regno = null;
                string depertment = null;
                string semester = null;
                string profilepic = dtl.Tables[0].Rows[0]["profilepicture"].ToString();
                string extend = null;
                string e_key = encryptdecrypt.encrypt(id + "," + table + "," + name + "," + email + "," + phone + "," + regno + "," + depertment + "," + semester + "," + profilepic + "," + extend);
                Response.Cookies["ocsims_ekey"].Value = e_key;
                Session["login"] = txt_id.Text.Trim();
                Response.Redirect("adminmainmenu.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Wrong Credentials!!!!!');</script>");
                txt_pass.Focus();
            }
        }
        
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
    }
}