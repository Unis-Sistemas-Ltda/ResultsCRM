Public Class UCLStatusNegociacao
    Private _Codigo As String
    Private _Descricao As String
    Private objAcessoDados As UCLAcessoDados

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
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

    Public Sub Incluir()
        Dim strSql As String = ""
        Try
            strSql += " insert into status_negociacao (cod_status, descricao) "
            strSql += " values ( " + Codigo + ", '" + Descricao + "') "
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Try
            strSql += " update status_negociacao set descricao = '" + Descricao + "'"
            strSql += "  where cod_status = " + Codigo
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select cod_status, descricao "
        StrSql += "   from status_negociacao "
        StrSql += "  where cod_status = " + Codigo
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub FillDropDown(ByRef DDL As Object, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Try
            Dim strSql As String = ""
            Dim dt As DataTable

            strSql += " select cod_status, descricao"
            strSql += "   from status_negociacao "
            dt = objAcessoDados.BuscarDados(strSql)

            If AdicionarRegistroEmBranco Then
                Dim NovaLinha As DataRow = dt.NewRow
                NovaLinha("cod_status") = 0
                If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                    DescricaoRegistroEmBranco = " "
                End If
                NovaLinha("descricao") = DescricaoRegistroEmBranco
                dt.Rows.InsertAt(NovaLinha, 0)
            End If

            DDL.DataSource = dt
            DDL.DataTextField = "descricao"
            DDL.DataValueField = "cod_status"
            DDL.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_status),0) + 1 max from status_negociacao "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
