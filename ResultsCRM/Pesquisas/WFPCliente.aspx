<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPCliente.aspx.vb" Inherits="ResultsCRM.WFPCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pesquisa de Clientes</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "WFPCliente.aspx";
        }
        function onSuccess() {
            window.parent.document.forms.item(0).submit();
            window.parent.document.getElementById('ButtonEditDone').click();
        }
        function onError() {
            getbacktostepone();
        }
        function cancel() {
            window.parent.document.getElementById('ButtonEditCancel').click();
        }
    </script>
</head>
<body class="TextoCadastro">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Scr4iptManager1" runat="server">
    </asp:ScriptManager>
    <asp:MultiView ID="MultiViewExpanse" runat="server">
        <asp:View ID="ViewInput" runat="server">
            <table class="TextoCadastro" 
                
                style="width: 350px; height: 390px; font-size: 7pt; background-color: #FFFFFF;">
                    <tr>
                        <td class="TituloConsulta" colspan="3" style="height: 20px">
                            Pesquisa de Clientes</td>
                    </tr>
                    <tr>
                        <td style="height: 25px">
                            <asp:Label ID="LblFornecedor" runat="server" 
                                Text="Informe o nome ou parte do nome do cliente:"></asp:Label>
                        </td>
                        <td class="CelulaCampoCadastro">
                            <asp:TextBox ID="TxtNome" runat="server" Font-Size="7pt" Width="145px"></asp:TextBox>
                        </td>
                        <td class="CelulaCampoCadastro">
                            <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="vertical-align: top">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                                CssClass="CampoCadastro" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                                GridLines="None" Width="345px" PageSize="4" Font-Size="7pt">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="BtnSelecionar" runat="server" 
                                                CommandArgument='<%# Eval("cod_emitente") %>' CommandName="SELECIONAR" 
                                                ForeColor="Black" Text='<%# Eval("nome") %>'></asp:LinkButton>
                                            <br />
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("abreviado") %>'></asp:Label>
                                            <br />
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("tipo_pessoa") %>'></asp:Label>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("cnpj") %>'></asp:Label>
                                            &nbsp; E-mail:<asp:Label ID="Label1" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                            &nbsp;Fone:<asp:Label ID="Label4" runat="server" Text='<%# Eval("telefone1") %>'></asp:Label>
                                            <br />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Código" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="LblCodigo" runat="server" Text='<%# Bind("cod_emitente") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cod_emitente") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings FirstPageText="1&nbsp;" LastPageText="Última" 
                                    Mode="NumericFirstLast" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Left" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select :cod_gestor gest, e.cod_emitente, e.nome || ' (' || e.cod_emitente || ')' nome, e.cnpj, e.telefone1, e.abreviado, e.email, convert(varchar(7), e.cod_emitente) || '§' || e.nome || '§' || e.cnpj || '§' || e.telefone1 || '§' || e.telefone2 || '§' || e.email || '§' || e.abreviado busca, if e.tp_pessoa = 'PF' then 'CPF:' else 'CNPJ:' endif tipo_pessoa,
isnull((select isnull(cf.cod_representante,-1)
  from cliente_financeiro cf
 where cf.cod_emitente = e.cod_emitente
   and empresa = :empresa),-1) cod_representante, cod_representante repre
           from v_emitente_endereco e
          where tipo in (2,3)
            and busca like '%' || isnull(:nome,'') || '%'
            and trim(e.nome) &lt;&gt; ''
            and trim(e.nome) &lt;&gt; '-'
            and e.preferencial = 'S'
            and ((gest &lt;= 0 and cod_representante = if :tipoacesso = 3 then :codemitenteexterno else cod_representante endif) or gest &gt; 0)
            and (:cod_gestor &lt;= 0 or exists(select 1 from gestor_conta_representante gr inner join gestor_conta gc on gr.cod_gestor = gc.cod_gestor where gc.cod_usuario =gest and gr.cod_representante = repre))
          order by replace(replace(trim(e.nome),'+',''),'&quot;','')">
                                <SelectParameters>
                                    <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name=":cod_gestor" SessionField="GlCodGestor" />
                                    <asp:SessionParameter ConvertEmptyStringToNull="False" Name=":empresa"    DbType="String" SessionField="GlEmpresa" />
                                    <asp:ControlParameter ConvertEmptyStringToNull="False" Name=":nome"       DbType="String" ControlID="TxtNome" PropertyName="Text" />
                                    <asp:SessionParameter ConvertEmptyStringToNull="False" Name=":tipoacesso" SessionField="GlTipoAcesso" />
                                    <asp:SessionParameter ConvertEmptyStringToNull="False" Name=":codemitenteexterno" DbType="String" SessionField="GlCodEmitenteExterno" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 16px">
                            <asp:Button ID="btnOkay" runat="server" CssClass="Botao" 
                                OnClick="btnOkay_Click" Text="Done" Visible="False" />
                            &nbsp;<input ID="btnCancel" class="Botao" onclick="cancel();" 
                                style="border-style: none; font-family: verdana; text-decoration: underline; text-align: center;" 
                                type="button" value="Fechar" /></td>
                    </tr>
                </table>
                
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>