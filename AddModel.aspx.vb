

Imports System.Data.SqlClient
    Imports System.Data
    Partial Class AddModel
        Inherits System.Web.UI.Page
        'call this method to bind gridview
        Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString

        Private Sub BindSubjectData()
            Using sqlCon As New SqlConnection(conn)
                Using cmd As New SqlCommand()
                cmd.CommandText = "select ModelId, ModelName, Images, MakeName, TypesName" +
                                        " from Models " +
                                   " join Makes on MakeId = MakesId " +
                                    " join Types as t on t.id = [TypeId] "
                cmd.Connection = sqlCon
                    sqlCon.Open()
                    Dim da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    gvModelDtl.DataSource = dt
                    gvModelDtl.DataBind()
                    sqlCon.Close()
                End Using

                Using cmd As New SqlCommand()
                cmd.CommandText = "select MakesId, MakeName from Makes  "
                cmd.Connection = sqlCon
                    sqlCon.Open()
                    Dim da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    ddlMake.DataSource = dt
                ddlMake.DataTextField = "MakeName"
                ddlMake.DataValueField = "MakesId"
                ddlMake.DataBind()
                    sqlCon.Close()
                End Using
            Using cmd As New SqlCommand()
                cmd.CommandText = "select Id, TypesName from Types  "
                cmd.Connection = sqlCon
                sqlCon.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                ddlType.DataSource = dt
                ddlType.DataTextField = "TypesName"
                ddlType.DataValueField = "Id"
                ddlType.DataBind()
                sqlCon.Close()
            End Using
        End Using
        End Sub
        Protected Sub gvSubDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvModelDtl.SelectedIndexChanged
        'txtModelId.Text = gvModelDtl.DataKeys(gvModelDtl.SelectedRow.RowIndex).Value.ToString()
        txtModelName.Text = (TryCast(gvModelDtl.SelectedRow.FindControl("lblmodel_name"), Label)).Text
        ddlMake.SelectedItem.Text = (TryCast(gvModelDtl.SelectedRow.FindControl("lblMake"), Label)).Text
        ddlType.SelectedItem.Text = (TryCast(gvModelDtl.SelectedRow.FindControl("lblType"), Label)).Text
            'make invisible Insert button during update/delete
            btnInsert.Visible = False
        End Sub
        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            lblMsg.Text = ""
            If Not IsPostBack Then
                BindSubjectData()
            End If
        End Sub
        Protected Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim IsAdded As Boolean = False
        Dim imagePath As String = ""
        If txtModelName.Text = "" Then
            Exit Sub
        End If
        If FileUpload1.HasFile Then
            imagePath = "~/Uploads/" + FileUpload1.FileName
            FileUpload1.SaveAs(Server.MapPath(imagePath))
        End If
        Dim ModelName As String = txtModelName.Text.Trim()
        Dim MakeId As Integer = Convert.ToInt32(ddlMake.SelectedItem.Value)
        Dim TypeId As String = Convert.ToInt32(ddlType.SelectedItem.Value)
        Using sqlCon As New SqlConnection(conn)
                Using cmd As New SqlCommand()
                cmd.CommandText = "INSERT INTO Models(ModelName, Images, MakeId, TypeId)" & "VALUES(@model_name, @Images, @make_id, @Type_id)"
                cmd.Parameters.AddWithValue("@model_name", ModelName)
                cmd.Parameters.AddWithValue("@make_id", MakeId)
                cmd.Parameters.AddWithValue("@Type_id", TypeId)
                cmd.Parameters.AddWithValue("@images", imagePath)
                cmd.Connection = sqlCon
                    sqlCon.Open()
                    IsAdded = cmd.ExecuteNonQuery()
                    sqlCon.Close()
                End Using
            End Using
            If IsAdded Then
            lblMsg.Text = "'" & ModelName & "' Model details added successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
            Else
            lblMsg.Text = "Error while adding '" & ModelName & "' Model details"
            lblMsg.ForeColor = System.Drawing.Color.Red
            End If
            ResetAll() 'to reset all form controls
        End Sub
        Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'If String.IsNullOrEmpty(txtModelId.Text) Then
        '    Exit Sub
        'End If
        Dim IsUpdated As Boolean = False
        Dim model_id As Integer = Convert.ToInt32(ModelId.SelectedItem.Value)
        Dim Model_name As String = txtModelName.Text.Trim()
            Dim Make_id As Integer = Convert.ToInt32(ddlMake.SelectedItem.Value)
            Dim Type_id As Integer = Convert.ToInt32(ddlType.SelectedItem.Value)
            Using sqlCon As New SqlConnection(conn)
                Using cmd As New SqlCommand()
                cmd.CommandText = "UPDATE Models SET ModelName=@model_name," &
                                        "MakeId=@make_id,TypeId=@type_id WHERE ModelId=@model_id"
                cmd.Parameters.AddWithValue("@model_name", Model_name)
                    cmd.Parameters.AddWithValue("@make_id", Make_id)
                    cmd.Parameters.AddWithValue("@type_id", Type_id)
                cmd.Parameters.AddWithValue("@model_id", model_id)
                cmd.Connection = sqlCon
                    sqlCon.Open()
                    IsUpdated = cmd.ExecuteNonQuery()
                    sqlCon.Close()
                End Using
            End Using
            If IsUpdated Then
            lblMsg.Text = "'" & Model_name & "' Model details updated successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
            Else
            lblMsg.Text = "Error while updating '" & Model_name & "' Model details"
            lblMsg.ForeColor = System.Drawing.Color.Red
            End If
            gvModelDtl.EditIndex = -1
            ResetAll() 'to reset all form controls
        End Sub
        Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        End Sub
        Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            ResetAll()
        End Sub
        'call to reset all form controls
        Private Sub ResetAll()
            btnInsert.Visible = True
            txtModelName.Text = ""
        'txtModelId.Text = ""
        ddlType.Items.Clear()
            ddlMake.Items.Clear()
            BindSubjectData()
        End Sub
    End Class


