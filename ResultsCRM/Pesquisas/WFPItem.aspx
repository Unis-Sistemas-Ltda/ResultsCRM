<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPItem.aspx.vb" Inherits="ResultsCRM.WFPItem" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pesquisa de Itens</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "WFPItem.aspx";
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
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:MultiView ID="MultiViewExpanse" runat="server">
        <asp:View ID="ViewInput" runat="server">
            <table class="TextoCadastro" 
                
                style="width: 350px; height: 340px; font-size: 7pt; background-color: #FFFFFF;">
                <tr>
                    <td class="TituloConsulta" colspan="3" style="height: 20px">
                        Pesquisa de Itens</td>
                </tr>
                <tr>
                    <td style="height: 25px">
                        <asp:Label ID="LblFornecedor" runat="server" 
                            Text="Informe o nome ou parte do nome do item:"></asp:Label>
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
                            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                            CssClass="CampoCadastro" Width="350px" PageSize="8" Font-Size="7pt">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BtnSelecionar" runat="server" 
                                            CommandArgument='<%# Eval("cod_item") %>' CommandName="SELECIONAR" 
                                            ForeColor="Black" Text='<%# Eval("descricao") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Código" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="LblCodigo" runat="server" Text='<%# Eval("cod_item") %>'></asp:Label>
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                            SelectCommand=" select i.cod_item, i.descricao || ' (' || cod_item || ')' descricao
       from item i left outer join familia f on i.cod_plano_familia = f.cod_plano_familia and i.cod_familia = f.cod_familia
      where i.descricao like '%' || isnull(:nome,'') || '%'
        and trim(i.descricao) &lt;&gt; ''
        and trim(i.descricao) &lt;&gt; '-'
        and isnull(f.comercial,'N') = if :comercial = 'True' then 'S' else isnull(f.comercial,'N') endif
      order by i.descricao">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtNome" ConvertEmptyStringToNull="False" 
                                    Name=":nome" PropertyName="Text" />
                                <asp:ControlParameter ControlID="ChkComercial" DbType="String" 
                                    Name=":comercial" PropertyName="Checked" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                    <tr>
                        <td colspan="2" style="height: 16px; text-align: left;">
                            <asp:CheckBox ID="ChkComercial" runat="server" Checked="True" 
                                Text="Mostrar somente itens de famílias comerciais" />
                            &nbsp;</td>
                        <td colspan="1" style="height: 16px">
                            <asp:Button ID="btnOkay" runat="server" CssClass="Botao" 
                                OnClick="btnOkay_Click" Text="Done" Visible="False" />
                            <input ID="btnCancel" class="Botao" onclick="cancel();" 
                                style="border-style: none; font-family: verdana; text-decoration: underline; text-align: center;" 
                                type="button" value="Fechar" /></td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>