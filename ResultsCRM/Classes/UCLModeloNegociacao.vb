Public Class UCLModeloNegociacao

    Private _CodModelo As String
    Private _Empresa As String
    Private _Descricao As String
    Private _Cabecalho As String
    Private _Rodape As String
    Private objAcessoDados As UCLAcessoDados

    Public Property CodModelo() As String
        Get
            Return _CodModelo
        End Get
        Set(ByVal value As String)
            _CodModelo = value
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

    Public Property Descricao() As String
        Get
            Return _Descricao
        End Get
        Set(ByVal value As String)
            _Descricao = value
        End Set
    End Property

    Public Property Cabecalho() As String
        Get
            Return _Cabecalho
        End Get
        Set(ByVal value As String)
            _Cabecalho = value
        End Set
    End Property

    Public Property Rodape() As String
        Get
            Return _Rodape
        End Get
        Set(ByVal value As String)
            _Rodape = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_modelo, descricao "
        strSql += "   from modelo_negociacao "
        strSql += "  where empresa = " + Empresa
        strSql += "  order by descricao "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_modelo") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_modelo"
        DDL.DataBind()
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select a.cod_modelo, a.descricao, a.cabecalho, a.rodape "
        StrSql += "   from modelo_negociacao a"
        StrSql += "  where a.empresa    = " + Empresa
        StrSql += "    and a.cod_modelo = " + CodModelo
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            Cabecalho = dt.Rows.Item(0).Item("cabecalho").ToString
            Rodape = dt.Rows.Item(0).Item("rodape").ToString
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            strSql += " insert into modelo_negociacao (empresa, cod_modelo, descricao, cabecalho, rodape)"
            strSql += " values ( " + Empresa + ", " + CodModelo + ", '" + Descricao + "', '" + Cabecalho + "', '" + Rodape + "');"
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            strSql += " update modelo_negociacao set descricao = '" + Descricao + "',"
            strSql += "                              cabecalho = '" + Cabecalho + "',"
            strSql += "                              rodape    = '" + Rodape + "'"
            strSql += "  where cod_modelo = " + CodModelo
            strSql += "    and empresa = " + Empresa
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_modelo),0) + 1 max from modelo_negociacao where empresa = " + Empresa
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
