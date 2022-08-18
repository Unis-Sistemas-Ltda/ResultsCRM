<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPUsuario.aspx.vb" Inherits="ResultsCRM.WFPUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pesquisa de Usuários</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "WFPUsuario.aspx";
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:MultiView ID="MultiViewExpanse" runat="server">
            <asp:View ID="ViewInput" runat="server">
                <table class="TextoCadastro" 
                    
                    style="width: 350px; height: 390px; font-size: 7pt; background-color: #FFFFFF;">
                    <tr>
                        <td class="TituloConsulta" colspan="3" style="height: 20px">
                            Pesquisa de Usuários</td>
                    </tr>
                    <tr style="height: 25px">
                        <td>
                            <asp:Label ID="LblFornecedor" runat="server"  
                                Text="Informe o nome ou parte do nome do usuário:"></asp:Label>
                        </td>
                        <td class="CelulaCampoCadastro">
                            <asp:TextBox ID="TxtNome" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td class="CelulaCampoCadastro">
                            <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" Text="Filtrar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="vertical-align: top">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                                CssClass="CampoCadastro" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                                GridLines="None" PageSize="11" Width="350px" Font-Size="7pt">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="BtnDescricao" runat="server" 
                                                CommandArgument='<%# Eval("cod_usuario") %>' CommandName="SELECIONAR" 
                                                ForeColor="Black" Text='<%# Eval("nome_usuario") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Código" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="LblCodigo" runat="server" Text='<%# Eval("cod_usuario") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cod_usuario") %>'></asp:TextBox>
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
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select u.cod_usuario, 
           u.nome_usuario || ' (' || u.cod_usuario || ')' nome_usuario
          from sysusuario u
         where u.nome_usuario like '%' || isnull(:nome,'') || '%'
           and u.id_situacao &lt;&gt; 5
         order by u.nome_usuario">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="TxtNome" ConvertEmptyStringToNull="False" 
                                        Name=":nome" PropertyName="Text" />
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