<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="mainmenu.aspx.cs" Inherits="mainmenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
<link href="Style/css/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.typekit.net/idk3wns.css">
    <link href="Style/fonts/material-design-iconic-font/css/material-design-iconic-font.min.css" rel="stylesheet" />
    <link href="Style/css/about.css" rel="stylesheet" />
    <script src="Style/js/Js.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <a href="mainmenu.aspx">Dashboards</a>
    <a href="assignments.aspx">Assignments</a>
    <a href="assignments.aspx">Knowledge Assesments</a>
    <br />
    <a href="upload_profile.aspx">Change Profilepic</a>
    <a href="forget.aspx">Change Password</a>
    
    <a href="logout.aspx">Log Out</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <div class="wrap">
        <a href="assignments.aspx"  class="card">
                <div style="margin-top:8px;"></div>
                    <img src="Site_images/assignment.png" style="width: 28%;" class="pnglogo">
                    <div >
                        <h4><b>ASSIGNMENTS</b></h4>
                    </div>      
            </a>
        <a href="startexam.aspx"  class="card">
                <div style="margin-top:8px;"></div>
                    <img src="../../Site_Images/attendance.png" style="width: 28%;" class="pnglogo">
                    <div >
                        <h4><b> KNOWLEDGE ASSESMENT</b></h4>
                    </div>
                    
            </a>
        
        
 </div>
</asp:Content>

