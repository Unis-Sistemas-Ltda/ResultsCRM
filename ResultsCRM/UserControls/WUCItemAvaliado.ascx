<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCItemAvaliado.ascx.vb" Inherits="ResultsCRM.WUCItemAvaliado" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
    <br />
    <asp:Label ID="Label9" runat="server" Height="17px" Text="Seq. Item:&nbsp;"
        Style="text-align: right" Width="125px"></asp:Label>
    <asp:Label ID="LblSeqItemAvaliado" runat="server" Text="0" Height="17px"></asp:Label>
    <br />
    <asp:Label ID="Label14" runat="server" Height="17px" Text="Descrição:&nbsp;" Style="text-align: right"
        Width="125px"></asp:Label>
    <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
        Width="333px" Height="45px" TextMode="MultiLine"></asp:TextBox>
    <br />
    <asp:Label ID="Label15" runat="server" Height="17px" 
        Text="Grupo Resultado:&nbsp;" Style="text-align: right"
        Width="125px"></asp:Label>
    <asp:DropDownList ID="DdlGrupoResultado" runat="server" 
        CssClass="CampoCadastro" Width="340px">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label16" runat="server" Height="17px" Text="Grupo Item:&nbsp;" Style="text-align: right"
        Width="125px"></asp:Label>
    <asp:DropDownList ID="DdlGrupoItem" runat="server" CssClass="CampoCadastro" 
        Width="340px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label8" runat="server" Height="17px" Style="text-align: right" Width="100px"></asp:Label>
    <asp:Button ID="BtnGravar" runat="server" Text="Gravar" />
    &nbsp;<asp:Button ID="Button1" runat="server" Text="Voltar" />
</div>
