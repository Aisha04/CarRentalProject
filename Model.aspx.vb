Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Model
    Inherits System.Web.UI.Page
    'Protected Sub txtClear_Click(sender As Object, e As EventArgs) Handles txtClear.Click
    '    model.Text = ""
    '    Make.SelectedIndex = "-1"


    'End Sub

    'Protected Sub txtButton_Click(sender As Object, e As EventArgs) Handles txtButton.Click
    '    If Page.IsValid Then
    '        lblStatus.Text = "Data Saved"
    '        lblStatus.ForeColor = System.Drawing.Color.Green
    '    Else
    '        lblStatus.Text = "Error"
    '        lblStatus.ForeColor = System.Drawing.Color.Red
    '    End If

    'End Sub
    Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblMsg.Text = ""
        If Not IsPostBack Then
            BindSubjectData()
        End If
    End Sub
    'call this method to bind gridview
    Private Sub BindSubjectData()

        If Not Me.IsPostBack Then
            Dim conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString
            Using con As New SqlConnection(conn)
                Using cmd As New SqlCommand("SELECT MakesId, MakeName FROM Makes")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    Using sda As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet()
                        sda.Fill(ds)
                        Make.DataSource = ds.Tables(0)
                        Make.DataTextField = "MakeName"
                        Make.DataValueField = "MakeId"
                        Make.DataBind()
                    End Using
                End Using
            End Using
            Make.Items.Insert(0, New ListItem("--Select Make--", "0"))
        End If
    End Sub

    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim IsAdded As Boolean = False
        Dim ModelName As String = model.Text.Trim()
        Dim Images As String = fileUpload2.FileName
        Dim MakeName As String = Make.Text
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "INSERT INTO Model(ModelName,Images)" & "VALUES(@ModelName,@images)"
                cmd.Parameters.AddWithValue("@ModelName", ModelName)
                cmd.Parameters.AddWithValue("@images", Images)

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsAdded = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using
        If IsAdded Then
            lblMsg.Text = "'" & MakeName & "' subject details added successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green

            BindSubjectData()
        Else
            lblMsg.Text = "Error while adding '" & MakeName & "' subject details"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If
        ResetAll() 'to reset all form controls
    End Sub

    'Update click event to update existing record from the gridview
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
        If String.IsNullOrEmpty(model.Text) Then
            lblMsg.Text = "Please select record to update"
            lblMsg.ForeColor = System.Drawing.Color.Red
            Return
        End If
        Dim IsUpdated As Boolean = False

        Dim ModelName As String = model.Text.Trim()
        Dim Images As String = fileUpload2.FileName
        Dim MakeName As String = Make.Text
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "UPDATE Model SET ModelName=@ModelName," & "Images=@Images, MakeName=@MakeName WHERE ModeName=@ModelName"


                cmd.Parameters.AddWithValue("@ModelName", ModelName)
                cmd.Parameters.AddWithValue("@Images", Images)
                cmd.Parameters.AddWithValue("@MakeName", MakeName)
                cmd.Connection = sqlCon
                sqlCon.Open()
                IsUpdated = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using
        If IsUpdated Then
            lblMsg.Text = "'" & ModelName & "' subject details updated successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
        Else
            lblMsg.Text = "Error while updating '" & ModelName & "' subject details"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If
        gvSubDetails.EditIndex = -1
        BindSubjectData()
        ResetAll() 'to reset all form controls
    End Sub

    'Delete click event to delete selected record from the database
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
        If String.IsNullOrEmpty(model.Text) Then
            lblMsg.Text = "Please select record to delete"
            lblMsg.ForeColor = System.Drawing.Color.Red
            Return
        End If
        Dim IsDeleted As Boolean = False


        Dim ModelName As String = model.Text.Trim()
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "DELETE FROM Model WHERE ModelName=@SModelName"
                cmd.Parameters.AddWithValue("@ModelName", ModelName)
                cmd.Connection = sqlCon
                sqlCon.Open()
                IsDeleted = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using
        If IsDeleted Then
            lblMsg.Text = "'" & ModelName & "' subject details deleted successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
            BindSubjectData()
        Else
            lblMsg.Text = "Error while deleting '" & ModelName & "' subject details"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If
        ResetAll() 'to reset all form controls
    End Sub

    'Cancel click event to clear and reset all the textboxes
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        ResetAll() 'to reset all form controls
    End Sub

    Protected Sub gvSubDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        'txtSubjectId.Text = gvSubDetails.DataKeys(gvSubDetails.SelectedRow.RowIndex).Value.ToString()
        model.Text = (TryCast(gvSubDetails.SelectedRow.FindControl("model"), Label)).Text
        'fileUpload2.FileName = (TryCast(gvSubDetails.SelectedRow.FindControl("fileUpload2"), FileUpload)).FileName

        Make.Text = (TryCast(gvSubDetails.SelectedRow.FindControl("make"), Label)).Text
        'make invisible Insert button during update/delete
        btnInsert.Visible = False
    End Sub

    'call to reset all form controls
    Private Sub ResetAll()
        btnInsert.Visible = True
        model.Text = ""
        'fileUpload2.FileName = ""
        Make.Text = ""

    End Sub


End Class