<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFGestorContaRepresentante.aspx.vb" Inherits="ResultsCRM.WFGestorContaRepresentante" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloCadastro">Vendedores/Representantes do Gestor
        <asp:Label ID="LblNomeGestor" runat="server"></asp:Label>
    </div>
    <div><asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
            GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Seleção" SortExpression="marcado">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("marcado") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CbxMarcado" runat="server" 
                            Checked='<%# Bind("selecionado") %>' />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Vendedor/Representante" 
                    SortExpression="nome_representante">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblNomeRepresentante" runat="server" 
                            Text='<%# Eval("nome_representante") %>'></asp:Label>
                        (<asp:Label ID="LblCodRepresentante" runat="server" 
                            Text='<%# Eval("cod_representante") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select e.cod_emitente cod_representante,
       e.nome nome_representante,
       isnull((select 'True' from gestor_conta_representante gr where gr.cod_gestor = g.cod_gestor and gr.cod_representante = e.cod_emitente),'False') selecionado
  from emitente e,
       gestor_conta g
 where e.representante = 'S'
   and g.cod_gestor = :cod_gestor
   and (selecionado = 'True' or e.situacao in (2,5))
 order by e.nome">
            <SelectParameters>
                <asp:SessionParameter Name=":cod_gestor" SessionField="SCodGestorConta" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <div style="text-align:center">
        <asp:Button ID="BtnVoltar" runat="server" Text="Voltar" />
&nbsp;
        <asp:Button ID="BtnGravar" runat="server" Text="Gravar" />
    </div>
    </form>
</body>
</html>
