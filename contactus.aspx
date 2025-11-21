<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="contactus.aspx.cs" Inherits="contactus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <div class="loginbox" style="top:85%;">
            <img src="Site_images/contactpic.jpg" class="avatar">
            <h3 style="text-align:center;">Drop Your Query</h3>
            
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btn_submit" >
            <p>Name</p>
                    <asp:TextBox ID="txt_name" runat="server" placeholder="Enter Name" CssClass="inputfield"></asp:TextBox>
            <p>Mobile No.</p>
                    <asp:TextBox ID="txt_mno" runat="server" placeholder="Enter Mobile Number" TextMode="Number" CssClass="inputfield"></asp:TextBox>
                    <p>Email</p>
                    <asp:TextBox ID="txt_email" runat="server" placeholder="Enter Your Email" TextMode="Email" CssClass="inputfield"></asp:TextBox>
                    <p>Query</p>
                    <asp:TextBox ID="txt_query" runat="server" placeholder="Write Your Query" TextMode="MultiLine" CssClass="inputfield" Height="100px"></asp:TextBox>
            <div class="btnlogin">
                <asp:Button ID="btn_submit" CssClass="btnsubmit" runat="server" Text="Submit" OnClick="btn_submit_Click"/>
                
                
                </div>
                </asp:Panel>
        </div>
</asp:Content>

