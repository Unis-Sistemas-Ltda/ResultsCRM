Public Class WFRelPrevisaoFechamento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call CarregaPais()
                Call CarregaEstado()
                Call CarregaCidade()
                Call CarregaVendedores("0", False)
                Call CarregaCanalVenda()
                Call CarregaStatus()
                Call CarregaFunil()
            End If
        Catch ex As Exception
            lblErro.Text = ex.Message
        End Try
    End Sub

    Public Sub CarregaCidade()
        Try
            Dim objCidade As New UCLCidade
            objCidade.CodPais = DdlPais.SelectedValue
            objCidade.CodEstado = DdlEstado.SelectedValue
            objCidade.FillDropDown(DdlCidade, True, "(Todas)")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CarregaEstado()
        Try
            Dim ObjEstado As New UCLEstado
            ObjEstado.CodPais = DdlPais.SelectedValue
            ObjEstado.FillDropDown(DdlEstado, True, "(Todos)", UCLEstado.Tipo.NomeEstado)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CarregaPais()
        Try
            Dim ObjPais As New UCLPais
            ObjPais.FillDropDown(DdlPais, True, "(Todos)")

            Dim objEstabelecimento As New UCLEstabelecimento
            objEstabelecimento.CodEmpresa = Session("GlEmpresa")
            objEstabelecimento.Estabelecimento = Session("GlEstabelecimento")
            objEstabelecimento.Buscar()
            DdlPais.SelectedValue = objEstabelecimento.CodPais
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaVendedores(ByVal codRepresentante As String, ByVal MostraInativos As Boolean)
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            objEmitente.FillDropDown(ddlRepresentante, True, "(Todos)", UCLEmitente.TipoEmitenteDDL.Representante, codRepresentante, MostraInativos, UCLEmitente.TipoExibicaoDDL.Nome, Session("GlCodGestor"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaStatus()
        Try
            Dim objStatus As New UCLStatusNegociacao
            objStatus.FillDropDown(DdlStatus, True, "(Todos)")
            DdlStatus.SelectedValue = "0"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaCanalVenda()
        Try
            Dim objCanalVenda As New UCLCanalVenda
            objCanalVenda.Empresa = Session("GlEmpresa")
            objCanalVenda.FillControl(ddlCanalVenda, True, "(Todos)")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFunil()
        Try
            Dim objFunil As New UCLFunilVenda
            objFunil.FillDropDown(DdlFunil, True, "(Todos)", Session("GlEmpresa"), Session("GlCodUsuario"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlPais.SelectedIndexChanged
        Try
            Call CarregaEstado()
            Call CarregaCidade()
        Catch ex As Exception
            lblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub DdlEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlEstado.SelectedIndexChanged
        Try
            Call CarregaCidade()
        Catch ex As Exception
            lblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        Response.Redirect("WFRelPrevisaoFechamentoRel.aspx?t=" + Now.ToString("yyyyMMddHHmmssfff") + "&da1=" + TxtData1.Text + "&da2=" + TxtData2.Text + "&re=" + ddlRepresentante.SelectedValue + "&ca=" + ddlCanalVenda.SelectedValue + "&pr1=" + TxtProbabilidadeSucesso1.Text + "&pr2=" + TxtProbabilidadeSucesso2.Text + "&st=" + GetStatus() + "&pa=" + DdlPais.SelectedValue + "&es=" + DdlEstado.SelectedValue + "&ci=" + DdlCidade.SelectedValue+ "&fu=" + DdlFunil.SelectedValue)
    End Sub

    Private Function GetStatus() As String
        Try
            Dim ret As String = ""
            For i As Long = 0 To DdlStatus.Items.Count - 1
                If DdlStatus.Items.Item(i).Selected Then
                    ret += DdlStatus.Items.Item(i).Value + ","
                End If
            Next
            If ret.Length > 0 Then
                ret = Left(ret, ret.Length - 1)
            End If
            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class