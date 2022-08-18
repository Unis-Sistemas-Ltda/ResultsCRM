<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGGrupoTEF.aspx.vb" Inherits="ResultsCRM.WGGrupoTEF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloCadastro">Grupos TEF</div>
    <div class="Erro"><asp:Label ID="LblErro" runat="server"></asp:Label></div>
    <div style="text-align: right">&nbsp;<asp:Label ID="Label2" runat="server" CssClass="TextoCadastro_BGBranco" Height="16px" 
                Text="Código:"></asp:Label>
            <asp:TextBox ID="TxtCodigo" runat="server" CssClass="CampoCadastro"></asp:TextBox>
&nbsp;
            <asp:Label ID="Label1" runat="server" CssClass="TextoCadastro_BGBranco" 
                Height="16px" Text="Nome:"></asp:Label>
            <asp:TextBox ID="TxtNome" runat="server" CssClass="CampoCadastro" Width="350px"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" Text="Filtrar" />
            <br />
    
        <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
            AlternateText="Novo Registro" ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" 
            AllowSorting="True">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="cod_adesao" HeaderText="Código" ReadOnly="True" 
                    SortExpression="cod_adesao">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_rede" HeaderText="Nome do Grupo" 
                    SortExpression="nome_rede" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("cod_adesao") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Detalhes do Registro" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnExcluir" runat="server" 
                            CommandArgument='<%# Eval("cod_adesao") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja realmente excluir este cliente?');" 
                            ToolTip="Excluir" 
                            
                            Visible='<%# iif( session("GlBloquearCadastroEmitenteRepresentante") = "S", "False", "True") %>' />
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
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select cod_adesao, nome_rede, :empresa emp, :codigo cod
from adesao_tef
where empresa = emp
and (trim(cod) = '' or (isnumeric(cod) = 1 and cod_adesao = cod))
and nome_rede like '%' || :nome || '%'
order by nome_rede">
            <SelectParameters>
                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                <asp:ControlParameter ControlID="TxtCodigo" ConvertEmptyStringToNull="False" 
                    Name=":codigo" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtNome" ConvertEmptyStringToNull="False" 
                    Name=":nome" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
