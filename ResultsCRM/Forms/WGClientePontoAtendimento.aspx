<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGClientePontoAtendimento.aspx.vb" Inherits="ResultsCRM.WGClientePontoAtendimento" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">

.TextoCadastro_BGBranco
{
    font-size: 7pt;
    text-align: left;
    font-family: verdana;
    color: #666666;
    background-color: #FFFFFF;
}
.CampoCadastro
{
    font-size: 7pt;
    height: 18px;
    font-family: verdana;
    color: #666666;
    text-align: left;
}
.Botao
{
    background-position: 100% 100%;
    font-size: 7pt;
    font-weight: bold;
    text-align: center;
    color: #666666;
    font-family: verdana;
    background-color: #CCCCCC;
}
.TextoCadastro
{
    font-size: 7pt;
    text-align: right;
    font-family: verdana;
    color: #666666;
    background-color: #EFEFEF;
}
body
{
    height: 100%
}
    </style>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div style="text-align: right; vertical-align: middle;">
    
            <table class="TextoCadastro_BGBranco" style="width:100%;">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Height="16px" 
                            Text="Tipo:"></asp:Label>
&nbsp;<asp:DropDownList ID="DdlTipoPontoAtendimento" runat="server" 
                CssClass="CampoCadastro" Width="95px">
            </asp:DropDownList>
        &nbsp;<asp:Label ID="Label2" runat="server" Height="16px" 
                            Text="P.A.:"></asp:Label>
                        <asp:TextBox ID="TxtPA" runat="server" CssClass="CampoCadastro"></asp:TextBox>
&nbsp;<asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" Text="Filtrar" />
                    </td>
                    <td style="text-align: right">
    
        <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
            AlternateText="Novo Registro" ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
                    </td>
                </tr>
                <tr>
                    <td class="Erro" colspan="2">
                        <asp:Label ID="LblErro" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
    
    </div>
    <div style="text-align: right">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="CampoCadastro" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Width="100%" 
            AllowSorting="True" 
            
            EmptyDataText="Nenhum ponto de atendimento a exibir.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="tipo_ponto_atendimento" HeaderText="Tipo" 
                    SortExpression="tipo_ponto_atendimento">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="numero_ponto_atendimento" HeaderText="Nº Ponto" 
                    SortExpression="numero_ponto_atendimento">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao" HeaderText="Descrição" 
                    SortExpression="descricao" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_cidade" HeaderText="Cidade" 
                    SortExpression="nome_cidade" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="sigla" HeaderText="UF" 
                    SortExpression="sigla" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("numero_ponto_atendimento") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Detalhes do Registro" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                            CommandArgument='<%# Eval("numero_ponto_atendimento") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" ToolTip="Excluir" 
                            
                            onclientclick="return confirm('Deseja realmente excluir o registro selecionado?');" 
                            Visible='<%# Iif( Session("GlBloquearCadastroEmitenteRepresentante") = "S", "False", "True" ) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select e.cod_emitente, pa.numero_ponto_atendimento, pa.descricao, ci.nome_cidade, uf.sigla, pa.numero_ponto_atendimento || ';' || pa.descricao chave, tpa.descricao tipo_ponto_atendimento
  from emitente e inner join ponto_atendimento pa on e.cod_emitente = pa.cod_emitente
                  left outer join cidade ci on ci.cod_pais   = pa.cod_pais
                                           and ci.cod_estado = pa.cod_estado
                                           and ci.cod_cidade = pa.cod_cidade
                  left outer join estado uf on uf.cod_pais   = pa.cod_pais
                                           and uf.cod_estado = pa.cod_estado
                  left outer join tipo_ponto_atendimento tpa on tpa.cod_tipo_ponto_atendimento = pa.cod_tipo_ponto_atendimento
 where e.cod_emitente = :codigo
    and chave like if trim(isnull(:pa1,'')) = '' then chave else '%' || trim(isnull(:pa2,'')) || '%' endif
    and isnull(tpa.cod_tipo_ponto_atendimento,-1) = if :tpPa = 0 then isnull(tpa.cod_tipo_ponto_atendimento,-1) else :tpPA2 endif
 order by pa.numero_ponto_atendimento">
            <SelectParameters>
                <asp:SessionParameter Name=":codigo" SessionField="SCodEmitente" />
                <asp:ControlParameter ControlID="TxtPA" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":pa1" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtPA" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":pa2" PropertyName="Text" />
                <asp:ControlParameter ControlID="DdlTipoPontoAtendimento" Name=":tpPa" 
                    PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlTipoPontoAtendimento" Name=":tpPa2" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    
    </div>
    </form>
</body>
</html>
