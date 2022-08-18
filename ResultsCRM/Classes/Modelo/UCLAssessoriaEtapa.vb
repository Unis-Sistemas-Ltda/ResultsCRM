Public Class UCLAssessoriaEtapa
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("assessoria_etapa")
    End Sub

    Public Function Buscar(ByVal pCodAssessoria As String, ByVal pCodEtapa As String) As Boolean
        Try
            Me.SetConteudo("cod_assessoria", pCodAssessoria)
            Me.SetConteudo("cod_etapa", pCodEtapa)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodAssessoria As String, ByVal pCodEtapa As String)
        Try
            Me.SetConteudo("cod_assessoria", pCodAssessoria)
            Me.SetConteudo("cod_etapa", pCodEtapa)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pCodAssessoria As String) As Long
        Try
            Dim StrSql As String = "select isnull(max(cod_etapa),0) + 1 seq from assessoria_etapa where cod_assessoria = " + pCodAssessoria
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("seq")
            Else
                Return 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub FillDropDown(ByVal pCodAssessoria As String, ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodigoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select ae.cod_etapa, ae.descricao || ' (' || ae.cod_etapa || ')' cf_descricao "
        strSql += "   from assessoria_etapa ae "
        strSql += "  where ae.cod_assessoria = " + pCodAssessoria
        strSql += "  order by cf_descricao "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_etapa") = CodigoRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("cf_descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "cf_descricao"
        DDL.DataValueField = "cod_etapa"
        DDL.DataBind()
    End Sub

End Class
