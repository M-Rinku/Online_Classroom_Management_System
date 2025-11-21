<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewattendance.aspx.cs" Inherits="viewattendance" %>

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
     <a href="mainmenu.aspx"> </a>
  <a href="Default2"></a>
  <a href="#">Clients</a>
  <a href="#">Contact</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <asp:Panel ID="pnl_searchattendance" runat="server">
    <table cellpadding="0" cellspacing="0" class="auto-style1">
        <tr>
            <td class="left">
                <div class="centertext">
                    <asp:Label ID="lbl_semester" runat="server" Text="Semester :- "></asp:Label> <asp:DropDownList ID="ddl_semester" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_semester_SelectedIndexChanged"></asp:DropDownList>
                    <br />
                    <br />
                    
                   <asp:Label ID="lbl_subject" runat="server" Text="Subject :- "></asp:Label> <asp:DropDownList ID="ddl_subject" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_subject_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </td>
            <td class="right">
                <div class="centertext">
                    <asp:GridView ID="gv_attendance" runat="server" AutoGenerateColumns="False" >
                        <Columns>
                            <asp:BoundField DataField="Sl.No." HeaderText="Sl.No." />
                            <asp:BoundField DataField="Code" HeaderText="Code" />
                            <asp:BoundField DataField="Date" HeaderText="Date" />
                            <asp:BoundField DataField="Time" HeaderText="Time" />
                        </Columns>
           
                    </asp:GridView>
                    
                </div>
            </td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnl_viewattendance" runat="server">
        


        <table cellpadding="0" cellspacing="0" class="auto-style2">
            <tr>
                <td class="left" style="position:fixed;top:45%;margin-left:30px;">
                    
                     <br /><br />
                    <asp:Button ID="btn_back" runat="server" Text="Back"  CssClass="btnsubmit" OnClick="btn_back_Click"  />
                    
                    <br /><br />
                       
                            
                   
                    
                </td>
                
            </tr>
        </table>


    </asp:Panel>
</asp:Content>

