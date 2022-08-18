Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Linq

Partial Public Class WFPClienteCNPJ
    Inherits System.Web.UI.Page
    Dim Controle As String
    Dim Comando As String
    Dim VariavelArmazenamentoPesquisaEmitente As String
    Dim VariavelArmazenamentoPesquisaCNPJ As String
    Dim VariavelArmazenamentoAlteracao As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Controle = Request.QueryString.Item("textbox").ToString
        MultiViewExpanse.ActiveViewIndex = 0
        VariavelArmazenamentoPesquisaEmitente = Request.QueryString.Item("varmp").ToString
        VariavelArmazenamentoPesquisaCNPJ = Request.QueryString.Item("varmpc").ToString
        VariavelArmazenamentoAlteracao = Request.QueryString.Item("varma").ToString
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            Dim cnpj As String
            Dim emitente As String
            Dim retorno As String
            If e.CommandName = "SELECIONAR" Then
                retorno = e.CommandArgument
                If retorno.IndexOf("§") >= 0 Then
                    emitente = retorno.Substring(0, retorno.IndexOf("§"))
                    cnpj = retorno.Substring(retorno.IndexOf("§") + 1)
                    Session(VariavelArmazenamentoPesquisaEmitente) = emitente
                    Session(VariavelArmazenamentoPesquisaCNPJ) = cnpj
                    Session(VariavelArmazenamentoAlteracao) = CDbl(IIf(Not String.IsNullOrEmpty(Session(VariavelArmazenamentoAlteracao)), 0, Session(VariavelArmazenamentoAlteracao))) + 2
                    ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtFornecedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNome.TextChanged
        TxtNome.Text = TxtNome.Text
    End Sub

    Protected Sub BtnFiltrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnFiltrar.Click
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub

    Protected Sub btnOkay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOkay.Click
        Try
            MultiViewExpanse.ActiveViewIndex = 0
            ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)

        Catch ex As Exception

            ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onError();", True)
            MultiViewExpanse.ActiveViewIndex = 0
        End Try
    End Sub

End Class