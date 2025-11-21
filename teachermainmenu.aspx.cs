using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class teachermainmenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("refresh");
        
        if (Session["login"] != null)
        {
            MasterPage obje = Master as MasterPage;
            obje.visibleimg = true;
            Response.Cookies["previous_path"].Value = "teachermainmenu.aspx";
        }
        else
        {
            Response.Write("<script>alert('-----Please Login-----');</script>");
            Server.Transfer("Default.aspx");
        }
    
}
}