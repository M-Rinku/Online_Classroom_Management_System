<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>OCSIMS</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
<link href="Style/css/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.typekit.net/idk3wns.css">
    <link href="Style/fonts/material-design-iconic-font/css/material-design-iconic-font.min.css" rel="stylesheet" />
    <link href="Style/css/about.css" rel="stylesheet" />
    <script src="Style/js/Js.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <a href="mainmenu.aspx">About</a>
  <a href="Default2">Services</a>
  <a href="#">Clients</a>
  <a href="contactus.aspx">Contact</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    
    <div class="centerpadding">
     <div class="wrap">
            <a href="login.aspx?who=std">
            <div class="card">
                <img src="../../Site_Images/student.png" style="width: 28%;" class="pnglogo">
                <div class="container">
                    <h4><b> Student Login</b></h4>
                </div>
                </div>
                </a>
        <a href="login.aspx?who=tchr">
                <div class="card">
                    <img src="../../Site_Images/teacher.png" style="width: 28%;" class="pnglogo">
                    <div class="container">
                        <h4><b> Teacher Login</b></h4>
                    </div>
                    </div>
            </a>
        <a href="login.aspx?who=admin">
                    <div class="card">
                        <img src="../../Site_Images/admin.png" style="width: 28%;" class="pnglogo">
                        <div class="container">
                            <h4><b> Administrator Login</b></h4>
                        </div>
                        </div>
            </a>
 </div>
</div>
</asp:Content>

