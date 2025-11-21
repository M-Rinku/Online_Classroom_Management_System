using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class support : System.Web.UI.Page
{
    string e_key = null;
    string d_key = null;
    string year = null;
    string table = null;
    string name = null;
    string id = null;
    int count;
    int nxt;
    protected void refresh()
    {
        cls_support obj = new cls_support();
        obj.to_id = "0";
        DataSet ds = obj.retrievequeries();
        count = ds.Tables[0].Rows.Count;
        if (count != 0)
        {
            if (nxt < count)
            {
                lbl_id.Text = ds.Tables[0].Rows[nxt]["query_id"].ToString();
                lbl_name.Text = ds.Tables[0].Rows[nxt]["name"].ToString();
                lbl_email.Text = ds.Tables[0].Rows[nxt]["email"].ToString();
                lbl_mob.Text = ds.Tables[0].Rows[nxt]["mobile"].ToString();
                lbl_query.Text = ds.Tables[0].Rows[nxt]["query"].ToString();
            }
            else
            {
                Response.Write("<script>alert('****No Querys Right Now ****');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('****No Querys Right Now ****');</script>");
            Server.Transfer("adminmainmenu.aspx");
        }
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
        if (!IsPostBack)
        {
            e_key = Request.Cookies["ocsims_ekey"].Value;            //collect data from cookies
            d_key = encryptdecrypt.Decrypt(e_key);                  //decrypt data by the encryptdycrypt class
            
            //split data by"," delemeter and store another another variable
            // s_id = d_key.Split(',')[0].ToString();
            id = d_key.Split(',')[0].ToString();
            table = d_key.Split(',')[1].ToString();
            name = d_key.Split(',')[2].ToString();
            if (table == "admin")
            {
                refresh();
            }
        }
    }

    protected void btn_reply_Click(object sender, EventArgs e)
    {
        string store = lbl_email.Text.Trim();
        SmtpClient client = new SmtpClient("Smtp.gmail.com", 587);
        client.EnableSsl = true;
        client.Credentials = new NetworkCredential("lowvocal7602@gmail.com", "7602307242");
        MailMessage msgobj = new MailMessage();
        msgobj.To.Add(store);
        msgobj.From = new MailAddress("lowvocal7602@gmail.com");
        msgobj.Subject = "Reply from OCSIMS against Your Query/Support";
        msgobj.IsBodyHtml = true;
        msgobj.Body = "Hello " + lbl_name.Text + ".<br />Your Query is--- <br />" + lbl_query.Text + ".<br /><br /><br />" + txt_message.Text.Trim() + "";
        client.Send(msgobj);
        cls_support obj = new cls_support();
        obj.query_id = lbl_id.Text.Trim();
        obj.deletequery();
        refresh();
    }

    protected void btn_next_Click(object sender, EventArgs e)
    {
        int val;
        if (Session["next"] != null)
        {
            val = Int32.Parse(Session["next"] as string);
        }
        else
        {
            val = 0;
        }
        nxt = val + 1;
        Session["next"] = nxt.ToString();
        refresh();
    }
}