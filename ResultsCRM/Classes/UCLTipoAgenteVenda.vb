Public Class UCLTipoAgenteVenda

    Private _Codigo As String
    Private _Descricao As String
    Private _Master As String
    Private _Acesso As String
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

    Public Property Master() As String
        Get
            Return _Master
        End Get
        Set(ByVal value As String)
            _Master = value
        End Set
    End Property

    Public Property Acesso() As String
        Get
            Return _Acesso
        End Get
        Set(ByVal value As String)
            _Acesso = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select a.cod_tp_agente_venda, a.descricao, a.master"
        StrSql += "   from tipo_agente_venda a "
        StrSql += "  where cod_tp_agente_venda = " + Codigo
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            Master = dt.Rows.Item(0).Item("master").ToString
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select a.cod_tp_agente_vendas, a.descricao "
        strSql += "   from tipo_agente_venda a "
        strSql += "  order by descricao "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_tp_agente_vendas") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_tp_agente_vendas"
        DDL.DataBind()
    End Sub

End Class
