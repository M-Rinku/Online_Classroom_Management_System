using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    

   

   

    protected void Button1_Click1(object sender, EventArgs e)
    {
        SmtpClient client = new SmtpClient("localhost", 587);
       // client.EnableSsl = true;
        client.Credentials = new NetworkCredential("noreply@103.2.132.154", "Amit@30898");
        MailMessage msgobj = new MailMessage();
        msgobj.To.Add(TextBox1.Text);
        msgobj.From = new MailAddress("noreply@103.2.132.154");
        msgobj.Subject = "Your Id Password";
        msgobj.Body = TextBox2.Text;
        client.Send(msgobj);
    }
}