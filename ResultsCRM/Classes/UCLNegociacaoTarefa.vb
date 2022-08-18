Public Class UCLNegociacaoTarefa
    Inherits System.Web.UI.Page

    Private objAcessoDados As UCLAcessoDados
    Private _Empresa As String
    Private _Estabelecimento As String
    Private _CodNegociacaoCliente As String
    Private _SeqTarefa As String
    Private _CodEtapa As String
    Private _CodTarefaPadrao As String
    Private _Prioridade As String
    Private _CodResponsavel As String
    Private _Situacao As String
    Private _ManterInformado As String
    Private _PrevisaoFinalizacao As String
    Private _DPrevisaoFinalizacao As Date
    Private _DataCadastro As String
    Private _DDataCadastro As Date
    Private _DataConclusao As String
    Private _DDataConclusao As Date
    Private _Titulo As String
    Private _Observacao As String
    Private _ObservacaoInterna As String

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Property Estabelecimento() As String
        Get
            Return _Estabelecimento
        End Get
        Set(ByVal value As String)
            _Estabelecimento = value
        End Set
    End Property

    Public Property CodNegociacaoCliente() As String
        Get
            Return _CodNegociacaoCliente
        End Get
        Set(ByVal value As String)
            _CodNegociacaoCliente = value
        End Set
    End Property

    Public Property CodEtapa() As String
        Get
            Return _CodEtapa
        End Get
        Set(ByVal value As String)
            _CodEtapa = value
        End Set
    End Property

    Public Property SeqTarefa() As String
        Get
            Return _SeqTarefa
        End Get
        Set(ByVal value As String)
            _SeqTarefa = value
        End Set
    End Property

    Public Property Situacao() As String
        Get
            Return _Situacao
        End Get
        Set(ByVal value As String)
            _Situacao = value
        End Set
    End Property

    Public Property CodTarefaPadrao() As String
        Get
            Return _CodTarefaPadrao
        End Get
        Set(ByVal value As String)
            _CodTarefaPadrao = value
        End Set
    End Property

    Public Property Prioridade() As String
        Get
            Return _Prioridade
        End Get
        Set(ByVal value As String)
            _Prioridade = value
        End Set
    End Property

    Public Property CodResponsavel() As String
        Get
            Return _CodResponsavel
        End Get
        Set(ByVal value As String)
            _CodResponsavel = value
        End Set
    End Property

    Public Property ManterInformado() As String
        Get
            Return _ManterInformado
        End Get
        Set(ByVal value As String)
            _ManterInformado = value
        End Set
    End Property

    Public Property PrevisaoFinalizacao() As String
        Get
            If _DPrevisaoFinalizacao <> Nothing Then
                Return DPrevisaoFinalizacao.ToString("dd/MM/yyyy")
            Else
                Return _PrevisaoFinalizacao
            End If
        End Get
        Set(ByVal value As String)
            _PrevisaoFinalizacao = value
            If value.isValidDate Then
                DPrevisaoFinalizacao = CDate(value)
            End If
        End Set
    End Property

    Public Property DPrevisaoFinalizacao() As Date
        Get
            Return _DPrevisaoFinalizacao
        End Get
        Set(ByVal value As Date)
            _DPrevisaoFinalizacao = value
        End Set
    End Property

    Public Property DataCadastro() As String
        Get
            If DDataCadastro <> Nothing Then
                Return DDataCadastro.ToString("dd/MM/yyyy")
            Else
                Return _DataCadastro
            End If
        End Get
        Set(ByVal value As String)
            _DataCadastro = value
            If value.isValidDate Then
                DDataCadastro = CDate(value)
            End If
        End Set
    End Property

    Public Property DDataCadastro() As Date
        Get
            Return _DDataCadastro
        End Get
        Set(ByVal value As Date)
            _DDataCadastro = value
        End Set
    End Property

    Public Property DataConclusao() As String
        Get
            If DDataConclusao <> Nothing Then
                Return DDataConclusao.ToString("dd/MM/yyyy")
            Else
                Return _DataConclusao
            End If
        End Get
        Set(ByVal value As String)
            _DataConclusao = value
            If value.isValidDate Then
                DDataConclusao = CDate(value)
            End If
        End Set
    End Property

    Public Property DDataConclusao() As Date
        Get
            Return _DDataConclusao
        End Get
        Set(ByVal value As Date)
            _DDataConclusao = value
        End Set
    End Property

    Public Property Titulo() As String
        Get
            Return _Titulo
        End Get
        Set(ByVal value As String)
            _Titulo = value
        End Set
    End Property

    Public Property Observacao() As String
        Get
            Return _Observacao
        End Get
        Set(ByVal value As String)
            _Observacao = value
        End Set
    End Property

    Public Property ObservacaoInterna() As String
        Get
            Return _ObservacaoInterna
        End Get
        Set(ByVal value As String)
            _ObservacaoInterna = value
        End Set
    End Property

    Public Sub New(ByVal StrConn As String)
        objAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Sub Buscar()
        Dim strSql As String = ""
        Dim dt As DataTable

        Try
            strSql += " select cod_tarefa_padrao, "
            strSql += "        cod_etapa, "
            strSql += "        prioridade, "
            strSql += "        cod_responsavel, "
            strSql += "        manter_informado, "
            strSql += "        previsao_finalizacao,"
            strSql += "        data_cadastro, "
            strSql += "        data_conclusao, "
            strSql += "        titulo,"
            strSql += "        observacao, "
            strSql += "        observacao_interna, "
            strSql += "        situacao"
            strSql += "   from negociacao_tarefa "
            strSql += "  where seq_tarefa = " + SeqTarefa
            strSql += "    and cod_negociacao_cliente = " + CodNegociacaoCliente
            strSql += "    and estabelecimento = " + Estabelecimento
            strSql += "    and empresa = " + Empresa

            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                CodTarefaPadrao = dt.Rows.Item(0).Item("cod_tarefa_padrao").ToString
                CodEtapa = dt.Rows.Item(0).Item("cod_etapa").ToString
                Prioridade = dt.Rows.Item(0).Item("prioridade").ToString
                CodResponsavel = dt.Rows.Item(0).Item("cod_responsavel").ToString
                ManterInformado = dt.Rows.Item(0).Item("manter_informado").ToString
                PrevisaoFinalizacao = CDate(dt.Rows.Item(0).Item("previsao_finalizacao"))
                If Not IsDBNull(dt.Rows.Item(0).Item("data_cadastro")) Then
                    DataCadastro = CDate(dt.Rows.Item(0).Item("data_cadastro"))
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("data_conclusao")) Then
                    DataConclusao = dt.Rows.Item(0).Item("data_conclusao").ToString
                End If
                Titulo = dt.Rows.Item(0).Item("titulo").ToString
                Observacao = dt.Rows.Item(0).Item("observacao").ToString
                Situacao = dt.Rows.Item(0).Item("situacao").ToString
                ObservacaoInterna = dt.Rows.Item(0).Item("observacao_interna").ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            If String.IsNullOrEmpty(CodTarefaPadrao) OrElse CodTarefaPadrao = "0" Then
                CodTarefaPadrao = "null"
            End If
            If String.IsNullOrEmpty(CodResponsavel) OrElse CodResponsavel = "0" Then
                CodResponsavel = "null"
            End If
            If String.IsNullOrEmpty(CodEtapa) OrElse CodEtapa = "0" Then
                CodEtapa = "null"
            End If
            strSql += " insert into negociacao_tarefa( "
            strSql += "    empresa, "
            strSql += "    estabelecimento, "
            strSql += "    cod_negociacao_cliente, "
            strSql += "    seq_tarefa, "
            strSql += "    cod_etapa, "
            strSql += "    cod_tarefa_padrao, "
            strSql += "    prioridade, "
            strSql += "    cod_responsavel, "
            strSql += "    manter_informado, "
            strSql += "    previsao_finalizacao,"
            strSql += "    data_cadastro, "
            strSql += "    data_conclusao, "
            strSql += "    situacao, "
            strSql += "    titulo,"
            strSql += "    observacao, "
            strSql += "    observacao_interna) "

            strSql += " values ( "
            strSql += Empresa + ", "
            strSql += Estabelecimento + ", "
            strSql += CodNegociacaoCliente + ", "
            strSql += SeqTarefa + ", "
            strSql += CodEtapa + ", "
            strSql += CodTarefaPadrao + ", "
            strSql += "'" + Prioridade + "', "
            strSql += CodResponsavel + ", "
            strSql += "'" + ManterInformado + "', "

            If DPrevisaoFinalizacao <> Nothing Then
                strSql += DPrevisaoFinalizacao.ToString("yyyyMMdd") + ", "
            Else
                strSql += " null, "
            End If

            If DDataCadastro <> Nothing Then
                strSql += DDataCadastro.ToString("yyyyMMdd") + ", "
            Else
                strSql += " null, "
            End If

            If DDataConclusao <> Nothing Then
                strSql += DDataConclusao.ToString("yyyyMMdd") + ", "
            Else
                strSql += " null, "
            End If

            strSql += "'" + Situacao + "', "
            strSql += "'" + Titulo + "', "
            strSql += "'" + Observacao + "', "
            strSql += "'" + ObservacaoInterna + "' ) "

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Dim strSql2 As String = ""
        Dim dt2 As DataTable
        Dim stant As String = ""
        Try
            strSql2 = " select situacao "
            strSql2 += "  from negociacao_tarefa "
            strSql2 += " where empresa                = " + Empresa + " "
            strSql2 += "   and estabelecimento        = " + Estabelecimento + " "
            strSql2 += "   and cod_negociacao_cliente = " + CodNegociacaoCliente + " "
            strSql2 += "   and seq_tarefa             = " + SeqTarefa
            dt2 = objAcessoDados.BuscarDados(strSql2)

            If dt2.Rows.Count > 0 Then
                stant = dt2.Rows.Item(0).Item("situacao").ToString
            End If

            If String.IsNullOrEmpty(CodTarefaPadrao) OrElse CodTarefaPadrao = "0" Then
                CodTarefaPadrao = "null"
            End If
            If String.IsNullOrEmpty(CodResponsavel) OrElse CodResponsavel = "0" Then
                CodResponsavel = "null"
            End If
            If String.IsNullOrEmpty(CodEtapa) OrElse CodEtapa = "0" Then
                CodEtapa = "null"
            End If
            strSql += " update negociacao_tarefa set "
            strSql += "    cod_tarefa_padrao = " + CodTarefaPadrao + ", "
            strSql += "    cod_etapa = " + CodEtapa + ", "
            strSql += "    prioridade = '" + Prioridade + "', "
            strSql += "    cod_responsavel = " + CodResponsavel + ", "
            strSql += "    manter_informado = '" + ManterInformado + "', "
            If DPrevisaoFinalizacao <> Nothing Then
                strSql += "    previsao_finalizacao = " + DPrevisaoFinalizacao.ToString("yyyyMMdd") + ", "
            Else
                strSql += "    previsao_finalizacao = null , "
            End If
            If DDataCadastro <> Nothing Then
                strSql += "    data_cadastro = " + DDataCadastro.ToString("yyyyMMdd") + ", "
            Else
                strSql += "    data_cadastro = null , "
            End If
            If DDataConclusao <> Nothing Then
                strSql += "    data_conclusao = " + DDataConclusao.ToString("yyyyMMdd") + ", "
            Else
                strSql += "    data_conclusao = null , "
            End If
            strSql += "    titulo = '" + Titulo + "', "
            strSql += "    situacao = '" + Situacao + "', "
            strSql += "    observacao = '" + Observacao + "', "
            strSql += "    observacao_interna = '" + ObservacaoInterna + "' "
            strSql += " where empresa = " + Empresa + " "
            strSql += "   and estabelecimento = " + Estabelecimento + " "
            strSql += "   and cod_negociacao_cliente = " + CodNegociacaoCliente + " "
            strSql += "   and seq_tarefa = " + SeqTarefa

            objAcessoDados.ExecutarSql(strSql)

            If stant <> Me.Situacao AndAlso Me.Situacao = "4" Then
                If Not String.IsNullOrEmpty(Me.ManterInformado) Then
                    Call EnviaEmailConclusaoTarefa()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Excluir()
        Dim strSql As String = ""

        Try
            strSql += " delete from negociacao_tarefa "
            strSql += " where empresa = " + Empresa + " "
            strSql += "   and estabelecimento = " + Estabelecimento + " "
            strSql += "   and cod_negociacao_cliente = " + CodNegociacaoCliente + " "
            strSql += "   and seq_tarefa = " + SeqTarefa
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(seq_tarefa),0) + 1 max from negociacao_tarefa where empresa = " + Empresa + " and estabelecimento = " + Estabelecimento + " and cod_negociacao_cliente = " + CodNegociacaoCliente
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Sub EnviaEmailConclusaoTarefa()
        Try
            Dim objEmail As New UCLNegociacaoEmail(StrConexaoUsuario(Session("GlUsuario")))
            Dim objAgenteVendas As New UCLAgenteVendas
            Dim objTarefaPadrao As New UCLTarefaPadrao
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))

            If String.IsNullOrEmpty(Me.CodResponsavel) Then
                Return
            End If

            If String.IsNullOrEmpty(Me.CodTarefaPadrao) Then
                Return
            End If

            If String.IsNullOrEmpty(Me.ManterInformado) Then
                Return
            End If

            objAgenteVendas.Codigo = Me.CodResponsavel
            If Not objAgenteVendas.Buscar() Then
                Return
            End If

            objNegociacao.Empresa = Me.Empresa
            objNegociacao.Estabelecimento = Me.Estabelecimento
            objNegociacao.CodNegociacao = Me.CodNegociacaoCliente
            If objNegociacao.Buscar().Rows.Count = 0 Then
                Return
            End If

            objEmitente.CodEmitente = objNegociacao.CodCliente
            If objEmitente.Buscar().Rows.Count = 0 Then
                Return
            End If

            objTarefaPadrao.CodTarefaPadrao = Me.CodTarefaPadrao
            objTarefaPadrao.Buscar()

            objEmail.Empresa = Me.Empresa
            objEmail.Estabelecimento = Me.Estabelecimento
            objEmail.CodNegociacaoCliente = Me.CodNegociacaoCliente
            objEmail.Seq = objEmail.GetProximoCodigo()
            objEmail.Assunto = "Negociação Nº" + Me.CodNegociacaoCliente + " - Tarefa concluída "
            objEmail.DataEmail = Now.ToString("dd/MM/yyyy")
            objEmail.HHoraEmail = Now.ToString("HH:mm")
            objEmail.De = objAgenteVendas.Email
            objEmail.Destinatario = Me.ManterInformado
            objEmail.EnviarAutomatico = "S"
            objEmail.Mensagem = "Prezado(a)<br><br>Informamos que a tarefa " + Chr(34) + objTarefaPadrao.DescricaoResumida + Chr(34) + ", referente à negociação nº " + Me.CodNegociacaoCliente + " do cliente " + objEmitente.Nome + "(" + objEmitente.CodEmitente + "), foi concluída nesta data.<br><br>Att,<br>" + objAgenteVendas.Nome
            objEmail.Para = Me.ManterInformado
            objEmail.Remetente = objAgenteVendas.Nome
            objEmail.Incluir()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
