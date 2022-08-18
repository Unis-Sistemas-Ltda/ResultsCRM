<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGPosVendaChamados.aspx.vb" Inherits="ResultsCRM.WGPosVendaChamados" %>

<!DOCTYPE html PUB1LIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TextoCadastro_BGBranco" style="font-weight: bold">
    
        <asp:Label ID="Label1" runat="server" Text="HISTÓRICO DE ATENDIMENTOS E SOLICITAÇÕES" 
            Width="80%"></asp:Label>
        <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
                        AlternateText="Novo Registro" ImageUrl="~/Imagens/BtnNovoRegistro.png" 
                        BorderColor="#000099" BorderStyle="Outset" Height="18px" ImageAlign="Bottom" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" DataSourceID="SqlDataSource1" 
            EmptyDataText="Nenhum chamado cadastrado até o momento." 
            EnableModelValidation="True" Font-Bold="False" ForeColor="#333333" 
            GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="cod_chamado" HeaderText="Nº Chamado" 
                    SortExpression="cod_chamado" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="data_chamado" DataFormatString="{0:dd/MM/yyyy HH:mm}" 
                    HeaderText="Data" SortExpression="data_chamado">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="assunto" 
                    HeaderText="Assunto" SortExpression="assunto">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao" HeaderText="Status" 
                    SortExpression="descricao" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_usuario" 
                    HeaderText="Analista" SortExpression="nome_usuario">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("cod_chamado") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select c.cod_chamado, c.data_chamado, c.assunto, sc.descricao, su.nome_usuario
  from chamado c inner join status_chamado sc on c.cod_status = sc.cod_status
                 inner join analista an on an.cod_analista = c.cod_analista
                 inner join sysusuario su on su.cod_usuario = an.cod_analista
 where cod_emitente = :cod_farmacia
order by c.cod_chamado desc">
            <SelectParameters>
                <asp:SessionParameter Name=":cod_farmacia" SessionField="SCodEmitente" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
