Public Class UCLTipoDespesaAcessoria
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("tipo_despesa_acessoria")
    End Sub

    Public Sub FillDropDown(ByVal pEmpresa As String, ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select convert(text,cod_tipo_desp_acess) codigo, descricao"
        strSql += "   from tipo_despesa_acessoria"
        strSql += "  where empresa = " + pEmpresa
        strSql += " order by descricao"
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("codigo") = CodRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "codigo"
        DDL.DataBind()
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodigo As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_tipo_desp_acess", pCodigo)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
