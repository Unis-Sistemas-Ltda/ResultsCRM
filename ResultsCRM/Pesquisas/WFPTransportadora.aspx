<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPTransportadora.aspx.vb" Inherits="ResultsCRM.WFPTransportadora" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pesquisa de Clientes</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "WFPTransportadora.aspx";
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
                            Pesquisa de Transportadoras</td>
                    </tr>
                    <tr>
                        <td style="height: 25px">
                            <asp:Label ID="LblFornecedor" runat="server" 
                                Text="Informe o nome ou parte do nome da transportadora:"></asp:Label>
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
                                GridLines="None" Width="345px" PageSize="11" Font-Size="7pt">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="BtnSelecionar" runat="server" 
                                                CommandArgument='<%# Eval("cod_emitente") %>' CommandName="SELECIONAR" 
                                                ForeColor="Black" Text='<%# Eval("nome") %>'></asp:LinkButton>
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
                                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select e.cod_emitente, e.nome || ' (' || e.cod_emitente || ')' nome
           from emitente e
          where tipo in (1,3)
            and e.nome like '%' || isnull(:nome,'') || '%'
            and trim(e.nome) &lt;&gt; ''
            and trim(e.nome) &lt;&gt; '-'
            and transportador ='S'
          order by replace(replace(trim(e.nome),'+',''),'&quot;','')">
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