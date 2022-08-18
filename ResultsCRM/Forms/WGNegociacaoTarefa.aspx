<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGNegociacaoTarefa.aspx.vb" Inherits="ResultsCRM.WGNegociacaoTarefa" %>

<%@ Register src="../UserControls/WUCNegociacaoTotais.ascx" tagname="WUCNegociacaoTotais" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Detalhes da Tarefa</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="SubTituloMovimento">Tarefas</div>
    <div>
         <div class="style1">
             <br />
             <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
            AlternateText="Novo Registro" 
                ImageUrl="~/Imagens/BtnNovoRegistro.png"/>
   
             <br />
         <asp:Label ID="LblErro" runat="server" CssClass="Erro" Font-Bold="False"></asp:Label>
    
             <br />
             <asp:Label ID="Label6" runat="server" CssClass="TextoCadastro_BGBranco" 
                 Height="17px" Text="Status:"></asp:Label>
&nbsp;<asp:DropDownList ID="DdlSituacao" runat="server" CssClass="CampoCadastro" 
                Width="210px" AutoPostBack="True">
                <asp:ListItem Value="1">Aguardando retorno do cliente</asp:ListItem>
                <asp:ListItem Value="2">Aguardar</asp:ListItem>
                <asp:ListItem Value="3">Cancelada</asp:ListItem>
                <asp:ListItem Value="4">Concluída</asp:ListItem>
                <asp:ListItem Value="5">Em Andamento</asp:ListItem>
                <asp:ListItem Value="6">Não Iniciada</asp:ListItem>
                 <asp:ListItem Value="-1">(Todas)</asp:ListItem>
                 <asp:ListItem Selected="True" Value="-2">(Não concluídas)</asp:ListItem>
            </asp:DropDownList>
    
             <br />
    
         </div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Width="100%">
            <PagerSettings FirstPageText="1" LastPageText="Última" Mode="NumericFirstLast" 
                PageButtonCount="8" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" 
                VerticalAlign="Middle" />
            <Columns>
                <asp:BoundField DataField="seq_tarefa" HeaderText="Seq." 
                    SortExpression="seq_tarefa" Visible="False" >
                </asp:BoundField>
                <asp:BoundField DataField="descricao_resumida" HeaderText="Tarefa" 
                    SortExpression="descricao_resumida" Visible="False">
                </asp:BoundField>
                <asp:TemplateField HeaderText="Prioridade" SortExpression="prioridade">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("prioridade") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        Seq:<asp:Label ID="Label1" runat="server" Text='<%# Eval("seq_tarefa") %>'></asp:Label>
                        &nbsp;- Prioridade:<asp:Label ID="LblPrioridade" runat="server" style="font-weight: 700" 
                            Text='<%# Eval("prioridade") %>'></asp:Label>
                        &nbsp;- Situação:<asp:Label ID="LblSituacao" runat="server" 
                            Text='<%# Eval("situacao") %>'></asp:Label>
                        <br />
                        Descrição:
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("descricao_resumida") %>' 
                            style="font-weight: 700"></asp:Label>
                        <br />
                        Responsável:
                        <asp:Label ID="Label2" runat="server" 
                            Text='<%# Eval("nome_usuario") %>'></asp:Label>
                        <br />
                        Previsão:
                        <asp:Label ID="Label3" runat="server" 
                            Text='<%# Eval("previsao_finalizacao", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        &nbsp;- Finalização:&nbsp;<asp:Label ID="Label5" runat="server" 
                            Text='<%# Eval("data_conclusao", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        &nbsp;<br />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="nome_usuario" 
                    HeaderText="Responsável" SortExpression="nome_usuario" Visible="False" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Situação" SortExpression="situacao" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("situacao") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="previsao_finalizacao" 
                    HeaderText="Previsão" SortExpression="previsao_finalizacao" 
                    DataFormatString="{0:dd/MM/yyyy}" Visible="False" >
                </asp:BoundField>
                <asp:BoundField DataField="data_conclusao" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Conclusão" SortExpression="data_conclusao" Visible="False" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("seq_tarefa") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Detalhes do registro" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" VerticalAlign="Bottom" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select seq_tarefa, e.descricao || ' (' || e.cod_etapa || ')' funil, tp.descricao_resumida, case nt.prioridade when 'A' then 'ALTA' when 'B' then 'BAIXA' when 'M' then 'MÉDIA' end prioridade, su.nome_usuario, case nt.situacao when 1 then 'Aguardando retorno do cliente' when 2 then 'Aguardar' when 3 then 'Cancelada' when 4 then 'Concluída' when 5 then 'Em andamento' when 6 then 'Não iniciada' end situacao, nt.previsao_finalizacao, nt.data_conclusao, case nt.prioridade when 'A' then 1 when 'M' then 2 else 3 end nprioridade, :situacao sit
  from negociacao_tarefa nt left outer join etapa_negociacao e on nt.empresa = e.empresa and nt.cod_etapa = e.cod_etapa
                            inner join tarefa_padrao tp on tp.cod_tarefa_padrao = nt.cod_tarefa_padrao
                            inner join sysusuario su on su.cod_usuario = nt.cod_responsavel
 where nt.cod_negociacao_cliente = :codNegociacao
   and nt.empresa = :empresa
   and nt.estabelecimento = :estabelecimento
   and nt.situacao = if sit = '-1' then    nt.situacao else    if sit = '-2' then       if nt.situacao in (1,2,5,6) then          nt.situacao       else          sit       endif   else       sit    endif endif
 order by seq_tarefa">
            <SelectParameters>
                <asp:ControlParameter ControlID="DdlSituacao" Name=":situacao" 
                    PropertyName="SelectedValue" />
                <asp:SessionParameter Name=":codNegociacao" SessionField="SCodNegociacao" />
                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </form>

</body>
</html>
