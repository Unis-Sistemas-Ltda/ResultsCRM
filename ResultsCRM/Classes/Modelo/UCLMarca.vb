Public Class UCLMarca
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("marca")
    End Sub

    Public Function Buscar(ByVal pCodMarca As String) As Boolean
        Try
            Me.SetConteudo("cod_marcas", pCodMarca)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodMarca As String)
        Try
            Me.SetConteudo("cod_marcas", pCodMarca)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_marcas, descricao "
        strSql += "   from marcas"
        strSql += " order by descricao "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_marcas") = CodRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_marcas"
        DDL.DataBind()
    End Sub
End Class
