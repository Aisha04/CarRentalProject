Imports System.Data.SqlClient
Imports System.Data

Public Class Type
    Inherits System.Web.UI.Page


    Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString

    Private Sub BindSubjectData()
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                'cmd.CommandText = "select t.Id, TypesName" +
                '    " from Types as t "
                '                " join Makes as m on m.id = MakeId "

                cmd.CommandText = "select Id, TypesName, MakeName" +
                    " from Types  " +
                               " join Makes on MakeId = MakesId "


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
                'cmd.CommandText = "select m.Id, MakeName from Makes as m  "
                cmd.CommandText = "select MakesId, MakeName from Makes  "
                cmd.Connection = sqlCon
                sqlCon.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                ddlMake1.DataSource = dt
                ddlMake1.DataTextField = "MakeName"
                ddlMake1.DataValueField = "MakesId"
                ddlMake1.DataBind()
                sqlCon.Close()
            End Using

        End Using
    End Sub
    Protected Sub gvSubDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvModelDtl.SelectedIndexChanged
        'txtModelId.Text = gvModelDtl.DataKeys(gvModelDtl.SelectedRow.RowIndex).Value.ToString()
        'Dim a As String = (TryCast(gvModelDtl.SelectedRow.FindControl("lblmake5"), Label)).Text
        'MsgBox(a)
        TName.Text = (TryCast(gvModelDtl.SelectedRow.FindControl("lbltype"), Label)).Text
        ddlMake1.SelectedItem.Text = (TryCast(gvModelDtl.SelectedRow.FindControl("lblmake2"), Label)).Text

        'ddlMake1.Items.FindByText("BMW").Selected = True


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

        If TName.Text = "" Then
            Exit Sub
        End If

        Dim TypesName As String = TName.Text.Trim()
        Dim MakeId As Integer = Convert.ToInt32(ddlMake1.SelectedItem.Value)

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "INSERT INTO Types(TypesName, MakeId)" & "VALUES(@type_name, @make_id )"
                cmd.Parameters.AddWithValue("@type_name", TypesName)
                cmd.Parameters.AddWithValue("@make_id", MakeId)

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsAdded = cmd.ExecuteNonQuery()
                sqlCon.Close()
            End Using
        End Using
        If IsAdded Then
            lblMsg.Text = "'" & TypesName & "' Type details added successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
        Else
            lblMsg.Text = "Error while adding '" & TypesName & "' Type details"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If
        ResetAll() 'to reset all form controls
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'If String.IsNullOrEmpty(txtModelId.Text) Then
        '    Exit Sub
        'End If
        Dim IsUpdated As Boolean = False
        'Dim model_id As Integer = Convert.ToInt32(txtModelId.Text)
        Dim Type_name As String = TName.Text.Trim()
        Dim Make_id As Integer = Convert.ToInt32(ddlMake1.SelectedItem.Value)

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "UPDATE Types SET TypesName=@type_name," &
                                        "MakeId=@make_id WHERE Id=@type_id"

                cmd.Parameters.AddWithValue("@make_id", Make_id)
                cmd.Parameters.AddWithValue("@type_name", Type_name)


                cmd.Connection = sqlCon
                sqlCon.Open()
                IsUpdated = cmd.ExecuteNonQuery()
                sqlCon.Close()
            End Using
        End Using
        If IsUpdated Then
            lblMsg.Text = "'" & Type_name & "' Type details updated successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
        Else
            lblMsg.Text = "Error while updating '" & Type_name & "' Type details"
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
        TName.Text = ""

        ddlMake1.Items.Clear()
        BindSubjectData()
    End Sub





End Class