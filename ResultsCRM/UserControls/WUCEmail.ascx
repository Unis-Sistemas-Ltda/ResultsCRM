<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCEmail.ascx.vb" Inherits="ResultsCRM.WUCEmail" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="../ResultsCRM.js" type="text/javascript"></script>
<style type="text/css">
    .style1
    {
        height: 22px;
    }
</style>
<script type="text/javascript">
    function voltar() {
        window.parent.document.getElementById('BtnVoltar').click();
    }
</script>
<table class="TextoCadastro_BGBranco" 
    style="margin: 0px; width: 100%; border-collapse: collapse;">
    <tr>
        <td colspan="4">
            <asp:ScriptManager ID="ScriptManager1" runat="server" 
                EnableScriptGlobalization="True">
            </asp:ScriptManager>
            <asp:Label ID="LblCaminhoAnexo1" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCaminhoAnexo2" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCaminhoAnexo3" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCaminhoAnexo4" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCaminhoAnexo5" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="text-align: center">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro" style="padding: 10px;"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-weight: bold; width: 20%;">
            E-mail:</td>
        <td colspan="3">
            <asp:Label ID="LblNrEmail" runat="server" Height="16px" Text="0"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Height="16px" Text="Data:"></asp:Label>
&nbsp;<asp:TextBox ID="TxtData" runat="server" CssClass="CampoCadastro" Width="70px" 
                MaxLength="10"></asp:TextBox><ajaxToolkit:CalendarExtender ID="TxtDataRecontatoI_CalendarExtender" runat="server" 
                        TargetControlID="TxtData" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
            <asp:TextBox ID="TxtHora" runat="server" CssClass="CampoCadastro" Width="60px" 
                MaxLength="5"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-weight: bold;">
            Remetente:</td>
        <td colspan="3">
            <asp:Label ID="LblRemetenteNome" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-weight: bold;">
            Destinatário(s):</td>
        <td colspan="3">
            <asp:TextBox ID="TxtDestinatarioEmail" runat="server" CssClass="CampoCadastro" 
                Width="98%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-weight: bold;">
            Cópia para (CC):</td>
        <td>
            <asp:TextBox ID="TxtEmailCC" runat="server" CssClass="CampoCadastro" 
                Width="100%"></asp:TextBox>
        </td>
        <td style="text-align: right; font-weight: bold; width: 15%;">
            Cópia Oculta (CCO):</td>
        <td>
            <asp:TextBox ID="TxtCCO" runat="server" CssClass="CampoCadastro" 
                Width="95%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-weight: bold;" class="style1">
            Assunto:</td>
        <td colspan="3" class="style1">
            <asp:TextBox ID="TxtAssunto" runat="server" CssClass="CampoCadastro" 
                Width="98%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top; font-weight: bold;">
            Anexo(s):</td>
        <td colspan="3">
            <asp:FileUpload ID="FUAnexo1" runat="server" CssClass="CampoCadastro" 
                Width="350px" />
            <asp:ImageButton ID="BtnExcluirAnexo1" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" style="height: 13px" 
                ToolTip="Excluir Anexo" Visible="False" Width="13px" />
            <asp:HyperLink ID="LblAnexo1" runat="server" Target="_blank"></asp:HyperLink>
            <br />
            <asp:FileUpload ID="FUAnexo2" runat="server" CssClass="CampoCadastro" 
                Width="350px" />
            <asp:ImageButton ID="BtnExcluirAnexo2" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" ToolTip="Excluir Anexo" Visible="False" 
                Width="13px" />
            <asp:HyperLink ID="LblAnexo2" runat="server" Target="_blank"></asp:HyperLink>
            <br />
            <asp:FileUpload ID="FUAnexo3" runat="server" CssClass="CampoCadastro" 
                Width="350px" />
            <asp:ImageButton ID="BtnExcluirAnexo3" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" ToolTip="Excluir Anexo" Visible="False" 
                Width="13px" />
            <asp:HyperLink ID="LblAnexo3" runat="server" Target="_blank"></asp:HyperLink>
            <br />
            <asp:FileUpload ID="FUAnexo4" runat="server" CssClass="CampoCadastro" 
                Width="350px" />
            <asp:ImageButton ID="BtnExcluirAnexo4" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" ToolTip="Excluir Anexo" Visible="False" 
                Width="13px" />
            <asp:HyperLink ID="LblAnexo4" runat="server" Target="_blank"></asp:HyperLink>
            <br />
            <asp:FileUpload ID="FUAnexo5" runat="server" CssClass="CampoCadastro" 
                Width="350px" />
            <asp:ImageButton ID="BtnExcluirAnexo5" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" ToolTip="Excluir Anexo" Visible="False" 
                Width="13px" />
            <asp:HyperLink ID="LblAnexo5" runat="server" Target="_blank"></asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top; font-weight: bold;">
            Mensagem:</td>
        <td colspan="3">
            
                    <asp:TextBox ID="TxtMensagem" runat="server" CssClass="CampoCadastro" 
                        Font-Size="8pt" Height="200px" TextMode="MultiLine" Width="98%"></asp:TextBox>
                    
            
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top">
            </td>
        <td colspan="3">
            <asp:Button ID="BtnEnviar" runat="server" CssClass="Botao" Text="Enviar" />
        &nbsp;
            <asp:Button ID="BtnSalvar" runat="server" CssClass="Botao" Text="Salvar" />
        </td>
    </tr>
</table>