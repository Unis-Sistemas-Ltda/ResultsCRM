Partial Public Class WFCliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call Carrega()
        End If
    End Sub

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGCliente.aspx")
    End Sub

    Private Sub CarregaFrame(ByVal frame As WUCFrame, ByVal pagina As String)
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.DataBind()
    End Sub

    Public Sub Carrega()
        CarregaFrame(FrameSuperior, "WFClienteCabecalho.aspx?embeeded=False&vcodemi=SCodEmitente&vcodemp=SCodClientePesquisado&valtecc=SAlterouCodCliente&vrecdc=SRecarregaDdlContatos&ccodcon=SCodContatoNegociacao&cnpjemi=SCNPJEmitente&vcodemin=SCodEmitenteNegociacao")
        CarregaFrame(FrameInferior, "WFClienteDetalhes.aspx")
    End Sub

End Class