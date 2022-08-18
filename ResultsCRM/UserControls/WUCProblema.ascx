<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCProblema.ascx.vb" Inherits="ResultsCRM.WUCProblema" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<table class="TextoCadastro" style="width:100%;">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
            <asp:TextBox ID="TxtResposta" runat="server" CssClass="CampoCadastro" 
                Width="300px" Visible="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Código:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodProblema" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Grupo:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlGrupo" runat="server" CssClass="CampoCadastro" 
                Width="300px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Descrição Resumida:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAssunto" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td valign="top" style="text-align: right">
            Narrativa:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtPergunta" runat="server" CssClass="CampoCadastro" 
                Width="300px" Height="130px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Criticidade:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCriticidade" runat="server" CssClass="CampoCadastro" style="text-align:center"
                Width="35px"></asp:TextBox>
&nbsp;<asp:Label ID="Label1" runat="server" Height="17px" 
                Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Detecção:"></asp:Label>
            &nbsp;<asp:TextBox ID="TxtDeteccao" runat="server" CssClass="CampoCadastro" style="text-align:center"
                Width="35px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td valign="top" style="text-align: right">
            Faturar:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="CbxFaturar" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <br />
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        </td>
    </tr>
</table>
