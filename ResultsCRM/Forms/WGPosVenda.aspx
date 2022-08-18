<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGPosVenda.aspx.vb" Inherits="ResultsCRM.WGPosVenda" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.TituloMovimento
{
    font-family: Verdana;
    font-size: 12pt;
    font-weight: bold;
    color: #FFFFFF;
    background-color: #666666;
    text-align: center;
}
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
    font-family: verdana;
    color: #666666;
    text-align: left;
    margin-bottom: 0px;
}
        .style1
        {
            width: 258px;
        }
    .Erro
{
    font-size: 7pt;
    text-align: left;
    color: #CC0000;
    font-family: verdana;
}
    </style>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <div class="TituloMovimento">Painel de Cliente</div>
    <div>
    
        <table style="border: thin groove #CCCCCC; width:100%; font-family: verdana; font-size: 7pt;" 
            class="TextoCadastro_BGBranco">
            <tr>
                <td style="text-align: right; ">
                    Cód. Cliente:</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="TxtCodCliente" runat="server" 
                        CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                        Width="70px"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    Nome Cliente:</td>
                <td class="style1">
                    <asp:TextBox ID="TxtNomeEmitente" runat="server" CssClass="CampoCadastro" 
                        ToolTip="Informe o nome ou parte do nome do cliente." Width="195px"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    CNPJ/CPF:</td>
                <td>
                    <asp:TextBox ID="TxtCNPJ" runat="server" Width="115px" 
                        CssClass="CampoCadastro" 
                        ToolTip="Informe o CNPJ do cliente"></asp:TextBox>
                </td>
                <td style="text-align: right; ">
                    <asp:Label ID="Label11" runat="server" Height="16px" Text="E-mail/Contato:"></asp:Label>
&nbsp;<asp:TextBox ID="TxtEmail" runat="server" CssClass="CampoCadastro" 
                        
                        ToolTip="Informe o e-mail do cliente." 
                        Width="195px"></asp:TextBox>
                </td>
                <td style="text-align: right; ">
                    <asp:Button ID="Button1" runat="server" CssClass="Botao" Text="Pesquisar" />
                     <br />
    
        <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
            AlternateText="Novo Registro" ImageUrl="~/Imagens/BtnNovoRegistro.png" />
                </td>
            </tr>
            <tr>
                <td style="background-color: #FFFFE6;" class="Erro" colspan="8">
                    <asp:Label ID="LblErro" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                        GridLines="None" Width="100%" AllowSorting="True" AllowPaging="True" 
                        PageSize="16" EmptyDataText="Nenhum cadastro foi encontrado.">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerSettings FirstPageText="1&nbsp;&nbsp;" LastPageText="Últ." 
                            Mode="NumericFirstLast" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateField HeaderText="Cód." SortExpression="cod_emitente">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cod_emitente") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("cod_emitente") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nome" SortExpression="nome">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nome") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="Label12" runat="server" Font-Bold="False" 
                                        Text='<%# Eval("abreviado") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="cnpj" HeaderText="CNPJ/CPF" SortExpression="cnpj" />
                            <asp:BoundField DataField="status_emitente" HeaderText="Situação CNPJ / CPF" SortExpression="status_emitente" />
                            <asp:BoundField DataField="cidade_nome" HeaderText="Município" SortExpression="cidade_nome" />
                            <asp:BoundField DataField="estado_sigla" HeaderText="UF" SortExpression="estado_sigla" />
                            <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
                            <asp:BoundField DataField="contatos" HeaderText="Contatos" SortExpression="contatos" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" runat="server" 
                                        CommandArgument='<%# Eval("chave") %>' CommandName="ALTERAR" 
                                        ImageUrl="~/Imagens/BtnEditar.png" 
                                        ToolTip="Clique para consultar o histórico." />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        
                        
                        
                        
                        
                        
                        
                        SelectCommand="select e.cod_emitente,
       e.cod_emitente || ';' || e.cnpj chave,
       e.cnpj,
       e.nome,
       e.abreviado,
       e.email,
       e.cidade_nome,
       e.estado_sigla,
       e.contato_nome || ' (' || e.contato_email || ')' contatos,
       isnull(e.email,'') || ',' || isnull(contatos,'') chave_email,
      descricao_situacao status_emitente,
       if isnull(e.ativo,'N') = 'N' then 'Não' else 'Sim' endif cnpj_ativo,
       isnull((select isnull(cf.cod_representante,-1)
                 from cliente_financeiro cf
                where cf.cod_emitente = e.cod_emitente
                  and empresa = :empresa),-1) cod_representante,
       trim(isnull(:nome,'')) arg_nome,
       trim(isnull(:cnpj1,'')) arg_cnpj,
       trim(isnull(:cod_emitente1,'')) arg_emitente,
       trim(isnull(:email,'')) arg_chave_email
  from v_emitente_endereco e
 where e.tipo in (2,3)
   and trim(isnull(e.nome,'')) not in ('','0')
   and (arg_nome = '' or e.nome || ';' || isnull(e.abreviado,'') like '%' || arg_nome || '%')
   and (arg_cnpj = '' or e.cnpj like '%' || replace(replace(replace(replace(arg_cnpj,'/',''),'-',''),'.',''),' ','') || '%')
   and (arg_emitente = '' or e.cod_emitente = arg_emitente)
   and (:tipoacesso &lt;&gt; 3 or cod_representante = :codemitenteexterno)
   and (arg_chave_email = '' or chave_email like '%' || arg_chave_email || '%')
 order by e.nome, e.cnpj" DeleteCommand="select e.cod_emitente, e.nome, e.cnpj, e.email
  from v_emitente_endereco e
 where e.tipo in (2,3)
   and e.ativo = 'S'">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                            <asp:ControlParameter ControlID="TxtNomeEmitente" Name=":nome" 
                                PropertyName="Text" ConvertEmptyStringToNull="False" DefaultValue="" />
                            <asp:ControlParameter ControlID="TxtCNPJ" Name=":cnpj1" 
                                PropertyName="Text" ConvertEmptyStringToNull="False" />
                            <asp:ControlParameter ControlID="TxtCodCliente" 
                                ConvertEmptyStringToNull="False" Name=":cod_emitente1" PropertyName="Text" />
                            <asp:ControlParameter ControlID="TxtEmail" ConvertEmptyStringToNull="False" 
                                Name=":email" PropertyName="Text" />
                            <asp:SessionParameter Name=":tipoacesso" SessionField="GlTipoAcesso" />
                            <asp:SessionParameter Name=":codemitenteexterno" SessionField="GlCodEmitenteExterno" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            </table>
    
    </div>
    
    </div>
    </form>
</body>
</html>
