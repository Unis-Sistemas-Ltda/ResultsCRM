Public Class WFGestorContaRepresentante
    Inherits System.Web.UI.Page

    Private Sub WFGestorContaRepresentante_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaFormulario()
        End If
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim objGestor As New UCLGestorConta

            objGestor.Codigo = Session("SCodGestorConta")
            objGestor.Buscar()
            LblNomeGestor.Text = objGestor.Nome
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function Gravar() As Boolean
        Try
            Dim objGestorContaRepresentante As New UCLGestorContaRepresentante

            For i As Long = 0 To GridView1.Rows.Count - 1
                Dim CbxMarcado As CheckBox = CType(GridView1.Rows.Item(i).FindControl("CbxMarcado"), CheckBox)
                If CbxMarcado.Checked Then
                    objGestorContaRepresentante.Excluir(Session("SCodGestorConta"), CType(GridView1.Rows.Item(i).FindControl("LblCodRepresentante"), Label).Text)
                    objGestorContaRepresentante.Incluir(Session("SCodGestorConta"), CType(GridView1.Rows.Item(i).FindControl("LblCodRepresentante"), Label).Text)
                Else
                    objGestorContaRepresentante.Excluir(Session("SCodGestorConta"), CType(GridView1.Rows.Item(i).FindControl("LblCodRepresentante"), Label).Text)
                End If
            Next

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub Voltar()
        Response.Redirect("WGGestorConta.aspx")
    End Sub

    Protected Sub BtnVoltar_Click(sender As Object, e As EventArgs) Handles BtnVoltar.Click
        Call Voltar()
    End Sub

    Protected Sub BtnGravar_Click(sender As Object, e As EventArgs) Handles BtnGravar.Click
        Try
            If Gravar() Then
                Call Voltar()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    
End Class