<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGCliente.aspx.vb" Inherits="ResultsCRM.WGCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloCadastro">
                Cadastro de Clientes</div>
        <div class="Erro">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
    </div>
        <div style="text-align: right; vertical-align: middle;">
    
            &nbsp;<asp:Label ID="Label2" runat="server" CssClass="TextoCadastro_BGBranco" Height="16px" 
                Text="Código:"></asp:Label>
            <asp:TextBox ID="TxtCodigo" runat="server" CssClass="CampoCadastro"></asp:TextBox>
&nbsp;
            <asp:Label ID="Label1" runat="server" CssClass="TextoCadastro_BGBranco" 
                Height="16px" Text="Nome:"></asp:Label>
            <asp:TextBox ID="TxtNome" runat="server" CssClass="CampoCadastro" Width="350px"></asp:TextBox>
             <td style="text-align: right;">
                    CNPJ/CPF:</td>
                <td>
                    <asp:TextBox ID="TxtCNPJ" runat="server" Width="115px" 
                        CssClass="CampoCadastro" 
                        ToolTip="Informe o CNPJ do cliente"></asp:TextBox>
                </td>
&nbsp;&nbsp;
            <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" Text="Filtrar" />
            <br />
    
        <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
            AlternateText="Novo Registro" ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
    </div>
    <div style="text-align: right">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" 
            AllowSorting="True">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="cod_emitente" HeaderText="Código" ReadOnly="True" 
                    SortExpression="cod_emitente">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nome" HeaderText="Nome/Razão Social" 
                    SortExpression="nome" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_abreviado" HeaderText="Nome Fantasia" 
                    SortExpression="nome_abreviado" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("cod_emitente") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Detalhes do Registro" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnExcluir" runat="server" 
                            CommandArgument='<%# Eval("cod_emitente") %>' CommandName="EXCLUIR" 
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
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select cod_emitente, nome, nome_abreviado,  isnull((select isnull(cod_representante,-1)
  from cliente_financeiro
 where cod_emitente = emitente.cod_emitente
   and empresa = :empresa),-1) cod_representante
    from emitente
 where cod_emitente = if isnull(:codigo,'') = '' or isnumeric(:codigo) = 0 then cod_emitente else :codigo endif
     and nome like if isnull(:nome,'') = '' then nome else '%' || :nome || '%' endif
     and tipo in (2,3)
     and cod_representante = if :tipoacesso = 3 then :codemitenteexterno else cod_representante endif
 order by nome">
            <SelectParameters>
                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                <asp:ControlParameter ControlID="TxtCodigo" ConvertEmptyStringToNull="False" 
                    Name=":codigo" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtNome" ConvertEmptyStringToNull="False" 
                    Name=":nome" PropertyName="Text" />
                <asp:SessionParameter Name=":tipoacesso" SessionField="GlTipoAcesso" />
                <asp:SessionParameter Name=":codemitenteexterno" 
                    SessionField="GlCodEmitenteExterno" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
