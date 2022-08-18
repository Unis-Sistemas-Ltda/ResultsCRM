<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCTEFGrupo.ascx.vb" Inherits="ResultsCRM.WUCTEFGrupo" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
<table class="TextoCadastro" style="width:100%;">
    <tr>
        <td class="Erro">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Código:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCodGrupo" runat="server" CssClass="CampoCadastro" 
                Width="55px" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nome da Rede/Campanha:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nome Responsável:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtNomeResponsavel" runat="server" CssClass="CampoCadastro" 
                Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Telefone Responsável:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtTelefoneResponsavel" runat="server" 
                CssClass="CampoCadastro" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            E-mail Responsável:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtEmailResponsavel" runat="server" CssClass="CampoCadastro" 
                Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Adquirente Padrão:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlAdquirentePadrao" runat="server" 
                CssClass="CampoCadastro" Height="16px" Width="308px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Operadora Padrão:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlOperadoraPadrao" runat="server" 
                CssClass="CampoCadastro" Width="308px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Valor Instalação:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtValorInstalacao" runat="server" CssClass="CampoCadastro" style="text-align: right"
                Width="80px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Valor Mensalidade:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtValorMensalidade" runat="server" CssClass="CampoCadastro" style="text-align: right"
                Width="80px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Valor Reinstalação:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtValorReinstalacao" runat="server" CssClass="CampoCadastro" style="text-align: right"
                Width="80px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Valor Mensalidade PDV Adicional:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtValorMensalidadePDVAdicional" runat="server" style="text-align: right"
                CssClass="CampoCadastro" Width="80px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Valor POO:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtValorPOO" runat="server" CssClass="CampoCadastro" style="text-align: right"
                Width="80px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Valor POS:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtValorPOS" runat="server" CssClass="CampoCadastro" style="text-align: right"
                Width="80px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Valor Repasse:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtValorRepasse" runat="server" CssClass="CampoCadastro" style="text-align: right"
                Width="80px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
            <br />
            <br />
        </td>
    </tr>
</table>