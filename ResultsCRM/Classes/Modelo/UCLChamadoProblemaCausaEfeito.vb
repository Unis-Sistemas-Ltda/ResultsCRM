Public Class UCLChamadoProblemaCausaEfeito
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("chamado_problema_causa_efeito")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodChamado As String, ByVal pSeqProblema As String, ByVal pCodCausa As String, ByVal pCodEfeito As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_chamado", pCodChamado)
            Me.SetConteudo("seq_problema", pSeqProblema)
            Me.SetConteudo("cod_causa", pCodCausa)
            Me.SetConteudo("cod_efeito", pCodEfeito)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodChamado As String, ByVal pSeqProblema As String, ByVal pCodCausa As String, ByVal pCodEfeito As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_chamado", pCodChamado)
            Me.SetConteudo("seq_problema", pSeqProblema)
            Me.SetConteudo("cod_causa", pCodCausa)
            Me.SetConteudo("cod_efeito", pCodEfeito)
            Call ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal pEmpresa As String, ByVal pCodChamado As String, ByVal pSeqProblema As String, ByVal pCodCausa As String)
        Try
            Dim strSql As String = ""
            Dim dt As DataTable

            strSql += " select ef.cod_efeito, ef.descricao "
            strSql += "   from chamado_problema cp inner join problema_padrao pp on pp.empresa = cp.empresa and pp.cod_problema = cp.cod_problema"
            strSql += "                            inner join problema_causa cpc on cpc.empresa = cp.empresa and cpc.cod_problema = cp.cod_problema"
            strSql += "                            inner join causa ca on ca.empresa = cpc.empresa and ca.cod_causa = cpc.cod_causa"
            strSql += "                            inner join causa_efeito ce on ce.empresa = ca.empresa and ce.cod_causa = ca.cod_causa"
            strSql += "                            inner join efeito ef on ef.empresa = ce.empresa and ef.cod_efeito = ce.cod_efeito"
            strSql += "  where cp.empresa      = " + pEmpresa
            strSql += "    and cp.cod_chamado  = " + pCodChamado
            strSql += "    and cp.seq_problema = " + pSeqProblema
            strSql += "    and ca.cod_causa    = " + pCodCausa
            strSql += " order by ca.descricao, ca.cod_causa "
            dt = ObjAcessoDados.BuscarDados(strSql)

            DDL.DataSource = dt
            DDL.DataTextField = "descricao"
            DDL.DataValueField = "cod_efeito"
            DDL.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
