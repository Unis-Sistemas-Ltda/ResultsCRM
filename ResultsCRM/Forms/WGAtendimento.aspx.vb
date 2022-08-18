Partial Public Class WGAtendimento
    Inherits System.Web.UI.Page
    Dim objParametrosManutencao As New UCLParametrosManutencao
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objTipoChamado As New UCLTipoChamado
            Dim objStatusChamado As New UCLStatusChamado
            Dim objAnalista As New UCLAnalista

            Session("SSequenciaEmail") = "0"

            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))
            Dim modeloChamadoCRM As String = objParametrosManutencao.GetConteudo("modelo_chamado_crm")
            If modeloChamadoCRM = "" Then
                modeloChamadoCRM = 0
            End If
            If modeloChamadoCRM = 2 OrElse modeloChamadoCRM = 3 OrElse modeloChamadoCRM = 4 Then
                TxtPontoDeAtendimento.Visible = False
                GridView1.Columns.Item(2).Visible = False
                'GridView1.Columns.Item(3).Visible = False
                GridView1.Columns.Item(5).Visible = False
                GridView1.Columns.Item(6).Visible = False
                GridView1.Columns.Item(7).Visible = False
                GridView1.Columns.Item(17).Visible = True
                GridView1.Columns.Item(21).Visible = False
                LblPontoAtend.Text = "Reabertura:"
                DdlReabertura.Visible = True
                ddlRegiao.Visible = False
                LblRegiaoAtend.Visible = False
            Else
                GridView1.Columns.Item(7).Visible = True
                GridView1.Columns.Item(17).Visible = False
                LblPontoAtend.Text = "Ponto Atend.:"
                DdlReabertura.Visible = False
                TxtPontoDeAtendimento.Visible = True
                GridView1.Columns.Item(21).Visible = True
                ddlRegiao.Visible = True
                LblRegiaoAtend.Visible = True
            End If

            If Not IsPostBack Then
                Call CarregaRegiao()
                Call CarregaAnalista()
                Call CarregaUsuarioInclusao()
                Call CarregaTecnico()
                Call CarregaSLA()
                objTipoChamado.FillDropDown(Session("GlEmpresa"), ddlTipoChamado, True, "(Todos)", -1)
                objStatusChamado.FillDropDown(DdlStatus, True, "(Todos)", -1, UCLStatusChamado.TipoDropDown.Completo, "0")
                Call CarregaContatos()
                Call AplicaFiltro(False)

                If Session("GlClienteUnis") = 47 Then
                    DdlTop.SelectedValue = "999999"
                    DdlTop.Visible = False
                    GridView1.AllowPaging = True
                End If
            End If

            objAnalista.Codigo = Session("GlCodUsuario")
            If Not objAnalista.Buscar OrElse objAnalista.Inativo = "S" Then
                LblErro.Text = "ACESSO NEGADO.<br/><br/>Prezado usuário<br>Para ter acesso ao painel de atendimentos, é necessário que você solicite à pessoa responsável o seu cadastramento como analista no Results."
                GridView1.Visible = False
                BtnNovoRegistro.Visible = False
                TxtNrAtendimento.Enabled = False
                DdlStatus.Enabled = False
                ddlTipoStatus.Enabled = False
                TxtCodEmitente.Enabled = False
                TxtNomeEmitente.Enabled = False
                DdlContato.Enabled = False
                ddlTipoChamado.Enabled = False
                ddlAnalista.Enabled = False
                TxtAssunto.Enabled = False
                DdlTop.Enabled = False
            End If

            Session.Remove("SCodEmitente")
            Session.Remove("SCNPJEmitente")
            Session("SAssuntoChamado") = ""

        Catch ex As Exception
            LblErro.Text = ex.ToString
        End Try
    End Sub

    Private Sub Colore()
        Dim LblDesobrigadoSLA As Label
        Dim LblDesobrigadoSLACor As Label
        Dim LblTipoStatus As Label
        Dim LblDias As Label
        Dim QtdID1 As Long = 0
        Dim QtdID2 As Long = 0
        Dim QtdID3 As Long = 0
        Dim QtdID4 As Long = 0
        Dim QtdID5 As Long = 0
        Dim QtdDes As Long = 0
        Dim QtdTotal As Long = 0
        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                QtdTotal += 1

                Select Case (CType(row.FindControl("LblIDTipo"), Label).Text)
                    Case "1"
                        QtdID1 += 1
                    Case "2"
                        QtdID2 += 1
                    Case "3"
                        QtdID3 += 1
                    Case "4"
                        QtdID4 += 1
                    Case "5"
                        QtdID5 += 1
                End Select

                LblTipoStatus = CType(row.FindControl("LblTipoStatus"), Label)
                LblDias = CType(row.FindControl("LblDias"), Label)
                LblDesobrigadoSLA = CType(row.FindControl("LblDesobrigadoSLA"), Label)
                LblDesobrigadoSLACor = CType(row.FindControl("LblDesobrigadoSLACor"), Label)

                If LblDesobrigadoSLA.Text = "S" Then
                    QtdDes += 1
                    LblDesobrigadoSLACor.BackColor = Drawing.Color.Red
                    LblDesobrigadoSLACor.ForeColor = Drawing.Color.Red
                    LblDesobrigadoSLACor.ToolTip = "Este chamado excedeu a quantidade de chamados prevista na SLA para esta data e seu atendimento dentro do prazo previsto na SLA fica desobrigado."
                End If

                If LblTipoStatus.Text = "3" Then
                    row.ForeColor = Drawing.Color.Green
                Else
                    If LblTipoStatus.Text = "4" Then
                        row.ForeColor = Drawing.Color.Gray
                    Else
                        If LblDesobrigadoSLA.Text <> "S" Then
                            If CDbl(LblDias.Text) < 0 Then
                                row.ForeColor = Drawing.Color.Red
                            ElseIf CDbl(LblDias.Text) = 0 Then
                                row.ForeColor = Drawing.Color.Blue
                            End If
                        End If
                    End If
                End If
            End If
        Next

        LblQtdAtendimentosEncerrados.Text = QtdID1.ToString("N0")
        LblQtdAtendimentosPrazoVencido.Text = QtdID2.ToString("N0")
        LblQtdAtendimentosPrazoFuturo.Text = QtdID3.ToString("N0")
        LblQtdAtendimentosHoje.Text = QtdID4.ToString("N0")
        LblQtdAtendimentosCancelados.Text = QtdID5.ToString("N0")
        LblQtdAtendimentosTotal.Text = QtdTotal.ToString("N0")
        LblQtdAtendimentosDesobrigados.Text = QtdDes.ToString("N0")
    End Sub

    Private Sub CarregaAnalista()
        Dim objAnalista As New UCLAnalista
        objAnalista.FillDropDown(ddlAnalista, True, "(Todos)", -1, True, False, -1, "")

        If objParametrosManutencao.GetConteudo("filtro_todos_analistas") = "S" Then
            ddlAnalista.Items.FindByValue(-1).Selected = True
        Else
            If ddlAnalista.Items.FindByValue(Session("GlCodUsuario")) IsNot Nothing Then
                ddlAnalista.Items.FindByValue(Session("GlCodUsuario")).Selected = True
            End If
        End If
    End Sub

    Private Sub CarregaUsuarioInclusao()
        Dim objAnalista As New UCLAnalista
        objAnalista.FillDropDown(DdlIncluidoPor, True, "(Todos)", -1, True, False, -1, "")
        DdlIncluidoPor.SelectedValue = -1
    End Sub

    Private Sub CarregaTecnico()
        Dim objAgTecnico As New UCLAgenteTecnico
        objAgTecnico.FillDropDown(ddlAgenteTecnico, True, "(Todos)", -1)
    End Sub

    Private Sub CarregaSLA()
        Try
            Dim objSla As New UCLSLA
            objSla.FillDropDown(ddlsla, True, "(Todos)")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaRegiao()
        Dim objRegiao As New UCLRegiao
        objRegiao.FillDropDown(Session("GlEmpresa"), ddlRegiao, True, "(Todas)")
    End Sub

    Private Sub GridView1_DataBound(sender As Object, e As System.EventArgs) Handles GridView1.DataBound
        Call Colore()
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SCodAtendimento") = e.CommandArgument
            Session("SAcao") = "ALTERAR"
            Session("SModoAbertura") = 0
            Session("SCamVoltar") = "WGAtendimento.aspx"
            Response.Redirect("WFAtendimento.aspx")
        ElseIf e.CommandName = "TRANSFERIR" Then
            Session("SCodAtendimento") = e.CommandArgument
            Session("SAcao") = "TRANSFERIR"
            Session("SModoAbertura") = 0
            Session("SCamVoltar") = "WGAtendimento.aspx"
            Response.Redirect("WFAtendimentoTransferencia.aspx")
        End If
    End Sub

    'Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
    '    Session("SAcao") = "INCLUIR"
    '    Session("SCodAtendimento") = -1
    '    Session("SModoAbertura") = 0
    '    Session("SCamVoltar") = "WGAtendimento.aspx"
    '    Response.Redirect("WFAtendimento.aspx")
    'End Sub

    Protected Sub AplicaFiltro(ByVal postback As Boolean)
        Try
            If postback Then
                For Each ctrl As Control In CType(Me.Page.Form.Controls.Item(3), UpdatePanel).Controls.Item(0).Controls
                    If TypeOf ctrl Is TextBox Then
                        Session("S_PCH_" + ctrl.ID) = CType(ctrl, TextBox).Text
                    ElseIf TypeOf ctrl Is Label Then
                        If ctrl.ID = "LblData" Then
                            Session("S_PCH_" + ctrl.ID) = CType(ctrl, Label).Text
                        End If
                    ElseIf TypeOf ctrl Is DropDownList Then
                        Session("S_PCH_" + ctrl.ID) = CType(ctrl, DropDownList).SelectedValue
                    End If
                Next
            Else
                For Each ctrl As Control In CType(Me.Page.Form.Controls.Item(3), UpdatePanel).Controls.Item(0).Controls
                    If TypeOf ctrl Is TextBox Then
                        If Session("S_PCH_" + ctrl.ID) IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("S_PCH_" + ctrl.ID).ToString) Then
                            CType(ctrl, TextBox).Text = Session("S_PCH_" + ctrl.ID)
                        End If
                    ElseIf TypeOf ctrl Is Label Then
                        If ctrl.ID = "LblData" Then
                            If Session("S_PCH_" + ctrl.ID) IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("S_PCH_" + ctrl.ID).ToString) Then
                                CType(ctrl, Label).Text = Session("S_PCH_" + ctrl.ID)
                            End If
                        End If
                    ElseIf TypeOf ctrl Is DropDownList Then
                        If Session("S_PCH_" + ctrl.ID) IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("S_PCH_" + ctrl.ID).ToString) Then
                            CType(ctrl, DropDownList).SelectedValue = Session("S_PCH_" + ctrl.ID)
                        End If
                    End If
                Next
            End If

            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
            Call Colore()
        Catch ex As Exception
            LblErro.Text = ex.ToString
        End Try
    End Sub

    Private Sub CarregaContatos()
        Try
            Dim objContato As New UCLContato
            objContato.CodEmitente = TxtCodEmitente.Text
            objContato.FillDropDown(DdlContato, True, "(Todos)", -1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtCodEmitente_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCodEmitente.TextChanged
        Call CarregaContatos()
    End Sub

    Protected Sub TxtDataI_TextChanged(sender As Object, e As EventArgs) Handles TxtDataI.TextChanged
        If Not String.IsNullOrWhiteSpace(TxtDataI.Text) And Not isValidDate(TxtDataI.Text) Then
            LblErro.Text = "Preencha corretamente a data inicial."
        Else
            If isValidDate(TxtDataI.Text) Then
                LblData.Text = TxtDataI.Text.PadRight(10, " ")
            Else
                LblData.Text = "01/01/1901"
            End If
            If isValidDate(TxtDataF.Text) Then
                LblData.Text += TxtDataF.Text.PadRight(10, " ")
            Else
                LblData.Text += "31/12/2999"
            End If
        End If
    End Sub

    Protected Sub TxtDataF_TextChanged(sender As Object, e As EventArgs) Handles TxtDataF.TextChanged
        If Not String.IsNullOrWhiteSpace(TxtDataF.Text) And Not isValidDate(TxtDataF.Text) Then
            LblErro.Text = "Preencha corretamente a data final."
        Else
            If isValidDate(TxtDataI.Text) Then
                LblData.Text = TxtDataI.Text.PadRight(10, " ")
            Else
                LblData.Text = "01/01/1901"
            End If
            If isValidDate(TxtDataF.Text) Then
                LblData.Text += TxtDataF.Text.PadRight(10, " ")
            Else
                LblData.Text += "31/12/2999"
            End If
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(sender As Object, e As EventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodAtendimento") = -1
        Session("SModoAbertura") = 0
        Session("SCamVoltar") = "WGAtendimento.aspx"
        Response.Redirect("WFAtendimento.aspx")
    End Sub

    Protected Sub BtnPesquisar_Click(sender As Object, e As EventArgs) Handles BtnPesquisar.Click
        Call AplicaFiltro(True)
    End Sub

    Protected Sub BtnLimparFiltro_Click(sender As Object, e As EventArgs) Handles BtnLimparFiltro.Click
        TxtNrAtendimento.Text = ""
        TxtOSCliente.Text = ""
        TxtOSInterna.Text = ""
        TxtDataI.Text = ""
        TxtDataF.Text = ""
        TxtCodEmitente.Text = ""
        TxtNomeEmitente.Text = ""
        TxtPontoDeAtendimento.Text = ""
        TxtAssunto.Text = ""
        TxtObservacao.Text = ""
        ddlTipoChamado.SelectedValue = "-1"
        ddlTipoStatus.SelectedValue = "12"
        DdlStatus.SelectedValue = "-1"
        CarregaAnalista()
        CarregaUsuarioInclusao()
        CarregaTecnico()
    End Sub
End Class