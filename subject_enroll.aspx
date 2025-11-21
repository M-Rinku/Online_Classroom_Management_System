<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="subject_enroll.aspx.cs" Inherits="subject_enroll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
     <div class="loginbox">
            <img src="Site_Images/avatar.png" class="avatar">
            <h3 style="text-align:center;">Enter Details</h3>
            
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btn_login">
                    <p>sem</p>
                    <asp:TextBox ID="txt_sem" runat="server"></asp:TextBox>
            <p>dept</p>
                    <asp:TextBox ID="txt_dept" runat="server"></asp:TextBox>
                    <p>sub code</p>
                    <asp:TextBox ID="txt_code" runat="server"></asp:TextBox>
                    <p>Subject</p>
                    <asp:TextBox ID="txt_sub" runat="server"></asp:TextBox>
                    
            <div class="btnlogin">
                <asp:Button ID="btn_login" CssClass="btnsubmit" runat="server" Text="Submit" OnClick="btn_login_Click"   />
                </div>
                </asp:Panel>
            
        </div>
</asp:Content>

