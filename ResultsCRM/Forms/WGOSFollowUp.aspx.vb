Partial Public Class WGOSFollowUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call SetaParaInclusao()
            Call CarregaCabecalho()
        Else
            Call MantemCabecalhoCarregado()
        End If
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "ALTERAR" Then
                Session("SPdSeqFollowUP") = e.CommandArgument
                Session("SAcaoPdFollowUP") = "ALTERAR"
                Call CarregaCabecalho()
            ElseIf e.CommandName = "EXCLUIR" Then
                Dim ObjFollowUP As New UCLFollowUpEmitente(StrConexaoUsuario(Session("GlUsuario")))
                Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))

                objPedido.empresa = Session("GlEmpresa")
                objPedido.estabelecimento = Session("GlEstabelecimento")
                objPedido.codPedidoVenda = Session("SAtCodPedido")
                objPedido.Buscar()

                If objPedido.statusDigitacao = "2" Then
                    Mensagem("OS já está encerrada. Não foi possível excluir follow-up.")
                Else
                    ObjFollowUP.Empresa = Session("GlEmpresa")
                    ObjFollowUP.Estabelecimento = Session("GlEstabelecimento")
                    ObjFollowUP.SeqFollowUP = e.CommandArgument
                    ObjFollowUP.Excluir()
                    
                    Mensagem("Follow-up excluído com sucesso!")

                    SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                    SqlDataSource1.DataBind()
                    GridView1.DataBind()

                    Call SetaParaInclusao()
                    Call CarregaCabecalho()
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub SetaParaInclusao()
        If Session("SAtCodPedido") <> -1 Then
            Session("SPdSeqFollowUP") = -1
            Session("SAcaoPdFollowUP") = "INCLUIR"
        Else
            Mensagem("Antes de adicionar um follow-up, você deve salvar o cabeçalho da OS.")
            WUCFollowUP1.Visible = False
        End If
    End Sub

    Private Sub Mensagem(ByVal texto As String)
        If Not String.IsNullOrEmpty(texto) Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('" + texto + "');", True)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "", True)
        End If
    End Sub

    Protected Sub MantemCabecalhoCarregado()
        Try
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            objPedido.empresa = Session("GlEmpresa")
            objPedido.estabelecimento = Session("GlEstabelecimento")
            objPedido.codPedidoVenda = Session("SAtCodPedido")
            objPedido.Buscar()

            WUCFollowUP1.Empresa = Session("GlEmpresa")
            WUCFollowUP1.Estabelecimento = Session("GlEstabelecimento")
            WUCFollowUP1.CodPedidoVenda = Session("SAtCodPedido")
            WUCFollowUP1.SeqFollowUp = Session("SPdSeqFollowUP")
            WUCFollowUP1.Acao = Session("SAcaoPdFollowUP")
            WUCFollowUP1.CodEmitente = objPedido.codEmitente
            WUCFollowUP1.CaminhoVoltar = "WGOSFollowUp.aspx"

            
            Session("SCodAtendimento") = objPedido.codChamado
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            objChamado.Empresa = objPedido.empresa
            objChamado.CodChamado = objPedido.codChamado
            If Not String.IsNullOrEmpty(objChamado.Empresa) AndAlso Not String.IsNullOrEmpty(objChamado.CodChamado) Then
                If objChamado.Buscar() Then
                    Session("SCodEmitenteAtNegociacao") = objChamado.CodEmitenteAtendimento
                    Session("SCNPJEmitenteAtendimento") = objChamado.CnpjAtendimento
                End If
            End If
            
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CarregaCabecalho()
        Try
            Call MantemCabecalhoCarregado()
            Call WUCFollowUP1.Carregar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

End Class