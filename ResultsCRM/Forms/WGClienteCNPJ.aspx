<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGClienteCNPJ.aspx.vb" Inherits="ResultsCRM.WGClienteCNPJ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">

.TextoCadastro_BGBranco
{
    font-size: 7pt;
    text-align: left;
    font-family: verdana;
    color: #666666;
    background-color: #FFFFFF;
}
.CampoCadastro
{
    font-size: 7pt;
    height: 18px;
    font-family: verdana;
    color: #666666;
    text-align: left;
}
.Botao
{
    background-position: 100% 100%;
    font-size: 7pt;
    font-weight: bold;
    text-align: center;
    color: #666666;
    font-family: verdana;
    background-color: #CCCCCC;
}
.TextoCadastro
{
    font-size: 7pt;
    text-align: right;
    font-family: verdana;
    color: #666666;
    background-color: #EFEFEF;
}
body
{
    height: 100%
}
    </style>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 100%;" class="TextoCadastro_BGBranco">
        <tr>
            <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Height="16px" Text="Pesquisar:"></asp:Label>
                <asp:TextBox ID="TxtPesquisa" runat="server" CssClass="CampoCadastro" 
                    ToolTip="Informe o CNPJ, o nome fantasia (ou parte), a cidade (ou parte) ou UF" 
                    Width="120px"></asp:TextBox>
                <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" 
                    Text="&nbsp;OK&nbsp;" />
            </td>
            <td style="text-align: right">
    
        <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
            AlternateText="Novo Registro" ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
            </td>
        </tr>
        <tr>
            <td colspan="2">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Width="100%" 
            AllowSorting="True">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="status_emitente" HeaderText="Situacao CNPJ/CPF" SortExpression="status_emitente" />
                <asp:BoundField DataField="cnpj" HeaderText="CNPJ" 
                    SortExpression="cnpj">
                </asp:BoundField>
                <asp:BoundField DataField="abreviado" HeaderText="Nome Fantasia" 
                    SortExpression="abreviado" />
                <asp:BoundField DataField="cidade_nome" HeaderText="Cidade" 
                    SortExpression="cidade_nome" >
                </asp:BoundField>
                <asp:BoundField DataField="estado_sigla" HeaderText="UF" 
                    SortExpression="estado_sigla" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("cnpj") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Detalhes do Registro" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                            CommandArgument='<%# Eval("cnpj") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" ToolTip="Excluir" 
                            
                            onclientclick="return confirm('Deseja realmente excluir o registro selecionado?');" 
                            Visible='<%# Iif( Session("GlBloquearCadastroEmitenteRepresentante") = "S", "False", "True" ) %>' />
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
            </td>
        </tr>
        <tr>
            <td colspan="2">
    <div style="text-align: right">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select cod_emitente, cnpj, abreviado, cidade_nome, estado_sigla, cod_emitente || '§' || cnpj || '§' || abreviado || '§' || cidade_nome || '§' || estado_sigla chave_pesquisa, descricao_situacao status_emitente
    from v_emitente_endereco
 where cod_emitente = :codigo
   and trim(cnpj) &lt;&gt; ''
   and trim(chave_pesquisa) like '%' || trim(isnull(:pesquisa,'')) || '%'
 order by nome">
            <SelectParameters>
                <asp:SessionParameter Name=":codigo" SessionField="SCodEmitente" />
                <asp:ControlParameter ControlID="TxtPesquisa" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":pesquisa" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
