<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="assignments.aspx.cs" Inherits="assignments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
<link href="Style/css/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.typekit.net/idk3wns.css">
    <link href="Style/fonts/material-design-iconic-font/css/material-design-iconic-font.min.css" rel="stylesheet" />
    <link href="Style/css/about.css" rel="stylesheet" />
    <script src="Style/js/Js.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            margin-top:100px;
        }
        .auto-style2 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <a href="mainmenu.aspx">Dashboards</a>
    <a href="assignments.aspx">Assignments</a>
    <a href="assignments.aspx">Knowledge Assesments</a>
    <br />
    <a href="assignments.aspx">Results</a>
    <a href="logout.aspx">Log Out</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <asp:Panel ID="pnl_searchassignment" runat="server">
    <table cellpadding="0" cellspacing="0" class="auto-style1">
        <tr>
            <td class="left">
                
                    <asp:Panel ID="pnl_select" runat="server" CssClass="centertext">
                    <asp:Label ID="lbl_semester" runat="server" Text="Semester :- " Font-Bold="True" Font-Size="Large"></asp:Label> 
                    <asp:DropDownList ID="ddl_semester" runat="server" OnTextChanged="ddl_semester_TextChanged" AutoPostBack="True"></asp:DropDownList>
                    &nbsp;
                    <br />
                    <br />
                    
                   <asp:Label ID="lbl_subject" runat="server" Text="Subject :- " Font-Bold="true" Font-Size="Large"></asp:Label> 
                        <asp:DropDownList ID="ddl_subject" runat="server" AutoPostBack="True" OnTextChanged="ddl_subject_TextChanged"></asp:DropDownList>
                </asp:Panel>
            </td>
            <td class="right">
                <div class="centertext">
                    <asp:GridView ID="gv_assignments" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_assignments_SelectedIndexChanged" CssClass="mydatagrid" PagerStyle-CssClass="pager"
 HeaderStyle-CssClass="gvhead" RowStyle-CssClass="rows" AllowPaging="True" >
                        <Columns>
                            <asp:BoundField DataField="Sl.No." HeaderText="Sl.No." />
                            <asp:BoundField DataField="assign_id" HeaderText="Assignment ID" Visible="true" />
                            <asp:BoundField DataField="Code" HeaderText="Subject Code" />
                            <asp:HyperLinkField DataTextField="Title" HeaderText="Title" DataNavigateUrlFields="link">
                            <ControlStyle ForeColor="#3333FF" />
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="Assignment Given Date" HeaderText="Assignment Given Date" />
                            <asp:BoundField DataField="Submission Date" HeaderText="Submission Date" />
                            <asp:CommandField SelectText="Action" ShowSelectButton="True" >

                            <ItemStyle ForeColor="#0000CC" />
                            </asp:CommandField>

                        </Columns>
           
                        <HeaderStyle CssClass="gvhead" />
                        <PagerStyle CssClass="pager" />
                        <RowStyle CssClass="rows" />
           
                    </asp:GridView>
                    <asp:Button ID="btn_back" runat="server" Text="Back" Visible="False" CssClass="right" OnClick="btn_back_Click" />
                </div>
            </td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnl_submitassignment" runat="server">
        


        <table cellpadding="0" cellspacing="0" class="auto-style2">
            <tr>
                <td class="left" style="position:fixed;top:45%;margin-left:30px;">
                    <asp:Panel ID="pnl_upload" runat="server">
                    
                        <asp:Label ID="lbl_uploadfile" runat="server" Text="Upload Your File"  Font-Bold="true" Font-Size="Large"></asp:Label>
                        <br />
                        <br />
                    <asp:FileUpload ID="file_assignment" runat="server" />
                     <br />
                    <br />
                    <asp:Button ID="btn_cncl" runat="server" Text="Cancel"  CssClass="btnsubmit" OnClick="btn_cncl_Click" />
                    <asp:Button ID="btn_upload" runat="server" Text="Upload" OnClick="btn_upload_Click" CssClass="btnsubmit"/>
                    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" CssClass="btnsubmit" />
                    <asp:Button ID="btn_view" runat="server" Text="View" CssClass="btnsubmit" OnClick="btn_view_Click" Visible="False" />
                    
                    <br /><br />
                       
                            
                    <br />
                    <div class="centertext">
                       <asp:Label ID="lbl_sfn" runat="server" Text="Server File Name :-"></asp:Label>
                         <asp:Label ID="lbl_filename" runat="server" Text=""></asp:Label>
                            </div>
                    <br />
                    
                    
                    <div class="centertext">
                       <asp:Label ID="lbl_tip" runat="server" Text="Your IP Address :-"></asp:Label> 
                        <asp:Label ID="lbl_ip" runat="server" Text=""></asp:Label>
                            </div>
                    </asp:Panel>
                </td>
                <td class="right">
                    <asp:Panel ID="pnl_pdfview" runat="server">
                    <iframe id="iframe" runat="server" class="pnlpdf" src=""></iframe>
                        
                        
                        </asp:Panel>
                </td>
            </tr>
        </table>


    </asp:Panel>
</asp:Content>

