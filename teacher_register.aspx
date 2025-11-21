<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="teacher_register.aspx.cs" Inherits="teacher_register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Style/css/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.typekit.net/idk3wns.css">
    <link href="Style/fonts/material-design-iconic-font/css/material-design-iconic-font.min.css" rel="stylesheet" />
    <script src="Style/js/Js.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
     <a href="adminmainmenu.aspx">Dashboard</a>
  <a href="register_student.aspx">Student Registration</a>
  <a href="teacher_register.aspx">Teacher Assign</a>
  <a href="logout.aspx">Logout</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
      <div class="loginbox" style="top:80%;">
            <img src="Site_Images/avatar.png" class="avatar">
            <h3 style="text-align:center;">Teacher Registration</h3>
            
               
            <p>Teacher's Name</p>
                    <asp:TextBox ID="txt_tname" runat="server" Placeholder="Enter the Teacher's Name" CssClass="inputfield"></asp:TextBox>
           <p>Teacher registration</p>
                    <asp:TextBox ID="txt_registration" runat="server" Placeholder="Enter the Teacher registration number" CssClass="inputfield"></asp:TextBox>
                    <p>Contact no.</p>
                    <asp:TextBox ID="txt_contact" runat="server" CssClass="inputfield" TextMode="Phone"></asp:TextBox>
            <p>Email</p>
                    <asp:TextBox ID="txt_email" runat="server" CssClass="inputfield" ></asp:TextBox>
          
            <p>Subject : </p>
          <asp:DropDownList ID="ddl_subject" runat="server" CssClass="inputfield">
              
            </asp:DropDownList>
           
                    
            <div class="btnlogin">
                <asp:Button ID="btn_login" CssClass="btnsubmit" runat="server" Text="SAVE" OnClick="btn_login_Click" />
                <br/>
           
                </div>
               
        </div>
</asp:Content>

