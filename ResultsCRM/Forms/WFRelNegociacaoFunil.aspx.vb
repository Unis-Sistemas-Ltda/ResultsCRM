Imports Sybase.DataWindow
Imports Sybase.DataWindow.Web

Partial Public Class WFRelNegociacaoFunil
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(Session("SCodItemPesquisado")) Then
            If Session("SAlterouCodItem") = "S" Then
                If TxtCodItem.Text <> Session("SCodItemPesquisado") Then
                    TxtCodItem.Text = Session("SCodItemPesquisado")
                End If
                Session("SAlterouCodItem") = "N"
            End If
        End If

        If Not IsPostBack Then
            Call CarregaAgentesVenda(0)
            Call CarregaCanalVenda()
            Call CarregaVendedores()
            Call CarregaFunilInicial()
            Call CarregaFunilFinal()
            Call CarregaStatus()
            TxtData1.Text = "01/01/" + Now.Year.ToString
            TxtData2.Text = "31/12/" + Now.Year.ToString
        End If

        Call MostraDescricaoItem()
    End Sub

    Private Sub MostraDescricaoItem()
        Dim ObjItem As New UCLItem
        ObjItem.CodItem = TxtCodItem.Text
        ObjItem.Buscar()
        LblDescricaoItem.Text = ObjItem.Descricao
        LblDescricaoItem.DataBind()
    End Sub

    Private Sub CarregaStatus()
        Dim objStatus As New UCLStatusNegociacao
        objStatus.FillDropDown(DdlStatus, True, "")
    End Sub

    Private Sub CarregaAgentesVenda(ByVal codAgenteVenda As String)
        Dim objAgente As New UCLAgenteVendas
        If Session("GlAgenteVendaMaster") = "S" OrElse Session("GlRestricaoAcessoAgenteVenda") = 0 Then
            objAgente.FillDropDown(ddlAgenteVenda, True, "(Todos)", 0, UCLAgenteVendas.TipoRestricaoAcesso.SemRestricao)
        Else
            objAgente.FillDropDown(ddlAgenteVenda, True, "(Todos)", Session("GlCodUsuario"), UCLAgenteVendas.TipoRestricaoAcesso.SomenteOProprioAgenteDeVendasNoCRMeNoResults)
        End If
    End Sub

    Private Sub CarregaCanalVenda()
        Dim objCanalVenda As New UCLCanalVenda
        objCanalVenda.Empresa = Session("GlEmpresa")
        objCanalVenda.FillControl(ddlCanalVenda, True, "")
    End Sub

    Private Sub CarregaFunilInicial()
        Dim objEtapaNegociacao As New UCLEtapaNegociacao
        objEtapaNegociacao.Empresa = Session("GlEmpresa")
        objEtapaNegociacao.FillDropDown(ddlEtapaInicial, True, "")
    End Sub

    Private Sub CarregaFunilFinal()
        Dim objEtapaNegociacao As New UCLEtapaNegociacao
        objEtapaNegociacao.Empresa = Session("GlEmpresa")
        objEtapaNegociacao.FillDropDown(ddlEtapaFinal, True, "")
    End Sub

    Private Sub CarregaVendedores()
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        objEmitente.FillDropDown(ddlRepresentante, True, "", UCLEmitente.TipoEmitenteDDL.Representante, "0", False, UCLEmitente.TipoExibicaoDDL.Nome, Session("GlCodGestor"))
    End Sub

    Protected Sub BtnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(TxtData1.Text) Or String.IsNullOrEmpty(TxtData2.Text) Then
            lblErro.Text = "Preencha o período."
            Return
        End If

        If DdlModelo.SelectedValue = "3" Then
            Response.Redirect("WFRelNegociacaoFunilReport.aspx?" & _
                          "data1=" & ValidaCampo("TxtData1", TxtData1.Text) & _
                          "&data2=" & ValidaCampo("TxtData2", TxtData2.Text) & _
                          "&etapai=" & ValidaCampo("DdlEtapaInicial", ddlEtapaInicial.SelectedValue) & _
                          "&etapaf=" & ValidaCampo("DdlEtapaFinal", ddlEtapaFinal.SelectedValue) & _
                          "&agente=" & ValidaCampo("DdlAgenteVenda", ddlAgenteVenda.SelectedValue) & _
                          "&status=" & ValidaCampo("DdlStatus", ddlStatus.SelectedValue) & _
                          "&representante=" & ValidaCampo("DdlRepresentante", ddlRepresentante.SelectedValue) & _
                          "&canal=" & ValidaCampo("DdlCanalVenda", ddlCanalVenda.SelectedValue) & _
                          "&item=" & ValidaCampo("TxtCodItem", TxtCodItem.Text) & _
                          "&mod=" & DdlModelo.SelectedValue)
        Else
            Response.Redirect("WFRelNegociacaoFunilRel.aspx?data1=" & TxtData1.Text & "&data2=" & TxtData2.Text & "&etapai=" & ddlEtapaInicial.SelectedValue & "&etapaf=" & ddlEtapaFinal.SelectedValue & "&agente=" & ddlAgenteVenda.SelectedValue & "&status=" & ddlStatus.SelectedValue & "&representante=" & ddlRepresentante.SelectedValue & "&item=" & TxtCodItem.Text & "&mod=" & DdlModelo.SelectedValue)
        End If

    End Sub

    Protected Sub DdlModelo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlModelo.SelectedIndexChanged
        If DdlModelo.SelectedValue = "2" Then
            TxtCodItem.Text = ""
            LblDescricaoItem.Text = ""
            TxtCodItem.Enabled = False
            BtnFiltrarItem.Enabled = False
        Else
            TxtCodItem.Enabled = True
            BtnFiltrarItem.Enabled = True
        End If
    End Sub

    Private Function ValidaCampo(ByVal nomeCampo As String, conteudo As String) As String
        Try
            Select Case nomeCampo
                Case "TxtData1"
                    If String.IsNullOrWhiteSpace(conteudo) Then
                        Return "01/01/1900"
                    End If
                Case "TxtData2"
                    If String.IsNullOrWhiteSpace(conteudo) Then
                        Return "31/12/2999"
                    End If
                Case "DdlEtapaInicial", "DdlAgenteVenda", "DdlStatus", "DdlRepresentante"
                    If String.IsNullOrWhiteSpace(conteudo) Then
                        Return "0"
                    End If
                Case "DdlEtapaFinal"
                    If String.IsNullOrWhiteSpace(conteudo) OrElse conteudo = "0" Then
                        Return "999"
                    End If
            End Select
            Return conteudo
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class