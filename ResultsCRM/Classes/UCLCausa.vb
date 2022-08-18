Public Class UCLCausa
    Private _Codigo As String
    Private _Descricao As String
    Private _DescricaoCompleta As String
    Private objAcessoDados As UCLAcessoDados
    Public Property Empresa As String

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

    Public Property DescricaoCompleta() As String
        Get
            Return _DescricaoCompleta
        End Get
        Set(ByVal value As String)
            _DescricaoCompleta = value
        End Set
    End Property

    Public Sub Incluir()
        Dim strSql As String = ""
        Try
            strSql += " insert into causa (empresa,cod_causa, descricao, descricao_completa) "
            strSql += " values ( " + Empresa + ", " + Codigo + ", '" + Descricao + "','" + DescricaoCompleta + "') "
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Try
            strSql += " update causa set descricao = '" + Descricao + "', descricao_completa = '" + DescricaoCompleta + "'"
            strSql += "  where cod_causa = " + Codigo
            strSql += "    and empresa   = " + Empresa
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Dim strSql As String = ""
        Try
            strSql += " delete from causa "
            strSql += "  where cod_causa = " + Codigo
            strSql += "    and empresa   = " + Empresa
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

        StrSql += " select cod_causa, descricao, descricao_completa "
        StrSql += "   from causa "
        StrSql += "  where cod_causa = " + Codigo
        StrSql += "    and empresa   = " + Empresa
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            DescricaoCompleta = dt.Rows.Item(0).Item("descricao_completa").ToString
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub FillDropDown(ByVal pEmpresa As String, ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodigoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_causa, descricao"
        strSql += "   from causa "
        strSql += "  where empresa = " + pEmpresa
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_causa") = CodigoRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_causa"
        DDL.DataBind()
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String) As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_causa),0) + 1 max from causa where empresa = " + pEmpresa
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
