<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCMarcador.ascx.vb" Inherits="ResultsCRM.WUCMarcador" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloCadastro">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    Marcador
</div>
<table class="TextoCadastro" style="width:100%; background-color: #FFFFFF;">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Código:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodMarcador" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Descrição:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                MaxLength="20" Width="275px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Marcador Pai:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlMarcadorPai" runat="server" CssClass="CampoCadastro" 
                Width="275px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <br />
            <asp:Button ID="btnOkay" runat="server" CssClass="Botao" 
                OnClick="btnOkay_Click" Text="Done" Visible="False" />
        </td>
        <td style="text-align: left">
            <br />
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
