using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    string msg=null;
    public bool visibleimg
    {
        set
        {
            profile_pic.Visible = value;
            profile_pic.ImageUrl = value.ToString();
            btn_logout.Visible = value;
        }
    }
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lbl_ip.Text = "Your IP is :-" + HttpContext.Current.Request.UserHostAddress.ToString();
            string marquee = Session["marquee"] as string;
            if (marquee == null)
            {
                pnl_mrq.Visible = true;
                pnl_f_mrq.Visible = true;
                pnl_no_mrq.Visible = false;
                pnl_f_no_mrq.Visible = false;
            }
            else
            {
                pnl_mrq.Visible = false;
                pnl_f_mrq.Visible = false;
                pnl_no_mrq.Visible = true;
                pnl_f_no_mrq.Visible = true;

            }
            Session["marquee"] = "1";
            if (Request.Cookies["ocsims_ekey"].Value != null)
            {
                string e_key = Request.Cookies["ocsims_ekey"].Value;
                if (e_key != "")
                {
                    string d_key = encryptdecrypt.Decrypt(e_key);

                    string table = d_key.Split(',')[1].ToString();
                    if (table == "admin")
                    {
                        string url = d_key.Split(',')[8].ToString();
                        profile_pic.ImageUrl = url;
                    }
                    else if (table == "student")
                    {
                        string url = d_key.Split(',')[8].ToString();
                        profile_pic.ImageUrl = url;
                    }
                    else
                    {
                        string url = d_key.Split(',')[8].ToString();
                        profile_pic.ImageUrl = url;
                    }
                }
                else
                {

                }
            }
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
    }

    protected void btn_logout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Request.Cookies.Clear();
        Response.Redirect("logout.aspx");
    }
    public void refresh()
    {
        try
        {
            lbl_ip.Text = "Your IP is :-" + HttpContext.Current.Request.UserHostAddress.ToString();
            string marquee = Session["marquee"] as string;
            if (marquee == null)
            {
                pnl_mrq.Visible = true;
                pnl_f_mrq.Visible = true;
                pnl_no_mrq.Visible = false;
                pnl_f_no_mrq.Visible = false;
            }
            else
            {
                pnl_mrq.Visible = false;
                pnl_f_mrq.Visible = false;
                pnl_no_mrq.Visible = true;
                pnl_f_no_mrq.Visible = true;

            }
            Session["marquee"] = "1";
            if (Request.Cookies["ocsims_ekey"].Value != null)
            {
                string e_key = Request.Cookies["ocsims_ekey"].Value;
                if (e_key != "")
                {
                    string d_key = encryptdecrypt.Decrypt(e_key);

                    string table = d_key.Split(',')[1].ToString();
                    if (table == "admin")
                    {
                        string url = d_key.Split(',')[8].ToString();
                        profile_pic.ImageUrl = url;
                    }
                    else if (table == "student")
                    {
                        string url = d_key.Split(',')[8].ToString();
                        profile_pic.ImageUrl = url;
                    }
                    else
                    {
                        string url = d_key.Split(',')[8].ToString();
                        profile_pic.ImageUrl = url;
                    }
                }
                else
                {

                }
            }
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
    }
}
