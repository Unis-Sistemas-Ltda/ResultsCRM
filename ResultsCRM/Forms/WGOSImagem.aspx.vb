Public Class WGOSImagem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView4_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView4.RowCommand
        If e.CommandName = "EXCLUIR" Then
            Dim ObjUsuario As New UCLUsuario
            Dim ObjPedidoVendaImagem As New UCLPedidoVendaImagem(StrConexaoUsuario(Session("GlUsuario")))
            Dim autorizado As Boolean = False

            ObjUsuario.CodUsuario = Session("GlCodUsuario")
            If ObjUsuario.BuscarPorCodigo() Then
                If ObjUsuario.Situacao = UCLUsuario.SituacaoUsuario.Administrador Or ObjUsuario.Situacao = UCLUsuario.SituacaoUsuario.Liberado Then
                    autorizado = True
                End If
            End If

            If autorizado Then
                ObjPedidoVendaImagem.Empresa = Session("GlEmpresa")
                ObjPedidoVendaImagem.Estabelecimento = Session("GlEstabelecimento")
                ObjPedidoVendaImagem.CodPedidoVenda = Session("SAtCodPedido")
                ObjPedidoVendaImagem.SeqImagem = e.CommandArgument
                ObjPedidoVendaImagem.Excluir()
                GridView4.DataBind()
                GridView4.DataBind()
            Else
                LblErro.Text = "Usuário sem permissão para excluir imagem."
            End If
        End If
    End Sub

    Private Sub GridView5_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView5.RowCommand
        If e.CommandName = "EXCLUIR" Then
            Dim ObjUsuario As New UCLUsuario
            Dim ObjPedidoVendaImagem As New UCLPedidoVendaImagem(StrConexaoUsuario(Session("GlUsuario")))

            Dim autorizado As Boolean = False

            ObjUsuario.CodUsuario = Session("GlCodUsuario")
            If ObjUsuario.BuscarPorCodigo() Then
                If ObjUsuario.Situacao = UCLUsuario.SituacaoUsuario.Administrador Or ObjUsuario.Situacao = UCLUsuario.SituacaoUsuario.Liberado Then
                    autorizado = True
                End If
            End If
            If autorizado Then
                ObjPedidoVendaImagem.Empresa = Session("GlEmpresa")
                ObjPedidoVendaImagem.Estabelecimento = Session("GlEstabelecimento")
                ObjPedidoVendaImagem.CodPedidoVenda = Session("SAtCodPedido")
                ObjPedidoVendaImagem.SeqImagem = e.CommandArgument
                ObjPedidoVendaImagem.Excluir()
                GridView5.DataBind()
                GridView5.DataBind()
            Else
                LblErro.Text = "Usuário sem permissão para excluir imagem."
            End If
        End If
    End Sub
End Class