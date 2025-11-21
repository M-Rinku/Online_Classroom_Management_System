using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forget : System.Web.UI.Page
{
    string e_key = null;
    string d_key = null;
    string table = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        pnl_pass.Visible = false;
        txt_otp.Visible = false;
        if (!IsPostBack)
        {
            btn_login.Text = "Send OTP";
            if (Session["login"] != null)
            {
                MasterPage obje = Master as MasterPage;
                obje.visibleimg = true;
                e_key = Request.Cookies["ocsims_ekey"].Value;            //collect data from cookies
                d_key = encryptdecrypt.Decrypt(e_key);                  //decrypt data by the encryptdycrypt class

                table = d_key.Split(',')[1].ToString();
                //split data by"," delemeter and store another another variable
                txt_id.Text = d_key.Split(',')[0].ToString();
                txt_id.Enabled = false;
                if (table == "student")
                {
                    ddl_who.SelectedIndex = 3;
                }
                else if (table == "teacher")
                {
                    ddl_who.SelectedIndex = 2;
                }
                else
                {
                    ddl_who.SelectedIndex = 1;
                }
                ddl_who.Enabled = false;
                pnl_mno.Visible = false;
                btn_login.Text = "Change";
                pnl_pass.Visible = true;
            }
        }
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
        if (btn_login.Text == "Send OTP")
        {
            string num = "0123456789";
            int len = num.Length;
            string otp = string.Empty;
            int otpdegit = 5;
            string finaldigit;
            int getindex;

            for (int i = 0; i < otpdegit; i++)
            {
                do
                {
                    getindex = new Random().Next(0, len);
                    finaldigit = num.ToCharArray()[getindex].ToString();
                }
                while (otp.IndexOf(finaldigit) != -1);
                otp += finaldigit;
            }
            Session["imsotp"] = otp.ToString();
            string send = otp;
            sms obj = new sms();
            obj.number = lbl_mobno.Text.Split('/')[0].ToString();
            string name = lbl_mobno.Text.Split('/')[1].ToString();
            string splt = name.Split(' ')[0].ToString();
            obj.massage = "Hi " + splt + ". Your OTP is " + send + ". Don't share this OTP to anyone for security reasons. Thank You.";
            obj.sendSMS();
            txt_otp.Visible = true;
            btn_login.Text = "Validate";
        }
        else if(btn_login.Text == "Validate")
        {
            string otp = Session["imsotp"] as string;
            if (otp==txt_otp.Text.Trim())
            {
                txt_otp.Visible = false;
                pnl_pass.Visible = true;
                btn_login.Text = "Change";
            }
        }
        else
        {
            clslogin obj = new clslogin();
            obj.tablename = ddl_who.SelectedValue;
            obj.password = txt_confirmpass.Text;
            if (ddl_who.SelectedIndex == 1)
            {
                obj.idname = "admin_id";
            }
            else if (ddl_who.SelectedIndex == 2)
            {
                obj.idname = "t_id";
            }
            else if (ddl_who.SelectedIndex == 3)
            {
                obj.idname = "roll";
            }
            obj.id = txt_id.Text;
            int result = obj.changepass();
            if(result==1)
            {
                Response.Write("<script>alert('-----Password Changed. Please Login-----');</script>");
                Session.RemoveAll();
                Server.Transfer("Default.aspx");
            }
            else
            {
                Response.Write("<script>alert('-----Please Try Again-----');</script>");
            }
        }
    }

    protected void txt_id_TextChanged(object sender, EventArgs e)
    {
        clslogin obj = new clslogin();
        obj.tablename = ddl_who.SelectedValue;
        if(ddl_who.SelectedIndex==1)
        {
            obj.idname = "admin_id";
        }
        else if(ddl_who.SelectedIndex == 2)
        {
            obj.idname = "t_id";
        }
        else if(ddl_who.SelectedIndex == 3)
        {
            obj.idname = "roll";
        }
        obj.id = txt_id.Text.Trim();
        string mob = obj.getmobile();
        txt_no.TextMode = TextBoxMode.SingleLine;
        lbl_mobno.Text = mob.Split('/')[0].ToString() + "/" + mob.Split('/')[2].ToString();
        txt_no.Text = mob.Split('/')[1].ToString();
        txt_no.Enabled = false;
        ddl_who.Enabled = false;
        txt_id.Enabled = false;
    }
}