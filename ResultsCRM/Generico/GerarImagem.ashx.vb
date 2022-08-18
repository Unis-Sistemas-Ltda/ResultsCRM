Imports System.Web
Imports System.Web.Services
Imports System.Web.UI.Page

Public Class GerarImagem
    Implements System.Web.IHttpHandler

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim objAcessoDados As New UCLAcessoDados(StrConexao)
        Dim dt As DataTable

        If String.IsNullOrEmpty(context.Request.QueryString("id")) Then
            context.Response.ContentType = "text/plain"
            context.Response.Write("Está faltando a querystring id.")
        Else
            Try
                dt = objAcessoDados.BuscarDados("select imagem from item where cod_item = '" + context.Request.QueryString("id") + "'")
                If Not IsDBNull(dt.Rows.Item(0).Item("Imagem")) Then
                    context.Response.ContentType = "image/jpg"
                    context.Response.Clear()
                    context.Response.BinaryWrite(dt.Rows.Item(0).Item("Imagem"))
                Else
                    context.Response.ContentType = "text/plain"
                    context.Response.Write("(imagem não disponível)")
                End If
            Catch ex As Exception
            End Try
        End If

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class