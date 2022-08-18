Public Class UCLSistema

    Private objAcessoDados As UCLAcessoDados
    Public Property CodSistema As String
    Public Property Descricao As String

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_sistema),0) + 1 max from sistema "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select descricao "
        StrSql += "   from sistema "
        StrSql += "  where cod_sistema  = " + CodSistema
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, Optional ByVal AdicionarRegistroEmBranco As Boolean = False, Optional ByVal DescricaoRegistroEmBranco As String = "")
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_sistema, descricao "
        strSql += "   from sistema "
        strSql += "  order by if cod_sistema = 1 then space(10) || descricao else descricao endif "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_sistema") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_sistema"
        DDL.DataBind()
    End Sub

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            strSql += " insert into sistema ( cod_sistema, descricao ) "
            strSql += " values ( " + CodSistema + ", '" + Descricao + "' ) "
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Try
            strSql += " update sistema "
            strSql += "    set descricao    = '" + Descricao + "'"
            strSql += "  where cod_sistema  = " + CodSistema
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Dim strSql As String = ""
        Try
            strSql += " delete from sistema "
            strSql += "  where cod_sistema  = " + CodSistema
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
