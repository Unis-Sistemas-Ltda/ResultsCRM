Public Class UCLBancoDados
    Private objAcessoDados As UCLAcessoDados

    Public Property CodBancoDados As String
    Public Property Descricao As String

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            strSql += " insert into banco_dados ( cod_banco_dados, descricao ) "
            strSql += " values ( " + CodBancoDados + ", '" + Descricao + "' ) "
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Try
            strSql += " update banco_dados "
            strSql += "    set descricao        = '" + Descricao + "'"
            strSql += "  where cod_banco_dados  = " + CodBancoDados
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Dim strSql As String = ""
        Try
            strSql += " delete from banco_dados "
            strSql += "  where cod_banco_dados  = " + CodBancoDados
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select descricao "
        StrSql += "   from banco_dados "
        StrSql += "  where cod_banco_dados  = " + CodBancoDados
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_banco_dados, descricao, descricao || ' (' || cod_banco_dados || ')' cf_descricao "
        strSql += "   from banco_dados "
        strSql += "  order by cod_banco_dados "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_banco_dados") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "cf_descricao"
        DDL.DataValueField = "cod_banco_dados"
        DDL.DataBind()
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_banco_dados),0) + 1 max from banco_dados "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
