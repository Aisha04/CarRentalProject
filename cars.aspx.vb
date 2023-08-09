Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient


Public Class cars
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.BindRepeater()
        End If

    End Sub

    Private Sub BindRepeater()
        Dim constr As String = ConfigurationManager.ConnectionStrings("connStr").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("GetModels", con)
                Using sda As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    cmd.CommandType = CommandType.StoredProcedure
                    sda.Fill(dt)
                    rptCustomers.DataSource = dt
                    rptCustomers.DataBind()
                End Using
            End Using
        End Using
    End Sub



End Class