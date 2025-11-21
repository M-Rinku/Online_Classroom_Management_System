using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    /// <summary>
    /// in cookies values are
    /// 
    ///s_id , table , name , roll , email , phone , depertment , semester , profilepic
    /// 0	    1	    2	   3	    4	    5	    6	        7		    8
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["ocsims_ekey"].Value = null;
       // string e_key = encryptdecrypt.encrypt("1,student,amit ghosh,10201019030,amitghosh7602@gmail.com,7602307242,mca,1,profile_pictures/amit.jpg");
       // Response.Cookies["ocsims_ekey"].Value = e_key;

    }
    /*
    protected void dwnld_Click(object sender, EventArgs e)
    {
        string filepath = Server.MapPath("~/softwere/SQLManagementStudio_x64_ENU.exe");
        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.AddHeader("Content-Disposition", "attachment; filename=SQLManagementStudio_x64_ENU.exe");
        Response.Flush();
        Response.TransmitFile(filepath);
        Response.End();
    }*/




    
}