<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="startexam.aspx.cs" Inherits="startexam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
     <a href="mainmenu.aspx">Dashboards</a>
    <a href="assignments.aspx">Assignments</a>
    <a href="assignments.aspx">Knowledge Assesments</a>
    <br />
    <a href="assignments.aspx">Results</a>
    <a href="contactus.aspx">Contact</a>
    <a href="logout.aspx">Log Out</a>
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <div style="margin-top:100px;">
        <asp:GridView ID="gv_exam" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_exam_SelectedIndexChanged" CssClass="mydatagrid" PagerStyle-CssClass="pager"
 HeaderStyle-CssClass="gvhead" RowStyle-CssClass="rows" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="sl_no" HeaderText="Sl.No." />
                            <asp:BoundField DataField="upid" HeaderText="UpId" />
                            <asp:BoundField DataField="subjectcode" HeaderText="Subject Code" Visible="true" />
                            <asp:BoundField DataField="teacher" HeaderText="Invigilator Name" />
                            <asp:BoundField DataField="date" HeaderText="Date" />
                            <asp:BoundField DataField="time" HeaderText="Time" />
                            <asp:BoundField DataField="duration" HeaderText="Duration" />
                            <asp:CommandField SelectText="Action" ShowSelectButton="True" >

                            <ItemStyle ForeColor="#0000CC" />
                            </asp:CommandField>

                        </Columns>
           
                        <HeaderStyle CssClass="gvhead" />
                        <PagerStyle CssClass="pager" />
                        <RowStyle CssClass="rows" />
           
                    </asp:GridView>
   
        </div>
</asp:Content>

