<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="assignment_upload.aspx.cs" Inherits="assignment_upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
<link href="Style/css/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.typekit.net/idk3wns.css">
    <link href="Style/fonts/material-design-iconic-font/css/material-design-iconic-font.min.css" rel="stylesheet" />
    <link href="Style/css/about.css" rel="stylesheet" />
    <script src="Style/js/Js.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
     <a href="teachermainmenu.aspx">Dashboard</a>
<a href="assignment_upload.aspx">Assign Assignment</a>
    <a href="question_upload.aspx">Set Question Paper</a>
    <br />

    <a href="logout.aspx">Log Out</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
 <div class="loginbox" style="margin-top:10%;padding:0PX 30PX; padding-bottom:20px;">
            
            <h3 style="text-align:center;">Put Assignment Here</h3>
            
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btn_login">
                    <p>Batch Year</p>
                    <asp:DropDownList ID="ddl_year" runat="server" CssClass="inputfield" AutoPostBack="True" OnSelectedIndexChanged="ddl_year_SelectedIndexChanged" ></asp:DropDownList>
            <p>Department</p>
                    <asp:DropDownList ID="ddl_department" runat="server" CssClass="inputfield" AutoPostBack="True" OnSelectedIndexChanged="ddl_department_SelectedIndexChanged"></asp:DropDownList>
            <p>Semester</p>
                    <asp:DropDownList ID="ddl_semester" runat="server" CssClass="inputfield" AutoPostBack="True" OnSelectedIndexChanged="ddl_semester_SelectedIndexChanged"></asp:DropDownList>
                    <p>Subject</p>
                    <asp:DropDownList ID="ddl_subject_code" runat="server" CssClass="inputfield"></asp:DropDownList>
                    <p>Title / Question / Description</p>
                    <asp:TextBox ID="txt_title" runat="server" CssClass="inputfield" TextMode="MultiLine"></asp:TextBox>
                    <p>File Upload</p>
                    <asp:FileUpload ID="file_question" runat="server" CssClass="inputfield" />
                    <p>Dead Line</p>
                    <asp:TextBox ID="txt_todate" runat="server" CssClass="inputfield" TextMode="Date"></asp:TextBox>
                    <p>Marks</p>
                    <asp:TextBox ID="txt_marks" runat="server" CssClass="inputfield" TextMode="Number"></asp:TextBox>

            <div class="btnlogin">
                <asp:Button ID="btn_login" CssClass="btnsubmit" runat="server" Text="Submit" OnClick="btn_login_Click"/>
                
                </div>
                </asp:Panel>
        </div>
</asp:Content>

