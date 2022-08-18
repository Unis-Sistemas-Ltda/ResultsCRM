Public Class UCLSLAEmitente

    Private _CodSLA As String
    Private _CodEmitente As String
    Private _PrazoChegada As String
    Private _PrazoEncerramento As String
    Private _QtdChamadoDia As String
    Private objAcessoDados As UCLAcessoDados

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
    Public Property QtdChamadoDia As String
        Get
            Return _QtdChamadoDia
        End Get
        Set(ByVal value As String)
            _QtdChamadoDia = value
        End Set
    End Property

    Public Sub Incluir()
        Dim strSql As String = ""
        Try
            PrazoChegada = IIf(String.IsNullOrEmpty(PrazoChegada), "null", PrazoChegada)
            PrazoChegada = PrazoChegada.Replace(",", ".")

            PrazoEncerramento = IIf(String.IsNullOrEmpty(PrazoEncerramento), "null", PrazoEncerramento)
            PrazoEncerramento = PrazoEncerramento.Replace(",", ".")

            QtdChamadoDia = IIf(String.IsNullOrEmpty(QtdChamadoDia), "null", QtdChamadoDia)
            QtdChamadoDia = QtdChamadoDia.Replace(",", ".")

            strSql += " insert into sla_emitente (cod_sla, cod_emitente, prazo_chegada, prazo_encerramento, qtd_chamado_dia) "
            strSql += " values ( " + CodSLA + ", '" + CodEmitente + "', " + PrazoChegada + ", " + PrazoEncerramento + ", " + QtdChamadoDia + ") "

            objAcessoDados.ExecutarSql(strSql)
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

            QtdChamadoDia = IIf(String.IsNullOrEmpty(QtdChamadoDia), "null", QtdChamadoDia)
            QtdChamadoDia = QtdChamadoDia.Replace(",", ".")

            strSql += " update sla_emitente set prazo_chegada = " + PrazoChegada + ", prazo_encerramento = " + PrazoEncerramento + ", qtd_chamado_dia = " + QtdChamadoDia
            strSql += "  where cod_sla      = " + CodSLA
            strSql += "    and cod_emitente = " + CodEmitente

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Dim strSql As String = ""
        Try
            strSql += " delete from sla_emitente_cidade "
            strSql += "  where cod_sla      = " + CodSLA
            strSql += "    and cod_emitente = " + CodEmitente + ";"

            strSql += " delete from sla_emitente_estado "
            strSql += "  where cod_sla      = " + CodSLA
            strSql += "    and cod_emitente = " + CodEmitente + ";"

            strSql += " delete from sla_emitente "
            strSql += "  where cod_sla      = " + CodSLA
            strSql += "    and cod_emitente = " + CodEmitente + ";"

            objAcessoDados.ExecutarSql(strSql)
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

        StrSql += " select prazo_chegada, prazo_encerramento, qtd_chamado_dia "
        StrSql += "   from sla_emitente "
        StrSql += "  where cod_sla      = " + CodSLA
        StrSql += "    and cod_emitente = " + CodEmitente
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            PrazoChegada = dt.Rows.Item(0).Item("prazo_chegada").ToString
            PrazoEncerramento = dt.Rows.Item(0).Item("prazo_encerramento").ToString
            QtdChamadoDia = dt.Rows.Item(0).Item("qtd_chamado_dia").ToString
            Return True
        Else
            Return False
        End If

    End Function

End Class
