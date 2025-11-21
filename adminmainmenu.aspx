<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminmainmenu.aspx.cs" Inherits="adminmainmenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <meta name="viewport" content="width=device-width, initial-scale=1">
<link href="Style/css/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.typekit.net/idk3wns.css">
    <link href="Style/fonts/material-design-iconic-font/css/material-design-iconic-font.min.css" rel="stylesheet" />
    <link href="Style/css/about.css" rel="stylesheet" />
    <script src="Style/js/Js.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <a href="adminmainmenu.aspx">Dashboard</a>
  <a href="register_student.aspx">Student Registration</a>
  <a href="teacher_register.aspx">Teacher Assign</a>
    <a href="upload_profile.aspx">Change Profilepic</a>
    <a href="forget.aspx">Change Password</a>
  <a href="logout.aspx">Logout</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
     <div class="wrap">
            
            <a href="register_student.aspx" class="card">
            <div style="margin-top:8px;"></div>
                <img src="../../Site_Images/assignment.png" style="width: 28%;" class="pnglogo">
                <div >
                    <h4><b>STUDENT REGISTRATION</b></h4>
                </div>
                
                </a>
        <a href="teacher_register.aspx"  class="card">
                
                    <div style="margin-top:8px;"></div>
                    <img src="Site_images/teacher_logo.jpg" style="width: 32%;" class="pnglogo">
                    <div >
                        <h4><b>TEACHER ASSIGN</b></h4>
                    </div>
                    
            </a>
      <a href="support.aspx"  class="card">
                <div style="margin-top:8px;"></div>
                    <img src="Site_images/attendance_modify.png" style="width: 28%;" class="pnglogo">
                    <div >
                        <h4><b>QUICK SUPPORT</b></h4>
                    </div>      
            </a>
 </div>
</asp:Content>

