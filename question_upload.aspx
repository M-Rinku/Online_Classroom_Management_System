<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="question_upload.aspx.cs" Inherits="question_upload" %>

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
            margin-top:30px;
        }
        .auto-style2 {
            width: 273px;
        }
        .auto-style9 {
           
            text-align: right;
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
    <table class="auto-style1">
        <tr>
            <td >

                <asp:HiddenField ID="hdn_subcode" runat="server" />
                

            </td>
        </tr>
        <tr>
            <td class="auto-style2" style="position: absolute;left: 50%;transform: translate(-50%);">
                
                <asp:Panel ID="pnl_select" runat="server">
                    <p>Batch Year</p>
                    <asp:DropDownList ID="ddl_year" runat="server" CssClass="inputfield" AutoPostBack="True" OnSelectedIndexChanged="ddl_year_SelectedIndexChanged" ></asp:DropDownList>
                    <p>Department</p>
                    <asp:DropDownList ID="ddl_department" runat="server" CssClass="inputfield" OnSelectedIndexChanged="ddl_department_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    <p>Semester</p>
                    <asp:DropDownList ID="ddl_semester" runat="server" CssClass="inputfield" AutoPostBack="True" OnSelectedIndexChanged="ddl_semester_SelectedIndexChanged" ></asp:DropDownList>
                    <p>Subject Code</p>
                    <asp:DropDownList ID="ddl_subject_code" runat="server" CssClass="inputfield" OnSelectedIndexChanged="ddl_subject_code_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    <p>Question Set</p>
                    <asp:DropDownList ID="ddl_questiona_set" runat="server" CssClass="inputfield" OnSelectedIndexChanged="ddl_questiona_set_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>--choose set--</asp:ListItem>
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>B</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                </asp:DropDownList>
                    </asp:Panel>
            </td>
            <td>
                <asp:Panel ID="pnl_upload" runat="server" DefaultButton="btn_addquestion" CssClass="pnlupload">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style9">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                <asp:Label ID="lbl_question" runat="server" Text="Question :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_questiontype" runat="server" TextMode="MultiLine"  CssClass="inputfield"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                <asp:Label ID="lbl_opt_a" runat="server" Text="A." ></asp:Label>
                                                  </td>
                            <td>
                                <asp:TextBox ID="txt_opt_a" runat="server"  CssClass="inputfield" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                <asp:Label ID="lbl_opt_b" runat="server" Text="B."></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_opt_b" runat="server" CssClass="inputfield"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                <asp:Label ID="lbl_opt_c" runat="server" Text="C."></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_opt_c" runat="server"  CssClass="inputfield"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                <asp:Label ID="lbl_opt_d" runat="server" Text="D."></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_opt_d" runat="server"  CssClass="inputfield"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9">Correct Answer:</td>
                            <td>
                                
                                <asp:RadioButtonList ID="rdbtn_correctans" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">A</asp:ListItem>
                                    <asp:ListItem Value="2">B</asp:ListItem>
                                    <asp:ListItem Value="3">C</asp:ListItem>
                                    <asp:ListItem Value="4">D</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                       
                        <tr>
                            <td class="auto-style9">Marks:</td>
                            <td>

                                

                                <asp:TextBox ID="txt_marks" runat="server" CssClass="inputfield"></asp:TextBox>

                                

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9">&nbsp;</td>
                            <td>
                                <asp:Button ID="btn_addquestion" runat="server" BackColor="#0066FF" BorderStyle="Ridge" Font-Bold="True" Font-Names="Arial Black" Font-Underline="True" ForeColor="White" OnClick="btn_addquestion_Click" style="margin-left: 477px" Text="ADD QUESTION" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            
            
               <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="gvhead" RowStyle-CssClass="rows" AllowPaging="True" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" >  
            <Columns>  
                 
                <asp:TemplateField HeaderText="ID">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Question Set">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_qset" runat="server" Text='<%#Eval("question_set") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_qset" runat="server" Text='<%#Eval("question_set") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Question">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_question" runat="server" Text='<%#Eval("question") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_question" runat="server" Text='<%#Eval("question") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Option A">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_optna" runat="server" Text='<%#Eval("option1") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_optna" runat="server" Text='<%#Eval("option1") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Option B">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_optnb" runat="server" Text='<%#Eval("option2") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_optnb" runat="server" Text='<%#Eval("option2") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Option C">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_optnc" runat="server" Text='<%#Eval("option3") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_optnc" runat="server" Text='<%#Eval("option3") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Option D">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_optnd" runat="server" Text='<%#Eval("option4") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_optnd" runat="server" Text='<%#Eval("option4") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Correct Answer">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ans" runat="server" Text='<%#Eval("correctanswer") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_ans" runat="server" Text='<%#Eval("correctanswer") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Marks">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_marks" runat="server" Text='<%#Eval("marks") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_marks" runat="server" Text='<%#Eval("marks") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True">
                <ControlStyle BackColor="#3366FF" ForeColor="#FFFF99" />
                </asp:CommandField>
            </Columns>  

<HeaderStyle CssClass="gvhead"></HeaderStyle>

<PagerStyle CssClass="pager"></PagerStyle>

<RowStyle CssClass="rows"></RowStyle>
        </asp:GridView> 
        </tr>
    </table>
    
</asp:Content>

