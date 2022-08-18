Public Class UCLItemLote
    Private ObjAcessoDados As UCLAcessoDados
    Public Property CodItem As String = ""
    Public Property Empresa As String = ""


    Public Sub New(ByVal StrC As String)
        ObjAcessoDados = New UCLAcessoDados(StrC)
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable
        Dim NovaLinha As DataRow

        strSql += "select saldo_estoque.lote, "
        strSql += "saldo_estoque.lote + ' - ' + CONVERT(varchar(10), sum(saldo))  as descricao "
        strSql += "from saldo_estoque "
        strSql += "where(saldo > 0) "
        strSql += " and saldo_estoque.empresa  = '" + Empresa + "'"
        strSql += " and saldo_estoque.cod_item = '" + CodItem + "'"
        strSql += " group by saldo_estoque.lote "
        strSql += " order by saldo_estoque.lote"

        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            NovaLinha = dt.NewRow
            NovaLinha("lote") = ""
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "lote"
        DDL.DataBind()
    End Sub

    Public Function QtdeItemPreco(ByVal lote As String) As Double
      
        Dim strSql As String = " "

        strSql += "select sum(saldo) as qtde "
        strSql += "from saldo_estoque "
        strSql += "where(saldo > 0) "
        strSql += " and saldo_estoque.empresa  = '" + Empresa + "'"
        strSql += " and saldo_estoque.cod_item = '" + CodItem + "'"
        strSql += " and saldo_estoque.lote = '" + lote + "'"


        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        Dim retorno As Double = 0
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows.Item(0).Item("qtde")) Then
                retorno = 0
            Else
                retorno = CDbl(dt.Rows.Item(0).Item("qtde").ToString)
            End If

        End If
        Return retorno
    End Function

End Class
