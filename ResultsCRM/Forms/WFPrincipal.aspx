<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPrincipal.aspx.vb" Inherits="ResultsCRM.WFPrincipal" %>

<%@ Register Src="../UserControls/WUCFrame.ascx" TagName="WUCFrame" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Results CRM</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .adjustedZIndex
        {
            z-index: 1;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function resizeIframe() {
            i = parent.document.getElementById('FrameConteudo');
            j = parent.document.getElementById('tdframe');
            iHeight = window.innerHeight;
            iWidth = window.innerWidth;

            if (i != null) {
                i.style.height = (iHeight - 80) + "px";
                i.style.width = (iWidth - 20) + "px"
            }

            if (j != null) {
                j.style.height = (iHeight - 77) + "px";
                j.style.width = (iWidth - 17) + "px"
            }
        }
          
    </script>
</head>
<body id="body1" runat="server" style="padding: 0px; width: 100%; text-align: left;
    top: 0px; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server" style="width: 100%;">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width: 100%; height: 100%; font-family: verdana; font-size: 7pt; border-collapse: collapse;">
        <tr>
            <td>
                <table style="width: 100%; border-collapse: collapse;">
                    <tr>
                        <td rowspan="2" style="width: 100px">
                            <img alt="" src="../Imagens/logo_cliente.jpg" style="height: 60px" />
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="LblRazaoSocial" runat="server" CssClass="CampoCadastro"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:ImageButton ID="BtnTarefas" runat="server" AlternateText="Tarefas" ImageUrl="~/Imagens/QMnTarefas.png"
                                ToolTip="PAINEL DE TAREFAS" Visible="False" />
                        </td>
                        <td style="text-align: center">
                            <asp:ImageButton ID="BtnNegociacao" runat="server" ImageUrl="~/Imagens/QMnNegociação.png"
                                AlternateText="Negociações" ToolTip="PAINEL DE NEGOCIAÇÕES" Visible="False" />
                        </td>
                        <td style="text-align: center">
                            <asp:ImageButton ID="BtnCliente" runat="server" Height="30px" ImageUrl="~/Imagens/ImgClientes.png"
                                ToolTip="Clientes" Visible="False" />
                        </td>
                        <td style="text-align: center">
                            <asp:ImageButton ID="BtnAtendimentos" runat="server" ImageUrl="~/Imagens/painel_atendimento.png"
                                ToolTip="ATENDIMENTOS" Height="30px" Visible="False" />
                        </td>
                        <td style="text-align: right; vertical-align: bottom; padding-top: 2px; padding-right: 1px;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Timer ID="Timer1" runat="server" Interval="20000">
                                    </asp:Timer>
                                    <asp:Label ID="LblRelogio" runat="server" CssClass="CampoCadastro" ForeColor="Gray"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="LblNomeUsuario" runat="server" CssClass="CampoCadastro"></asp:Label>
                                    <br />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td style="text-align: left; vertical-align: bottom; padding-top: 2px; padding-left: 6px;">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WFDesconectar.aspx">Sair</asp:HyperLink>
                        </td>
                        <td style="text-align: right; vertical-align: top;">
                            Release: 1.182</td>
                        <td rowspan="2" style="text-align: right; width: 100px;">
                            <img alt="Unis Sistemas" src="../Imagens/unis.jpg" style="width: 60px; height: 57px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; vertical-align: top;" class="CampoCadastro" colspan="8">
                            <asp:Menu ID="MnuPrincipal" runat="server" Orientation="Horizontal" Font-Names="Verdana"
                                Font-Size="9pt" ForeColor="#999999" CssClass="adjustedZIndex" RenderingMode="List">
                                <StaticMenuStyle CssClass="ajustedZIndex" />
                                <DynamicMenuStyle CssClass="adjustedZIndex" BorderColor="#F7F6F3" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <StaticMenuItemStyle Font-Names="Verdana" Font-Size="10pt" ForeColor="#333333" VerticalPadding="1px"
                                    HorizontalPadding="4px" />
                                <DynamicHoverStyle BackColor="#E1E1E1" />
                                <DynamicSelectedStyle ForeColor="#333333" />
                                <DynamicMenuItemStyle ForeColor="#333333" VerticalPadding="8px" BackColor="White"
                                    HorizontalPadding="11px" />
                                <StaticHoverStyle ForeColor="#333333" BackColor="#EFEFEF" />
                                <Items>
                                    <asp:MenuItem Text=" " Value="Cadastros" ImageUrl="~/Imagens/MnCadastros.png" Selectable="False">
                                        <asp:MenuItem Text="Globais" Value="Globais" Selectable="False">
                                            <asp:MenuItem Text="Cliente" Value="WGPosVenda.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Tipo de Assessoria" Value="WGTipoAssessoria.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Assessoria" Value="WGAssessoria.aspx"></asp:MenuItem>
                                        </asp:MenuItem>
                                        <asp:MenuItem Selectable="False" Text="Vendas" Value="Vendas">
                                            <asp:MenuItem Text="Carteira" Value="WGCarteira.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Agente de Vendas" Value="WGAgenteVenda.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Gestor Conta" Value="WGGestorConta.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Funil de Vendas" Value="WGFunilVenda.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Etapa da Negociação" Value="WGEtapaNegociacao.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Status da Negociação" Value="WGStatusNegociacao.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Origem da Negociação" Value="WGOrigemNegociacao.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Motivo de Fechamento" Value="WGMotivoFechamento.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Ação" Value="WGAcaoFollowUp.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Modelo de Proposta" Value="WGModelo.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Tarefa Padrão" Value="WGTarefaPadrao.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Grupo de Cliente/Mercado" Value="WGMercado.aspx"></asp:MenuItem>
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="Atendimento" Value="Atendimento" Selectable="False">
                                            <asp:MenuItem Text="Agente Técnico" Value="WGAgenteTecnico.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Tipo de Ponto de Atendimento" Value="WGTipoPontoAtendimento.aspx">
                                            </asp:MenuItem>
                                            <asp:MenuItem Text="SLA" Value="WGSLA.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Rotina" Value="WGRotina.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Manual" Value="WGManual.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="FAQ" Value="WGFAQ.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Tipo de Serviço" Value="WGTipoServicoAtendimento.aspx"></asp:MenuItem>
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="FMEA" Value="FMEA">
                                            <asp:MenuItem Text="Grupo de Problema / Categoria de Modo de Falha" Value="WGGrupoProblema.aspx">
                                            </asp:MenuItem>
                                            <asp:MenuItem Text="Problema / Modo de Falha" Value="WGProblema.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Causa" Value="WGCausa.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Efeito" Value="WGEfeito.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Ação / Barreira Implementada" Value="WGAcao.aspx"></asp:MenuItem>
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="Finanças" Value="Finanças" Selectable="False">
                                            <asp:MenuItem Text="Forma de Pagamento" Value="WGFormasPagamento.aspx"></asp:MenuItem>
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="Desenvolvimento" Value="Desenvolvimento">
                                            <asp:MenuItem Text="Banco de Dados" Value="WGBancoDados.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Versão de Banco de Dados" Value="WGVersaoBancoDados.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Sistema" Value="WGSistema.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Release de Sistema" Value="WGSistemaRelease.aspx"></asp:MenuItem>
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="TEF" Value="TEF">
                                            <asp:MenuItem Text="Grupo" Value="WGGrupoTEF.aspx"></asp:MenuItem>
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="Emails" Value="Emails">
                                            <asp:MenuItem Text="Marcadores" Value="WGMarcador.aspx"></asp:MenuItem>
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="Avaliação" Value="Avaliação">
                                            <asp:MenuItem Text="Tipo" Value="WGTipoAvaliacao.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Grupo de Item Avaliado" Value="WGGrupoItemAvaliado.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Resultado" Value="WGGrupoResultado.aspx"></asp:MenuItem>
                                        </asp:MenuItem>
                                    </asp:MenuItem>
                                    <asp:MenuItem Text=" " Value="Movimentos" ImageUrl="~/Imagens/MnMovimentos.png" Selectable="False">
                                        <asp:MenuItem Text="Painel de Clientes" Value="WGPosVenda.aspx"></asp:MenuItem>
                                        <asp:MenuItem Text="Painel de Negociações" Value="WFNegociacaoFiltro.aspx"></asp:MenuItem>
                                        <asp:MenuItem Text="Painel de Atendimentos" Value="WGAtendimento.aspx"></asp:MenuItem>
                                        <asp:MenuItem Text="Painel de Ordens de Serviço" Value="WGOrdemServico.aspx"></asp:MenuItem>
                                        <asp:MenuItem Text="Reagendamento de OS" Value="WFLiberaReagendamentoOS.aspx"></asp:MenuItem>
                                        <asp:MenuItem Text="Painel de Pedidos" Value="WGPedidoVenda.aspx"></asp:MenuItem>
                                        <asp:MenuItem Text="Painel de Solicitações" Value="WGSolicitacaoDesenvolvimento.aspx">
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="Migração de Ponto de Atendimento" Value="WFAlterarNumeroPontoAtendimento.aspx">
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="Painel de Visitações" Value="WGVisitacao.aspx"></asp:MenuItem>
                                        <asp:MenuItem Text="Painel de Avaliações" Value="WGAvaliacao.aspx"></asp:MenuItem>
                                        <asp:MenuItem Text="Roteiro de Atendimento" Value="WGRoteiroAtendimento.aspx"></asp:MenuItem>
                                        <asp:MenuItem Text="Painel de Campanhas TEF" Value="WGTEF.aspx"></asp:MenuItem>
                                        <asp:MenuItem Text="Painel de Adesões TEF" Value="WGAdesaoTEF.aspx"></asp:MenuItem>
                                        <asp:MenuItem Text="Programação de Atendimento" Value="WGProgramacaoAtendimento.aspx">
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="Ausências de Agente Técnico" Value="WGFalta.aspx"></asp:MenuItem>                                       
                                        <asp:MenuItem Text="Roteiro de Visitações" Value="WGRoteiroVisita.aspx">
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="Painel Assessoria" Value="WGAssessoriaPainel.aspx">
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="Clientes Não  Atendidos" Value="WGClientesNaoAtendidos.aspx">
                                        </asp:MenuItem>
                                    </asp:MenuItem>
                                    <asp:MenuItem Text=" " Value="Consultas" ImageUrl="~/Imagens/MnConsultas.png" Selectable="False">
                                        <asp:MenuItem Text="Painel de Tarefas" Value="WGTarefas.aspx?tid=0"></asp:MenuItem>
                                        <asp:MenuItem Text="Histórico do Ponto de Atendimento" Value="WGConsultaPontoAtendimento.aspx">
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="Ordens de Serviço Pendentes de Impressão" Value="WFRelOSPendenteImpressao.aspx">
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="Programações de Compra/Produção" Value="WGProgramacaoCompra.aspx">
                                        </asp:MenuItem>
                                    </asp:MenuItem>
                                    <asp:MenuItem Text=" " Value="Relatórios" ImageUrl="~/Imagens/MnRelatorios.png" Selectable="False">
                                        <asp:MenuItem Text="Vendas" Value="New Item">
                                            <asp:MenuItem Text="Negociações por Item" Value="WFRelNegociacaoProduto.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Negociações por Funil" Value="WFRelNegociacaoFunil.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Previsão de Fechamento" Value="WFRelPrevisaoFechamento.aspx">
                                            </asp:MenuItem>
                                            <asp:MenuItem Text="Atividades" Value="WFRelAtividade.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Resumo Ações" Value="WFRelResumoAcoes.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Ações por Empresa" Value="WFRelAcoesEmpresa.aspx">
                                            </asp:MenuItem>
                                            <asp:MenuItem Text="Resumo Ações por Colaborador" 
                                                Value="WFRelResumoAcoesColaborador.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Ações por Colaborador" Value="WFRelAcoesColaborador.aspx">
                                            </asp:MenuItem>
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="Atendimentos" Value="Atendimentos">
                                            <asp:MenuItem Text="Listagem de Chamados" Value="WFListagemChamadosFiltro.aspx?">
                                            </asp:MenuItem>
                                            <asp:MenuItem Text="Acompanhamento de Demanda" Value="WFRelOS.aspx"></asp:MenuItem>
                                            <asp:MenuItem Text="Acompanhamento de Demanda por Item" Value="WFRelOSItem.aspx">
                                            </asp:MenuItem>
                                            <asp:MenuItem Text="Acompanhamento de SLA - Encerramento" Value="WFRelSLAComparativoEncerramento.aspx">
                                            </asp:MenuItem>
                                            <asp:MenuItem Text="Acompanhamento de SLA - Chegada" Value="WFRelSLAComparativoAgendamento.aspx">
                                            </asp:MenuItem>
                                            <asp:MenuItem Text="Acompanhamento de Chamado" Value="WFRelAcompanhamentoChamado.aspx">
                                            </asp:MenuItem>
                                            <asp:MenuItem Text="Consumo de Horas por Cliente/Contrato" Value="WFRelConsumoHoras.aspx">
                                            </asp:MenuItem>
                                            <asp:MenuItem Text="Chamados / Horas por Cliente" Value="WFRelChamadoHoras.aspx">
                                            </asp:MenuItem>
                                            <asp:MenuItem Text="Chamados / Horas por Cliente - Detalhado" Value="WFRelChamadoHorasDetalhado.aspx">
                                            </asp:MenuItem>
                                            <asp:MenuItem Text="Chamados / Deslocamentos por Cliente - Detalhado" Value="WFRelChamadoDeslocamentoDetalhado.aspx">
                                            </asp:MenuItem>
                                            <asp:MenuItem Text="Registro de Horas por Data / Agente Técnico" Value="WFRelHorasPorAgenteTecnico.aspx">
                                            </asp:MenuItem>
                                            <asp:MenuItem Text="Faltas de Agente Técnico" Value="WFRelFalta.aspx"></asp:MenuItem>
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="FMEA" Value="FMEA">
                                            <asp:MenuItem Text="Registros de Falha" Value="WFRelFMEA.aspx"></asp:MenuItem>
                                        </asp:MenuItem>
                                    </asp:MenuItem>
                                    <asp:MenuItem Text=" " Value="Utilitários" ImageUrl="~/Imagens/MnUtilitarios.png"
                                        Selectable="False">
                                        <asp:MenuItem Text="Alterar senha" Value="WFTrocaSenha.aspx"></asp:MenuItem>
                                    </asp:MenuItem>
                                </Items>
                            </asp:Menu>
                            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="width: 100%;">
            <td id="tdframe" style="border-width: 1px; border-color: #CCCCCC; width: 100%; border-top-style: solid;
                height: calc(100vh - 73px);">
                <uc1:WUCFrame ID="FrameConteudo" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
