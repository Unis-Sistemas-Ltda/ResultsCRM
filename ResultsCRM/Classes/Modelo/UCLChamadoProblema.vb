Public Class UCLChamadoProblema
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("chamado_problema")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodChamado As String, ByVal pSeqProblema As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_chamado", pCodChamado)
            Me.SetConteudo("seq_problema", pSeqProblema)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodChamado As String, ByVal pSeqProblema As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_chamado", pCodChamado)
            Me.SetConteudo("seq_problema", pSeqProblema)
            Call ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ExcluirPorCodProblema(ByVal pEmpresa As String, ByVal pCodChamado As String, ByVal pCodProblema As String)
        Try
            If Me.BuscarPorCodProblema(pEmpresa, pCodChamado, pCodProblema) Then
                Call Me.Excluir(pEmpresa, pCodChamado, Me.GetConteudo("seq_problema"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function BuscarPorCodProblema(ByVal pEmpresa As String, ByVal pCodChamado As String, ByVal pCodProblema As String) As Boolean
        Try
            Dim StrSql As String = " select seq_problema from chamado_problema where empresa = " + pEmpresa + " and cod_chamado = " + pCodChamado + " and cod_problema = " + pCodProblema
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count = 0 Then
                Return False
            Else
                Return Me.Buscar(pEmpresa, pCodChamado, dt.Rows.Item(0).Item("seq_problema"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetProximoCodigo(ByVal pEmpresa As String, ByVal pCodChamado As String) As Long
        Try
            Dim StrSql As String = " select isnull(max(seq_problema),0) + 1 seq from chamado_problema where empresa = " + pEmpresa + " and cod_chamado = " + pCodChamado
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

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal pEmpresa As String, ByVal pCodChamado As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cp.seq_problema, pp.assunto "
        strSql += "   from problema_padrao pp inner join chamado_problema cp on pp.empresa = cp.empresa and pp.cod_problema = cp.cod_problema"
        strSql += "  where cp.empresa     = " + pEmpresa
        strSql += "    and cp.cod_chamado = " + pCodChamado
        strSql += " order by pp.assunto "
        dt = ObjAcessoDados.BuscarDados(strSql)

        DDL.DataSource = dt
        DDL.DataTextField = "assunto"
        DDL.DataValueField = "seq_problema"
        DDL.DataBind()
    End Sub

    Public Function GetProblemas(ByVal pEmpresa As String, ByVal pCodChamado As String) As List(Of String)
        Dim strSql As String = ""
        Dim dt As DataTable
        Dim problemas As New List(Of String)

        strSql += " select distinct pp.assunto "
        strSql += "   from problema_padrao pp inner join chamado_problema cp on pp.empresa = cp.empresa and pp.cod_problema = cp.cod_problema"
        strSql += "  where cp.empresa     = " + pEmpresa
        strSql += "    and cp.cod_chamado = " + pCodChamado
        dt = ObjAcessoDados.BuscarDados(strSql)

        For Each row As DataRow In dt.Rows
            problemas.Add(row.Item("assunto"))
        Next

        Return problemas
    End Function

    Public Function GetGrupoProblemas(ByVal pEmpresa As String, ByVal pCodChamado As String) As List(Of String)
        Dim strSql As String = ""
        Dim dt As DataTable
        Dim problemas As New List(Of String)

        strSql += " select distinct gp.descricao "
        strSql += "   from problema_padrao pp inner join chamado_problema cp on pp.empresa = cp.empresa and pp.cod_problema = cp.cod_problema "
        strSql += "                           inner join grupo_problema gp on pp.empresa = gp.empresa and pp.cod_grupo = gp.cod_grupo "
        strSql += "  where cp.empresa     = " + pEmpresa
        strSql += "    and cp.cod_chamado = " + pCodChamado
        dt = ObjAcessoDados.BuscarDados(strSql)

        For Each row As DataRow In dt.Rows
            problemas.Add(row.Item("descricao"))
        Next

        Return problemas
    End Function

End Class
