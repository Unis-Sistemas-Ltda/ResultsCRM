<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPEquipamento2.aspx.vb" Inherits="ResultsCRM.WFPEquipamento2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pesquisa de Itens</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "WFPEquipamento.aspx";
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
                        Pesquisa de
                        <asp:Label ID="LblTituloLbl" runat="server" Text="Equipamentos"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 25px">
                        <asp:Label ID="LblFornecedor" runat="server" 
                            Text="Pesquisar:"></asp:Label>
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
                            CssClass="CampoCadastro" Width="350px" PageSize="7" Font-Size="7pt">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BtnSelecionar" runat="server" 
                                            CommandArgument='<%# Eval("numero_serie") %>' CommandName="SELECIONAR" 
                                            ForeColor="Black" Text='<%# Eval("descricao") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Código" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="LblCodigo" runat="server" Text='<%# Eval("numero_serie") %>'></asp:Label>
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
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select e.numero_serie, e.numero_serie || ' - ' || i.descricao || ' (' || i.cod_item || ') ' || e.referencia descricao
  from equipamento e inner join item i
 where e.empresa     = :empresa
   and e.cod_cliente = :cod_cliente
   and e.numero_ponto_atendimento = :numero_ponto_atendimento
   and descricao like '%' || :nome || '%'">
                            <SelectParameters>
                                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                    Name=":empresa" SessionField="GlEmpresa" />
                                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                    Name=":cod_cliente" SessionField="SCliEquipamento" />
                                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                    Name=":numero_ponto_atendimento" SessionField="SPAEquipamento" />
                                <asp:ControlParameter ControlID="TxtNome" ConvertEmptyStringToNull="False" 
                                    Name=":nome" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                    <tr>
                        <td colspan="2" style="height: 16px; text-align: left;">
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