Public Class UCLTransferenciaTecnicoRemessa

    Private ObjAcessoDados As UCLAcessoDados

    Public Property empresa As String
    Public Property estabelecimento As String
    Public Property cod_transferencia As String
    Public Property seq_transferencia As String
    Public Property cod_item As String
    Public Property lote As String
    Public Property referencia As String
    Public Property quantidade As String
    Public Property quantidade_pendente As String
    Public Property datahora As String
    Public Property cod_usuario As String
    Public Property qtd_retorno As String
    Public Property cod_solicitacao As String
    Public Property status As String
    Public Property d_datahora As Date
    Public Property h_datahora As String

    Public Sub New(ByVal StrConn As String)
        ObjAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim StrSql As String
            Dim dt As DataTable

            StrSql = "select cod_item, lote, referencia, quantidade, datahora, cod_usuario, qtd_retorno, cod_solicitacao, status, convert(numeric(12,2),isnull(f.quantidade,0) - isnull((select sum(quantidade) from transferencia_tecnico_baixa b where b.empresa = f.empresa and b.estabelecimento = f.estabelecimento and b.cod_transferencia = f.cod_transferencia and b.seq_transferencia = f.seq_transferencia),0)) quantidade_pendente from transferencia_tecnico_remessa f where empresa = " + empresa + " and estabelecimento = " + estabelecimento + " and cod_transferencia = " + cod_transferencia + " and seq_transferencia = " + seq_transferencia
            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                cod_item = dt.Rows.Item(0).Item("cod_item").ToString
                lote = dt.Rows.Item(0).Item("lote").ToString
                referencia = dt.Rows.Item(0).Item("referencia").ToString
                quantidade = dt.Rows.Item(0).Item("quantidade").ToString
                cod_usuario = dt.Rows.Item(0).Item("cod_usuario").ToString
                qtd_retorno = dt.Rows.Item(0).Item("qtd_retorno").ToString
                cod_solicitacao = dt.Rows.Item(0).Item("cod_solicitacao").ToString
                quantidade_pendente = dt.Rows.Item(0).Item("quantidade_pendente").ToString
                status = dt.Rows.Item(0).Item("status").ToString
                If Not IsDBNull(dt.Rows.Item(0).Item("datahora")) Then
                    datahora = CType(dt.Rows.Item(0).Item("datahora"), DateTime).ToString("dd/MM/yyyy HH:mm:ss")
                    d_datahora = CDate(dt.Rows.Item(0).Item("datahora"))
                    h_datahora = CType(dt.Rows.Item(0).Item("datahora"), DateTime).ToString("HH:mm:ss")
                Else
                    datahora = ""
                    d_datahora = Nothing
                    h_datahora = ""
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
