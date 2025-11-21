using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mainmenu : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["assign_refresh"] = "1";
        Session.Remove("assignment_id");
        Session.Remove("script_id");
        Session.Remove("btnstart_view");
        Session.Remove("value");
        if (Session["login"] != null)
        {
            MasterPage obje = Master as MasterPage;
            obje.visibleimg = true;
            Response.Cookies["previous_path"].Value = "mainmenu.aspx";
        }
        else
        {
            Response.Write("<script>alert('-----Please Login-----');</script>");
            Server.Transfer("Default.aspx");
        }
    }
}