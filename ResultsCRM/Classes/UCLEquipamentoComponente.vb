Public Class UCLEquipamentoComponente

    Private objAcessoDados As UCLAcessoDados
    Private _Empresa As String
    Private _NumeroSerie As String
    Private _SeqComponente As String
    Private _CodItem As String
    Private _Observacao As String
    Private _Quantidade As Integer


    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Property NumeroSerie() As String
        Get
            Return _NumeroSerie
        End Get
        Set(ByVal value As String)
            _NumeroSerie = value
        End Set
    End Property

    Public Property SeqComponente() As String
        Get
            Return _SeqComponente
        End Get
        Set(ByVal value As String)
            _SeqComponente = value
        End Set
    End Property

    Public Property CodItem() As String
        Get
            Return _CodItem
        End Get
        Set(ByVal value As String)
            _CodItem = value
        End Set
    End Property

    Public Property Observacao() As String
        Get
            Return _Observacao
        End Get
        Set(ByVal value As String)
            _Observacao = value
        End Set
    End Property

    Public Property Quantidade() As String
        Get
            Return _Quantidade
        End Get
        Set(ByVal value As String)
            _Quantidade = value
        End Set
    End Property

    Public Sub New(ByVal StrConn As String)
        objAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Function Buscar() As Boolean
        Dim strSql As String = " select * from equipamento_componente where empresa = " + Empresa + " and numero_serie = '" + NumeroSerie + "' and seq_componente = " + SeqComponente
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)

        If dt.Rows.Count > 0 Then
            CodItem = dt.Rows.Item(0).Item("cod_item").ToString
            Observacao = dt.Rows.Item(0).Item("observacao").ToString
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub Incluir()
        Try
            Dim strSql As String = " insert into equipamento_componente(empresa, numero_serie, seq_componente, cod_item, observacao,quantidade) values (" + Empresa + ", '" + NumeroSerie + "', " + SeqComponente + ", '" + CodItem + "', '" + Observacao + "', " + Quantidade + ");"
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            strSql += " update equipamento_componente set cod_item = '" + CodItem + "', observacao = '" + Observacao + "', quantidade = " + Quantidade + " where empresa = " + Empresa + " and numero_serie = '" + NumeroSerie + "' and seq_componente = " + SeqComponente
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Dim strSql As String = ""

        Try
            strSql += " delete from equipamento_componente where empresa = " + Empresa + " and numero_serie = '" + NumeroSerie + "' and seq_componente = " + SeqComponente
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += "select e.seq_componente seq, i.descricao || ' - ' || e.observacao || ' (' || e.Seq_componente || ')'  descricao"
        strSql += "  from equipamento_componente e inner join item i on e.cod_item = i.cod_item"
        strSql += " where empresa = " + Empresa
        strSql += "   and numero_serie = '" + NumeroSerie + "'"
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("seq") = CodRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "seq"
        DDL.DataBind()
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(seq_componente),0) + 1 max from equipamento_componente where empresa = " + Empresa + " and numero_serie = '" + NumeroSerie + "'"
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
