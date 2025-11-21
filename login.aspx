<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Style/css/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.typekit.net/idk3wns.css">
    <link href="Style/fonts/material-design-iconic-font/css/material-design-iconic-font.min.css" rel="stylesheet" />
    <script src="Style/js/Js.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
     
    <a href="login.aspx?who=std">Student Login</a>
        <a href="login.aspx?who=tchr">Teacher Login</a>
            <a href="login.aspx?who=admin">Admin Login</a>
    <a href="contactus.aspx">Contact</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <div class="loginbox" style="top:60%;">
            <img src="Site_Images/avatar.png" class="avatar">
            <h3 style="text-align:center;">Login Here</h3>
            
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btn_login">
            <p>UserID</p>
                    <asp:TextBox ID="txt_id" runat="server" placeholder="Enter Username" TextMode="Number" CssClass="inputfield"></asp:TextBox>
            <p>Password</p>
            <input type="password" runat="server" id="txt_pass" name="" placeholder="Enter Password">
            <div class="btnlogin">
                <asp:Button ID="btn_login" CssClass="btnsubmit" runat="server" Text="Login" OnClick="btn_login_Click"/>
                <br>
                <a href="forget.aspx">Lost your password?</a>
                </div>
                </asp:Panel>
        </div>
</asp:Content>

