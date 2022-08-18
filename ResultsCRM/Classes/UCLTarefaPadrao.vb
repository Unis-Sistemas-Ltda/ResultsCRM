Public Class UCLTarefaPadrao

    Private objAcessoDados As UCLAcessoDados
    Private _CodTarefaPadrao As String
    Private _DescricaoResumida As String
    Private _Descricao As String
    Private _DiasPrevisao As String
    Private _Prioridade As String
    Private _TipoResponsavel As String
    Private _ManterInformado As String
    Private _Titulo As String
    Private _Observacao As String

    Public Property Descricao() As String
        Get
            Return _Descricao
        End Get
        Set(ByVal value As String)
            _Descricao = value
        End Set
    End Property

    Public Property CodTarefaPadrao() As String
        Get
            Return _CodTarefaPadrao
        End Get
        Set(ByVal value As String)
            _CodTarefaPadrao = value
        End Set
    End Property

    Public Property DescricaoResumida() As String
        Get
            Return _DescricaoResumida
        End Get
        Set(ByVal value As String)
            _DescricaoResumida = value
        End Set
    End Property

    Public Property DiasPrevisao() As String
        Get
            Return _DiasPrevisao
        End Get
        Set(ByVal value As String)
            _DiasPrevisao = value
        End Set
    End Property

    Public Property Prioridade() As String
        Get
            Return _Prioridade
        End Get
        Set(ByVal value As String)
            _Prioridade = value
        End Set
    End Property

    Public Property TipoResponsavel() As String
        Get
            Return _TipoResponsavel
        End Get
        Set(ByVal value As String)
            _TipoResponsavel = value
        End Set
    End Property

    Public Property ManterInformado() As String
        Get
            Return _ManterInformado
        End Get
        Set(ByVal value As String)
            _ManterInformado = value
        End Set
    End Property

    Public Property Titulo() As String
        Get
            Return _Titulo
        End Get
        Set(ByVal value As String)
            _Titulo = value
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

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            strSql += " update tarefa_padrao set "
            strSql += "    descricao_resumida = '" + DescricaoResumida + "', "
            strSql += "    dias_previsao_conclusao = " + DiasPrevisao + ","
            strSql += "    prioridade = '" + Prioridade + "', "
            strSql += "    descricao = '" + Descricao + "',"
            strSql += "    tipo_responsavel = " + TipoResponsavel + ", "
            strSql += "    manter_informado = '" + ManterInformado + "',"
            strSql += "    titulo = '" + Titulo + "',"
            strSql += "    observacao = '" + Observacao + "'"
            strSql += " where cod_tarefa_padrao = " + CodTarefaPadrao

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            strSql += " insert into tarefa_padrao ( "
            strSql += "   cod_tarefa_padrao, "
            strSql += "   descricao_resumida, "
            strSql += "   dias_previsao_conclusao, "
            strSql += "   prioridade, "
            strSql += "   descricao, "
            strSql += "   tipo_responsavel, "
            strSql += "   manter_informado, "
            strSql += "   titulo, "
            strSql += "   observacao) "
            strSql += " values ("
            strSql += CodTarefaPadrao + ", "
            strSql += "'" + DescricaoResumida + "', "
            strSql += DiasPrevisao + ","
            strSql += "'" + Prioridade + "', "
            strSql += "'" + Descricao + "',"
            strSql += TipoResponsavel + ", "
            strSql += "'" + ManterInformado + "',"
            strSql += "'" + Titulo + "',"
            strSql += "'" + Observacao + "')"

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Buscar()
        Dim strSql As String = ""
        Dim dt As DataTable

        Try
            strSql += " select descricao_resumida, "
            strSql += "        isnull(descricao,'') descricao, "
            strSql += "        isnull(dias_previsao_conclusao,0) dias, "
            strSql += "        isnull(prioridade,'M') prioridade, "
            strSql += "        tipo_responsavel, "
            strSql += "        manter_informado, "
            strSql += "        titulo, "
            strSql += "        observacao "
            strSql += "   from tarefa_padrao "
            strSql += "  where cod_tarefa_padrao = " + CodTarefaPadrao

            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                DescricaoResumida = dt.Rows.Item(0).Item("descricao_resumida").ToString
                Descricao = dt.Rows.Item(0).Item("descricao").ToString
                DiasPrevisao = dt.Rows.Item(0).Item("dias").ToString
                Prioridade = dt.Rows.Item(0).Item("prioridade").ToString
                TipoResponsavel = dt.Rows.Item(0).Item("tipo_responsavel").ToString
                ManterInformado = dt.Rows.Item(0).Item("manter_informado").ToString
                Titulo = dt.Rows.Item(0).Item("titulo").ToString
                Observacao = dt.Rows.Item(0).Item("observacao").ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select a.cod_tarefa_padrao, a.descricao_resumida "
        strSql += "   from tarefa_padrao a "
        strSql += "  order by descricao_resumida "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_tarefa_padrao") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao_resumida") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao_resumida"
        DDL.DataValueField = "cod_tarefa_padrao"
        DDL.DataBind()
    End Sub

    Public Sub FillCheckBoxList(ByRef ChkList As CheckBoxList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select a.cod_tarefa_padrao, a.descricao_resumida "
        strSql += "   from tarefa_padrao a "
        strSql += "  order by descricao_resumida "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_tarefa_padrao") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao_resumida") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        ChkList.DataSource = dt
        ChkList.DataTextField = "descricao_resumida"
        ChkList.DataValueField = "cod_tarefa_padrao"
        ChkList.DataBind()
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_tarefa_padrao),0) + 1 max from tarefa_padrao "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
