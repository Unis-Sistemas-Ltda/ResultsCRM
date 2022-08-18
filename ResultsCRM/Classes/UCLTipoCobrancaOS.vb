Public Class UCLTipoCobrancaOS
    Private ObjAcessoDados As UCLAcessoDados

    Public Sub New()
        ObjAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodigoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += "select convert(varchar(10),cod_tipo_cobranca_os) cod_tipo_cobranca_os, descricao from tipo_cobranca_os"

        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_tipo_cobranca_os") = CodigoRegistroEmBranco
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_tipo_cobranca_os"
        DDL.DataBind()
    End Sub

    Public Function VerificaFaturamento(ByVal CodTipoCobrancaOs As Integer) As String
        Dim faturado As String
        Dim strSql As String
        Dim dt As DataTable

        strSql = " select isnull(faturado,'N') faturado from tipo_cobranca_os where cod_tipo_cobranca_os = " + CodTipoCobrancaOs.ToString

        dt = ObjAcessoDados.BuscarDados(strSql)

        If dt.Rows.Count > 0 Then
            faturado = dt.Rows.Item(0).Item("faturado").ToString
        Else
            faturado = "E"
        End If

        If CodTipoCobrancaOs = 0 Then
            faturado = "E"
        End If

        Return faturado

    End Function

End Class
