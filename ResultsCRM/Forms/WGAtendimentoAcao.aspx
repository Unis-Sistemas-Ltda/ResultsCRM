<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAtendimentoAcao.aspx.vb" Inherits="ResultsCRM.WGAtendimentoAcao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
        <asp:Button ID="BtnIncluir" runat="server" Text="Incluir" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource1" 
            EmptyDataText="&lt;br&gt;Nenhuma ação foi incluída até o momento." 
            ForeColor="#333333" GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Problema" SortExpression="assunto">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("assunto") %>'></asp:Label>
                        (<asp:Label ID="Label3" runat="server" Text='<%# Eval("cod_problema") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("assunto") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Causa" SortExpression="descricao_causa">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("descricao_causa") %>'></asp:Label>
                        (<asp:Label ID="Label4" runat="server" Text='<%# Eval("cod_causa") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Efeito" SortExpression="descricao_efeito">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("descricao_efeito") %>'></asp:Label>
                        (<asp:Label ID="Label6" runat="server" Text='<%# Eval("cod_efeito") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("descricao1") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ação" SortExpression="descricao_acao">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("descricao_acao") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("descricao_acao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:BoundField DataField="descricao_situacao" HeaderText="Situação" 
                    SortExpression="descricao_situacao">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="responsavel" HeaderText="Responsável" 
                    SortExpression="responsavel">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_prevista" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Previsão" SortExpression="data_prevista">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_execucao" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Execução" SortExpression="data_execucao">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="ALTERAR"
                            CommandArgument='<%# Eval("seq_acao") %>' ImageUrl="~/Imagens/BtnEditar.png" 
                            style="margin-top: 0px" ToolTip="Editar dados do registro" />
                        &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("seq_acao") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja excluir o registro?')" 
                            ToolTip="Excluir o registro" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" Width="45px" />
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
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            
            
            SelectCommand="select cc.seq_acao, cp.seq_problema, e.cod_problema, e.assunto, ca.cod_causa, ca.descricao descricao_causa, ce.cod_efeito, ce.descricao descricao_efeito, a.cod_acao, a.descricao descricao_acao,
       (case cc.situacao when 1 then 'Não iniciada' when 2 then 'Iniciada' when 3 then 'Concluída' when 4 then 'Pausada' when 5 then 'Cancelada' end) descricao_situacao,
       cc.responsavel,
       cc.data_prevista,
       cc.data_execucao
  from chamado_acao cc inner join causa ca on ca.empresa = cc.empresa and ca.cod_causa = cc.cod_causa
                       inner join chamado_problema cp on cc.empresa = cp.empresa and cc.cod_chamado = cp.cod_chamado and cc.seq_problema = cp.seq_problema
                       inner join problema_padrao e on e.empresa = cp.empresa and e.cod_problema = cp.cod_problema
                       inner join efeito ce on ce.empresa = cc.empresa and ce.cod_efeito = cc.cod_efeito
                       inner join acao a on a.empresa = cc.empresa and a.cod_acao = cc.cod_acao
 where cc.empresa     = :empresa
   and cc.cod_chamado = :cod_chamado
 order by e.assunto, e.cod_problema, ca.descricao, ca.cod_causa, ce.cod_efeito, ce.descricao, a.descricao, a.cod_acao">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":cod_chamado" SessionField="SCodAtendimento" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>