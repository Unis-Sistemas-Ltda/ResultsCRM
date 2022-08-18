Public Class UCLNegociacaoMotivoFechamento

    Private _Empresa As String
    Private _Estabelecimento As String
    Private _CodNegociacao As String
    Private _CodMotivo As String
    Private objAcessoDados As UCLAcessoDados

    Public Property CodNegociacao() As String
        Get
            Return _CodNegociacao
        End Get
        Set(ByVal value As String)
            _CodNegociacao = value
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

    Public Property CodMotivo() As String
        Get
            Return _CodMotivo
        End Get
        Set(ByVal value As String)
            _CodMotivo = value
        End Set
    End Property

    Public Sub New(ByVal StrConn As String)
        objAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Function Existe() As Boolean
        Dim strSql As String = ""
        Dim dt As DataTable

        Try
            strSql += " select cod_motivo "
            strSql += "   from negociacao_cliente_motivo_fechamento "
            strSql += "  where ni.empresa = " + Empresa
            strSql += "    and ni.estabelecimento = " + Estabelecimento
            strSql += "    and ni.cod_negociacao_cliente = " + CodNegociacao
            strSql += "    and ni.seq_item = " + CodMotivo
            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                Existe = True
            Else
                Existe = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Existe
    End Function

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            strSql += " insert into negociacao_cliente_motivo_fechamento( "
            strSql += "    empresa, "
            strSql += "    estabelecimento, "
            strSql += "    cod_negociacao_cliente, "
            strSql += "    cod_motivo) values ("
            strSql += Empresa + ", "
            strSql += Estabelecimento + ", "
            strSql += CodNegociacao + ", "
            strSql += CodMotivo + ")"
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Excluir()
        Dim strSql As String = ""

        Try
            strSql += " delete from negociacao_cliente_motivo_fechamento "
            strSql += "  where empresa = " + Empresa + " and estabelecimento = " + Estabelecimento + " and cod_negociacao_cliente = " + CodNegociacao + " and cod_motivo = " + CodMotivo
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub



End Class
