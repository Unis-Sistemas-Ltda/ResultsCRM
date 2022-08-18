Public Class UCLTEFBandeira
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("bandeira_tef")
    End Sub

    Public Function Buscar(ByVal pCodBandeira As String) As Boolean
        Try
            Me.SetConteudo("tef_bandeira", pCodBandeira)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodBandeira As String)
        Try
            Me.SetConteudo("cod_bandeira", pCodBandeira)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_bandeira codigo, descricao nome"
        strSql += "   from tef_bandeira"
        strSql += " order by nome"
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("codigo") = CodRegistroEmBranco
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
