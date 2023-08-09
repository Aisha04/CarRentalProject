
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Login1
    Inherits System.Web.UI.Page

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim connStr As String
        Dim dReader As SqlDataReader
        connStr = ConfigurationManager.ConnectionStrings("ConnStr").ToString
        Dim con As New SqlConnection(connStr)
        Dim cmd As New SqlCommand
        cmd.CommandText = "select Role, FirstName from [Users] where UserName=@username and Password =@password"


        cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = txtUserName.Text
        cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtPassword.Text
        cmd.Connection = con

        con.Open()
        dReader = cmd.ExecuteReader()

        If dReader.HasRows Then
            dReader.Read()
            Session("UserName") = txtUserName.Text
            Session("FirstName") = dReader("FirstName").ToString
            If dReader("Role").Equals("C") Then
                Response.Redirect("~/Home.aspx")
            ElseIf dReader("Role").Equals("A") Then
                'Session("UserName") = txtUserName.Text
                Response.Redirect("~/AdminHome.aspx")
            End If
        Else
            MsgBox("invalid username or Pasword")
        End If


    End Sub


End Class