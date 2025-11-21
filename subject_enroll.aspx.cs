using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subject_enroll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
        string dept = txt_dept.Text.Trim();
        string sem = txt_sem.Text.Trim();
        string sub = txt_sub.Text.Trim();
        string code = txt_code.Text.Trim();
        int res = server.InsertUpdateDelete("insert into coursedetails values('" + dept + "','" + sem + "','" + sub + "','" + code + "')");
        if(res==1)
        {
            txt_sub.Text = "";
            txt_code.Text = "";
            txt_sub.Focus();
        }
    }
}