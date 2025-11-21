<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="support.aspx.cs" Inherits="support" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Style/css/about.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.typekit.net/idk3wns.css">
    <link href="Style/fonts/material-design-iconic-font/css/material-design-iconic-font.min.css" rel="stylesheet" />
    <script src="Style/js/Js.js"></script>
    <style type="text/css">
        .buttonreply{
            background-color: #3366FF;
            border-style: None;
            font-weight: bold;
            height: 30px;
            width: 89px;
            position: absolute;
            left: 50%;
            transform: translate(-50%,-50%);
            cursor:pointer;
        }
        .buttonskip{
            background-color: #3366FF;
            border-style: None;
            font-weight: bold;
            height: 30px;
            width: 89px;
            position: absolute;
            right: 0;
            cursor:pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <a href="adminmainmenu.aspx">Dashboard</a>
  <a href="register_student.aspx">Student Registration</a>
  <a href="teacher_register.aspx">Teacher Assign</a>
  <a href="logout.aspx">Logout</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">

    <asp:Panel ID="Panel2" runat="server" CssClass="containercard" >
        
 
       <h2 style="text-align:center; font-family: 'Times New Roman', Times, serif; color: #000099; text-decoration: underline;">QUICK SUPPORT </h2>
        <div>
            <a><b>Case No :</b> <asp:Label ID="lbl_id" runat="server"  ></asp:Label></a>
            <br />
            <br />
        <a><b>Name: </b><asp:Label ID="lbl_name" runat="server"></asp:Label>
            </a>
            <br />
             <br />
        
        <a><b>Email:</b> <asp:Label ID="lbl_email" runat="server" ></asp:Label></a>
        <br />
         <br />
        <a><b>Mobile No. :</b> <asp:Label ID="lbl_mob" runat="server" ></asp:Label></a>
         <br />
        <br />
        <a><b>Problem:</b></a>
        <asp:Label ID="lbl_query" runat="server"  ></asp:Label>
        <br /> 
            <br />
        <a><b>Message:</b></a>
        <asp:TextBox ID="txt_message" runat="server" placeholder="Write the message...." TextMode="MultiLine" CssClass="inputfield"></asp:TextBox>
       <br />
             <br />
        <asp:Button ID="btn_reply" runat="server" Text="SEND" OnClick="btn_reply_Click" CssClass="buttonreply"  /><asp:Button ID="btn_next" runat="server" Text="SKIP" OnClick="btn_next_Click" CssClass="buttonskip"  />
        <br />
             <br />
            
</div>

            
    </asp:Panel>
    

</asp:Content>

