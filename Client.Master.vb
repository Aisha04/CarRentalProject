Public Class Client
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("Username") Is Nothing Then
            lblWelcome.Text = "Welcome " + Session("FirstName")
            sign.Text = "Sign Out"
        Else
            lblWelcome.Text = " "
            sign.Text = "Sign In"
        End If


    End Sub



    Private Sub sign_Click(sender As Object, e As EventArgs) Handles sign.Click
        If Not Session("Username") Is Nothing Then
            Session.Remove("Username")
            Session.Remove("Full_Name")
            Response.Redirect("~/Login1.aspx")
        Else
            Response.Redirect("~/Login1.aspx")
        End If
    End Sub




End Class