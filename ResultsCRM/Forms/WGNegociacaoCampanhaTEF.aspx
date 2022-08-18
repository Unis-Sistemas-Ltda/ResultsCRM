<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGNegociacaoCampanhaTEF.aspx.vb" Inherits="ResultsCRM.WGNegociacaoCampanhaTEF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.TextoCadastro
{
    font-size: 8pt;
    text-align: left;
    font-family: verdana;
    color: #2A2A2A;
    border-collapse: collapse;
    margin-bottom: 0px;
}

    </style>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" 
            AllowSorting="True" Font-Size="7pt">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="nome_rede" HeaderText="Grupo TEF" 
                    SortExpression="nome_rede">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_emitente" HeaderText="Código" ReadOnly="True" 
                    SortExpression="cod_emitente">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="razao_social" HeaderText="Razão Social" 
                    SortExpression="razao_social" >
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cnpj" HeaderText="CNPJ" SortExpression="cnpj" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="telefone" HeaderText="Telefone" 
                    SortExpression="telefone" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="sigla" HeaderText="Estado" SortExpression="sigla">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_cidade" HeaderText="Cidade" 
                    SortExpression="nome_cidade">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="desc_status_adesao" HeaderText="Status" 
                    SortExpression="desc_status_adesao" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_negociacao_cliente" HeaderText="Nº Negociação" 
                    SortExpression="cod_negociacao_cliente">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="email_enviado" HeaderText="E-mail enviado" 
                    SortExpression="email_enviado">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("chave") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Detalhes do Registro" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnExcluir" runat="server" 
                            CommandArgument='<%# Eval("chave") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja realmente excluir este cliente?');" 
                            ToolTip="Excluir" 
                            Visible='<%# iif( session("GlBloquearCadastroEmitenteRepresentante") = "S", "False", "True") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select l.cod_adesao, l.cod_emitente, l.razao_social, l.cnpj, a.nome_rede, s.descricao desc_status_adesao, l.cod_emitente || ';' || l.cnpj chave, uf.sigla, ci.nome_cidade, ee.telefone,
       isnull((select first 'S' from email_campanha_tef where cod_emitente = l.cod_emitente and cnpj = l.cnpj),'N') email_enviado,
       if l.cod_negociacao_cliente is null then 'N' else 'S' endif com_negociacao,
       l.cod_negociacao_cliente,
       trim(isnull((select email from contatos where cod_emitente = l.cod_emitente and preferencial = 'S'),'')) email,
       if email = '' then 'N' else 'S' endif email_preenchido
  from adesao_tef_loja l left outer join adesao_tef a on l.empresa = a.empresa and l.cod_adesao = a.cod_adesao
                         inner join endereco_emitente ee on ee.cod_emitente = l.cod_emitente and ee.cnpj = l.cnpj
                         inner join estado uf on uf.cod_pais = ee.cod_pais and uf.cod_estado = ee.cod_estado
                         inner join cidade ci on ci.cod_pais = ee.cod_pais and ci.cod_estado = ee.cod_estado and ci.cod_cidade = ee.cod_cidade
                         left outer join status_adesao_tef s on s.cod_status = l.cod_status
 where l.cod_negociacao_cliente = :negociacao
order by l.razao_social">
            <SelectParameters>
                <asp:SessionParameter Name=":negociacao" SessionField="SCodNegociacao" 
                    ConvertEmptyStringToNull="False" DbType="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
