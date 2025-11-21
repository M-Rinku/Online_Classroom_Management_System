<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="upload_profile.aspx.cs" Inherits="upload_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <div class="loginbox" style="top:55%;">
            <img src="Site_images/avatar.png" class="avatar">
            <h3 style="text-align:center;">Upload Your Profile Picture</h3>
            
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btn_submit" >
            <p>Upload Picture</p>
                    <asp:FileUpload ID="file_profilepic" runat="server" CssClass="inputfield" />
            <div class="btnlogin">
                <asp:Button ID="btn_submit" CssClass="btnsubmit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
                
                
                </div>
                </asp:Panel>
        </div>
</asp:Content>

