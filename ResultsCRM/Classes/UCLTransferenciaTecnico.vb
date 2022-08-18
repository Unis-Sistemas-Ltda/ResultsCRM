Public Class UCLTransferenciaTecnico

    Private ObjAcessoDados As UCLAcessoDados

    Public Property empresa As String
    Public Property estabelecimento As String
    Public Property cod_transferencia As String
    Public Property cod_pedido_venda As String
    Public Property cod_agente_tecnico As String
    Public Property cod_usuario As String
    Public Property atualizado As String
    Public Property aprovada As String
    Public Property datahora As String
    Public Property d_datahora As Date
    Public Property h_datahora As String

    Public Sub New(ByVal StrConn As String)
        ObjAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim StrSql As String
            Dim dt As DataTable

            StrSql = "select cod_pedido_venda, cod_agente_tecnico, cod_usuario, atualizado, aprovada, datahora from transferencia_tecnico f where empresa = " + empresa + " and estabelecimento = " + estabelecimento + " and cod_transferencia = " + cod_transferencia
            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                cod_pedido_venda = dt.Rows.Item(0).Item("cod_pedido_venda").ToString
                cod_agente_tecnico = dt.Rows.Item(0).Item("cod_agente_tecnico").ToString
                cod_usuario = dt.Rows.Item(0).Item("cod_usuario").ToString
                atualizado = dt.Rows.Item(0).Item("atualizado").ToString
                aprovada = dt.Rows.Item(0).Item("aprovada").ToString
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
