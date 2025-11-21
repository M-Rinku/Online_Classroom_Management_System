using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class upload_profile : System.Web.UI.Page
{
    string e_key = null;
    string d_key = null;
    string table = null;
    string msg = null;
    
    private String upload(String Filename)
    {
        string val = null;
        try
        {
            //  Server.MapPath() it will return the server current path
            string ext = Filename.Substring(Filename.LastIndexOf("."));
            String newfilename = DateTime.Now.Ticks + ext;
            String fileserverpath = Server.MapPath("~/profile_pictures/" + newfilename);
            //saving the file to the serverhttp:profile_pictures/amit.jpg
            file_profilepic.PostedFile.SaveAs(fileserverpath);
            val = "profile_pictures/"+newfilename;
        }
        catch (Exception err)
        {
            msg = err.Message.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
        }
        return val;
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
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        string filename = null;
        clslogin obj = new clslogin();
        e_key = Request.Cookies["ocsims_ekey"].Value;            //collect data from cookies
        d_key = encryptdecrypt.Decrypt(e_key);                  //decrypt data by the encryptdycrypt class

        table = d_key.Split(',')[1].ToString();
        obj.tablename = table;
        if (file_profilepic.HasFile)
        {
            filename = upload(file_profilepic.PostedFile.FileName);
            obj.path = filename;
        }
        else
        {
            Response.Write("<script>alert('-----Select a Picture-----');</script>");
            file_profilepic.Focus();
        }
        
        if (table=="admin")
        {
            obj.idname = "admin_id";
        }
        else if (table == "teacher")
        {
            obj.idname = "t_id";
        }
        else if (table == "student")
        {
            obj.idname = "roll";
        }
        obj.id = d_key.Split(',')[0].ToString();
        int result = obj.changepic();
        if (result == 1)
        {
            e_key = Request.Cookies["ocsims_ekey"].Value;
            Response.Cookies.Remove("ocsims_ekey");
             d_key = encryptdecrypt.Decrypt(e_key);
            table = d_key.Split(',')[1].ToString();
            string name = d_key.Split(',')[2].ToString();
            string roll = d_key.Split(',')[0].ToString();
            string email = d_key.Split(',')[3].ToString();
            string phone = d_key.Split(',')[4].ToString();
            string year = d_key.Split(',')[5].ToString();
            string depertment = d_key.Split(',')[6].ToString();
            string semester = d_key.Split(',')[7].ToString();
            string profilepic = filename;
            string extend = null;
            e_key = encryptdecrypt.encrypt(roll + "," + table + "," + name + "," + email + "," + phone + "," + year + "," + depertment + "," + semester + "," + profilepic + "," + extend);
            Response.Cookies["ocsims_ekey"].Value = e_key;
            Response.Write("<script>alert('-----Profile Picture Changed-----');</script>");
            string path = Request.Cookies["previous_path"].Value;
            Server.Transfer(path);
        }
        else
        {
            Response.Write("<script>alert('-----Please Try Again-----');</script>");
        }
    }
}