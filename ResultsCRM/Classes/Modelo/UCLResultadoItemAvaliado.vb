Public Class UCLResultadoItemAvaliado
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("resultado_item_avaliado")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodGrupoResultado As String, ByVal pSeqResultado As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_grupo_resultado", pCodGrupoResultado)
            Me.SetConteudo("seq_resultado", pSeqResultado)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodGrupoResultado As String, ByVal pSeqResultado As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_grupo_resultado", pCodGrupoResultado)
            Me.SetConteudo("seq_resultado", pSeqResultado)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String, ByVal pCodGrupoResultado As String) As Long
        Try
            Dim StrSql As String = " select isnull(max(seq_resultado),0) + 1 seq from resultado_item_avaliado where empresa = " + pEmpresa + " and cod_grupo_resultado = " + pCodGrupoResultado
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

    Public Sub FillDropDown(ByVal pEmpresa As String, ByVal pCodGrupoResultado As String, ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable


        strSql += " select seq_resultado, descricao"
        strSql += "   from resultado_item_avaliado"
        strSql += "  where empresa             = " + pEmpresa
        strSql += "    and cod_grupo_resultado = " + pCodGrupoResultado
        strSql += "  order by seq_resultado "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("seq_resultado") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "seq_resultado"
        DDL.DataBind()
    End Sub
End Class
