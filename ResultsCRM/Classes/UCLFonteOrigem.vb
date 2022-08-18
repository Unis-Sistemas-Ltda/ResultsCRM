Public Class UCLFonteOrigem
    Private _CodFonte As String
    Private _Descricao As String
    Private objAcessoDados As UCLAcessoDados

    Public Property CodFonte() As String
        Get
            Return _CodFonte
        End Get
        Set(ByVal value As String)
            _CodFonte = value
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

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Function Buscar() As DataTable
        Dim StrSql As String
        Dim dt As DataTable

        StrSql = " select cod_fonte, descricao "
        StrSql += "  from fonte_origem_negociacao "
        StrSql += " where cod_fonte = " + CodFonte

        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
        End If

        Return dt
    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_fonte, descricao "
        strSql += "   from fonte_origem_negociacao "
        strSql += "  order by descricao "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_fonte") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_fonte"
        DDL.DataBind()
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_fonte),0) + 1 max from fonte_origem_negociacao "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Sub Incluir()
        Dim strSql As String = ""
        Try
            strSql += " insert into fonte_origem_negociacao (cod_fonte, descricao) "
            strSql += " values ( " + CodFonte + ", '" + Descricao + "') "
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Try
            strSql += " update fonte_origem_negociacao set descricao = '" + Descricao + "'"
            strSql += "  where cod_fonte = " + CodFonte
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
