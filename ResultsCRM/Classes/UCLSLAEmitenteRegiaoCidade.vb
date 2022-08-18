Public Class UCLSLAEmitenteRegiaoCidade

    Private _CodSLA As String
    Private _CodEmitente As String
    Private _CodPais As String
    Private _CodEstado As String
    Private _CodRegiao As String
    Private _CodCidade As String
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

    Public Property CodCidade As String
        Get
            Return _CodCidade
        End Get
        Set(ByVal value As String)
            _CodCidade = value
        End Set
    End Property

    Public Sub Incluir()
        Dim strSql As String = ""
        Try
            
            strSql += " insert into sla_emitente_regiao_cidade (cod_sla, cod_emitente, cod_pais, cod_estado, cod_regiao, cod_cidade) "
            strSql += " values ( " + CodSLA + ", " + CodEmitente + ", " + CodPais + ", " + CodEstado + ", " + CodRegiao + ", " + CodCidade + ") "

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Existe() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select 1 "
        StrSql += "   from sla_emitente_regiao_cidade "
        StrSql += "  where cod_sla      = " + CodSLA
        StrSql += "    and cod_emitente = " + CodEmitente
        StrSql += "    and cod_pais     = " + CodPais
        StrSql += "    and cod_estado   = " + CodEstado
        StrSql += "    and cod_regiao   = " + CodRegiao
        StrSql += "    and cod_cidade   = " + CodCidade
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
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
            strSql += "    and cod_regiao   = " + CodRegiao
            strSql += "    and cod_cidade   = " + CodCidade

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
