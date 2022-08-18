Public Class UCLChamadoProblemaCausa
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("chamado_problema_causa")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodChamado As String, ByVal pSeqProblema As String, ByVal pCodCausa As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_chamado", pCodChamado)
            Me.SetConteudo("seq_problema", pSeqProblema)
            Me.SetConteudo("cod_causa", pCodCausa)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodChamado As String, ByVal pSeqProblema As String, ByVal pCodCausa As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_chamado", pCodChamado)
            Me.SetConteudo("seq_problema", pSeqProblema)
            Me.SetConteudo("cod_causa", pCodCausa)
            Call ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal pEmpresa As String, ByVal pCodChamado As String, ByVal pSeqProblema As String, ByVal pSomenteJaIncluidas As Boolean)
        Try
            Dim strSql As String = ""
            Dim dt As DataTable

            strSql += " select ca.cod_causa, ca.descricao "
            strSql += "   from chamado_problema cp inner join problema_padrao pp on pp.empresa = cp.empresa and pp.cod_problema = cp.cod_problema"
            strSql += "                            inner join problema_causa cpc on cpc.empresa = cp.empresa and cpc.cod_problema = cp.cod_problema"
            strSql += "                            inner join causa ca on ca.empresa = cpc.empresa and ca.cod_causa = cpc.cod_causa"
            If pSomenteJaIncluidas Then
                strSql += "                            inner join chamado_problema_causa cca on cca.empresa = cp.empresa and cca.cod_chamado = cp.cod_chamado and cca.seq_problema = cp.seq_problema and cca.cod_causa = cpc.cod_causa"
            End If
            strSql += "  where cp.empresa      = " + pEmpresa
            strSql += "    and cp.cod_chamado  = " + pCodChamado
            strSql += "    and cp.seq_problema = " + pSeqProblema
            strSql += " order by ca.descricao, ca.cod_causa "
            dt = ObjAcessoDados.BuscarDados(strSql)

            DDL.DataSource = dt
            DDL.DataTextField = "descricao"
            DDL.DataValueField = "cod_causa"
            DDL.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetCausas(ByVal pEmpresa As String, ByVal pCodChamado As String) As List(Of String)
        Try
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim causas As New List(Of String)

            strSql += " select distinct ca.descricao "
            strSql += "   from chamado_problema cp inner join problema_padrao pp on pp.empresa = cp.empresa and pp.cod_problema = cp.cod_problema"
            strSql += "                            inner join problema_causa cpc on cpc.empresa = cp.empresa and cpc.cod_problema = cp.cod_problema"
            strSql += "                            inner join causa ca on ca.empresa = cpc.empresa and ca.cod_causa = cpc.cod_causa"
            strSql += "                            inner join chamado_problema_causa cc on cc.empresa = cp.empresa and cc.cod_chamado = cp.cod_chamado and cc.seq_problema = cp.seq_problema"
            strSql += "  where cp.empresa      = " + pEmpresa
            strSql += "    and cp.cod_chamado  = " + pCodChamado
            dt = ObjAcessoDados.BuscarDados(strSql)

            For Each row As DataRow In dt.Rows
                causas.Add(row.Item("descricao"))
            Next
            Return causas
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
