<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAssessoriaPainel.aspx.vb"
    Inherits="ResultsCRM.WGAssessoriaPainel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../ResultsCRM.js" type="text/javascript"> </script>
    <style type="text/css">
        .style1
        {
            font-size: 8pt;
            text-align: left;
            color: #CC0000;
            font-family: verdana;
            height: 15px;
        }
    </style>
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 100%;
    min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div style="text-align: center; position: fixed; top: 10%; right: 46%; z-index: 10;">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/carregando.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div class="TituloMovimento">
                    Painel de Assessoria</div>
                <div>
                    <table style="border: thin groove #CCCCCC; width: 100%; font-family: verdana; font-size: 7pt;
                        border-collapse: collapse;" class="TextoCadastro_BGBranco">
                        <tr>
                            <td class="style1" colspan="5">
                                <asp:Label ID="LblErro" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                Tipo Assessoria:
                            </td>
                            <td>
                                <asp:DropDownList ID="DdlTipoAssessoria" runat="server" CssClass="CampoCadastro" Width="300px"></asp:DropDownList>
                            </td>
                            <td style="text-align: right">
                                Etapa Assesoria:
                            </td>
                            <td>
                                <asp:DropDownList ID="DdlEtapaAssessoria" runat="server" CssClass="CampoCadastro" Width="300px"></asp:DropDownList>
                            </td>
                            <td style="text-align: right">Status:</td>
                            <td>
                                <asp:DropDownList ID="DdlStatus" runat="server" CssClass="CampoCadastro" Width="200px">
                                    <asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
                                    <asp:ListItem Value="1">Ativa</asp:ListItem>
                                    <asp:ListItem Value="3">Inativa</asp:ListItem>
                                    <asp:ListItem Value="2">Em credenciamento</asp:ListItem>
                                    <asp:ListItem Value="4">Não credenciado</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                Assessoria:
                            </td>
                            <td>
                                <asp:DropDownList ID="DdlAssessoria" runat="server" CssClass="CampoCadastro" 
                                    Width="300px" AutoPostBack="True"></asp:DropDownList>
                            </td>
                            <td style="text-align: right">
                                Cliente:
                            </td>
                            <td>
                                <asp:TextBox ID="TxtCliente" runat="server" CssClass="TextoCadastro" Width="290px"></asp:TextBox>
                            </td>
                            <td></td>
                            <td></td>
                            <td style="text-align: right">
                                <asp:Button ID="BtnAplicarFiltro" runat="server" Text="Pesquisar" />
                                &nbsp;
                                </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7">
                                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
                                    PageSize="14" Width="100%">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                    <Columns>
                                        <asp:BoundField DataField="emitente_nome" HeaderText="Emitente" ReadOnly="True"
                                            SortExpression="emitente_nome">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="tipo_assessoria" HeaderText="Tipo" 
                                            SortExpression="tipo_assessoria" />
                                        <asp:BoundField DataField="assessoria" HeaderText="Assessoria" 
                                            SortExpression="assessoria" />
                                        <asp:BoundField DataField="etapa" HeaderText="Etapa" SortExpression="etapa">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Status" SortExpression="status_credenciamento">
                                            <ItemTemplate>
                                                <asp:Label ID="LblColorida" runat="server" Text="__"></asp:Label>
                                                <asp:Label ID="LblFunil" runat="server" Text='<%# Eval("status_credenciamento") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerSettings FirstPageText="1&nbsp;&nbsp;" LastPageText="Últ." Mode="NumericFirstLast" PageButtonCount="15" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                                    
                                    SelectCommand="call sp_assessoria(1,:emitente,:tipoAssessoria,:assessoria,:etapaAssessoria,:status,'','','','','','')
">
                                    <SelectParameters>
                                        <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                            Name=":emitente" SessionField="emitente" />
                                        <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                            DefaultValue="" Name=":tipoAssessoria" SessionField="tipoAssessoria" />
                                        <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                            Name=":assessoria" SessionField="assessoria" />
                                        <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                            Name=":etapaAssessoria" SessionField="etapa" />
                                        <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                            Name=":status" SessionField="status" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
