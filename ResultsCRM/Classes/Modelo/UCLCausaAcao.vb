Public Class UClCausaAcao
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("causa_acao")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodCausa As String, ByVal pCodAcao As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_causa", pCodCausa)
            Me.SetConteudo("cod_acao", pCodAcao)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodCausa As String, ByVal pCodAcao As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_causa", pCodCausa)
            Me.SetConteudo("cod_acao", pCodAcao)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillDropDown(ByVal pEmpresa As String, ByVal pCodCausa As String, ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodigoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select a.cod_acao, a.descricao || ' (' || a.cod_acao || ')' cf_descricao "
        strSql += "   from causa_acao ca inner join acao a on ca.empresa = a.empresa and ca.cod_acao = a.cod_acao "
        strSql += "  where ca.empresa   = " + pEmpresa
        strSql += "    and ca.cod_causa = " + pCodCausa
        strSql += "  order by cf_descricao "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_acao") = CodigoRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("cf_descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "cf_descricao"
        DDL.DataValueField = "cod_acao"
        DDL.DataBind()
    End Sub

End Class
