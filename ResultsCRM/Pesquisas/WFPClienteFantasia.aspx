<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPClienteFantasia.aspx.vb" Inherits="ResultsCRM.WFPClienteFantasia" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:MultiView ID="MultiViewExpanse" runat="server">
        <asp:View ID="ViewInput" runat="server">
            <table class="TextoCadastro" 
                
                style="width: 350px; height: 390px; font-size: 7pt; background-color: #FFFFFF;">
                    <tr>
                        <td class="TituloConsulta" colspan="3" style="height: 20px">
                            Pesquisa de Pontos de Atendimento</td>
                    </tr>
                    <tr>
                        <td style="height: 15px; text-align: left;" colspan="3">
                            Cliente:
                            <asp:Label ID="LblCliente" runat="server" Font-Bold="True"></asp:Label>
                            (<asp:Label ID="LblClienteCod" runat="server" Font-Bold="True"></asp:Label>
                            )</td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label5" runat="server" Height="16px" Text="Tipo:"></asp:Label>
                            &nbsp;</td>
                        <td style="height: 18px; text-align: left;">
                            <asp:DropDownList ID="DdlTipoPontoAtendimento" runat="server" 
                                CssClass="CampoCadastro" Width="115px">
                            </asp:DropDownList>
                        </td>
                        <td class="CelulaCampoCadastro" rowspan="2">
                            <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="LblFornecedor" runat="server" Height="16px" Text="Buscar:"></asp:Label>
                        </td>
                        <td style="height: 18px; text-align: left;">
                            <asp:TextBox ID="TxtNome" runat="server" Font-Size="7pt" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="vertical-align: top">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="2" 
                                CssClass="CampoCadastro" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                                GridLines="None" Width="345px" PageSize="6" Font-Size="7pt">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="numero_ponto_atendimento" HeaderText="Nº" 
                                        SortExpression="numero_ponto_atendimento">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Ponto Atendimento">
                                        <ItemTemplate>
                                            &nbsp;<asp:Label ID="Label4" runat="server" Text='<%# Eval("descricao") %>'></asp:Label>
                                            &nbsp;&nbsp;
                                            <asp:LinkButton ID="BtnSelecionar" runat="server" 
                                                CommandArgument='<%# Eval("numero_ponto_atendimento") %>' 
                                                CommandName="SELECIONAR" ForeColor="Black" Text='<%# Eval("nome") %>'></asp:LinkButton>
                                            <br />
                                            CNPJ:
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("cnpj") %>'></asp:Label>
                                            <br />
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("endereco") %>'></asp:Label>
                                            &nbsp;-
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("nome_cidade") %>'></asp:Label>
                                            &nbsp;-
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("sigla") %>'></asp:Label>
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
                                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                                
                                
                                SelectCommand="select ee.numero_ponto_atendimento, ee.descricao nome, ee.cod_emitente, if length(trim(cnpj)) &gt; 3 then substr(ee.cnpj,1,2) || '.' || substr(ee.cnpj,3,3) || '.' || substr(ee.cnpj,6,3) || '/' || substr(ee.cnpj,9,4) || '-' || substr(ee.cnpj,13,2) else '' endif cnpj,
       ee.cnpj || '§' || ee.descricao || '§' || ee.numero_ponto_atendimento || '§' || ee.endereco || '§' || ci.nome_cidade || '§' || uf.sigla  busca,
       ee.endereco, ci.nome_cidade, uf.sigla, tpa.descricao
  from ponto_atendimento ee left outer join estado uf on uf.cod_pais = ee.cod_pais and uf.cod_estado = ee.cod_estado
                            left outer join cidade ci on ci.cod_pais = ee.cod_pais and ci.cod_estado = ee.cod_estado and ci.cod_cidade = ee.cod_cidade
                            left outer join tipo_ponto_atendimento tpa on tpa.cod_tipo_ponto_atendimento = ee.cod_tipo_ponto_atendimento
 where ee.cod_emitente = :cod_emitente
    and busca like '%' || replace(replace(replace(replace(trim(replace(isnull(:nome,''),'','%')),'.',''),'/',''),'-',''),'\','') || '%' 
    and isnull(tpa.cod_tipo_ponto_atendimento,-1) = if :tpPa = 0 then isnull(tpa.cod_tipo_ponto_atendimento,-1) else :tpPA2 endif
 order by nome">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="LblClienteCod" DefaultValue="" 
                                        Name=":cod_emitente" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="TxtNome" ConvertEmptyStringToNull="False" 
                                        Name=":nome" PropertyName="Text" DbType="String" />
                                    <asp:ControlParameter ControlID="DdlTipoPontoAtendimento" Name=":tpa1" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="DdlTipoPontoAtendimento" Name=":tpa2" 
                                        PropertyName="SelectedValue" />
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