Public Class UCLAssessoria
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("assessoria")
    End Sub

    Public Function Buscar(ByVal pCodAssessoria As String) As Boolean
        Try
            Me.SetConteudo("cod_assessoria", pCodAssessoria)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodAssessoria As String)
        Try
            Me.SetConteudo("cod_assessoria", pCodAssessoria)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Try
            Dim StrSql As String = "select isnull(max(cod_assessoria),0) + 1 seq from assessoria"
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

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodigoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select ae.cod_assessoria, ae.descricao || ' (' || ae.cod_assessoria || ')' cf_descricao "
        strSql += "   from assessoria ae "
        strSql += "  order by cf_descricao "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_assessoria") = CodigoRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("cf_descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "cf_descricao"
        DDL.DataValueField = "cod_assessoria"
        DDL.DataBind()
    End Sub

End Class
