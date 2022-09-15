Partial Public Class WFNegociacaoFiltro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objEtapaNegociacao As New UCLEtapaNegociacao
            Dim objAgente As New UCLAgenteVendas
            Dim objItem As New UCLItem
            Dim objAcao As New UCLAcaoFollowUp
            Dim objStatus As New UCLStatusNegociacao
            Dim objFunil As New UCLFunilVenda
            Dim objCarteira As New UCLCarteiraCRM
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objFonte As New UCLFonteOrigem
            Dim objMarca As New UCLMarca

            TxtDataCadastramentoI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtDataCadastramentoF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtDataRecontatoI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtDataRecontatoF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")

            If Not IsPostBack Then
                objEtapaNegociacao.Empresa = Session("GlEmpresa")
                objEtapaNegociacao.FillDropDown(DdlEtapa, True, "(Todas)")

                objEmitente.FillDropDown(DdlVendedor, True, "(Todos)", UCLEmitente.TipoEmitenteDDL.Representante, "0", False, UCLEmitente.TipoExibicaoDDL.Nome, Session("GlCodGestor"))

                If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
                    DdlVendedor.SelectedValue = Session("GlCodEmitenteExterno")
                    DdlVendedor.Enabled = False
                    objAgente.FillDropDown(ddlAgente, True, "(Todos)", 0, UCLAgenteVendas.TipoRestricaoAcesso.SemRestricao)
                ElseIf Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Regional Then
                    objAgente.FillDropDown(ddlAgente, True, "(Todos)", Session("GlCodUsuario"), UCLAgenteVendas.TipoRestricaoAcesso.SemRestricao)
                    'ddlAgente.SelectedValue = Session("GlCodEmitenteExterno")
                Else
                    If Session("GlAgenteVendaMaster") = "S" OrElse Session("GlRestricaoAcessoAgenteVenda") = 0 Then
                        objAgente.FillDropDown(ddlAgente, True, "(Todos)", 0, UCLAgenteVendas.TipoRestricaoAcesso.SemRestricao)
                    Else
                        objAgente.FillDropDown(ddlAgente, True, "(Todos)", Session("GlCodUsuario"), UCLAgenteVendas.TipoRestricaoAcesso.SomenteOProprioAgenteDeVendasNoCRMeNoResults)
                    End If
                End If
                
                objMarca.FillDropDown(DdlMarca, True, "(Todas)", 0)
                objFonte.FillDropDown(DdlFonteOrigem, True, "(Todas)")
                objItem.FillDropDown(ddlItem, True, "(Todos)")
                'objAcao.FillDropDown(ddlAcao, True, "(Todas)")
                objFunil.FillDropDown(ddlFunil, True, "(Todos)", Session("GlEmpresa"), Session("GlCodUsuario"))
                objCarteira.FillControl(DdlCarteira, True, "(Todas)")

                objStatus.FillDropDown(DdlStatusNegociacao, True, "(Todos)")

                objAgente.Codigo = Session("GlCodUsuario")
                objAgente.Buscar()

                Session("S_PNG_ddlFunil") = objAgente.CodFunil

                Call AplicaFiltro(False)
                Call AplicaFiltro(True)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AplicaFiltro(ByVal postback As Boolean)
        Try
            If postback Then
                For Each ctrl As Control In Me.Page.Form.Controls
                    If TypeOf ctrl Is TextBox Then
                        Session("S_PNG_" + ctrl.ID) = CType(ctrl, TextBox).Text
                    ElseIf TypeOf ctrl Is DropDownList Then
                        Session("S_PNG_" + ctrl.ID) = CType(ctrl, DropDownList).SelectedValue
                    ElseIf TypeOf ctrl Is CheckBox Then
                        Session("S_PNG_" + ctrl.ID) = CType(ctrl, CheckBox).Checked
                    ElseIf TypeOf ctrl Is Menu Then
                        Session("S_PNG_" + ctrl.ID) = CType(ctrl, Menu).SelectedValue
                    End If
                Next
                Session("S_PNG_ddlFunil") = ddlFunil.SelectedValue
                Session("S_PNG_DdlEtapa") = DdlEtapa.SelectedValue
                Call CarregaFrame(WUCFrameNegociacao, MnuTipoVisualizacao.SelectedValue + "?t=" + Now().ToString("yyyyMMddHHmmssfff"))
            Else
                For Each ctrl As Control In Me.Page.Form.Controls
                    If TypeOf ctrl Is TextBox Then
                        If Session("S_PNG_" + ctrl.ID) IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("S_PNG_" + ctrl.ID).ToString) Then
                            CType(ctrl, TextBox).Text = Session("S_PNG_" + ctrl.ID)
                        End If
                    ElseIf TypeOf ctrl Is DropDownList Then
                        If Session("S_PNG_" + ctrl.ID) IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("S_PNG_" + ctrl.ID).ToString) Then
                            CType(ctrl, DropDownList).SelectedValue = Session("S_PNG_" + ctrl.ID)
                        End If
                    ElseIf TypeOf ctrl Is CheckBox Then
                        If Session("S_PNG_" + ctrl.ID) IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("S_PNG_" + ctrl.ID).ToString) Then
                            CType(ctrl, CheckBox).Checked = Session("S_PNG_" + ctrl.ID)
                        End If
                    ElseIf TypeOf ctrl Is Menu Then
                        If Session("S_PNG_" + ctrl.ID) IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("S_PNG_" + ctrl.ID).ToString) Then
                            For i As Long = 0 To CType(ctrl, Menu).Items.Count - 1
                                If CType(ctrl, Menu).Items.Item(i).Value = Session("S_PNG_" + ctrl.ID) Then
                                    CType(ctrl, Menu).Items.Item(i).Selected = True
                                Else
                                    CType(ctrl, Menu).Items.Item(i).Selected = False
                                End If
                            Next
                        End If
                    End If
                    ddlFunil.SelectedValue = Session("S_PNG_ddlFunil")
                    DdlEtapa.SelectedValue = Session("S_PNG_DdlEtapa")
                    DdlTop.SelectedValue = 200
                Next
                Call CarregaFrame(WUCFrameNegociacao, MnuTipoVisualizacao.SelectedValue + "?t=" + Now().ToString("yyyyMMddHHmmssfff"))
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Protected Sub BtnAplicarFiltro_Click(sender As Object, e As EventArgs) Handles BtnAplicarFiltro.Click
        Try
            Call AplicaFiltro(True)
            Session("SCodAtendimento") = ""
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub MnuTipoVisualizacao_MenuItemClick(sender As Object, e As System.Web.UI.WebControls.MenuEventArgs) Handles MnuTipoVisualizacao.MenuItemClick
        Try
            Dim erro As Boolean = False
            Select Case CType(sender, Menu).SelectedValue
                Case "WGNegociacaoPipe.aspx"
                    If ddlFunil.SelectedValue = "0" Then
                        LblErro.Text = "Selecione o funil para prosseguir."
                        MnuTipoVisualizacao.Items.Item(0).Selected = True
                        MnuTipoVisualizacao.Items.Item(1).Selected = False
                        erro = True
                    End If
            End Select

            If Not erro Then
                Call AplicaFiltro(True)
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnNovoRegistro_Click(sender As Object, e As EventArgs) Handles BtnNovoRegistro.Click
        Session("SCodAtendimento") = ""
        Session("SAcaoNegociacao") = "INCLUIR"
        Session("SCodNegociacao") = -1
        Response.Redirect("WFNegociacaoDetalhes.aspx?b=WFNegociacaoFiltro.aspx")
    End Sub

    Protected Sub BtnRedirect_Click(sender As Object, e As EventArgs) Handles BtnRedirect.Click
        Response.Redirect(Session("SRedir"))
    End Sub

    Protected Sub ddlFunil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFunil.SelectedIndexChanged
        Try
            Dim objEtapaNegociacao As New UCLEtapaNegociacao
            objEtapaNegociacao.Empresa = Session("GlEmpresa")
            objEtapaNegociacao.FillDropDown(DdlEtapa, True, "(Todas)", ddlFunil.SelectedValue, "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class