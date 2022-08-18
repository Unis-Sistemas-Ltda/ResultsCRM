Public Class UCLEtapaNegociacao
    Private _Codigo As String
    Private _Descricao As String
    Private _Empresa As String
    Private _Status As String
    Private _Cor As String
    Public Property TempoMaximo As String
    Private objAcessoDados As UCLAcessoDados

    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    Public Property Cor() As String
        Get
            Return _Cor
        End Get
        Set(ByVal value As String)
            _Cor = value
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

    Public Property PercentualFechamento As String
    Public Property NaoExigirDataPrevisao As String
    Public Property ExigirDataRecontato As String

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select cod_etapa, descricao, status, cor, percentual_fechamento, tempo_maximo, nao_exigir_data_previsao, exigir_data_recontato "
        StrSql += "   from etapa_negociacao"
        StrSql += "  where empresa   = " + Empresa
        StrSql += "    and cod_etapa = " + Codigo
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            Status = dt.Rows.Item(0).Item("status").ToString
            Cor = dt.Rows.Item(0).Item("cor").ToString
            If Not IsDBNull(dt.Rows.Item(0).Item("percentual_fechamento")) Then
                PercentualFechamento = dt.Rows.Item(0).Item("percentual_fechamento").ToString
            Else
                PercentualFechamento = ""
            End If
            If Not IsDBNull(dt.Rows.Item(0).Item("tempo_maximo")) Then
                TempoMaximo = dt.Rows.Item(0).Item("tempo_maximo").ToString
            Else
                TempoMaximo = ""
            End If
            If Not IsDBNull(dt.Rows.Item(0).Item("nao_exigir_data_previsao")) Then
                NaoExigirDataPrevisao = dt.Rows.Item(0).Item("nao_exigir_data_previsao").ToString
            Else
                NaoExigirDataPrevisao = "N"
            End If
            If Not IsDBNull(dt.Rows.Item(0).Item("exigir_data_recontato")) Then
                ExigirDataRecontato = dt.Rows.Item(0).Item("exigir_data_recontato").ToString
            Else
                ExigirDataRecontato = "N"
            End If
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal pCodFunil As String, ByVal pCodEtapa As String)
        Try
            Dim strSql As String = ""
            Dim dt As DataTable

            If String.IsNullOrEmpty(pCodFunil) OrElse pCodFunil = "0" Then
                Call FillDropDown(DDL, AdicionarRegistroEmBranco, DescricaoRegistroEmBranco)
            Else
                strSql += " select e.cod_etapa, e.descricao"
                strSql += "   from etapa_negociacao e inner join funil_venda_etapa_negociacao f on e.cod_etapa = f.cod_etapa and e.empresa = f.empresa "
                strSql += "  where e.empresa   = " + Empresa
                strSql += "    and ( f.cod_funil = " + pCodFunil + " or e.cod_etapa = " + IIf(String.IsNullOrEmpty(pCodEtapa), "0", pCodEtapa) + " ) "
                dt = objAcessoDados.BuscarDados(strSql)

                If AdicionarRegistroEmBranco Then
                    Dim NovaLinha As DataRow = dt.NewRow
                    NovaLinha("cod_etapa") = 0
                    If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                        DescricaoRegistroEmBranco = " "
                    End If
                    NovaLinha("descricao") = DescricaoRegistroEmBranco
                    dt.Rows.InsertAt(NovaLinha, 0)
                End If

                DDL.DataSource = dt
                DDL.DataTextField = "descricao"
                DDL.DataValueField = "cod_etapa"
                DDL.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Try
            Dim strSql As String = ""
            Dim dt As DataTable

            strSql += " select cod_etapa, descricao"
            strSql += "   from etapa_negociacao"
            strSql += "  where empresa = " + Empresa
            dt = objAcessoDados.BuscarDados(strSql)

            If AdicionarRegistroEmBranco Then
                Dim NovaLinha As DataRow = dt.NewRow
                NovaLinha("cod_etapa") = 0
                If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                    DescricaoRegistroEmBranco = " "
                End If
                NovaLinha("descricao") = DescricaoRegistroEmBranco
                dt.Rows.InsertAt(NovaLinha, 0)
            End If

            DDL.DataSource = dt
            DDL.DataTextField = "descricao"
            DDL.DataValueField = "cod_etapa"
            DDL.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Incluir()
        Dim strSql As String = ""
        Try
            strSql += " insert into etapa_negociacao (empresa, cod_etapa, descricao, status, cor, percentual_fechamento, tempo_maximo, nao_exigir_data_previsao, exigir_data_recontato ) "
            strSql += " values ( " + Empresa + "," + Codigo + ", '" + Descricao + "','" + Status + "'," + Cor + ", " + IIf(String.IsNullOrEmpty(PercentualFechamento), "null", PercentualFechamento.Replace(".", "").Replace(",", ".")) + ", " + IIf(String.IsNullOrEmpty(TempoMaximo), "null", TempoMaximo.Replace(".", "").Replace(",", ".")) + ", '" + IIf(Not String.IsNullOrEmpty(NaoExigirDataPrevisao), NaoExigirDataPrevisao, "N") + "', '" + IIf(Not String.IsNullOrEmpty(ExigirDataRecontato), ExigirDataRecontato, "N") + "') "
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Try
            strSql += " update etapa_negociacao set descricao = '" + Descricao + "',"
            strSql += "                             status = '" + Status + "', "
            strSql += "                             cor = " + Cor + ", "
            strSql += "                             percentual_fechamento = " + IIf(String.IsNullOrEmpty(PercentualFechamento), "null", PercentualFechamento.Replace(".", "").Replace(",", ".")) + ", "
            strSql += "                             tempo_maximo = " + IIf(String.IsNullOrEmpty(TempoMaximo), "null", TempoMaximo.Replace(".", "").Replace(",", ".")) + ", "
            strSql += "                             nao_exigir_data_previsao = '" + IIf(Not String.IsNullOrEmpty(NaoExigirDataPrevisao), NaoExigirDataPrevisao, "N") + "', "
            strSql += "                             exigir_data_recontato = '" + IIf(Not String.IsNullOrEmpty(ExigirDataRecontato), ExigirDataRecontato, "N") + "'"
            strSql += "  where cod_etapa = " + Codigo
            strSql += "    and empresa = " + Empresa
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_etapa),0) + 1 max from etapa_negociacao where empresa = " + Empresa
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
