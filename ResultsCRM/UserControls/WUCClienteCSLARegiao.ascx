<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCClienteCSLARegiao.ascx.vb" Inherits="ResultsCRM.WUCClienteCSLARegiao" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloCadastro">Detalhe de SLA por Região</div>
<table style="width:100%;" class="TextoCadastro_BGBranco">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            SLA:</td>
        <td class="CelulaCampoCadastro" style="font-weight: bold">
            <asp:Label ID="LblDescricaoSLA" runat="server"></asp:Label>
            (<asp:Label ID="LblCodSLA" runat="server"></asp:Label>
            )&nbsp;&nbsp;&nbsp;&nbsp; UF:
            <asp:Label ID="LblUF" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Cód. Região:</td>
        <td class="CelulaCampoCadastro" style="font-weight: bold">
            <asp:Label ID="LblCodRegiao" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nome Região:</td>
        <td class="CelulaCampoCadastro" style="font-weight: bold">
            <asp:TextBox ID="TxtNomeRegiao" runat="server" CssClass="CampoCadastro" 
                Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Prazo Chegada:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtPrazoChegada" runat="server" CssClass="CampoCadastro" style="text-align: center"
                Width="80px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label1" runat="server" Height="16px" Text="h."></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Prazo Encerramento:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtPrazoEncerramento" runat="server" CssClass="CampoCadastro" style="text-align: center"
                Width="80px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label2" runat="server" Height="16px" Text="h."></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <table style="border: 1px solid #C0C0C0; width:420px;">
                <tr>
                    <td colspan="2" style="text-align: left">
                        <asp:TextBox ID="TxtPesquisaCidade" runat="server" CssClass="CampoCadastro" 
                            Width="95px"></asp:TextBox>
&nbsp;<asp:Button ID="BtnPesquisa" runat="server" CssClass="Botao" Text="Pesq. Município" />
                    </td>
                    <td style="text-align: left">
                        <asp:Label ID="Label3" runat="server" Text="Municípios Adicionados" style="text-align:right"
                            Width="170px" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ListBox ID="LbFiltro" runat="server" CssClass="CampoCadastro" 
                            Height="170px" Width="170px"></asp:ListBox>
                    </td>
                    <td style="text-align: center; ">
                        <asp:Button ID="BtnIncluir" runat="server" CssClass="Botao" Font-Bold="True" 
                            Text="&gt;&gt;" />
                        <br />
                        <br />
                        <asp:Button ID="BtnExcluir" runat="server" CssClass="Botao" Font-Bold="True" 
                            Text="&lt;&lt;" />
                    </td>
                    <td style="text-align: left">
                        <asp:ListBox ID="LbCidades" runat="server" CssClass="CampoCadastro" 
                            Height="170px" Width="170px"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="BtnGravar" runat="server" Text="Gravar" CssClass="Botao" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
