Public Class WGClientesNaoAtendidos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaEstabelecimentos()
            Call CarregaRepresentantes()
            Session("SJaComprou") = "N"
            Session("SEstab_i") = 0
            Session("SRep_i") = 0
            Session("SEstab_f") = 9999
            Session("SRep_f") = 9999999
            Session("SPeriodo_i") = DateAndTime.Today.AddDays(-180)
            Session("SPeriodo_f") = DateAndTime.Today
            TxtDataPeriodoI.Text = DateAndTime.Today.AddDays(-180).ToShortDateString()
            TxtDataPeriodoF.Text = DateAndTime.Today.ToShortDateString()
        End If
    End Sub

    Protected Sub AplicaFiltro()

        If TxtDataPeriodoI.Text = "" Then
            LblErro.Text = "Informe a data de Inicio da pesquisa"
            Return
        End If
        If TxtDataPeriodoF.Text = "" Then
            LblErro.Text = "Informe a data final da pesquisa"
            Return
        End If
        Session("SJaComprou") = CBxJaComprou.Checked.ToString.Replace("False", "N").Replace("True", "S")
        If DDlRepresentante_f.SelectedValue > 0 Then
            Session("SRep_i") = DDlRepresentante_f.SelectedValue
        Else
            Session("SRep_i") = 0
        End If
        If DDlRepresentante_f.SelectedValue > 0 Then
            Session("SRep_f") = DDlRepresentante_f.SelectedValue
        Else
            Session("SRep_f") = 999999
        End If
        If DdlEstabelecimento_f.SelectedValue > 0 Then
            Session("SEstab_i") = DdlEstabelecimento_f.SelectedValue
        Else
            Session("SEstab_i") = 1
        End If
        If DdlEstabelecimento_f.SelectedValue > 0 Then

            Session("SEstab_f") = DdlEstabelecimento_f.SelectedValue
        Else
            Session("SEstab_f") = 9999
        End If
        Session("SPeriodo_i") = Convert.ToDateTime(TxtDataPeriodoI.Text)
        Session("SPeriodo_f") = Convert.ToDateTime(TxtDataPeriodoF.Text)
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim params As String() = {"", "", "", "", "", ""}
        Dim dt As DataTable



        If e.CommandName = "GERAR" Then

            If CheckBox1.Checked And DdlAgenteVendas.SelectedValue = "" Then
                LblErro.Text = "Informe o Agente de Vendas"
                Return
            End If
            params = e.CommandArgument.ToString().Split(";")
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            Session("SCodEmitente") = params(0)
            Session("SCNJPEmitente") = params(1)
            Session("SCodCanalVenda") = params(2)
            Session("SCodNatuOp") = params(3)
            Session("SCodFunil") = params(4)
            If params(5) = "" Then
                Session("SEtapaNeg") = "1"
            Else
                Session("SEtapaNeg") = params(5)
            End If

            'GridView1.DeleteRow(e.CommandSource)


            GetCodEmitente(e.CommandArgument)
            objNegociacao.Empresa = Session("GlEmpresa")
            objNegociacao.Estabelecimento = Session("GlEstabelecimento")
            objNegociacao.CodNegociacao = objNegociacao.GetProximoCodigo
            objNegociacao.Buscar()
            objNegociacao = CarregaObjeto(objNegociacao)
            objNegociacao.Incluir()

            'dt = GridView1.DataSource
            'dt.Rows.RemoveAt(1)
            'GridView1.DataSource = dt
            'GridView1.DataBind()


            LblErro.Text = "<span style=""color:DarkGreen"">Negociação incluída com sucesso.</span>"
            'AplicaFiltro()
        End If
    End Sub

    Protected Function CarregaObjeto(ByRef objNegociacao As UCLNegociacao) As UCLNegociacao
        Try
            Dim dataHoraRecontato As String = ""

            objNegociacao.CodCliente = Session("SCodEmitente")
            objNegociacao.CNPJ = Session("SCNJPEmitente")

            objNegociacao.NumeroSerie = ""
            objNegociacao.CodContato = "null"
            objNegociacao.CodCarteira = "null"
            objNegociacao.CodGestorConta = "null"
            objNegociacao.CodTipoCobrancaOs = "null"
            objNegociacao.CodTipoCobrancaOs = "null"
            objNegociacao.CodMotivo = "null"
            If CheckBox1.Checked Then
                objNegociacao.CodAgenteVenda = DdlAgenteVendas.SelectedValue
            Else
                objNegociacao.CodAgenteVenda = Session("GlCodUsuario")
            End If

            If Session("SCodCanalVenda") = "" Or Session("SCodCanalVenda") = "&nbsp;" Then
                objNegociacao.CodCanalVendas = "null"
            Else
                objNegociacao.CodCanalVendas = Session("SCodCanalVenda")
            End If
            'objNegociacao.CodCanalVendas = Session("SCodCanalVenda")
            'objNegociacao.CodNaturOper = Session("SCodNatuOp")
            If Session("SCodNatuOp") = "" Then
                objNegociacao.CodNaturOper = "null"
            Else
                objNegociacao.CodNaturOper = Session("SCodNatuOp")
            End If
            objNegociacao.CodModelo = "null"
            objNegociacao.GerarPedido = "N"
            objNegociacao.DataValidade = ""
            objNegociacao.DataPrevisaoFechamento = ""
            objNegociacao.ProbabilidadeSucesso = "null"
            objNegociacao.Prioridade = "B"
            objNegociacao.Receptividade = "M"
            objNegociacao.CodFormaPagto = "null"
            objNegociacao.CodCondPagto = "null"
            objNegociacao.CodFonteOrigemNegociacao = "null"
            objNegociacao.CodStatus = "null"


            objNegociacao.Moeda = 1

            objNegociacao.CodRepresentante = "null"

            objNegociacao.CodTipoObra = "null"
            objNegociacao.CodEstagioObra = "null"
            objNegociacao.CodModalidadeObra = "null"
            objNegociacao.TamanhoObra = ""

            objNegociacao.tipo_frete = "2"

            objNegociacao.CodEtapaNegociacao = Session("SEtapaNeg")

            If Session("SCodFunil") = "" Then
                objNegociacao.CodFunil = "null"
            Else
                objNegociacao.CodFunil = Session("SCodFunil")
            End If

            Return objNegociacao
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Private Function GetCodEmitente(ByVal cnpj As String) As String
        Dim cod As String = ""
        Try
            Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
            If Not String.IsNullOrEmpty(cnpj) Then
                cod = objEnderecoEmitente.GetCodEmitente(cnpj)
            End If
            Return cod
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CarregaEstabelecimentos()
        Try
            Dim objEstabelecimento As New UCLEstabelecimento
            objEstabelecimento.CodEmpresa = Session("GlEmpresa")
            objEstabelecimento.FillDropDown(DdlEstabelecimento_i, True, "(Todos)")
            DDlRepresentante_i.SelectedValue = "0"
            objEstabelecimento.FillDropDown(DdlEstabelecimento_f, True, "(Todos)")
            DDlRepresentante_i.SelectedValue = "0"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaRepresentantes()
        Dim objRepresentante As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        objRepresentante.FillDropDown(DDlRepresentante_i, True, "(Todos)", 3, "", True, 1, "")
        DDlRepresentante_i.SelectedValue = "0"
        objRepresentante.FillDropDown(DDlRepresentante_f, True, "(Todos)", 3, "", True, 1, "")
        DDlRepresentante_i.SelectedValue = "0"
    End Sub

    Private Sub CarregaAgentesVenda()
        Dim objAgente As New UCLAgenteVendas
        If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
            objAgente.FillDropDown(DdlAgenteVendas, True, "(Todos)", 0, UCLAgenteVendas.TipoRestricaoAcesso.SemRestricao)
        Else
            If Session("GlAgenteVendaMaster") = "S" OrElse Session("GlRestricaoAcessoAgenteVenda") = 0 Then
                objAgente.FillDropDown(DdlAgenteVendas, True, "(Todos)", 0, UCLAgenteVendas.TipoRestricaoAcesso.SemRestricao)
            Else
                objAgente.FillDropDown(DdlAgenteVendas, True, "(Todos)", Session("GlCodUsuario"), UCLAgenteVendas.TipoRestricaoAcesso.SomenteOProprioAgenteDeVendasNoCRMeNoResults)
            End If
        End If
    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call AplicaFiltro()
    End Sub

    Protected Sub CBxJaComprou_CheckedChanged(sender As Object, e As EventArgs)
        If CBxJaComprou.Checked Then
            Session("SJaComprou") = "S"
        Else
            Session("SJaComprou") = "N"
        End If
    End Sub

    Protected Sub DDlRepresentante_f_SelectedIndexChanged(sender As Object, e As EventArgs)
        If DDlRepresentante_f.SelectedValue > 0 Then
            Session("SRep_f") = DDlRepresentante_f.SelectedValue
        Else
            Session("SRep_f") = 9999
        End If
    End Sub

    Protected Sub DdlEstabelecimento_f_SelectedIndexChanged(sender As Object, e As EventArgs)
        If DdlEstabelecimento_f.SelectedValue > 0 Then
            Session("SEstab_f") = DdlEstabelecimento_f.SelectedValue
        Else
            Session("SEstab_f") = 9999
        End If
    End Sub

    Protected Sub DdlEstabelecimento_i_SelectedIndexChanged(sender As Object, e As EventArgs)
        If DdlEstabelecimento_f.SelectedValue > 0 Then
            Session("SEstab_i") = DdlEstabelecimento_f.SelectedValue
        Else
            Session("SEstab_i") = 1
        End If
    End Sub

    Protected Sub DDlRepresentante_i_SelectedIndexChanged(sender As Object, e As EventArgs)
        If DDlRepresentante_f.SelectedValue > 0 Then
            Session("SRep_i") = DDlRepresentante_f.SelectedValue
        Else
            Session("SRep_i") = 1
        End If
    End Sub

    Protected Sub TxtDataPeriodoI_TextChanged(sender As Object, e As EventArgs)

        Session("SPeriodo_i") = Convert.ToDateTime(TxtDataPeriodoI.Text)

    End Sub

    Protected Sub TxtDataPeriodoF_TextChanged(sender As Object, e As EventArgs)
        Session("SPeriodo_f") = Convert.ToDateTime(TxtDataPeriodoF.Text)
    End Sub

    Private Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting

    End Sub

    Private Sub GridView1_RowDeleted(sender As Object, e As GridViewDeletedEventArgs) Handles GridView1.RowDeleted

    End Sub

    Private Sub SqlDataSource1_Deleted(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Deleted

    End Sub

    Private Sub SqlDataSource1_Deleting(sender As Object, e As SqlDataSourceCommandEventArgs) Handles SqlDataSource1.Deleting

    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CheckBox1.Checked And DdlAgenteVendas.SelectedIndex = 0 Then
            LblErro.Text = "Informe o Agente de Vendas"
            Return
        End If
        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(10).FindControl("chkRow"), CheckBox)
                If chkRow.Checked Then
                    Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
                    Dim objParametros As New UCLParametrosCRM()
                    Dim codEmitente As String = TryCast(row.Cells(0).FindControl("Label1"), Label).Text
                    Dim cnpj As String = TryCast(row.Cells(1).FindControl("Label2"), Label).Text
                    If row.Cells(8).Text = "&nbsp;" Then
                        Session("SCodCanalVenda") = ""
                    Else
                        Session("SCodCanalVenda") = row.Cells(8).Text
                    End If
                    Session("SCodEmitente") = codEmitente
                    Session("SCNJPEmitente") = row.Cells(2).Text
                    Session("SCodCanalVenda") = ""
                    Session("SCodNatuOp") = ""
                    objParametros.Empresa = Session("GlEmpresa")
                    objParametros.Buscar()

                    Session("SCodFunil") = objParametros.CodFunil

                    Session("SEtapaNeg") = objParametros.CodEtapa

                    objNegociacao.Empresa = Session("GlEmpresa")
                    objNegociacao.Estabelecimento = Session("GlEstabelecimento")
                    objNegociacao.CodNegociacao = objNegociacao.GetProximoCodigo
                    objNegociacao.Buscar()
                    objNegociacao = CarregaObjeto(objNegociacao)
                    objNegociacao.Incluir()
                End If
            End If
        Next
        Call AplicaFiltro()
    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Call CarregaAgentesVenda()
            lblAgenteVendas.Visible = True
            DdlAgenteVendas.Visible = True
        Else
            lblAgenteVendas.Visible = False
            DdlAgenteVendas.Visible = False
        End If
    End Sub
End Class