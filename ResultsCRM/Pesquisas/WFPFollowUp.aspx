<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPFollowUp.aspx.vb" Inherits="ResultsCRM.WFPFollowUp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pesquisa de Itens</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "WFPFollowUp.aspx";
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
<body class="TextoCadastro" style="padding: 0px; margin: 0px">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <table class="TextoCadastro" 
         style="font-size: 7pt; background-color: #FFFFFF;">
                <tr>
                    <td colspan="3">
                            <asp:Button ID="btnOkay" runat="server" CssClass="Botao" 
                                OnClick="btnOkay_Click" Text="Done" Visible="False" />
                            <input ID="btnCancel" class="Botao" onclick="cancel();" 
                                style="border-style: none; font-family: verdana; text-decoration: underline; text-align: center;" 
                                type="button" value="Fechar" /></td>
                </tr>
                <tr>
                    <td class="TituloConsulta" colspan="3">
                        Pesquisa de Follow-ups</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblFornecedor" runat="server" 
                            Text="Informe o texto que deseja pesquisar:"></asp:Label>
                    </td>
                    <td class="CelulaCampoCadastro">
                        <asp:TextBox ID="TxtPesquisa" runat="server" Width="150px"></asp:TextBox>
                    </td>
                    <td class="CelulaCampoCadastro">
                        <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" Text="Pesquisar" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="vertical-align: top; height: 100%;">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                            CssClass="CampoCadastro" Width="100%" PageSize="1" 
                            EnableModelValidation="True" ShowHeader="False" Font-Size="7pt">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Descrição" SortExpression="chave">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BtnSelecionar" runat="server" 
                                            CommandArgument='<%# Eval("descricao") %>' CommandName="SELECIONAR" 
                                            ForeColor="Black" Text='<%# Eval("assunto") %>' Font-Bold="True" 
                                            ToolTip="Selecionar a resposta abaixo."></asp:LinkButton>
                                        <br />
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("descricao") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings FirstPageText="1&nbsp;" LastPageText="Última" 
                                Mode="NumericFirstLast" Position="Top" PageButtonCount="16" />
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
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select c.assunto, fc.descricao
              from follow_up_chamado fc inner join chamado c on fc.empresa = c.empresa and fc.cod_chamado = c.cod_chamado
             where tipo = 3
               and trim(:nome1) &lt;&gt; '' and ( fc.descricao like '%' || replace(:nome2,' ','%') || '%' or c.assunto like '%' || replace(:nome3,' ','%') )
             order by fc.data_follow_up desc">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtPesquisa" ConvertEmptyStringToNull="False" 
                                    Name=":nome1" PropertyName="Text" DbType="String" />
                                <asp:ControlParameter ControlID="TxtPesquisa" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":nome2" PropertyName="Text" />
                                <asp:ControlParameter ControlID="TxtPesquisa" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":nome3" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                    </table>
                    </form>
</body>
</html>