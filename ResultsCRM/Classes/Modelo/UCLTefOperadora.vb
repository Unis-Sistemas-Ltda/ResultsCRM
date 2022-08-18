Public Class UCLTefOperadora
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("tef_operadora")
    End Sub

    Public Function Buscar(ByVal pCodAdquirente As String) As Boolean
        Try
            Me.SetConteudo("cod_operadora", pCodAdquirente)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodAdquirente As String)
        Try
            Me.SetConteudo("cod_operadora", pCodAdquirente)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Try
            Dim StrSql As String = " select isnull(max(cod_operadora),0) + 1 seq from tef_operadora "
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

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal pCodRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_operadora codigo, nome_operadora nome "
        strSql += "   from tef_operadora "
        strSql += "  order by nome "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("codigo") = pCodRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome"
        DDL.DataValueField = "codigo"
        DDL.DataBind()
    End Sub
End Class
