<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAvaliacaoItem.ascx.vb" Inherits="ResultsCRM.WUCAvaliacaoItem" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
    <br />
    <asp:Label ID="Label9" runat="server" Height="17px" Text="Seq. Item:&nbsp;"
        Style="text-align: right" Width="100px"></asp:Label>
    <asp:Label ID="LblSeqItemAvaliado" runat="server" Text="0" Height="17px"></asp:Label>
    <br />
    <asp:Label ID="Label14" runat="server" Text="Descrição Item:&nbsp;" Style="text-align: right"
        Width="100px"></asp:Label>
    <asp:Label ID="LblDescricaoItem" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label15" runat="server" Height="17px" Text="Resultado:&nbsp;" Style="text-align: right"
        Width="100px"></asp:Label>
    <asp:DropDownList ID="DdlResultado" runat="server" CssClass="CampoCadastro" 
        Width="295px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label8" runat="server" Height="17px" Style="text-align: right" Width="100px"></asp:Label>
    <asp:Button ID="BtnGravar" runat="server" Text="Gravar" />
    &nbsp;<asp:Button ID="Button1" runat="server" Text="Voltar" />
</div>
