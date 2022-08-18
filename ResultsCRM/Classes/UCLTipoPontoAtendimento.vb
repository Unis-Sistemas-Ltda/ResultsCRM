Public Class UCLTipoPontoAtendimento

    Private _CodTipoPontoAtendimento As String
    Private _Descricao As String
    Private _SequencialAutomatico As String
    Private ObjAcessoDados As UCLAcessoDados

    Public Property CodTipoPontoAtendimento() As String
        Get
            Return _CodTipoPontoAtendimento
        End Get
        Set(ByVal value As String)
            _CodTipoPontoAtendimento = value
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

    Public Property SequencialAutomatico As String
        Get
            Return _SequencialAutomatico
        End Get
        Set(value As String)
            _SequencialAutomatico = value
        End Set
    End Property

    Public Sub New()
        ObjAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_tipo_ponto_atendimento cod, descricao"
        strSql += "   from tipo_ponto_atendimento "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod"
        DDL.DataBind()
    End Sub

    Public Sub Incluir()
        Try
            Dim strSql As String
            SequencialAutomatico = IIf(String.IsNullOrWhiteSpace(SequencialAutomatico), "N", SequencialAutomatico)
            strSql = "insert into tipo_ponto_atendimento(cod_tipo_ponto_atendimento, descricao, sequencial_automatico) values (" + CodTipoPontoAtendimento + ", '" + Descricao + "','" + SequencialAutomatico + "')"
            ObjAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Try
            Dim strSql As String
            SequencialAutomatico = IIf(String.IsNullOrWhiteSpace(SequencialAutomatico), "N", SequencialAutomatico)
            strSql = " update tipo_ponto_atendimento "
            strSql += "   set descricao             = '" + Descricao + "', "
            strSql += "       sequencial_automatico = '" + SequencialAutomatico + "' "
            strSql += " where cod_tipo_ponto_atendimento = " + CodTipoPontoAtendimento
            ObjAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim strSql As String
            Dim dt As DataTable
            strSql = " select descricao, sequencial_automatico "
            strSql += "  from tipo_ponto_atendimento "
            strSql += " where cod_tipo_ponto_atendimento = " + CodTipoPontoAtendimento
            dt = ObjAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                Descricao = dt.Rows.Item(0).Item("descricao").ToString
                SequencialAutomatico = dt.Rows.Item(0).Item("sequencial_automatico").ToString
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_tipo_ponto_atendimento),0) + 1 max from tipo_ponto_atendimento "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
