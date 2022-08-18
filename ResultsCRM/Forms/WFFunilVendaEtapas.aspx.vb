Public Class WFFunilVendaEtapas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim ObjFunil As New UCLFunilVenda
            ObjFunil.Empresa = Session("GlEmpresa")
            ObjFunil.Codigo = Session("SCodFunil")
            ObjFunil.Buscar()
            LblDescricaoFunil.Text = ObjFunil.Descricao
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function Gravar() As Boolean
        Try
            Dim ObjFunilEtapa As New UCLFunilVendaEtapaNegociacao

            For i As Long = 0 To GridView1.Rows.Count - 1
                Dim CbxMarcado As CheckBox = CType(GridView1.Rows.Item(i).FindControl("CbxMarcado"), CheckBox)
                If CbxMarcado.Checked Then
                    ObjFunilEtapa.Excluir(Session("GlEmpresa"), Session("SCodFunil"), CType(GridView1.Rows.Item(i).FindControl("LblCodEtapa"), Label).Text)
                    ObjFunilEtapa.Incluir(Session("GlEmpresa"), Session("SCodFunil"), CType(GridView1.Rows.Item(i).FindControl("LblCodEtapa"), Label).Text, CType(GridView1.Rows.Item(i).FindControl("TxtSequencia"), TextBox).Text)
                Else
                    ObjFunilEtapa.Excluir(Session("GlEmpresa"), Session("SCodFunil"), CType(GridView1.Rows.Item(i).FindControl("LblCodEtapa"), Label).Text)
                End If
            Next

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub Voltar()
        Response.Redirect("WGFunilVenda.aspx")
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