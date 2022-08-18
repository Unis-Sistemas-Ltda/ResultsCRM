Public Class UCLSLAEmitenteRegiao

    Private _CodSLA As String
    Private _CodEmitente As String
    Private _CodPais As String
    Private _CodEstado As String
    Private _CodRegiao As String
    Private _NomeRegiao As String
    Private _PrazoChegada As String
    Private _PrazoEncerramento As String
    Private _Cidades As List(Of UCLSLAEmitenteRegiaoCidade)
    Private objAcessoDados As UCLAcessoDados

    Public Property Cidades As List(Of UCLSLAEmitenteRegiaoCidade)
        Get
            Return _Cidades
        End Get
        Set(ByVal value As List(Of UCLSLAEmitenteRegiaoCidade))
            _Cidades = value
        End Set
    End Property

    Public Property CodSLA() As String
        Get
            Return _CodSLA
        End Get
        Set(ByVal value As String)
            _CodSLA = value
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

    Public Property PrazoChegada As String
        Get
            Return _PrazoChegada
        End Get
        Set(ByVal value As String)
            _PrazoChegada = value
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

    Public Property CodPais As String
        Get
            Return _CodPais
        End Get
        Set(ByVal value As String)
            _CodPais = value
        End Set
    End Property

    Public Property CodEstado As String
        Get
            Return _CodEstado
        End Get
        Set(ByVal value As String)
            _CodEstado = value
        End Set
    End Property

    Public Property CodRegiao As String
        Get
            Return _CodRegiao
        End Get
        Set(ByVal value As String)
            _CodRegiao = value
        End Set
    End Property

    Public Property NomeRegiao As String
        Get
            Return _NomeRegiao
        End Get
        Set(ByVal value As String)
            _NomeRegiao = value
        End Set
    End Property

    Public Sub Incluir()
        Dim strSql As String = ""
        Try
            PrazoChegada = IIf(String.IsNullOrEmpty(PrazoChegada), "null", PrazoChegada)
            PrazoChegada = PrazoChegada.Replace(",", ".")

            PrazoEncerramento = IIf(String.IsNullOrEmpty(PrazoEncerramento), "null", PrazoEncerramento)
            PrazoEncerramento = PrazoEncerramento.Replace(",", ".")

            strSql += " insert into sla_emitente_regiao (cod_sla, cod_emitente, cod_pais, cod_estado, cod_regiao, nome, prazo_chegada, prazo_encerramento) "
            strSql += " values ( " + CodSLA + ", " + CodEmitente + ", " + CodPais + ", " + CodEstado + ", " + CodRegiao + ", '" + NomeRegiao + "', " + PrazoChegada + ", " + PrazoEncerramento + ") "

            objAcessoDados.ExecutarSql(strSql)

            Call AtualizaListaCidades()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Try

            PrazoChegada = IIf(String.IsNullOrEmpty(PrazoChegada), "null", PrazoChegada)
            PrazoChegada = PrazoChegada.Replace(",", ".")

            PrazoEncerramento = IIf(String.IsNullOrEmpty(PrazoEncerramento), "null", PrazoEncerramento)
            PrazoEncerramento = PrazoEncerramento.Replace(",", ".")

            strSql += " update sla_emitente_regiao set prazo_chegada = " + PrazoChegada + ", prazo_encerramento = " + PrazoEncerramento + ", nome = '" + NomeRegiao + "' "
            strSql += "  where cod_sla      = " + CodSLA
            strSql += "    and cod_emitente = " + CodEmitente
            strSql += "    and cod_pais     = " + CodPais
            strSql += "    and cod_estado   = " + CodEstado
            strSql += "    and cod_regiao   = " + CodRegiao

            objAcessoDados.ExecutarSql(strSql)

            Call AtualizaListaCidades()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select prazo_chegada, prazo_encerramento, nome "
        StrSql += "   from sla_emitente_regiao "
        StrSql += "  where cod_sla      = " + CodSLA
        StrSql += "    and cod_emitente = " + CodEmitente
        StrSql += "    and cod_pais     = " + CodPais
        StrSql += "    and cod_estado   = " + CodEstado
        StrSql += "    and cod_regiao   = " + CodRegiao
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            PrazoChegada = dt.Rows.Item(0).Item("prazo_chegada").ToString
            PrazoEncerramento = dt.Rows.Item(0).Item("prazo_encerramento").ToString
            NomeRegiao = dt.Rows.Item(0).Item("nome").ToString

            Call ObterListaCidades()

            Return True
        Else
            Return False
        End If

    End Function

    Public Sub Excluir()
        Dim strSql As String = ""
        Try
            strSql += " delete from sla_emitente_regiao_cidade "
            strSql += "  where cod_sla      = " + CodSLA
            strSql += "    and cod_emitente = " + CodEmitente
            strSql += "    and cod_pais     = " + CodPais
            strSql += "    and cod_estado   = " + CodEstado
            strSql += "    and cod_regiao   = " + CodRegiao + "; "

            strSql += " delete from sla_emitente_regiao "
            strSql += "  where cod_sla      = " + CodSLA
            strSql += "    and cod_emitente = " + CodEmitente
            strSql += "    and cod_pais     = " + CodPais
            strSql += "    and cod_estado   = " + CodEstado
            strSql += "    and cod_regiao   = " + CodRegiao + "; "

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub AtualizaListaCidades()
        Try
            Dim strSql As String
            strSql = ""
            strSql += " delete from sla_emitente_regiao_cidade "
            strSql += "  where cod_sla      = " + CodSLA
            strSql += "    and cod_emitente = " + CodEmitente
            strSql += "    and cod_pais     = " + CodPais
            strSql += "    and cod_estado   = " + CodEstado
            strSql += "    and cod_regiao   = " + CodRegiao + "; "
            objAcessoDados.ExecutarSql(strSql)

            For Each objSLAEmitenteRegiaoCidade As UCLSLAEmitenteRegiaoCidade In Cidades
                objSLAEmitenteRegiaoCidade.Incluir()
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ObterListaCidades()
        Try
            Dim objSLAEmitenteRegiaoCidade As UCLSLAEmitenteRegiaoCidade
            Dim strSql As String
            Dim dt As DataTable
            Dim cids As New List(Of UCLSLAEmitenteRegiaoCidade)

            strSql = " select a.cod_cidade cod_cidade "
            strSql += "  from sla_emitente_regiao_cidade a inner join cidade c on a.cod_pais = c.cod_pais and a.cod_estado = c.cod_estado and a.cod_cidade = c.cod_cidade where a.cod_sla = " + Me.CodSLA + " and a.cod_emitente = " + Me.CodEmitente + " and a.cod_pais = " + Me.CodPais + " and a.cod_estado = " + Me.CodEstado + " and a.cod_regiao = " + Me.CodRegiao + " order by c.nome_cidade "
            dt = objAcessoDados.BuscarDados(strSql)

            For Each row As DataRow In dt.Rows
                objSLAEmitenteRegiaoCidade = New UCLSLAEmitenteRegiaoCidade
                objSLAEmitenteRegiaoCidade.CodSLA = Me.CodSLA
                objSLAEmitenteRegiaoCidade.CodEmitente = Me.CodEmitente
                objSLAEmitenteRegiaoCidade.CodPais = Me.CodPais
                objSLAEmitenteRegiaoCidade.CodEstado = Me.CodEstado
                objSLAEmitenteRegiaoCidade.CodRegiao = Me.CodRegiao
                objSLAEmitenteRegiaoCidade.CodCidade = row.Item("cod_cidade")
                cids.Add(objSLAEmitenteRegiaoCidade)
            Next

            Cidades = cids

        Catch ex As Exception
            Throw ex
        End Try
        
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = ""
        Dim dt As DataTable
        Try
            strSql += " select isnull(max(cod_regiao),0) + 1 max from sla_emitente_regiao "
            strSql += "  where cod_sla      = " + CodSLA
            strSql += "    and cod_emitente = " + CodEmitente
            strSql += "    and cod_pais     = " + CodPais
            strSql += "    and cod_estado   = " + CodEstado

            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                ret = dt.Rows.Item(0).Item("max").ToString
            End If
            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
