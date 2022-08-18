Public Class UCLContratoManutencaoItem
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("contrato_manutencao_item")
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal Empresa As String, ByVal Contrato As String, ByVal CodItem As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        If String.IsNullOrWhiteSpace(Contrato) OrElse String.IsNullOrWhiteSpace(Empresa) Then
            Return
        End If

        strSql += " select cmi.cod_item, i.descricao || ' (' || cmi.cod_item || ')' descricao_item "
        strSql += "   from contrato_manutencao_item cmi inner join item i on cmi.cod_item = i.cod_item "
        strSql += "  where cmi.contrato     = '" + Contrato + "'"
        strSql += "    and cmi.empresa      = " + Empresa
        strSql += "    and isnull(cmi.tipo_horas,0) in (0,3) "
        strSql += "  order by descricao_item "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If Not String.IsNullOrWhiteSpace(CodItem) Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_item") = CodItem
            Dim objItem As New UCLItem
            objItem.CodItem = CodItem
            objItem.Buscar()
            NovaLinha("descricao_item") = objItem.Descricao
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_item") = ""
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao_item") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao_item"
        DDL.DataValueField = "cod_item"
        DDL.DataBind()
    End Sub

    Public Function GetTipoHorasItemContrato(ByVal pEmpresa As String, ByVal pCodContrato As String, ByVal pCodItem As String) As String
        Try
            Dim t As String
            Dim seqItem As String
            Dim StrSql As String = " select item from contrato_manutencao_item where empresa = " + pEmpresa + " and contrato = '" + pCodContrato + "' and cod_item = '" + pCodItem + "'"
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                seqItem = dt.Rows.Item(0).Item("item").ToString
                Me.SetConteudo("empresa", pEmpresa)
                Me.SetConteudo("contrato", pCodContrato)
                Me.SetConteudo("item", seqItem)
                If Not Me.Buscar() Then
                    t = "0"
                Else
                    If Me.IsNull("tipo_horas") Then
                        t = "0"
                    Else
                        t = Me.GetConteudo("tipo_horas").ToString
                    End If
                End If
            Else
                t = "0"
            End If

            Return t
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
