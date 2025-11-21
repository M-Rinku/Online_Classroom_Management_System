<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="exam_schedule.aspx.cs" Inherits="exam_schedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <div class="loginbox" style="margin-top:10%;padding:0PX 30PX; padding-bottom:20px;">
            
            <h3 style="text-align:center;">Exam Schedule</h3>
            
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

