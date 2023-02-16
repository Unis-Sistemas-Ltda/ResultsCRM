Public Class WGNegociacaoItemFormula
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'Dim objParametrosCRM As New UCLParametrosCRM
                'objParametrosCRM.Empresa = Session("GlEmpresa")
                'If objParametrosCRM.Buscar() Then
                '    If objParametrosCRM.ItensNegociacaoFormatoPlanilha = "S" Then
                '        BtnListarItens.Visible = True
                '    Else
                '        BtnListarItens.Visible = False
                '    End If
                'End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim objNegociacaoItemFormula As New UCLNegociacaoItemFormula(StrConexaoUsuario(Session("GlUsuario")))
        If e.CommandName = "ALTERAR" Then
            Session("SSeqFormula") = e.CommandArgument
            Session("SAcaoItem") = "ALTERAR"
            Response.Redirect("WFNegociacaoItemFormula.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            objNegociacaoItemFormula.Empresa = Session("GlEmpresa")
            objNegociacaoItemFormula.Estabelecimento = Session("SEstabelecimentoNegociacao")
            objNegociacaoItemFormula.CodNegociacao = Session("SCodNegociacao")
            objNegociacaoItemFormula.SeqItem = Session("SSeqItemNegociacao")
            objNegociacaoItemFormula.SeqFormula = e.CommandArgument
            objNegociacaoItemFormula.Excluir()
            Response.Redirect("WGNegociacaoItemFormula.aspx") 'Autorrecarregamento
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNovoRegistro.Click
        If Session("SCodNegociacao") <> -1 Then
            Session("SSeqFormula") = -1
            Session("SAcaoItem") = "INCLUIR"
            Response.Redirect("WFNegociacaoItemFormula.aspx")
        Else
            LblErro.Text = "Não é permitido incluir um registro de item antes de salvar o cabeçalho da negociação."
        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("WGNegociacaoItem.aspx")
    End Sub
End Class