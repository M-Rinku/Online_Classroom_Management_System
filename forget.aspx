<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="forget.aspx.cs" Inherits="forget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Style/css/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.typekit.net/idk3wns.css">
    <link href="Style/fonts/material-design-iconic-font/css/material-design-iconic-font.min.css" rel="stylesheet" />
    <script src="Style/js/Js.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <a href="Login.aspx">Login</a>
  <a href="Default2"> </a>
  <a href="#"></a>
  <a href="#">Contact</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <div class="loginbox">
            <img src="Site_Images/avatar.png" class="avatar">
            <h3 style="text-align:center;">Enter Details</h3>
            
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btn_login">
                    <p>I am...</p>
                    <asp:DropDownList ID="ddl_who" runat="server" CssClass="inputfield">
                        <asp:ListItem Selected="True">Select</asp:ListItem>
                        <asp:ListItem Value="admin">Admin</asp:ListItem>
                        <asp:ListItem Value="teacher">Teacher</asp:ListItem>
                        <asp:ListItem Value="student">Student</asp:ListItem>
                    </asp:DropDownList>
            <p>UserID</p>
                    <asp:TextBox ID="txt_id" runat="server" placeholder="Enter UserID" TextMode="Number" CssClass="inputfield" OnTextChanged="txt_id_TextChanged" AutoPostBack="True"></asp:TextBox>
                    <asp:Panel runat="server" ID="pnl_mno">
            <p>Mobile No.<asp:Label ID="lbl_mobno" runat="server" Visible="False"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_no" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </p>
            <asp:TextBox ID="txt_no" runat="server" CssClass="inputfield" TextMode="Number"></asp:TextBox>
                        </asp:Panel>
                    <asp:TextBox ID="txt_otp" runat="server" CssClass="inputfield" TextMode="Number" placeholder="Enter OTP" Visible="False"></asp:TextBox>
                    <asp:Panel runat="server" ID="pnl_pass">
                        <p>New Password
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_pass" ErrorMessage="* Enter a strong Password" ForeColor="Red" ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&amp;+=]).*$"></asp:RegularExpressionValidator>
                        </p>
                        <asp:TextBox runat="server" ID="txt_pass" TextMode="Password" CssClass="inputfield"></asp:TextBox>
                        <p>Confirm Password&nbsp;
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_pass" ControlToValidate="txt_confirmpass" ErrorMessage="* Password Not Match" ForeColor="Red"></asp:CompareValidator>
                        </p>
                        <asp:TextBox runat="server" ID="txt_confirmpass" TextMode="Password" CssClass="inputfield"></asp:TextBox>
                    </asp:Panel>
            <div class="btnlogin">
                <asp:Button ID="btn_login" CssClass="btnsubmit" runat="server" Text="Reset" OnClick="btn_login_Click"  />
                </div>
                </asp:Panel>
            
        </div>
</asp:Content>

