<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGTefGrupo.aspx.vb" Inherits="ResultsCRM.WGTefGrupo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../ResultsCRM.js" type="text/javascript"> </script>
    <style type="text/css"> .style1
        {
            height: 21px;
        }
    </style>
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 100%; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div style="text-align:center; position: fixed; top: 10%; right: 46%; z-index: 10;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/carregando.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
        <div class="TituloMovimento">Painel de Campanhas TEF</div>
        <div>
    
            <table style="border: thin groove #CCCCCC; width:100%; font-family: verdana; font-size: 7pt; border-collapse: collapse;" 
                class="TextoCadastro_BGBranco">
                <tr>
                    <td style="text-align: right; ">
                        Cód. Campanha:</td>
                    <td style="text-align: left; ">
                        <asp:TextBox ID="TxtCodCampanha" runat="server" 
                            CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                            Width="70px" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td style="text-align: right; ">
                        Adquirente:</td>
                    <td style="vertical-align: top; ">
                        <asp:DropDownList ID="DdlAdquirente" runat="server" AutoPostBack="True" 
                            CssClass="CampoCadastro" Width="300px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: right; " class="style1">
                        Nome Campanha:</td>
                    <td style="text-align: left; " class="style1">
                        <asp:TextBox ID="TxtNomeCampanha" runat="server" AutoPostBack="True" 
                            CssClass="CampoCadastro" ToolTip="Informe o nome ou parte do nome da campanha." 
                            Width="200px"></asp:TextBox>
                    </td>
                    <td style="text-align: right;" class="style1">
                        Operadora:</td>
                    <td style="vertical-align: top" class="style1">
                        <asp:DropDownList ID="DdlOperadora" runat="server" AutoPostBack="True" 
                            CssClass="CampoCadastro" Width="300px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right;">
                        </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        &nbsp;</td>
                    <td style="text-align: left; width: 180px;">
                        &nbsp;</td>
                    <td style="text-align: right;">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td style="text-align: right;">
                        <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
                            AlternateText="Novo Registro" BorderColor="#000099" BorderStyle="Outset" 
                            Height="18px" ImageAlign="Bottom" ImageUrl="~/Imagens/BtnNovoRegistro.png" />
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFFFE6;" class="Erro" colspan="5">
                        <asp:Label ID="LblErro" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                            GridLines="None" Width="100%" AllowSorting="True" PageSize="14">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                                VerticalAlign="Top" />
                            <Columns>
                                <asp:BoundField DataField="cod_grupo" HeaderText="Código" 
                                    SortExpression="cod_grupo">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nome_rede" HeaderText="Nome Campanha" 
                                    SortExpression="nome_rede" >
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nome_autorizadora" HeaderText="Autorizadora" 
                                    SortExpression="nome_autorizadora" >
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nome_operadora" HeaderText="Operadora" 
                                    SortExpression="nome_operadora">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" 
                                            CommandArgument='<%# Eval("cod_grupo") %>' CommandName="ALTERAR" 
                                            ImageUrl="~/Imagens/BtnEditar.png" 
                                            ToolTip="Clique para alterar ou consultar o registro" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Excluir">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton3" runat="server" 
                                            CommandArgument='<%# Eval("cod_grupo") %>' CommandName="EXCLUIR" 
                                            ImageUrl="~/Imagens/BtnExcluir.png" 
                                            onclientclick="return confirm('Deseja realmente excluir o registro selecionado?')" 
                                            ToolTip="Clique para excluir o registro" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerSettings FirstPageText="1&nbsp;&nbsp;" LastPageText="Últ." 
                                Mode="NumericFirstLast" PageButtonCount="15" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                            
                            SelectCommand="select tg.cod_grupo, tg.nome_rede, ta.cod_adquirente, ta.nome_autorizadora, op.cod_operadora, op.nome_operadora
  from tef_grupo tg inner join tef_adquirente ta on ta.cod_adquirente = tg.cod_adquirente_padrao
                    inner join tef_operadora op on op.cod_operadora = tg.cod_operadora
 where tg.empresa = :empresa
   and ( trim(isnull(:nome_rede1,'')) &lt;&gt; '' or tg.nome_rede like '%' || replace(replace(:nome_rede2,' ','%'),'+','%') || '%' )
   and ( trim(isnull(:cod_adquirente1,'0')) = '0' or ta.cod_adquirente = :cod_adquirente2 )
   and ( trim(isnull(:cod_operadora1,'0'))  = '0' or op.cod_operadora  = :cod_operadora2 )">
                            <SelectParameters>
                                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                                <asp:ControlParameter ControlID="TxtNomeCampanha" Name=":nome_rede1" 
                                    PropertyName="Text" ConvertEmptyStringToNull="False" DbType="String" />
                                <asp:ControlParameter ControlID="TxtNomeCampanha" Name=":nome_rede2" 
                                    PropertyName="Text" ConvertEmptyStringToNull="False" DbType="String" />
                                <asp:ControlParameter ControlID="DdlAdquirente" 
                                    ConvertEmptyStringToNull="False" DbType="String" Name=":cod_adquirente1" 
                                    PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="DdlAdquirente" 
                                    ConvertEmptyStringToNull="False" DbType="String" Name=":cod_adquirente2" 
                                    PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="DdlOperadora" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":cod_operadora1" PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="DdlOperadora" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":cod_operadora2" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="color: #000000">
                        &nbsp;</td>
                </tr>
            </table>
    
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
