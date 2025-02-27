﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAgenteVenda.aspx.vb" Inherits="ResultsCRM.WGAgenteVenda" %>

<%@ Register src="../UserControls/WUCAgenteVenda.ascx" tagname="WUCAgenteVenda" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: right">
    <div class="TituloCadastro">Cadastro de Agente de Vendas
        </div>
        <div>
    
            <asp:ImageButton ID="ImageButton2" runat="server" 
                ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
        </div>
    
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
            CssClass="TextoCadastro" ForeColor="#333333" GridLines="None" Width="100%" 
            AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="cod_agente_venda" HeaderText="Código" 
                    SortExpression="cod_agente_venda">
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_usuario" HeaderText="Nome" 
                    SortExpression="nome_usuario">
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao" HeaderText="Tipo" 
                    SortExpression="descricao">
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("cod_agente_venda") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select av.cod_agente_venda,
       s.nome_usuario,
       av.cod_tp_agente_venda,
       t.descricao
  from agente_venda av left outer join tipo_agente_venda t on t.cod_tp_agente_vendas = av.cod_tp_agente_venda,
       sysusuario s
 where av.cod_agente_venda = s.cod_usuario
order by s.nome_usuario"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
