<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TextBoxData.ascx.vb" Inherits="ResultsCRM.TextBoxData" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="../ResultsCRM.js" type="text/javascript"></script>
<body style="border:0; margin:0; padding:0">
<asp:TextBox ID="TextBox1" runat="server" CssClass="CampoCadastro" style="text-align:center" MaxLength="10" Width="75px"></asp:TextBox>
<cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                        TargetControlID="TextBox1" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
    </body>