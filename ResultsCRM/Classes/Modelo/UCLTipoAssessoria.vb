Public Class UCLTipoAssessoria
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("tipo_assessoria")
    End Sub

    Public Function Buscar(ByVal pCodTipoAssessoria As String) As Boolean
        Try
            Me.SetConteudo("cod_tipo_assessoria", pCodTipoAssessoria)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodTipoAssessoria As String)
        Try
            Me.SetConteudo("cod_tipo_assessoria", pCodTipoAssessoria)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Try
            Dim StrSql As String = "select isnull(max(cod_tipo_assessoria),0) + 1 seq from tipo_assessoria"
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

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable


        strSql += " select cod_tipo_assessoria, descricao || ' (' || cod_tipo_assessoria || ')' nome"
        strSql += "   from tipo_assessoria"
        strSql += "  order by nome "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_tipo_assessoria") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome"
        DDL.DataValueField = "cod_tipo_assessoria"
        DDL.DataBind()
    End Sub

End Class
