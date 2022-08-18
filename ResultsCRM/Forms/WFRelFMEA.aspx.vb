Public Class WFRelFMEA
    Inherits System.Web.UI.Page

    Private Const NAO_SELECIONADO As String = "0"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim alterouCodCliente As Long
            Dim CodClientePesquisado As String
            If Not String.IsNullOrEmpty(Session("SCodItemPesquisado")) Then
                If Session("SAlterouCodItem") = "S" Then
                    If TxtCodItem.Text <> Session("SCodItemPesquisado") Then
                        TxtCodItem.Text = Session("SCodItemPesquisado")
                        Call CodItemMudou()
                    End If
                    Session("SAlterouCodItem") = "N"
                End If
            End If

            If Not String.IsNullOrEmpty(Session("SAlterouCodCliente")) Then
                alterouCodCliente = Session("SAlterouCodCliente")
            Else
                alterouCodCliente = 0
            End If

            CodClientePesquisado = Session("SCodClientePesquisado")

            If Not String.IsNullOrEmpty(CodClientePesquisado) Then
                If alterouCodCliente > 0 Then
                    If TxtCodCliente.Text <> CodClientePesquisado Then
                        TxtCodCliente.Text = CodClientePesquisado
                        Call CodigoClienteMudou()
                    End If
                    Session("SAlterouCodCliente") = alterouCodCliente - 1
                End If
            End If
            If Not IsPostBack Then
                Dim objGrupoProblema As New UCLGrupoProblema
                objGrupoProblema.FillDropDown(DdlGrupoProblema, Session("GlEmpresa"), True, "(selecione)", NAO_SELECIONADO)

                Dim objProblema As New UCLProblemaPadrao
                objProblema.FillDropDown(DdlProblema, Session("GlEmpresa"), "", True, "(selecione)", NAO_SELECIONADO)

                TxtDataI.Text = "01/" + Today.Month.ToString.PadLeft(2, "0") + "/" + Today.Year.ToString
                TxtDataF.Text = Date.DaysInMonth(Today.Year, Today.Month).ToString.PadLeft(2, "0") + "/" + Today.Month.ToString.PadLeft(2, "0") + "/" + Today.Year.ToString
                GridView1.DataBind()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub TxtCodItem_TextChanged(sender As Object, e As EventArgs) Handles TxtCodItem.TextChanged
        Try
            Call CodItemMudou()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnAplicarFiltro_Click(sender As Object, e As EventArgs) Handles BtnAplicarFiltro.Click
        GridView1.DataBind()
    End Sub

    Private Sub CodItemMudou()
        Try
            Session("SCodItemPesquisado") = TxtCodItem.Text

            Dim objItem As New UCLItem
            objItem.CodItem = TxtCodItem.Text
            objItem.Buscar()
            LblDescricaoItem.Text = objItem.Descricao
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlGrupoProblema_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlGrupoProblema.SelectedIndexChanged
        Try
            Dim objProblema As New UCLProblemaPadrao
            objProblema.FillDropDown(DdlProblema, Session("GlEmpresa"), DdlGrupoProblema.SelectedValue, True, "(selecione)", NAO_SELECIONADO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CodigoClienteMudou()
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))

            If Not String.IsNullOrWhiteSpace(TxtCodCliente.Text) Then
                objEmitente.CodEmitente = TxtCodCliente.Text
                objEmitente.Buscar()
                LblNomeCliente.Text = objEmitente.Nome
            Else
                LblNomeCliente.Text = ""
            End If

            Session("SCodEmitenteNegociacao") = TxtCodCliente.Text
            Session("SCodClientePesquisado") = TxtCodCliente.Text
            Session("SAlterouCodCliente") = 0

            Call CarregaEquipamentoCliente()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtCodCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtCodCliente.TextChanged
        Try
            Call CodigoClienteMudou()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaEquipamentoCliente()
        Try
            Dim objEquipamentoCliente As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objParametrosManutencao As New UCLParametrosManutencao

            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))

            objEquipamentoCliente.Empresa = Session("GlEmpresa")
            objEquipamentoCliente.CodCliente = IIf(String.IsNullOrEmpty(TxtCodCliente.Text), "0", TxtCodCliente.Text)
            objEquipamentoCliente.NumeroPontoAtendimento = ""

            If Session("GlTipoFaturamento").ToString = "G" OrElse objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 4 Then
                objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "-1", UCLEquipamentoCliente.TipoDescricaoEquipamento.DescricaoItem, "0")
            Else
                objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "-1", UCLEquipamentoCliente.TipoDescricaoEquipamento.Observacao, "0")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class