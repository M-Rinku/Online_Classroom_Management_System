using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contactus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        clscontactus obj = new clscontactus();
        obj.name = txt_name.Text.Trim();
        obj.mobile = Int64.Parse(txt_mno.Text.Trim());
        obj.email = txt_email.Text.Trim();
        obj.query = txt_query.Text.Trim();
        obj.date = DateTime.Now.ToString();
        obj.to_id = "0";
        obj.status = "New Filed";
        int result = obj.submitquery();
        if(result==1)
        {
            Response.Write("<script>alert('Submit Successfully. Get in touch with you shortly...');</script>");
            Server.Transfer("Default.aspx");
            
        }
        else
        {
            
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please try after sometime!!!!!');</script>");
            btn_submit.Focus();

        }
    }
}