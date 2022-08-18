<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAtendimentoEmail.ascx.vb" Inherits="ResultsCRM.WUCAtendimentoEmail" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="../ResultsCRM.js" type="text/javascript"></script>
<style type="text/css">
    .style1
    {
        height: 22px;
    }
</style>
<table class="TextoCadastro_BGBranco" 
    style="margin: 0px; width: 450px; border-collapse: collapse;">
    <tr>
        <td colspan="4">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
            <asp:Label ID="LblCaminhoAnexo1" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCaminhoAnexo2" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCaminhoAnexo3" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            E-mail:</td>
        <td colspan="3">
            <asp:Label ID="LblNrEmail" runat="server" Height="16px" Text="0"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Height="16px" Text="Data:"></asp:Label>
&nbsp;<asp:TextBox ID="TxtData" runat="server" CssClass="CampoCadastro" Width="70px" 
                MaxLength="10"></asp:TextBox>
            <asp:TextBox ID="TxtHora" runat="server" CssClass="CampoCadastro" Width="45px" 
                MaxLength="5"></asp:TextBox>
&nbsp;
            <asp:Label ID="Label2" runat="server" Height="16px" Text="Enviado:"></asp:Label>
&nbsp;<asp:Label ID="LblEnviadoData" runat="server" Height="16px" Font-Bold="True"></asp:Label>
            <asp:Label ID="LblEnviadoHora" runat="server" Height="16px" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Remetente:</td>
        <td>
            <asp:Label ID="LblRemetenteNome" runat="server"></asp:Label>
        </td>
        <td style="text-align: right">
            E-mail:</td>
        <td>
            <asp:Label ID="LblRemetenteEmail" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Destinatário:</td>
        <td>
            <asp:TextBox ID="TxtDestinatario" runat="server" CssClass="CampoCadastro" 
                Width="150px"></asp:TextBox>
        </td>
        <td style="text-align: right">
            E-mail:</td>
        <td>
            <asp:TextBox ID="TxtDestinatarioEmail" runat="server" CssClass="CampoCadastro" 
                Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Cópia para:</td>
        <td>
            <asp:TextBox ID="TxtEmailCC" runat="server" CssClass="CampoCadastro" 
                Width="150px"></asp:TextBox>
        </td>
        <td style="text-align: right">
            CCO:</td>
        <td>
            <asp:TextBox ID="TxtCCO" runat="server" CssClass="CampoCadastro" 
                Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="style1">
            Assunto:</td>
        <td colspan="3" class="style1">
            <asp:TextBox ID="TxtAssunto" runat="server" CssClass="CampoCadastro" 
                Width="99%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            Anexo(s):</td>
        <td colspan="3">
            <asp:FileUpload ID="FUAnexo1" runat="server" CssClass="CampoCadastro" 
                Width="320px" />
            <asp:ImageButton ID="BtnExcluirAnexo1" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" style="height: 13px" 
                ToolTip="Excluir Anexo" Visible="False" Width="13px" />
            <asp:HyperLink ID="LblAnexo1" runat="server" Target="_blank">[LblAnexo1]</asp:HyperLink>
            <br />
            <asp:FileUpload ID="FUAnexo2" runat="server" CssClass="CampoCadastro" 
                Width="320px" />
            <asp:ImageButton ID="BtnExcluirAnexo2" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" ToolTip="Excluir Anexo" Visible="False" 
                Width="13px" />
            <asp:HyperLink ID="LblAnexo2" runat="server" Target="_blank">[LblAnexo2]</asp:HyperLink>
            <br />
            <asp:FileUpload ID="FUAnexo3" runat="server" CssClass="CampoCadastro" 
                Width="320px" />
            <asp:ImageButton ID="BtnExcluirAnexo3" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" ToolTip="Excluir Anexo" Visible="False" 
                Width="13px" />
            <asp:HyperLink ID="LblAnexo3" runat="server" Target="_blank">[LblAnexo3]</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top">
            Mensagem:</td>
        <td colspan="3">
            <asp:TextBox ID="TxtMensagem" runat="server" CssClass="CampoCadastro" 
                Height="100px" TextMode="MultiLine" Width="100%" Font-Size="8pt"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top">
            &nbsp;</td>
        <td colspan="2">
            <asp:Button ID="BtnSalvar" runat="server" CssClass="Botao" Text="Salvar" />
&nbsp; <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
        <td colspan="1" style="text-align: right">
            <asp:Button ID="BtnEnviar" runat="server" CssClass="Botao" Text="Enviar" />
        </td>
    </tr>
</table>
