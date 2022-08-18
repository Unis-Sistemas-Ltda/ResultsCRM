<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelAcoesColaborador.aspx.vb" Inherits="ResultsCRM.WFRelAcoesColaborador" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<%@ Register assembly="WebDataWindow" namespace="Sybase.DataWindow.Web" tagprefix="dw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
    </head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
    <div class="TituloRelatorio">Relatório Ações por Colaborador</div>
    <table style="width:100%;" class="TextoCadastro">
        <tr>
            <td colspan="2" style="text-align: left">
                <asp:Label ID="lblErro" runat="server" CssClass="Erro"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Período:"></asp:Label>
            </td>
            <td class="CelulaCampoCadastro">
                <uc1:TextBoxData ID="TxtData1" runat="server" />
            &nbsp;<uc1:TextBoxData ID="TxtData2" runat="server" />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Emitente:"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="TxtEmitente" runat="server" Width="192px" CssClass="CampoCadastro" ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Etapa:"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlEtapa" runat="server" CssClass="CampoCadastro" Width="200px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Funil:"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlFunil" runat="server" CssClass="CampoCadastro" Width="200px"></asp:DropDownList>
            </td>
        </tr>        
        <tr>
            <td style="vertical-align: top; text-align: left">Usuário:</td>
            <td style="text-align: left">
                <asp:ListBox ID="LbxUsuario" runat="server" CssClass="CampoCadastro" Rows="6" SelectionMode="Multiple" Width="200px"></asp:ListBox>
            </td>
            <td style="vertical-align: top; text-align: left">Canal de Vendas:</td>
            <td style="text-align: left">
                <asp:ListBox ID="LbxCanalVenda" runat="server" CssClass="CampoCadastro" Rows="6" SelectionMode="Multiple" Width="200px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="4">
                <asp:Button ID="BtnOk" runat="server" CssClass="Botao" Text="Aplicar Filtro" TabIndex="1" />
            </td>
        </tr>
        <tr>
            <td colspan="4"> &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="vertical-align: bottom">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" Width="100%" AllowSorting="True" AutoGenerateColumns="False" 
                    EmptyDataText="Não há dados a exibir.">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="usuario" HeaderText="Usuário">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="descricao" HeaderText="Ação">
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="qtd_acao" HeaderText="Qtd Ação">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="qtd_empresa" HeaderText="Qtd Empresa">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
