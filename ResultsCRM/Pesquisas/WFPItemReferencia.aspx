<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPItemReferencia.aspx.vb" Inherits="ResultsCRM.WFPItemReferencia" %>

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
                
                
                style="width: 470px; height: 340px; font-size: 7pt; background-color: #FFFFFF;">
                <tr>
                    <td class="TituloConsulta" colspan="5" style="height: 20px">
                        Saldo por Item/Referência</td>
                </tr>
                <tr>
                    <td style="height: 25px; text-align: right;">
                        <asp:Label ID="LblFornecedor" runat="server" 
                            Text="Informe o código ou a descrição do Item:" Width="106px" 
                            style="margin-top: 0px; margin-bottom: 0px"></asp:Label>
                    </td>
                    <td style="text-align: right; height: 25px;">
                        <asp:TextBox ID="TxtNome" runat="server" CssClass="CampoCadastro" Width="125px"></asp:TextBox>
                    </td>
                    <td class="CelulaCampoCadastro" style="text-align: right">
                        OCs e OPs com entrega até:</td>
                    <td class="CelulaCampoCadastro" style="text-align: right">
                        <asp:TextBox ID="TxtPeriodo" runat="server" CssClass="CampoCadastro" 
                            Width="72px"></asp:TextBox>
                        <asp:MaskedEditExtender ID="TxtData_MaskedEditExtender" runat="server" 
                            BehaviorID="TxtPeriodo_MaskedEditExtender" Century="2000" 
                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                            MaskType="Date" TargetControlID="TxtPeriodo" UserDateFormat="DayMonthYear" />
                    </td>
                    <td class="CelulaCampoCadastro" style="text-align: right">
                        <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" Text="Filtrar" 
                            Width="50px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="vertical-align: top">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                            CssClass="CampoCadastro" Width="468px" PageSize="7" Font-Size="7pt">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Item">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BtnSelecionar" runat="server" 
                                            CommandArgument='<%# Eval("chave") %>' CommandName="SELECIONAR" 
                                            ForeColor="Black" Text='<%# Eval("descricao") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
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
                                <asp:BoundField DataField="referencia" HeaderText="Ref." 
                                    SortExpression="referencia">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="saldo_disponivel" DataFormatString="{0:F2}" 
                                    HeaderText="Saldo Físico" SortExpression="saldo_disponivel">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="saldo_programado" DataFormatString="{0:F2}" 
                                    HeaderText="Programado" SortExpression="saldo_programado">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="saldo_previsto" DataFormatString="{0:F2}" 
                                    HeaderText="Saldo Previsto" SortExpression="saldo_previsto">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                </asp:BoundField>
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
                            SelectCommand="call sp_pesquisa_item_referencia(:empresa, :estabelecimento, :item, :periodo, :comercial)">
                            <SelectParameters>
                                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                    Name=":empresa" SessionField="GlEmpresa" />
                                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                    Name=":estabelecimento" SessionField="GlEstabelecimento" />
                                <asp:ControlParameter ControlID="TxtNome" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":item" PropertyName="Text" />
                                <asp:ControlParameter ControlID="TxtPeriodo" ConvertEmptyStringToNull="False" 
                                    Name=":periodo" PropertyName="Text" DbType="String" />
                                <asp:ControlParameter ControlID="ChkComercial" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":comercial" PropertyName="Checked" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                    <tr>
                        <td colspan="4" style="height: 16px; text-align: left;">
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