<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGNegociacaoPipe.aspx.vb" Inherits="ResultsCRM.WGNegociacaoPipe" %>
<%@ Register assembly="WebDataWindow" namespace="Sybase.DataWindow.Web" tagprefix="dw" %>
<%@ Register src="../UserControls/WUCFunilEtapaPainel.ascx" tagname="WUCFunilEtapaPainel" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 100%; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    <div>
    
        <table style="border: thin groove #CCCCCC; width:100%; border-collapse: collapse;" 
            class="TextoCadastro_BGBranco">
            <tr><td></td></tr>
            <tr>
                <td>
                    <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource2"
                        GroupItemCount="7">
                        <AlternatingItemTemplate>
                            <td runat="server" style="" valign="top">
                                <asp:Label ID="LblCodEtapa" runat="server" Text='<%# Eval("cod_etapa") %>' 
                                    Visible="False"></asp:Label>
                                <asp:Label ID="LblNomeEtapa" runat="server" Text='<%# Eval("descricao") %>' 
                                    Visible="False" />
                                <uc1:WUCFunilEtapaPainel ID="WUCFunilEtapaPainel2" runat="server" />
                                <br />
                            </td>
                        </AlternatingItemTemplate>
                        <EditItemTemplate>
                            <td runat="server" style="">
                                cod_etapa:
                                <asp:TextBox ID="cod_etapaTextBox" runat="server" 
                                    Text='<%# Bind("cod_etapa") %>' />
                                <br />descricao:
                                <asp:TextBox ID="descricaoTextBox" runat="server" 
                                    Text='<%# Bind("descricao") %>' />
                                <br />
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                    Text="Update" />
                                <br />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                    Text="Cancel" />
                                <br />
                            </td>
                        </EditItemTemplate>
                        <EmptyDataTemplate>
                            <table runat="server" style="">
                                <tr>
                                    <td>
                                        Nenhuma negociação a exibir.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <EmptyItemTemplate>
<td runat="server" />
                        </EmptyItemTemplate>
                        <GroupTemplate>
                            <tr ID="itemPlaceholderContainer" runat="server">
                                <td ID="itemPlaceholder" runat="server">
                                </td>
                            </tr>
                        </GroupTemplate>
                        <InsertItemTemplate>
                            <td runat="server" style="">
                                cod_etapa:
                                <asp:TextBox ID="cod_etapaTextBox" runat="server" 
                                    Text='<%# Bind("cod_etapa") %>' />
                                <br />descricao:
                                <asp:TextBox ID="descricaoTextBox" runat="server" 
                                    Text='<%# Bind("descricao") %>' />
                                <br />
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                                    Text="Insert" />
                                <br />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                    Text="Clear" />
                                <br />
                            </td>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <td runat="server" style="" valign="top">
                                <asp:Label ID="LblCodEtapa" runat="server" Text='<%# Eval("cod_etapa") %>' 
                                    Visible="False" />
                                <asp:Label ID="LblNomeEtapa" runat="server" Text='<%# Eval("descricao") %>' 
                                    Visible="False" />
                                <uc1:WUCFunilEtapaPainel ID="WUCFunilEtapaPainel1" runat="server" />
                                <br />
                            </td>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table runat="server">
                                <tr runat="server">
                                    <td runat="server">
                                        <table ID="groupPlaceholderContainer" runat="server" border="0" style="">
                                            <tr ID="groupPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server" style="">
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <SelectedItemTemplate>
                            <td runat="server" style="">
                                cod_etapa:
                                <asp:Label ID="cod_etapaLabel" runat="server" Text='<%# Eval("cod_etapa") %>' />
                                <br />descricao:
                                <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' />
                                <br />
                            </td>
                        </SelectedItemTemplate>
                    </asp:ListView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select e.cod_etapa, e.descricao
  from funil_venda_etapa_negociacao f inner join etapa_negociacao e on f.cod_etapa = e.cod_etapa and f.empresa = e.empresa
 where f.empresa   = :empresa
   and f.cod_funil = :cod_funil
  order by f.seq_Pipeline, e.seq_pipeline, e.descricao">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                            <asp:SessionParameter Name=":cod_funil" SessionField="S_PNG_ddlFunil" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
