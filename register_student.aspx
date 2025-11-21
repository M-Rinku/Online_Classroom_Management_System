<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="register_student.aspx.cs" Inherits="register_student" %>

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
    <div  class="loginbox" style="top:110%;">
            <img src="Site_Images/avatar.png" class="avatar">
            <h3 style="text-align:center;">Student Registration</h3>
            
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btn_login">
            <p>Student Name</p>
                    <asp:TextBox ID="txt_name" runat="server" Placeholder="Enter the Student Name"></asp:TextBox>
            <p>Roll_no</p>
                   
                    <asp:TextBox ID="txt_roll" runat="server" TextMode="Number" Placeholder="Enter the Roll Number"></asp:TextBox>
                    <p>EMAIL</p>
                    <asp:TextBox ID="txt_email" runat="server" TextMode="Email" Placeholder="Write the email" CssClass="inputfield"></asp:TextBox>
                    <p>MOBILE NUMBER:</p>
                    <asp:TextBox ID="txt_mob" runat="server" TextMode="Phone" PLACEHOLDER="Enter Mobile Number" CssClass="inputfield"></asp:TextBox>
                    <p>Address</p>
                    <asp:TextBox ID="txt_address" runat="server" Placeholder="Enter The Address" CssClass="inputfield" TextMode="MultiLine"></asp:TextBox>
                    <p>YEAR</p>
                    <asp:DropDownList ID="ddl_year" runat="server" CssClass="inputfield" AutoPostBack="True" OnSelectedIndexChanged="ddl_year_SelectedIndexChanged">
                        
                    </asp:DropDownList>
                    <p>DEPARTMENT</p>
                    <asp:DropDownList ID="ddl_depertment" runat="server" CssClass="inputfield" OnSelectedIndexChanged="ddl_depertment_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    <p>SEMESTER</p>
                    <asp:DropDownList ID="ddl_semester" runat="server" CssClass="inputfield">
                        
                    </asp:DropDownList>
                    
                    
                    
            <div class="btnlogin">
                <asp:Button ID="btn_login" CssClass="btnsubmit" runat="server" Text="SAVE" OnClick="btn_login_Click" />
                <br>
               
                </div>
                </asp:Panel>
        </div>
</asp:Content>

