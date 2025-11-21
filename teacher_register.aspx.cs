using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class teacher_register : System.Web.UI.Page
{
    string msg = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
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
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
        if (!IsPostBack)
        {
            cls_teacher obj = new cls_teacher();
            DataTable dt = obj.retrivesubjectwithoutcode();
            ddl_subject.DataSource = dt;

            ddl_subject.DataTextField = "Subject";
            ddl_subject.DataValueField = "Subject";
            ddl_subject.DataBind();
        }
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
       try
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
            obj.name = txt_tname.Text.Trim();
            obj.registration_no = txt_registration.Text.Trim();
            obj.email = txt_email.Text.Trim();
            obj.mob_no = txt_contact.Text.Trim();
            obj.subject = ddl_subject.SelectedValue;
            obj.profilepicture = "Site_images/default_profilepic.png";
            string result = obj.insertteacher();
            if (result == "0")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Something Wrong Please Try Again.');</script>");
            }
            else if (result == "9")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Registred Already');</script>");
            }
            else
            {
                string store = txt_email.Text.Trim();
                SmtpClient client = new SmtpClient("Smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("lowvocal7602@gmail.com", "7602307242");
                MailMessage msgobj = new MailMessage();
                msgobj.To.Add(store);
                msgobj.From = new MailAddress("lowvocal7602@gmail.com");
                msgobj.Subject = "Your Id Password";
                msgobj.Body = "Your ID is :==" + result + ". And your password is :==" + finalString.ToString();
                client.Send(msgobj);
                txt_tname.Text = "";
                txt_registration.Text = "";
                txt_contact.Text = "";
                txt_email.Text = "";
                txt_tname.Focus();
            }

        }
         catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
    }
}