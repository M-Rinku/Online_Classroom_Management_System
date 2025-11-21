<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="show_assignments.aspx.cs" Inherits="show_assignments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <a href="teachermainmenu.aspx">Dashboard</a>
<a href="assignment_upload.aspx">Assign Assignment</a>
    <a href="question_upload.aspx">Set Question Paper</a>
    <br />

    <a href="logout.aspx">Log Out</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <div>
        <asp:Panel ID="pnl_select" runat="server">
            <div class="loginbox" style="top:60%;">
            <img src="Site_Images/assignment.png" class="avatar">
            <h3 style="text-align:center;">Select Batch</h3>
            <p>Batch Year</p>
                    <asp:DropDownList ID="ddl_year" runat="server" CssClass="inputfield" AutoPostBack="True" OnSelectedIndexChanged="ddl_year_SelectedIndexChanged" ></asp:DropDownList>
                    <p>Department</p>
                    <asp:DropDownList ID="ddl_department" runat="server" CssClass="inputfield" OnSelectedIndexChanged="ddl_department_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    <p>Semester</p>
                    <asp:DropDownList ID="ddl_semester" runat="server" CssClass="inputfield" AutoPostBack="True" OnSelectedIndexChanged="ddl_semester_SelectedIndexChanged" ></asp:DropDownList>
                                <p>Subject</p>
                    <asp:DropDownList ID="ddl_subject" runat="server" CssClass="inputfield" AutoPostBack="True" OnSelectedIndexChanged="ddl_subject_SelectedIndexChanged"  ></asp:DropDownList>
        
            </div>
                </asp:Panel>
        <asp:Panel ID="pnl_assignment" runat="server"  CssClass="pnlupload">
                    
                            <div class="diroll">
                                <table cellpadding="0" cellspacing="0" class="auto-style1">
                                    <tr>
                                        <td>Answer Script ID :
                                            <asp:Label ID="lbl_script_id" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td>Roll :
                                            <asp:Label ID="lbl_roll" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td>Uploaded Date :
                                            <asp:Label ID="lbl_datetime" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td>Uploaded IP :
                                            <asp:Label ID="lbl_ip" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                &nbsp;
                            </div>
                        <div style="height:500px;">
                            <iframe id="iframe" runat="server" src="" style="width:100%;height:100%;"></iframe>
                        </div>
            <br />
            <div style="text-align:center;">
                Marks : <asp:TextBox ID="txt_marks" runat="server"></asp:TextBox>
                &nbsp;Of
                <asp:Label ID="lbl_totalmarks" runat="server" Text="Label"></asp:Label>
            </div>
            <br />
                            <div style="text-align:center;">
                                <asp:Image runat="server" ImageUrl="~/Site_images/tick.png" style="height:70px;width:80px;border-radius: 50%;" ID="img_tick"></asp:Image>
                                <asp:Button ID="btn_checked" runat="server" Text="Check" OnClick="btn_checked_Click" CssClass="btnsubmit"/>
                                &nbsp;
                            <asp:Button ID="btn_next" runat="server" Text="Next"  CssClass="btnsubmit" OnClick="btn_next_Click"/>
                            </div>
                        
                </asp:Panel>
    </div>
</asp:Content>

