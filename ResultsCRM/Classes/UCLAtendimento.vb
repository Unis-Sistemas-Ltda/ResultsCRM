Imports System.IO
Public Class UCLAtendimento
    Inherits System.Web.UI.Page

    Private objAcessoDados As UCLAcessoDados

    Private AssuntoMaiusculo As Boolean
    Private ObservacaoMaiusculo As Boolean
    Private _Empresa As String
    Private _Estabelecimento As String
    Private _CodChamado As String
    Private _CodChamadoOriginal As String
    Private _CodChamadoVinculado As String
    Private _CodEmitente As String
    Private _CodEmitenteAtendimento As String
    Private _CodContato As String
    Private _CodContatoAtendimento As String
    Private _CodAnalista As String
    Private _TipoChamado As String
    Private _NumeroSerie As String
    Private _CodUsuario As String
    Private _CodStatus As String
    Private _DataChamado As String
    Private _DDataChamado As Date
    Private _HoraChamado As String
    Private _DataEncerramentoPrevista As String
    Private _DDataEncerramentoPrevista As Date
    Private _HoraEncerramentoPrevista As String
    Private _DataChegadaPrevista As String
    Private _DDataChegadaPrevista As Date
    Private _HoraChegadaPrevista As String
    Private _DataChegada As String
    Private _DDataChegada As Date
    Private _HoraChegada As String
    Private _DataEncerramentoPrevistaInicio As String
    Private _DDataEncerramentoPrevistaInicio As Date
    Private _HoraEncerramentoPrevistaInicio As String
    Private _DataEncerramento As String
    Private _DDataEncerramento As Date
    Private _HoraEncerramento As String
    Private _Assunto As String
    Private _MotivoCancelamento As String
    Private _OSCliente As String
    Private _Observacao As String
    Private _Cnpj As String
    Private _CnpjAtendimento As String
    Private _NumeroPontoAtendimento As String
    Private _CodVeiculo As String
    Private _ChecaEnvioEmail As Boolean
    Private _PrazoChegada As String
    Private _PrazoEncerramento As String
    Private _CodSla As String
    Private _SAG As String
    Private _AceiteTecnico As String

    Public Property CodSistema As String
    Public Property CodModulo As String
    Public Property CaminhoMenu As String
    Public Property Programa As String
    Public Property Contrato As String = ""
    Public Property QtdChamadoDia As String
    Public Property QtdChamadoDiaSLA As String
    Public Property DesobrigadoSLA As String

    Public Property IntervencaoConjunta As String
    Public Property IntervencaoConjuntaNarrativa As String

    Public Property CodFormaPagamentoOS As String
    Public Property CodCondPagtoOS As String

    Private _DataInicioAtendimento As String
    Private _DDataInicioAtendimento As Date
    Private _HoraInicioAtendimento As String

    Private _DataInicioTrabalhoTecnico As String
    Private _DDataInicioTrabalhoTecnico As Date
    Private _HoraInicioTrabalhoTecnico As String

    Private _DataInstalacaoTEF As String
    Private _DDataInstalacaoTEF As Date

    Private _DataLiberacaoOSTEF As String
    Private _DDataLiberacaoOSTEF As Date

    Public Property AceiteTecnico As String
        Get
            Return _AceiteTecnico
        End Get
        Set(value As String)
            _AceiteTecnico = value
        End Set
    End Property

    Public Property SAG As String
        Get
            Return _SAG
        End Get
        Set(value As String)
            _SAG = value
        End Set
    End Property

    Public Property PrazoChegada As String
        Get
            Return _PrazoChegada
        End Get
        Set(ByVal value As String)
            _PrazoChegada = value
        End Set
    End Property

    Public Property CodChamadoVinculado As String
        Get
            Return _CodChamadoVinculado
        End Get
        Set(value As String)
            _CodChamadoVinculado = value
        End Set
    End Property

    Public Property PrazoEncerramento As String
        Get
            Return _PrazoEncerramento
        End Get
        Set(ByVal value As String)
            _PrazoEncerramento = value
        End Set
    End Property

    Public Property CodSla As String
        Get
            Return _CodSla
        End Get
        Set(ByVal value As String)
            _CodSla = value
        End Set
    End Property

    Public Property ChecaEnvioEmailStatus() As Boolean
        Get
            Return _ChecaEnvioEmail
        End Get
        Set(ByVal value As Boolean)
            _ChecaEnvioEmail = value
        End Set
    End Property

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

    Public Property CodChamado() As String
        Get
            Return _CodChamado
        End Get
        Set(ByVal value As String)
            _CodChamado = value
        End Set
    End Property

    Public Property CodChamadoOriginal() As String
        Get
            Return _CodChamadoOriginal
        End Get
        Set(ByVal value As String)
            _CodChamadoOriginal = value
        End Set
    End Property

    Public Property CodEmitente() As String
        Get
            Return _CodEmitente
        End Get
        Set(ByVal value As String)
            _CodEmitente = value
        End Set
    End Property

    Public Property CodEmitenteAtendimento() As String
        Get
            Return _CodEmitenteAtendimento
        End Get
        Set(ByVal value As String)
            _CodEmitenteAtendimento = value
        End Set
    End Property

    Public Property CodContato() As String
        Get
            Return _CodContato
        End Get
        Set(ByVal value As String)
            _CodContato = value
        End Set
    End Property

    Public Property CodContatoAtendimento() As String
        Get
            Return _CodContatoAtendimento
        End Get
        Set(ByVal value As String)
            _CodContatoAtendimento = value
        End Set
    End Property

    Public Property CodAnalista() As String
        Get
            Return _CodAnalista
        End Get
        Set(ByVal value As String)
            _CodAnalista = value
        End Set
    End Property

    Public Property TipoChamado() As String
        Get
            Return _TipoChamado
        End Get
        Set(ByVal value As String)
            _TipoChamado = value
        End Set
    End Property

    Public Property NumeroSerie() As String
        Get
            Return _NumeroSerie
        End Get
        Set(ByVal value As String)
            _NumeroSerie = value
        End Set
    End Property

    Public Property CodUsuario() As String
        Get
            Return _CodUsuario
        End Get
        Set(ByVal value As String)
            _CodUsuario = value
        End Set
    End Property

    Public Property CodStatus() As String
        Get
            Return _CodStatus
        End Get
        Set(ByVal value As String)
            _CodStatus = value
        End Set
    End Property

    Public Property DataChamado() As String
        Get
            Return _DataChamado
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataChamado = CDate(value)
            End If
            _DataChamado = value
        End Set
    End Property

    Public Property DDataChamado() As Date
        Get
            Return _DDataChamado
        End Get
        Set(ByVal value As Date)
            _DDataChamado = value
        End Set
    End Property

    Public Property HoraChamado() As String
        Get
            Return _HoraChamado
        End Get
        Set(ByVal value As String)
            _HoraChamado = value
        End Set
    End Property

    Public Property DataEncerramentoPrevista() As String
        Get
            Return _DataEncerramentoPrevista
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataEncerramentoPrevista = CDate(value)
            End If
            _DataEncerramentoPrevista = value
        End Set
    End Property

    Public Property DDataEncerramentoPrevista() As Date
        Get
            Return _DDataEncerramentoPrevista
        End Get
        Set(ByVal value As Date)
            _DDataEncerramentoPrevista = value
        End Set
    End Property

    Public Property HoraEncerramentoPrevista() As String
        Get
            Return _HoraEncerramentoPrevista
        End Get
        Set(ByVal value As String)
            _HoraEncerramentoPrevista = value
        End Set
    End Property

    Public Property DataChegadaPrevista() As String
        Get
            Return _DataChegadaPrevista
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataChegadaPrevista = CDate(value)
            End If
            _DataChegadaPrevista = value
        End Set
    End Property

    Public Property DDataChegadaPrevista() As Date
        Get
            Return _DDataChegadaPrevista
        End Get
        Set(ByVal value As Date)
            _DDataChegadaPrevista = value
        End Set
    End Property

    Public Property HoraChegadaPrevista() As String
        Get
            Return _HoraChegadaPrevista
        End Get
        Set(ByVal value As String)
            _HoraChegadaPrevista = value
        End Set
    End Property

    Public Property DataChegada() As String
        Get
            Return _DataChegada
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataChegada = CDate(value)
            End If
            _DataChegada = value
        End Set
    End Property

    Public Property DDataChegada() As Date
        Get
            Return _DDataChegada
        End Get
        Set(ByVal value As Date)
            _DDataChegada = value
        End Set
    End Property

    Public Property HoraChegada() As String
        Get
            Return _HoraChegada
        End Get
        Set(ByVal value As String)
            _HoraChegada = value
        End Set
    End Property

    Public Property DataInicioAtendimento() As String
        Get
            Return _DataInicioAtendimento
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataInicioAtendimento = CDate(value)
            End If
            _DataInicioAtendimento = value
        End Set
    End Property

    Public Property DataInicioTrabalhoTecnico() As String
        Get
            Return _DataInicioTrabalhoTecnico
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataInicioTrabalhoTecnico = CDate(value)
            End If
            _DataInicioTrabalhoTecnico = value
        End Set
    End Property

    Public Property DataEncerramentoPrevistaInicio() As String
        Get
            Return _DataEncerramentoPrevistaInicio
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataEncerramentoPrevistaInicio = CDate(value)
            End If
            _DataEncerramentoPrevistaInicio = value
        End Set
    End Property

    Public Property MotivoCancelamento() As String
        Get
            Return _MotivoCancelamento
        End Get
        Set(ByVal value As String)
            _MotivoCancelamento = value
        End Set
    End Property

    Public Property DDataInicioAtendimento() As Date
        Get
            Return _DDataInicioAtendimento
        End Get
        Set(ByVal value As Date)
            _DDataInicioAtendimento = value
        End Set
    End Property

    Public Property DDataInicioTrabalhoTecnico() As Date
        Get
            Return _DDataInicioTrabalhoTecnico
        End Get
        Set(ByVal value As Date)
            _DDataInicioTrabalhoTecnico = value
        End Set
    End Property

    Public Property DDataEncerramentoPrevistaInicio() As Date
        Get
            Return _DDataEncerramentoPrevistaInicio
        End Get
        Set(ByVal value As Date)
            _DDataEncerramentoPrevistaInicio = value
        End Set
    End Property

    Public Property HoraEncerramentoPrevistaInicio() As String
        Get
            Return _HoraEncerramentoPrevistaInicio
        End Get
        Set(ByVal value As String)
            _HoraEncerramentoPrevistaInicio = value
        End Set
    End Property

    Public Property HoraInicioAtendimento() As String
        Get
            Return _HoraInicioAtendimento
        End Get
        Set(ByVal value As String)
            _HoraInicioAtendimento = value
        End Set
    End Property

    Public Property HoraInicioTrabalhoTecnico() As String
        Get
            Return _HoraInicioTrabalhoTecnico
        End Get
        Set(ByVal value As String)
            _HoraInicioTrabalhoTecnico = value
        End Set
    End Property

    Public Property DataEncerramento() As String
        Get
            Return _DataEncerramento
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataEncerramento = CDate(value)
            End If
            _DataEncerramento = value
        End Set
    End Property

    Public Property DDataEncerramento() As Date
        Get
            Return _DDataEncerramento
        End Get
        Set(ByVal value As Date)
            _DDataEncerramento = value
        End Set
    End Property

    Public Property HoraEncerramento() As String
        Get
            Return _HoraEncerramento
        End Get
        Set(ByVal value As String)
            _HoraEncerramento = value
        End Set
    End Property

    Public Property Assunto() As String
        Get
            Return _Assunto
        End Get
        Set(ByVal value As String)
            _Assunto = value
        End Set
    End Property

    Public Property OSCliente() As String
        Get
            Return _OSCliente
        End Get
        Set(ByVal value As String)
            _OSCliente = value
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

    Public Property Cnpj() As String
        Get
            Return _Cnpj
        End Get
        Set(ByVal value As String)
            _Cnpj = value
        End Set
    End Property

    Public Property CnpjAtendimento() As String
        Get
            Return _CnpjAtendimento
        End Get
        Set(ByVal value As String)
            _CnpjAtendimento = value
        End Set
    End Property

    Public Property NumeroPontoAtendimento() As String
        Get
            Return _NumeroPontoAtendimento
        End Get
        Set(ByVal value As String)
            _NumeroPontoAtendimento = value
        End Set
    End Property

    Public Property CodVeiculo() As String
        Get
            Return _CodVeiculo
        End Get
        Set(ByVal value As String)
            _CodVeiculo = value
        End Set
    End Property

    Public Property DataInstalacaoTEF() As String
        Get
            Return _DataInstalacaoTEF
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataInstalacaoTEF = CDate(value)
            End If
            _DataInstalacaoTEF = value
        End Set
    End Property

    Public Property DDataInstalacaoTEF() As Date
        Get
            Return _DDataInstalacaoTEF
        End Get
        Set(ByVal value As Date)
            _DDataInstalacaoTEF = value
        End Set
    End Property


    Public Property DataLiberacaoOSTEF() As String
        Get
            Return _DataLiberacaoOSTEF
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataLiberacaoOSTEF = CDate(value)
            End If
            _DataLiberacaoOSTEF = value
        End Set
    End Property

    Public Property DDataLiberacaoOSTEF() As Date
        Get
            Return _DDataLiberacaoOSTEF
        End Get
        Set(ByVal value As Date)
            _DDataLiberacaoOSTEF = value
        End Set
    End Property

    Public Sub New(ByVal strConn As String)
        Dim objParametrosManutencao As New UCLParametrosManutencao
        objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))
        AssuntoMaiusculo = (objParametrosManutencao.GetConteudo("assunto_maiusculo") = "S")
        ObservacaoMaiusculo = (objParametrosManutencao.GetConteudo("observacao_maiusculo") = "S")

        objAcessoDados = New UCLAcessoDados(strConn)
    End Sub

    Public Sub New(ByVal strConn As String, ByVal pEmpresa As String, ByVal pEstabelecimento As String)
        Dim objParametrosManutencao As New UCLParametrosManutencao
        objParametrosManutencao.Buscar(pEmpresa, pEstabelecimento)
        AssuntoMaiusculo = (objParametrosManutencao.GetConteudo("assunto_maiusculo") = "S")
        ObservacaoMaiusculo = (objParametrosManutencao.GetConteudo("observacao_maiusculo") = "S")

        objAcessoDados = New UCLAcessoDados(strConn)
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim strSql As String
            Dim dt As DataTable

            strSql = ""
            strSql += " select contrato, cod_chamado_original, estabelecimento, cod_emitente, cod_contato, cod_analista, tipo_chamado, numero_serie, cod_usuario, cod_status, data_chamado, cod_sla, data_chegada_prevista, data_chegada, isnull(aceite_tecnico,'N') aceite_tecnico, "
            strSql += "        data_encerramento_prevista, data_encerramento_prevista_inicio, data_encerramento, assunto, os_cliente, motivo_cancelamento, sag, cod_sistema, cod_modulo, caminho_menu, programa, "
            strSql += "        observacao, cnpj, cod_veiculo, cod_emitente_atendimento, cnpj_atendimento, cod_contato_atendimento, numero_ponto_atendimento, prazo_chegada, prazo_encerramento, data_inicio_trabalho_tecnico, "
            strSql += "        isnull(intervencao_conjunta,'') intervencao_conjunta, isnull(intervencao_conjunta_narrativa,'') intervencao_conjunta_narrativa, desobrigado_sla, qtd_chamado_dia, qtd_chamado_dia_sla, "
            strSql += "        data_instalacao_tef, data_liberacao_os_tef "
            strSql += "   from chamado "
            strSql += "  where cod_chamado = " + CodChamado
            strSql += "    and empresa = " + Empresa

            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                Contrato = dt.Rows.Item(0).Item("contrato").ToString
                Estabelecimento = dt.Rows.Item(0).Item("estabelecimento").ToString
                CodChamadoOriginal = dt.Rows.Item(0).Item("cod_chamado_original").ToString
                CodEmitente = dt.Rows.Item(0).Item("cod_emitente").ToString
                CodEmitenteAtendimento = dt.Rows.Item(0).Item("cod_emitente_atendimento").ToString
                Cnpj = dt.Rows.Item(0).Item("cnpj").ToString
                CnpjAtendimento = dt.Rows.Item(0).Item("cnpj_atendimento").ToString
                CodContato = dt.Rows.Item(0).Item("cod_contato").ToString
                CodContatoAtendimento = dt.Rows.Item(0).Item("cod_contato_atendimento").ToString
                CodAnalista = dt.Rows.Item(0).Item("cod_analista").ToString
                TipoChamado = dt.Rows.Item(0).Item("tipo_chamado").ToString
                NumeroSerie = dt.Rows.Item(0).Item("numero_serie").ToString
                CodUsuario = dt.Rows.Item(0).Item("cod_usuario").ToString
                CodStatus = dt.Rows.Item(0).Item("cod_status").ToString
                Assunto = dt.Rows.Item(0).Item("assunto").ToString
                MotivoCancelamento = dt.Rows.Item(0).Item("motivo_cancelamento").ToString
                OSCliente = dt.Rows.Item(0).Item("os_cliente").ToString.ToUpper
                Observacao = dt.Rows.Item(0).Item("observacao").ToString
                CodVeiculo = dt.Rows.Item(0).Item("cod_veiculo").ToString
                PrazoChegada = dt.Rows.Item(0).Item("prazo_chegada").ToString
                PrazoEncerramento = dt.Rows.Item(0).Item("prazo_encerramento").ToString
                IntervencaoConjunta = dt.Rows.Item(0).Item("intervencao_conjunta").ToString
                DesobrigadoSLA = dt.Rows.Item(0).Item("desobrigado_sla").ToString
                QtdChamadoDia = dt.Rows.Item(0).Item("qtd_chamado_dia").ToString
                QtdChamadoDiaSLA = dt.Rows.Item(0).Item("qtd_chamado_dia_sla").ToString
                IntervencaoConjuntaNarrativa = dt.Rows.Item(0).Item("intervencao_conjunta_narrativa").ToString
                CodSla = dt.Rows.Item(0).Item("cod_sla").ToString
                AceiteTecnico = dt.Rows.Item(0).Item("aceite_tecnico").ToString
                NumeroPontoAtendimento = dt.Rows.Item(0).Item("numero_ponto_atendimento").ToString
                CodSistema = dt.Rows.Item(0).Item("cod_sistema").ToString
                CodModulo = dt.Rows.Item(0).Item("cod_modulo").ToString
                CaminhoMenu = dt.Rows.Item(0).Item("caminho_menu").ToString
                Programa = dt.Rows.Item(0).Item("programa").ToString
                SAG = dt.Rows.Item(0).Item("sag").ToString

                If Not IsDBNull(dt.Rows.Item(0).Item("data_chamado")) Then
                    DataChamado = CDate(dt.Rows.Item(0).Item("data_chamado")).ToString("dd/MM/yyyy")
                    HoraChamado = CType(dt.Rows.Item(0).Item("data_chamado"), DateTime).ToString("HH:mm")
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("data_encerramento_prevista")) Then
                    DataEncerramentoPrevista = CDate(dt.Rows.Item(0).Item("data_encerramento_prevista")).ToString("dd/MM/yyyy")
                    HoraEncerramentoPrevista = CType(dt.Rows.Item(0).Item("data_encerramento_prevista"), DateTime).ToString("HH:mm")
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("data_chegada_prevista")) Then
                    DataChegadaPrevista = CDate(dt.Rows.Item(0).Item("data_chegada_prevista")).ToString("dd/MM/yyyy")
                    HoraChegadaPrevista = CType(dt.Rows.Item(0).Item("data_chegada_prevista"), DateTime).ToString("HH:mm")
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("data_chegada")) Then
                    DataChegada = CDate(dt.Rows.Item(0).Item("data_chegada")).ToString("dd/MM/yyyy")
                    HoraChegada = CType(dt.Rows.Item(0).Item("data_chegada"), DateTime).ToString("HH:mm")
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("data_encerramento_prevista_inicio")) Then
                    DataEncerramentoPrevistaInicio = CDate(dt.Rows.Item(0).Item("data_encerramento_prevista_inicio")).ToString("dd/MM/yyyy")
                    HoraEncerramentoPrevistaInicio = CType(dt.Rows.Item(0).Item("data_encerramento_prevista_inicio"), DateTime).ToString("HH:mm")
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("data_encerramento")) Then
                    DataEncerramento = CDate(dt.Rows.Item(0).Item("data_encerramento")).ToString("dd/MM/yyyy")
                    HoraEncerramento = CType(dt.Rows.Item(0).Item("data_encerramento"), DateTime).ToString("HH:mm")
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("data_inicio_trabalho_tecnico")) Then
                    DataInicioTrabalhoTecnico = CDate(dt.Rows.Item(0).Item("data_inicio_trabalho_tecnico")).ToString("dd/MM/yyyy")
                    HoraInicioTrabalhoTecnico = CType(dt.Rows.Item(0).Item("data_inicio_trabalho_tecnico"), DateTime).ToString("HH:mm")
                End If

                If Not IsDBNull(dt.Rows.Item(0).Item("data_instalacao_tef")) Then
                    DataInstalacaoTEF = CDate(dt.Rows.Item(0).Item("data_instalacao_tef")).ToString("dd/MM/yyyy")
                End If

                If Not IsDBNull(dt.Rows.Item(0).Item("data_liberacao_os_tef")) Then
                    DataLiberacaoOSTEF = CDate(dt.Rows.Item(0).Item("data_liberacao_os_tef")).ToString("dd/MM/yyyy")
                End If

                '
                strSql = "  select first cod_chamado "
                strSql += "   from chamado "
                strSql += "  where cod_chamado_original = " + CodChamado
                strSql += "    and empresa              = " + Empresa
                dt = objAcessoDados.BuscarDados(strSql)
                If dt.Rows.Count > 0 Then
                    CodChamadoVinculado = dt.Rows.Item(0).Item("cod_chamado").ToString
                Else
                    CodChamadoVinculado = ""
                End If

                strSql = "  select max(data_inicio_execucao) data_inicio_execucao "
                strSql += "   from pedido_venda "
                strSql += "  where cod_chamado = " + CodChamado
                strSql += "    and empresa     = " + Empresa
                dt = objAcessoDados.BuscarDados(strSql)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows.Item(0).Item("data_inicio_execucao")) Then
                        DataInicioAtendimento = CDate(dt.Rows.Item(0).Item("data_inicio_execucao")).ToString("dd/MM/yyyy")
                        HoraInicioAtendimento = CType(dt.Rows.Item(0).Item("data_inicio_execucao"), DateTime).ToString("HH:mm")
                    End If
                Else
                    DataInicioAtendimento = ""
                    HoraInicioAtendimento = ""
                End If

                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Incluir(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodChamado As String)
        Try
            Dim strSql As String
            Dim dbDataChamado As String
            Dim dbDataChegadaPrevista As String
            Dim dbDataChegada As String
            Dim dbDataEncerramentoPrevista As String
            Dim dbDataEncerramentoPrevistaInicio As String
            Dim dbDataEncerramento As String
            Dim dbDataInicioTrabalhoTecnico As String
            Dim dbDataInstalacaoTEF As String
            Dim dbDataLiberacaoOSTEF As String

            If DDataChamado <> Nothing Then
                dbDataChamado = DDataChamado.ToString("yyyy-MM-dd")
                If Not String.IsNullOrWhiteSpace(HoraChamado) Then
                    dbDataChamado += " " + HoraChamado + ":00"
                End If
                dbDataChamado = "'" + dbDataChamado + "'"
            Else
                dbDataChamado = "null"
            End If

            If DDataInicioTrabalhoTecnico <> Nothing Then
                dbDataInicioTrabalhoTecnico = DDataInicioTrabalhoTecnico.ToString("yyyy-MM-dd")
                If Not String.IsNullOrWhiteSpace(HoraInicioTrabalhoTecnico) Then
                    dbDataInicioTrabalhoTecnico += " " + HoraInicioTrabalhoTecnico + ":00"
                End If
                dbDataInicioTrabalhoTecnico = "'" + dbDataInicioTrabalhoTecnico + "'"
            Else
                dbDataInicioTrabalhoTecnico = "null"
            End If

            If DDataEncerramentoPrevista <> Nothing AndAlso DataEncerramentoPrevista <> "" Then
                dbDataEncerramentoPrevista = DDataEncerramentoPrevista.ToString("yyyy-MM-dd")
                If Not String.IsNullOrWhiteSpace(HoraEncerramentoPrevista) Then
                    dbDataEncerramentoPrevista += " " + HoraEncerramentoPrevista + ":00"
                End If
                dbDataEncerramentoPrevista = "'" + dbDataEncerramentoPrevista + "'"
            Else
                dbDataEncerramentoPrevista = "null"
            End If

            If DDataChegadaPrevista <> Nothing Then
                dbDataChegadaPrevista = DDataChegadaPrevista.ToString("yyyy-MM-dd")
                If Not String.IsNullOrWhiteSpace(HoraChegadaPrevista) Then
                    dbDataChegadaPrevista += " " + HoraChegadaPrevista + ":00"
                End If
                dbDataChegadaPrevista = "'" + dbDataChegadaPrevista + "'"
            Else
                dbDataChegadaPrevista = "null"
            End If

            If DDataChegada <> Nothing Then
                dbDataChegada = DDataChegada.ToString("yyyy-MM-dd")
                If Not String.IsNullOrWhiteSpace(HoraChegada) Then
                    dbDataChegada += " " + HoraChegada + ":00"
                End If
                dbDataChegada = "'" + dbDataChegada + "'"
            Else
                dbDataChegada = "null"
            End If

            If DDataEncerramentoPrevistaInicio <> Nothing AndAlso DataEncerramentoPrevistaInicio <> "" Then
                dbDataEncerramentoPrevistaInicio = DDataEncerramentoPrevistaInicio.ToString("yyyy-MM-dd")
                If Not String.IsNullOrWhiteSpace(HoraEncerramentoPrevistaInicio) Then
                    dbDataEncerramentoPrevistaInicio += " " + HoraEncerramentoPrevistaInicio + ":00"
                End If
                dbDataEncerramentoPrevistaInicio = "'" + dbDataEncerramentoPrevistaInicio + "'"
            Else
                dbDataEncerramentoPrevistaInicio = "null"
            End If

            If DDataEncerramento <> Nothing Then
                dbDataEncerramento = DDataEncerramento.ToString("yyyy-MM-dd")
                If Not String.IsNullOrWhiteSpace(HoraEncerramento) Then
                    dbDataEncerramento += " " + HoraEncerramento + ":00"
                End If
                dbDataEncerramento = "'" + dbDataEncerramento + "'"
            Else
                dbDataEncerramento = "null"
            End If

            If String.IsNullOrWhiteSpace(PrazoChegada) Then
                Call CarregaPrazos()
            End If

            If AssuntoMaiusculo Then
                Assunto = Assunto.ToUpper
            End If

            If ObservacaoMaiusculo Then
                Observacao = Observacao.ToUpper
            End If

            If CodChamadoOriginal Is Nothing Then
                CodChamadoOriginal = "null"
            Else
                If String.IsNullOrWhiteSpace(CodChamadoOriginal) Then
                    CodChamadoOriginal = "null"
                End If
            End If

            If String.IsNullOrWhiteSpace(Contrato) Then
                Contrato = "null"
            Else
                Contrato = "'" + Contrato + "'"
            End If

            If DDataInstalacaoTEF <> Nothing Then
                dbDataInstalacaoTEF = DDataInstalacaoTEF.ToString("yyyy-MM-dd")
                dbDataInstalacaoTEF = "'" + dbDataInstalacaoTEF + "'"
            Else
                dbDataInstalacaoTEF = "null"
            End If

            If DDataLiberacaoOSTEF <> Nothing Then
                dbDataLiberacaoOSTEF = DDataLiberacaoOSTEF.ToString("yyyy-MM-dd")
                dbDataLiberacaoOSTEF = "'" + dbDataLiberacaoOSTEF + "'"
            Else
                dbDataLiberacaoOSTEF = "null"
            End If

            strSql = ""
            strSql += "insert into chamado("
            strSql += "   empresa, "
            strSql += "   estabelecimento, "
            strSql += "   cod_chamado, "
            strSql += "   cod_chamado_original, "
            strSql += "   cod_emitente, "
            strSql += "   cod_contato, "
            strSql += "   cod_analista, "
            strSql += "   tipo_chamado, "
            strSql += "   numero_serie, "
            strSql += "   cod_usuario, "
            strSql += "   cod_status, "
            strSql += "   data_chamado, "
            strSql += "   data_chegada_prevista, "
            strSql += "   data_chegada, "
            strSql += "   data_encerramento_prevista, "
            strSql += "   data_encerramento_prevista_inicio, "
            strSql += "   data_encerramento, "
            strSql += "   assunto, "
            strSql += "   os_cliente, "
            strSql += "   observacao, "
            strSql += "   cnpj, "
            strSql += "   motivo_cancelamento, "
            strSql += "   cod_emitente_atendimento, "
            strSql += "   cnpj_atendimento, "
            strSql += "   numero_ponto_atendimento, "
            strSql += "   prazo_chegada, "
            strSql += "   prazo_encerramento, "
            strSql += "   cod_contato_atendimento, "
            strSql += "   cod_sla, "
            strSql += "   cod_sistema, "
            strSql += "   cod_modulo, "
            strSql += "   caminho_menu, "
            strSql += "   programa, "
            strSql += "   sag,"
            strSql += "   data_inicio_trabalho_tecnico,"
            strSql += "   contrato,"
            strSql += "   intervencao_conjunta,"
            strSql += "   intervencao_conjunta_narrativa,"
            strSql += "   desobrigado_sla,"
            strSql += "   qtd_chamado_dia,"
            strSql += "   qtd_chamado_dia_sla,"
            strSql += "   cod_veiculo, "
            strSql += "   cod_forma_pagamento_os, "
            strSql += "   cod_cond_pagto_os, "
            strSql += "   data_instalacao_tef, "
            strSql += "   data_liberacao_os_tef) "
            strSql += "  values("
            strSql += pEmpresa + ", "
            strSql += pEstabelecimento + ", "
            strSql += pCodChamado + ", "
            strSql += CodChamadoOriginal + ", "
            strSql += CodEmitente + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CodContato), "null", CodContato) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CodAnalista), "null", CodAnalista) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(TipoChamado), "null", TipoChamado) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(NumeroSerie), "null", "'" + NumeroSerie + "'") + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CodUsuario), "null", CodUsuario) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CodStatus), "null", CodStatus) + ", "
            strSql += dbDataChamado + ", "
            strSql += dbDataChegadaPrevista + ", "
            strSql += dbDataChegada + ", "
            strSql += dbDataEncerramentoPrevista + ", "
            strSql += dbDataEncerramentoPrevistaInicio + ", "
            strSql += dbDataEncerramento + ", "
            strSql += "'" + Assunto + "', "
            strSql += "'" + OSCliente.ToUpper + "', "
            strSql += "'" + Observacao + "', "
            strSql += "'" + Cnpj + "', "
            strSql += "'" + MotivoCancelamento + "', "
            strSql += IIf(String.IsNullOrWhiteSpace(CodEmitenteAtendimento), "null", CodEmitenteAtendimento) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CnpjAtendimento), "null", "'" + CnpjAtendimento + "'") + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(NumeroPontoAtendimento), "null", "'" + NumeroPontoAtendimento + "'") + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(PrazoChegada), "null", PrazoChegada.ToString.Replace(",", ".")) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(PrazoEncerramento), "null", PrazoEncerramento.ToString.Replace(",", ".")) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CodContatoAtendimento), "null", CodContatoAtendimento) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CodSla), "null", CodSla) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CodSistema), "null", CodSistema) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CodModulo), "null", CodModulo) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CaminhoMenu), "null", "'" + CaminhoMenu + "'") + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(Programa), "null", "'" + Programa + "'") + ", "
            strSql += "'" + SAG + "', "
            strSql += dbDataInicioTrabalhoTecnico + ", "
            strSql += Contrato + ", "
            strSql += "'" + IIf(String.IsNullOrEmpty(IntervencaoConjunta), "N", IntervencaoConjunta) + "', "
            strSql += "'" + IntervencaoConjuntaNarrativa + "', "
            strSql += IIf(String.IsNullOrWhiteSpace(DesobrigadoSLA), "null", "'" + DesobrigadoSLA + "'") + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(QtdChamadoDia), "null", QtdChamadoDia) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(QtdChamadoDiaSLA), "null", QtdChamadoDiaSLA) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CodVeiculo), "null", CodVeiculo) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CodFormaPagamentoOS) OrElse CodFormaPagamentoOS = "0", "null", CodFormaPagamentoOS) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CodCondPagtoOS) OrElse CodCondPagtoOS = "0", "null", CodCondPagtoOS) + ", "
            strSql += dbDataInstalacaoTEF + ", "
            strSql += dbDataLiberacaoOSTEF + ")"

            objAcessoDados.ExecutarSql(strSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CarregaPrazos()
        Try
            Dim StrSql As String
            Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim dt As DataTable

            PrazoChegada = ""
            PrazoEncerramento = ""

            If String.IsNullOrWhiteSpace(CodEmitente) OrElse String.IsNullOrWhiteSpace(CodEmitenteAtendimento) OrElse String.IsNullOrWhiteSpace(CodSla) OrElse String.IsNullOrWhiteSpace(NumeroPontoAtendimento) Then
                Return
            End If

            objPontoAtendimento.CodEmitente = Me.CodEmitenteAtendimento
            objPontoAtendimento.NumeroPontoAtendimento = Me.NumeroPontoAtendimento
            objPontoAtendimento.Buscar()

            If String.IsNullOrWhiteSpace(objPontoAtendimento.CodPais) OrElse String.IsNullOrWhiteSpace(objPontoAtendimento.CodEstado) OrElse String.IsNullOrWhiteSpace(objPontoAtendimento.CodCidade) Then
                Return
            End If

            StrSql = "call sp_sla_prazos(" + CodEmitente + ", " + objPontoAtendimento.CodPais + ", " + objPontoAtendimento.CodEstado + ", " + objPontoAtendimento.CodCidade + ", " + CodSla + ")"
            dt = objAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                PrazoChegada = dt.Rows.Item(0).Item("prazo_chegada").ToString
                PrazoEncerramento = dt.Rows.Item(0).Item("prazo_encerramento").ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EncerraNegociacoesPendentes(ByVal pEmpresa As String, ByVal pCodChamado As String, ByVal pCodStatus As String)
        Try
            If String.IsNullOrEmpty(pCodChamado) OrElse String.IsNullOrEmpty(pCodStatus) OrElse String.IsNullOrEmpty(pEmpresa) Then
                Return
            End If
            Dim StrSql As String
            Dim dt As DataTable
            StrSql = " select nc.estabelecimento, nc.cod_negociacao_cliente, f.cod_etapa_final_insucesso "
            StrSql += "  from negociacao_cliente nc inner join funil_venda f on f.empresa = nc.empresa and f.cod_funil = nc.cod_funil "
            StrSql += "                             inner join etapa_negociacao e on e.empresa = nc.empresa and e.cod_etapa = nc.cod_etapa "
            StrSql += "                             inner join status_chamado sc on sc.cod_status = " + pCodStatus
            StrSql += " where nc.empresa     = " + pEmpresa
            StrSql += "   and nc.cod_chamado = " + pCodChamado
            StrSql += "   and e.status      in (1,2) "
            StrSql += "   and f.cod_etapa_final_insucesso is not null "
            StrSql += "   and sc.tipo       in (3)"
            dt = objAcessoDados.BuscarDados(StrSql)
            For Each row As DataRow In dt.Rows
                Dim negociacao As New UCLNegociacao(StrConexao)
                negociacao.Empresa = pEmpresa
                negociacao.Estabelecimento = row.Item("estabelecimento")
                negociacao.CodNegociacao = row.Item("cod_negociacao_cliente")
                If negociacao.Buscar().Rows.Count > 0 Then
                    negociacao.CodEtapaNegociacao = row.Item("cod_etapa_final_insucesso").ToString
                    negociacao.Alterar()
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodChamado As String)
        Try
            Dim strSql As String
            Dim dbDataChamado As String
            Dim dbDataEncerramentoPrevista As String
            Dim dbDataChegadaPrevista As String
            Dim dbDataChegada As String
            Dim dbDataEncerramentoPrevistaInicio As String
            Dim dbDataEncerramento As String
            Dim dbDataInicioTrabalhoTecnico As String
            Dim dbDataInstalacaoTEF As String
            Dim dbDataLiberacaoOSTEF As String

            If DDataInicioTrabalhoTecnico <> Nothing Then
                dbDataInicioTrabalhoTecnico = DDataInicioTrabalhoTecnico.ToString("yyyy-MM-dd")
                If Not String.IsNullOrWhiteSpace(HoraInicioTrabalhoTecnico) Then
                    dbDataInicioTrabalhoTecnico += " " + HoraInicioTrabalhoTecnico + ":00"
                End If
                dbDataInicioTrabalhoTecnico = "'" + dbDataInicioTrabalhoTecnico + "'"
            Else
                dbDataInicioTrabalhoTecnico = "null"
            End If

            If DDataChamado <> Nothing Then
                dbDataChamado = DDataChamado.ToString("yyyy-MM-dd")
                If Not String.IsNullOrWhiteSpace(HoraChamado) Then
                    dbDataChamado += " " + HoraChamado + ":00"
                End If
                dbDataChamado = "'" + dbDataChamado + "'"
            Else
                dbDataChamado = "null"
            End If

            If DDataChegadaPrevista <> Nothing Then
                dbDataChegadaPrevista = DDataChegadaPrevista.ToString("yyyy-MM-dd")
                If Not String.IsNullOrWhiteSpace(HoraChegadaPrevista) Then
                    dbDataChegadaPrevista += " " + HoraChegadaPrevista + ":00"
                End If
                dbDataChegadaPrevista = "'" + dbDataChegadaPrevista + "'"
            Else
                dbDataChegadaPrevista = "null"
            End If

            If DDataChegada <> Nothing Then
                dbDataChegada = DDataChegada.ToString("yyyy-MM-dd")
                If Not String.IsNullOrWhiteSpace(HoraChegada) Then
                    dbDataChegada += " " + HoraChegada + ":00"
                End If
                dbDataChegada = "'" + dbDataChegada + "'"
            Else
                dbDataChegada = "null"
            End If

            If DDataEncerramentoPrevista <> Nothing AndAlso DataEncerramentoPrevista <> "" Then
                dbDataEncerramentoPrevista = DDataEncerramentoPrevista.ToString("yyyy-MM-dd")
                If Not String.IsNullOrWhiteSpace(HoraEncerramentoPrevista) Then
                    dbDataEncerramentoPrevista += " " + HoraEncerramentoPrevista + ":00"
                End If
                dbDataEncerramentoPrevista = "'" + dbDataEncerramentoPrevista + "'"
            Else
                dbDataEncerramentoPrevista = "null"
            End If

            If DDataEncerramentoPrevistaInicio <> Nothing AndAlso DataEncerramentoPrevistaInicio <> "" Then
                dbDataEncerramentoPrevistaInicio = DDataEncerramentoPrevistaInicio.ToString("yyyy-MM-dd")
                If Not String.IsNullOrWhiteSpace(HoraEncerramentoPrevistaInicio) Then
                    dbDataEncerramentoPrevistaInicio += " " + HoraEncerramentoPrevistaInicio + ":00"
                End If
                dbDataEncerramentoPrevistaInicio = "'" + dbDataEncerramentoPrevistaInicio + "'"
            Else
                dbDataEncerramentoPrevistaInicio = "null"
            End If

            If DDataEncerramento <> Nothing Then
                dbDataEncerramento = DDataEncerramento.ToString("yyyy-MM-dd")
                If Not String.IsNullOrWhiteSpace(HoraEncerramento) Then
                    dbDataEncerramento += " " + HoraEncerramento + ":00"
                End If
                dbDataEncerramento = "'" + dbDataEncerramento + "'"
            Else
                dbDataEncerramento = "null"
            End If

            If String.IsNullOrWhiteSpace(PrazoChegada) Then
                Call CarregaPrazos()
            End If

            If AssuntoMaiusculo Then
                Assunto = Assunto.ToUpper
            End If

            If ObservacaoMaiusculo Then
                Observacao = Observacao.ToUpper
            End If

            If CodChamadoOriginal Is Nothing Then
                CodChamadoOriginal = "null"
            Else
                If String.IsNullOrWhiteSpace(CodChamadoOriginal) Then
                    CodChamadoOriginal = "null"
                End If
            End If

            If String.IsNullOrWhiteSpace(Contrato) Then
                Contrato = "null"
            Else
                Contrato = "'" + Contrato + "'"
            End If

            If DDataInstalacaoTEF <> Nothing Then
                dbDataInstalacaoTEF = DDataInstalacaoTEF.ToString("yyyy-MM-dd")
                dbDataInstalacaoTEF = "'" + dbDataInstalacaoTEF + "'"
            Else
                dbDataInstalacaoTEF = "null"
            End If

            If DDataLiberacaoOSTEF <> Nothing Then
                dbDataLiberacaoOSTEF = DDataLiberacaoOSTEF.ToString("yyyy-MM-dd")
                dbDataLiberacaoOSTEF = "'" + dbDataLiberacaoOSTEF + "'"
            Else
                dbDataLiberacaoOSTEF = "null"
            End If

            strSql = ""
            strSql += "update chamado"
            strSql += "   set cod_emitente               = " + CodEmitente + ", "
            strSql += "       estabelecimento            = " + pEstabelecimento + ", "
            strSql += "       cod_chamado_original       = " + CodChamadoOriginal + ", "
            strSql += "       cod_contato                = " + IIf(String.IsNullOrWhiteSpace(CodContato), "null", CodContato) + ", "
            strSql += "       cod_analista               = " + IIf(String.IsNullOrWhiteSpace(CodAnalista), "null", CodAnalista) + ", "
            strSql += "       tipo_chamado               = " + IIf(String.IsNullOrWhiteSpace(TipoChamado), "null", TipoChamado) + ", "
            strSql += "       numero_serie               = " + IIf(String.IsNullOrWhiteSpace(NumeroSerie), "null", "'" + NumeroSerie + "'") + ", "
            strSql += "       cod_status                 = " + IIf(String.IsNullOrWhiteSpace(CodStatus), "null", CodStatus) + ", "
            strSql += "       data_chamado               = " + dbDataChamado + ", "
            strSql += "       data_encerramento_prevista = " + dbDataEncerramentoPrevista + ", "
            strSql += "       data_chegada_prevista      = " + dbDataChegadaPrevista + ", "
            strSql += "       data_chegada               = " + dbDataChegada + ", "
            strSql += "       data_inicio_trabalho_tecnico      = " + dbDataInicioTrabalhoTecnico + ", "
            strSql += "       data_encerramento_prevista_inicio = " + dbDataEncerramentoPrevistaInicio + ", "
            strSql += "       data_encerramento          = " + dbDataEncerramento + ", "
            strSql += "       assunto                    = '" + Assunto + "', "
            strSql += "       os_cliente                 = '" + OSCliente.ToUpper + "', "
            strSql += "       observacao                 = '" + Observacao + "', "
            strSql += "       cnpj                       = '" + Cnpj + "', "
            strSql += "       motivo_cancelamento        = '" + MotivoCancelamento + "', "
            strSql += "       numero_ponto_atendimento   = " + IIf(String.IsNullOrWhiteSpace(NumeroPontoAtendimento), "null", "'" + NumeroPontoAtendimento + "'") + ", "
            strSql += "       cod_emitente_atendimento   = " + IIf(String.IsNullOrWhiteSpace(CodEmitenteAtendimento), "null", CodEmitenteAtendimento) + ", "
            strSql += "       cnpj_atendimento           = " + IIf(String.IsNullOrWhiteSpace(CnpjAtendimento), "null", "'" + CnpjAtendimento + "'") + ", "
            strSql += "       cod_contato_atendimento    = " + IIf(String.IsNullOrWhiteSpace(CodContatoAtendimento), "null", CodContatoAtendimento) + ", "
            strSql += "       prazo_chegada              = " + IIf(String.IsNullOrWhiteSpace(PrazoChegada), "null", PrazoChegada.ToString.Replace(",", ".")) + ", "
            strSql += "       prazo_encerramento         = " + IIf(String.IsNullOrWhiteSpace(PrazoEncerramento), "null", PrazoEncerramento.ToString.Replace(",", ".")) + ", "
            strSql += "       cod_sla                    = " + IIf(String.IsNullOrWhiteSpace(CodSla), "null", CodSla) + ", "
            strSql += "       cod_sistema                = " + IIf(String.IsNullOrWhiteSpace(CodSistema), "null", CodSistema) + ", "
            strSql += "       cod_modulo                     = " + IIf(String.IsNullOrWhiteSpace(CodModulo), "null", CodModulo) + ", "
            strSql += "       caminho_menu                   = " + IIf(String.IsNullOrWhiteSpace(CaminhoMenu), "null", "'" + CaminhoMenu + "'") + ", "
            strSql += "       programa                       = " + IIf(String.IsNullOrWhiteSpace(Programa), "null", "'" + Programa + "'") + ", "
            strSql += "       intervencao_conjunta           = '" + IIf(String.IsNullOrEmpty(IntervencaoConjunta), "N", IntervencaoConjunta) + "', "
            strSql += "       intervencao_conjunta_narrativa = '" + IntervencaoConjuntaNarrativa + "', "
            strSql += "       desobrigado_sla                = " + IIf(String.IsNullOrWhiteSpace(DesobrigadoSLA), "null", "'" + DesobrigadoSLA + "'") + ", "
            strSql += "       qtd_chamado_dia                = " + IIf(String.IsNullOrWhiteSpace(QtdChamadoDia), "null", QtdChamadoDia) + ", "
            strSql += "       qtd_chamado_dia_sla            = " + IIf(String.IsNullOrWhiteSpace(QtdChamadoDiaSLA), "null", QtdChamadoDiaSLA) + ", "
            strSql += "       sag                            = '" + SAG + "',"
            strSql += "       contrato                       = " + Contrato + ", "
            strSql += "       cod_veiculo                    = " + IIf(String.IsNullOrWhiteSpace(CodVeiculo), "null", CodVeiculo) + ", "
            strSql += "       data_liberacao_os_tef          = " + dbDataLiberacaoOSTEF + ", "
            strSql += "       data_instalacao_tef            = " + dbDataInstalacaoTEF
            strSql += " where empresa     = " + pEmpresa
            strSql += "   and cod_chamado = " + pCodChamado
            objAcessoDados.ExecutarSql(strSql)

            Contrato = Contrato.Replace("'", "")

            Call EncerraNegociacoesPendentes(pEmpresa, pCodChamado, CodStatus)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql As String = "select f_gera_sysseq( " + Empresa.ToString() + " , 39, 1) max from dummy"
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Function EnviaEmailStatus(ByVal StrConn As String, ByVal pEmpresa As String, ByVal pCodChamado As String) As String
        Try
            Dim strSql As String = "select f_email_chamado_cabecalho( " + pEmpresa + ", " + pCodChamado + " ) ret from dummy"
            Dim retorno As String = objAcessoDados.BuscarDadosComTransacao(strSql, StrConn)
            Return retorno
        Catch ex As Exception
            GravaLog("UCLAtendimento: EnviaEmailStatus() " + vbCr + vbLf + ex.ToString)
            Throw ex
        End Try
    End Function

    Public Function EnviaEmailConsumoHoras(ByVal StrConn As String, ByVal pEmpresa As String, ByVal pCodChamado As String) As String
        Try
            Dim strSql As String = "select f_email_chamado_confirmacao_horas( " + pEmpresa + ", " + pCodChamado + " ) ret from dummy"
            Dim retorno As String = objAcessoDados.BuscarDadosComTransacao(strSql, StrConn)
            Return retorno
        Catch ex As Exception
            GravaLog("UCLAtendimento: EnviaEmailConsumoHoras() " + vbCr + vbLf + ex.ToString)
            Throw ex
        End Try
    End Function

    Public Function ExistemOSsAbertas() As Boolean
        Try
            Dim strSql As String
            Dim dt As DataTable

            strSql = " select count(1) qtd "
            strSql += "  from pedido_venda "
            strSql += " where empresa         = " + Empresa
            strSql += "   and cod_chamado     = " + CodChamado
            strSql += "   and status_digitacao = 1 "

            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                If dt.Rows.Item(0).Item("qtd") > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetNumeroChamado(ByVal pEmpresa As String, ByVal pCodCliente As String, ByVal pOsCliente As String) As String
        Try
            Dim strSql As String = "select cod_chamado from chamado where empresa = " + pEmpresa + " and os_cliente = '" + pOsCliente + "' and cod_emitente = " + pCodCliente
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            Dim ret As String = ""
            If dt.Rows.Count > 0 Then
                ret = dt.Rows.Item(0).Item("cod_chamado").ToString
            End If
            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TemOS() As Boolean
        Try
            Dim strSql As String = "select count(1) qtd from pedido_venda where empresa = " + Empresa + " and cod_chamado = " + CodChamado + " and status_digitacao in (1,2) "
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            Dim qtd As Long

            If dt.Rows.Count > 0 Then
                qtd = dt.Rows.Item(0).Item("qtd").ToString
                If qtd > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetOSsChamado(pEmpresa As String, pEstabelecimento As String, pCodChamado As String) As List(Of String)
        Try
            Dim ret As New List(Of String)
            Dim StrSql As String = "select cod_pedido_venda from pedido_venda where isnull(id_os,'N') = 'S' and empresa = " + pEmpresa + " and estabelecimento = " + pEstabelecimento + " and isnull(cod_chamado,0) = " + pCodChamado
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
            For Each row As DataRow In dt.Rows
                ret.Add(row.Item("cod_pedido_venda"))
            Next
            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function OSLiberadaFinanceiro(pEmpresa As String, pEstabelecimento As String, pCodPedidoVenda As String) As String
        Try
            Dim StrSql As String = "select f_pedido_liberado_financeiro( " + pEmpresa + ", " + pEstabelecimento + ", " + pCodPedidoVenda + " ) msg from dummy "
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
            Dim ret As String
            If dt.Rows.Count > 0 Then
                ret = dt.Rows.Item(0).Item("msg").ToString
            Else
                ret = ""
            End If
            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function OSEmFechamento(pEmpresa As String, pEstabelecimento As String, pCodPedidoVenda As String) As String
        Try
            Dim StrSql As String = "select f_pedido_em_fechamento( " + pEmpresa + ", " + pEstabelecimento + ", " + pCodPedidoVenda + " ) msg from dummy "
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
            Dim ret As String
            If dt.Rows.Count > 0 Then
                ret = dt.Rows.Item(0).Item("msg").ToString
            Else
                ret = ""
            End If
            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub TransferirOSs(ByVal pEmpresa As String, ByVal pCodChamadoOrigem As String, ByVal pCodChamadoDestino As String)
        Try
            Dim StrSql As String = "call sp_sysvar; call sp_transfere_os_chamado(" + pEmpresa + ", " + pCodChamadoOrigem + ", " + pCodChamadoDestino + ")"
            objAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetListaAnexosParaSolicitacao(ByVal pCodSolicitacao As String) As List(Of String)
        Try
            Dim ret As New List(Of String)
            Dim strSql As String
            Dim dt As DataTable

            strSql = "select arquivo from follow_up_chamado_anexo where empresa = " + Empresa + " and cod_chamado = " + CodChamado + " order by seq_follow_up, seq_anexo"
            dt = objAcessoDados.BuscarDados(strSql)

            For Each row As DataRow In dt.Rows
                ret.Add(row.Item("arquivo"))
            Next

            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub CopiaAnexos(ByVal pCodSolicitacao As String)
        Try
            Dim Arquivos As List(Of String) = GetListaAnexosParaSolicitacao(pCodSolicitacao)
            Dim n As Long = 0

            For Each Arquivo As String In Arquivos
                n += 1
                File.Copy(CaminhoFisicoAnexoChamado + Arquivo, "C:\Inetpub\wwwroot\" + DirVirtual + "Arquivos\AnexoSolicitacaoDesenvolvimento\" + pCodSolicitacao + "_" + n.ToString + "_" + Arquivo)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GeraSolicitacaoDesenvolvimento(ByVal StrConn As String) As Boolean
        Try
            Dim StrSql As String = "select f_gera_solicitacao_desenvolvimento(" + IIf(String.IsNullOrWhiteSpace(Empresa), "0", Empresa) + ", " + IIf(String.IsNullOrWhiteSpace(Estabelecimento), "0", Estabelecimento) + ", " + IIf(String.IsNullOrWhiteSpace(CodChamado), "0", CodChamado) + ")"
            Dim retorno As String = objAcessoDados.BuscarDadosComTransacao(StrSql, StrConn)
            Dim lCodSolicitacao As String

            If IsNumeric(retorno) Then
                lCodSolicitacao = retorno
                Call CopiaAnexos(lCodSolicitacao)
                Return True
            Else
                Throw New Exception(retorno)
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function QtdOSAlemDesta(ByVal NrDestaOs As String) As Long
        Try
            Dim strSql As String = "select count(1) qtd from pedido_venda where empresa = " + Empresa + " and cod_chamado = " + CodChamado + " and cod_pedido_venda <> " + NrDestaOs
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            Dim qtd As Long

            If dt.Rows.Count > 0 Then
                qtd = dt.Rows.Item(0).Item("qtd").ToString
                Return qtd
            Else
                Return 0
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetFollowUps(ByVal pEmpresa As String, ByVal pCodChamado As String) As List(Of UCLAtendimentoFollowUp)
        Try
            Dim f As New List(Of UCLAtendimentoFollowUp)
            Dim strSql As String = "select empresa, cod_chamado, seq_follow_up from follow_up_chamado where empresa = " + pEmpresa + " and cod_chamado = " + pCodChamado + " order by seq_follow_up"
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            For Each row As DataRow In dt.Rows
                Dim objAtendimentoFollowUp As New UCLAtendimentoFollowUp(StrConexao)
                objAtendimentoFollowUp.Empresa = row.Item("empresa")
                objAtendimentoFollowUp.CodChamado = row.Item("cod_chamado")
                objAtendimentoFollowUp.SeqFollowUP = row.Item("seq_follow_up")
                objAtendimentoFollowUp.Buscar()
                f.Add(objAtendimentoFollowUp)
            Next
            Return f
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
