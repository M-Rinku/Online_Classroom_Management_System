<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="exam.aspx.cs" Inherits="exam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
<link href="Style/css/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.typekit.net/idk3wns.css">
    <link href="Style/fonts/material-design-iconic-font/css/material-design-iconic-font.min.css" rel="stylesheet" />
    <link href="Style/css/about.css" rel="stylesheet" />
    <script src="Style/js/Js.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 97%;
            margin-left:20px;
            
        }
        .auto-style2 {
            height: 19px;
        } 
        .auto-style3 {
            text-align: right;
            
        }
        #countdown
        {
        
            border: solid 1px;
            width:100px;
            height:50px;
            background-color:yellow;
            color:red;
            position:absolute;
            left:90%;
            top:5%;
            text-align:center;
            }
        .auto-style4 {
            width: 100%;
        }
    </style>
    <style type="text/css" media="print">
body {visibility: hidden; display: none;}
</style>
    <script type="text/javascript">


        var secs = 0;
        var min = 0;
        var sec2 = 0;
        var timerID = null;
        var timerRunning = false;
        var delay = 1000;
        var calmin = 0;
        var calsec = 0;
        var ttclock = "0 minutes &nbsp;&nbsp;00 seconds";
        
        function InitializeTimer(form) {
            var adday3 = form;
            secs = adday3 * 60;
            StopTheClock();
            StartTheTimer();
        }

        function StopTheClock() {
            if (timerRunning)
                clearTimeout(timerID)
            timerRunning = false;
        }
       
        function redirect() {

            
            
            document.getElementById('<%= btn_submit.ClientID %>').click();
            
            document.getElementById('<%= btn_see.ClientID %>').click();
           // window.location = "Default.aspx";
        }

        function StartTheTimer() {
            if (secs == -1) {
                StopTheClock()
                
                    redirect();
                    
                

            }
            else {
                min = Math.floor(secs / 60);
                sec2 = secs % 60;
                ttclock = min + " minutes " + "&nbsp;&nbsp;" + pad(sec2) + " seconds";
                //document.getElementById('<%= btn_submit.ClientID %>').Text = "aaa";
                //btn_time.textContent = "amit";
                calmin = min * 60;
                calsec = calmin + sec2;
                
                secs = secs - 1;
                timerRunning = true;
                timerID = self.setTimeout("StartTheTimer()", delay);
            }
        }

        function countdown_clock(ttclock) {
            html_code = '<div id="countdown"></div>';
            document.write(html_code);
            countdown();
        }

        function countdown(ttclock) {

            document.all.countdown.innerHTML = ttclock;
            setTimeout('countdown(ttclock);', 0);
        }

        function pad(n) {

            if (n < 10) {
                return "0" + n;
            }
            else {
                return n;
            }
        }

        
        




    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
 
  <a href="logout.aspx">Logout</a>   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <asp:Button ID="btn_start" runat="server" Text="Start Exam" OnClick="btn_start_Click" CssClass="btnstartexam" Visible="False" />
    <asp:Panel ID="pnl_question" runat="server" CssClass="pnlquestion" oncopy="return false" oncut="return false" onpaste="return false" >
        <div>

            <table cellpadding="0" cellspacing="0" class="auto-style4">
                <tr>
                    <td>
                        <asp:Label ID="lbl_qheader" runat="server" Text="" Font-Bold="true" Font-Size="Large" Font-Underline="true"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="lbl_start" runat="server" Text=""></asp:Label>
                        
                        <asp:Label ID="lbl_starttime" runat="server" Text="Total Time : "></asp:Label>
                        <asp:Label ID="lbl_time" runat="server" Text="2"></asp:Label>
                        <asp:Label ID="lbl_minutes" runat="server" Text="Minutes"></asp:Label>
                    </td>
                </tr>
            </table>

        </div>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            

            <table cellpadding="0" cellspacing="0" class="auto-style1" style="@media print { html, body { display: none;  /* hide whole page */ } }; @media save { html, body { display: none;  /* hide whole page */ } }">
            <tr>
                <td>
                    <asp:Label ID="lbl_slno" runat="server" Text='<%#Eval("sl_no") %>'></asp:Label> : <asp:Label ID="lbl_question" runat="server" Text='<%#Eval("question") %>'></asp:Label></td>
                <td class="auto-style3">
                    <asp:Label ID="lbl_marks" runat="server" Text='<%#Eval("marks") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:RadioButton ID="option1" runat="server" Text='<%#Eval("option1") %>' GroupName="rdexam"/>
                        <asp:RadioButton ID="option2" runat="server" Text='<%#Eval("option2") %>' GroupName="rdexam"/>
                     
                        <asp:RadioButton ID="option3" runat="server" Text='<%#Eval("option3") %>' GroupName="rdexam"/>
                        <asp:RadioButton ID="option4" runat="server" Text='<%#Eval("option4") %>' GroupName="rdexam"/>
                    <br />
                    <asp:Label ID="lbl_ans" runat="server" Text='<%#Eval("correctanswer") %>' Visible="False"></asp:Label>
                </td>
                
                
                <br />

            </tr>
        </table>
        </ItemTemplate>
    </asp:Repeater>
    <div class="centertext">
        <asp:Panel ID="pnl_time" runat="server">
        <div id=countdown1>
            

</div>
            </asp:Panel>
    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" CssClass="btnlogin" />
        <asp:Button ID="btn_see" runat="server" Text="See Answers" CssClass="btnlogin" OnClick="btn_see_Click" />
        </div>
        </asp:Panel>
    <script>
        var time = document.getElementById('<%= lbl_time.ClientID %>');
        
        window.onload = function () { InitializeTimer(time.textContent); };
        
    </script>
    <script>
document.addEventListener("contextmenu", function(event){
event.preventDefault();
alert('Right Click is Disabled');    
}, false);


var a = 0;

document.onkeydown = function (e)
{  
 return false;  
}

</script>
</asp:Content>

