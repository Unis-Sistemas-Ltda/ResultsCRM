Public Class UCLTefGrupo
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("tef_grupo")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodGrupo As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_grupo", pCodGrupo)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodGrupo As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_grupo", pCodGrupo)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String) As Long
        Dim ret As Long = 1
        Dim strSql = " select right( floor( rand() * 10000 ), 4 ) max from dummy "
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        If Me.Buscar(pEmpresa, ret) Then
            Return GetProximoCodigo(pEmpresa)
        End If
        Return ret
    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal pCodRegistroEmBranco As String, ByVal pEmpresa As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_grupo codigo, nome_rede nome"
        strSql += "   from tef_grupo"
        strSql += "  where empresa = " + pEmpresa
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
