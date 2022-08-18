Public Class UCLMotivoFechamento

    Private _CodMotivo As String
    Private _Tipo As String
    Private _Descricao As String
    Private objAcessoDados As UCLAcessoDados

    Public Property CodMotivo() As String
        Get
            Return _CodMotivo
        End Get
        Set(ByVal value As String)
            _CodMotivo = value
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

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            strSql += " insert into motivo_fechamento_negociacao ( cod_motivo, descricao, tipo) "
            strSql += " values (" + CodMotivo + ", '" + Descricao + "', '" + Tipo + "')"

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            strSql += " update motivo_fechamento_negociacao set descricao = '" + Descricao + "', tipo = '" + Tipo + "'"
            strSql += " where cod_motivo = " + CodMotivo

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function Buscar() As DataTable
        Dim StrSql As String
        Dim dt As DataTable

        StrSql = " select cod_motivo, descricao, tipo "
        StrSql += "  from motivo_fechamento_negociacao "
        StrSql += " where cod_motivo = " + CodMotivo

        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            Tipo = dt.Rows.Item(0).Item("tipo").ToString
        End If

        Return dt
    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_motivo, descricao "
        strSql += "   from motivo_fechamento_negociacao "
        strSql += "  order by descricao "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_motivo") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_motivo"
        DDL.DataBind()
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_motivo),0) + 1 max from motivo_fechamento_negociacao "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
