<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCPosVendaFollowUp.ascx.vb" Inherits="ResultsCRM.WUCPosVendaFollowUp" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<%@ Register src="../OutrosControles/TextBoxHora.ascx" tagname="TextBoxHora" tagprefix="uc2" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<table class="TextoCadastro_BGBranco" style="width:100%;">
    <tr>
        <td colspan="2" style="font-weight: bold">
            FOLLOW-UP DO CLIENTE<asp:ScriptManager 
                ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
            </asp:ScriptManager>
        </td>
    </tr>
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label7" runat="server" Text="Seq.:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LblSeq" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Usuário:</td>
        <td>
            <asp:Label ID="LblNomeUsuario" runat="server"></asp:Label>
            (<asp:Label ID="LblCodUsuario" runat="server"></asp:Label>
            )</td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label2" runat="server" Text="Data:"></asp:Label>
        </td>
        <td>
            <uc1:TextBoxData ID="TxtData" runat="server" Width="80" />
        &nbsp;<asp:Label ID="Label3" runat="server" Text="Hora:" Height="16px"></asp:Label>
            <uc2:TextBoxHora ID="TxtHora" runat="server" Width="50" />
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top; text-align: right;">
            <asp:Label ID="Label6" runat="server" Text="Comentário:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                Height="100px" Width="350px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top">
            &nbsp;</td>
        <td>
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Salvar" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
