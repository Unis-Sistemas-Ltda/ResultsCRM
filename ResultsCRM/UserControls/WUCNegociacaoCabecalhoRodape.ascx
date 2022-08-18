<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoCabecalhoRodape.ascx.vb" Inherits="ResultsCRM.WUCNegociacaoCabecalhoRodape" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />

<table class="TextoCadastro_BGBranco" 
    style="width:100%; border-collapse: collapse;">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
            <asp:Label ID="LblCaminhoAnexo1" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCaminhoAnexo2" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCaminhoAnexo3" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCaminhoAnexo4" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCaminhoAnexo5" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label1" runat="server" Text="Cabeçalho" Width="460px" 
                style="text-align:left"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:Label ID="Label2" runat="server" Text="Rodapé"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; padding-right: 5px;">
            <asp:TextBox ID="TxtCabecalho" runat="server" Height="190px" 
                TextMode="MultiLine" Width="450px" CssClass="CampoCadastro"></asp:TextBox>
        </td>
        <td style="text-align: left">
            <asp:TextBox ID="TxtRodape" runat="server" Height="190px" TextMode="MultiLine" 
                Width="450px" CssClass="CampoCadastro"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: left" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: center" colspan="2">
            Anexo(s)</td>
    </tr>
    <tr>
        <td style="text-align: center" colspan="2">
            <asp:FileUpload ID="FuAnexoProposta1" runat="server" CssClass="CampoCadastro" 
                Width="450px" />
            <asp:ImageButton ID="BtnExcluirAnexo1" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" style="height: 13px" 
                ToolTip="Excluir Anexo" Visible="False" Width="13px" />
            <asp:HyperLink ID="LblAnexo1" runat="server" Target="_blank" Visible="False" style="text-align:left"
                Width="435px"></asp:HyperLink>
            <br />
            <asp:FileUpload ID="FuAnexoProposta2" runat="server" CssClass="CampoCadastro" 
                Width="450px" />
            <asp:ImageButton ID="BtnExcluirAnexo2" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" style="height: 13px" 
                ToolTip="Excluir Anexo" Visible="False" Width="13px" />
            <asp:HyperLink ID="LblAnexo2" runat="server" Target="_blank" Visible="False" style="text-align:left"
                Width="435px"></asp:HyperLink>
            <br />
            <asp:FileUpload ID="FuAnexoProposta3" runat="server" CssClass="CampoCadastro" 
                Width="450px" />
            <asp:ImageButton ID="BtnExcluirAnexo3" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" style="height: 13px" 
                ToolTip="Excluir Anexo" Visible="False" Width="13px" />
            <asp:HyperLink ID="LblAnexo3" runat="server" Target="_blank" Visible="False" style="text-align:left"
                Width="435px"></asp:HyperLink>
            <br />
            <asp:FileUpload ID="FuAnexoProposta4" runat="server" CssClass="CampoCadastro" 
                Width="450px" />
            <asp:ImageButton ID="BtnExcluirAnexo4" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" style="height: 13px" 
                ToolTip="Excluir Anexo" Visible="False" Width="13px" />
            <asp:HyperLink ID="LblAnexo4" runat="server" Target="_blank" Visible="False" style="text-align:left"
                Width="435px"></asp:HyperLink>
            <br />
            <asp:FileUpload ID="FuAnexoProposta5" runat="server" CssClass="CampoCadastro" 
                Width="450px" />
            <asp:ImageButton ID="BtnExcluirAnexo5" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" style="height: 13px" 
                ToolTip="Excluir Anexo" Visible="False" Width="13px" />
            <asp:HyperLink ID="LblAnexo5" runat="server" Target="_blank" Visible="False" style="text-align:left"
                Width="435px"></asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td style="text-align: center" colspan="2">
            <br />
            <asp:Button ID="BtnGravar" runat="server" Text="Salvar" CssClass="Botao" />
            &nbsp;&nbsp;<asp:Button ID="BtnImprimir" runat="server" CssClass="Botao" 
                Text="Visualizar proposta" />
        &nbsp;
            <asp:Button ID="BtnEmail" runat="server" CssClass="Botao" 
                Text="Enviar por e-mail" />
        </td>
    </tr>
</table>