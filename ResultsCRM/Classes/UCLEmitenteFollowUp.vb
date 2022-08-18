Public Class UCLEmitenteFollowUp
    Private objAcessoDados As UCLAcessoDados
    Private _Empresa As String
    Private _CodEmitente As String
    Private _SeqFollowUP As String
    Private _CodUsuario As String
    Private _Descricao As String
    Private _DataFollowUp As String
    Private _DDataFollowUp As Date
    Private _HoraFollowUp As String
    Private _Estabelecimento As String
    Private _Tipo As String

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
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

    Public Property SeqFollowUP() As String
        Get
            Return _SeqFollowUP
        End Get
        Set(ByVal value As String)
            _SeqFollowUP = value
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

    Public Property Descricao() As String
        Get
            Return _Descricao
        End Get
        Set(ByVal value As String)
            _Descricao = value
        End Set
    End Property

    Public Property DataFollowUp() As String
        Get
            Return _DataFollowUp
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataFollowUp = CDate(value)
            End If
            _DataFollowUp = value
        End Set
    End Property

    Public Property DDataFollowUp() As Date
        Get
            Return _DDataFollowUp
        End Get
        Set(ByVal value As Date)
            _DDataFollowUp = value
        End Set
    End Property

    Public Property HoraFollowUp() As String
        Get
            Return _HoraFollowUp
        End Get
        Set(ByVal value As String)
            _HoraFollowUp = value
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

    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Public Sub New(ByVal ConnectString As String)
        objAcessoDados = New UCLAcessoDados(ConnectString)
    End Sub

    Public Function Buscar() As DataTable
        Dim StrSql As String
        Dim dt As DataTable

        StrSql = " select * "
        StrSql += "  from follow_up_emitente "
        StrSql += " where empresa       = " + Empresa
        StrSql += "   and cod_emitente  = " + CodEmitente
        StrSql += "   and seq_follow_up = " + SeqFollowUP

        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            CodUsuario = dt.Rows.Item(0).Item("cod_usuario").ToString
            If IsDBNull(dt.Rows.Item(0).Item("data_follow_up")) Then
                DataFollowUp = ""
                HoraFollowUp = ""
            Else
                DataFollowUp = CType(dt.Rows.Item(0).Item("data_follow_up"), Date).ToString("dd/MM/yyyy")
                HoraFollowUp = dt.Rows.Item(0).Item("hora_follow_up").ToString
            End If
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            Estabelecimento = dt.Rows.Item(0).Item("estabelecimento").ToString
            Tipo = dt.Rows.Item(0).Item("tipo").ToString
        End If

        Return dt
    End Function

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = ""

        strSql = " select isnull(max(seq_follow_up),0) + 1 max  "
        strSql += "  from follow_up_emitente"
        strSql += " where empresa     = " + Empresa

        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Sub Incluir()
        Dim strSql As String = ""
        Dim dbDataFollowUp As String
        Try

            If DDataFollowUp = Nothing Then
                dbDataFollowUp = "null"
            Else
                dbDataFollowUp = DDataFollowUp.ToString("yyyy-MM-dd")
                dbDataFollowUp = "'" + dbDataFollowUp + "'"
            End If

            strSql = " insert into follow_up_emitente (empresa, cod_emitente, seq_follow_up, cod_usuario, data_follow_up, hora_follow_up, descricao, estabelecimento, tipo) "
            strSql += " values ( " + Empresa + ", " + CodEmitente + "," + SeqFollowUP + ", " + CodUsuario + ", " + dbDataFollowUp + ", '" + HoraFollowUp + "', '" + Descricao + "', '" + Estabelecimento + "', '" + Tipo + "')"

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Dim dbDataFollowUp As String
        Try

            If DDataFollowUp = Nothing Then
                dbDataFollowUp = "null"
            Else
                dbDataFollowUp = DDataFollowUp.ToString("yyyy-MM-dd")
                dbDataFollowUp = "'" + dbDataFollowUp + "'"
            End If

            strSql += " update follow_up_emitente "
            strSql += "    set data_follow_up = " + dbDataFollowUp + ", "
            strSql += "        hora_follow_up = '" + HoraFollowUp + "', "
            strSql += "        descricao = '" + Descricao + "', "
            strSql += "        estabelecimento = '" + Estabelecimento + "', "
            strSql += "        tipo = '" + Tipo + "'"
            strSql += "  where empresa = " + Empresa
            strSql += "    and cod_emitente = " + CodEmitente
            strSql += "    and seq_follow_up = " + SeqFollowUP

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
