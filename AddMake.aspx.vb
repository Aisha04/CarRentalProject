
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient



Public Class Make
    Inherits System.Web.UI.Page


    'call this method to bind gridview
    Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString

    Private Sub BindSubjectData()
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "select MakesId, MakeName, Image" +
                                        " from Makes "

                cmd.Connection = sqlCon
                sqlCon.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                gvModelDtl.DataSource = dt
                gvModelDtl.DataBind()
                sqlCon.Close()
            End Using


        End Using
    End Sub
    Protected Sub gvSubDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvModelDtl.SelectedIndexChanged


        make.SelectedItem.Text = (TryCast(gvModelDtl.SelectedRow.FindControl("lblmake"), Label)).Text
        'make invisible Insert button during update/delete
        btnInsert.Visible = False
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Makeddl()
        lblMsg.Text = ""
        If Not IsPostBack Then
            Makeddl()
            BindSubjectData()
        End If
    End Sub
    Protected Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim IsAdded As Boolean = False
        Dim imagePath As String = ""
        If make.Text = "" Then
            Exit Sub
        End If
        If FileUpload2.HasFile Then
            imagePath = "~/Uploads/" + FileUpload2.FileName
            FileUpload2.SaveAs(Server.MapPath(imagePath))
        End If

        Dim MakeName As String = Convert.ToString(make.SelectedItem.Value)

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "INSERT INTO Makes(MakeName, Image)" & "VALUES(@make_name, @Image)"
                cmd.Parameters.AddWithValue("@make_name", MakeName)
                cmd.Parameters.AddWithValue("@image", imagePath)
                cmd.Connection = sqlCon
                sqlCon.Open()
                IsAdded = cmd.ExecuteNonQuery()
                sqlCon.Close()
            End Using
        End Using
        If IsAdded Then
            lblMsg.Text = "'" & MakeName & "' Make details added successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
        Else
            lblMsg.Text = "Error while adding '" & MakeName & "' Make details"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If
        ResetAll() 'to reset all form controls
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'If String.IsNullOrEmpty(txtMakeId.Text) Then
        '    Exit Sub
        'End If
        Dim IsUpdated As Boolean = False

        Dim make_id As Integer = Convert.ToInt32(txtMakeId.Text)
        Dim Make_name As String = Convert.ToString(make.SelectedItem.Value)

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "UPDATE Makes SET MakeName=@make_name WHERE MakesId=@make_id "
                cmd.Parameters.AddWithValue("@make_name", Make_name)
                cmd.Parameters.AddWithValue("@make_id", make_id)

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsUpdated = cmd.ExecuteNonQuery()
                sqlCon.Close()
            End Using
        End Using
        If IsUpdated Then
            lblMsg.Text = "'" & Make_name & "' Make details updated successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
        Else
            lblMsg.Text = "Error while updating '" & Make_name & "' Make details"
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



        make.Items.Clear()
        BindSubjectData()
    End Sub







    'Protected Sub txtClear_Click(sender As Object, e As EventArgs) Handles txtClear.Click
    '    make.SelectedIndex = "-1"

    'End Sub


    'call this method to bind gridview
    'Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString

    'Private Sub BindSubjectData()
    '    Using sqlCon As New SqlConnection(conn)
    '        Using cmd As New SqlCommand()
    '            cmd.CommandText = "select MakeID, MakeName, Image " + " from Make "
    '            cmd.Connection = sqlCon
    '            sqlCon.Open()
    '            Dim da As New SqlDataAdapter(cmd)
    '            Dim dt As New DataTable()
    '            da.Fill(dt)
    '            gvModelDtl.DataSource = dt
    '            gvModelDtl.DataBind()
    '            sqlCon.Close()
    '        End Using

    '        Using cmd As New SqlCommand()
    '            cmd.CommandText = "select MakeId, MakeName from Make "
    '            cmd.Connection = sqlCon
    '            sqlCon.Open()
    '            Dim da As New SqlDataAdapter(cmd)
    '            Dim dt As New DataTable()
    '            da.Fill(dt)
    '            make.DataSource = dt
    '            make.DataTextField = "MakeName"
    '            make.DataValueField = "MakeId"
    '            make.DataBind()
    '            sqlCon.Close()
    '        End Using
    '    End Using
    'End Sub
    'Protected Sub gvSubDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvModelDtl.SelectedIndexChanged

    '    make.SelectedItem.Text = (TryCast(gvModelDtl.SelectedRow.FindControl("lblDescription"), Label)).Text

    '    'make invisible Insert button during update/delete
    '    btnInsert.Visible = False
    'End Sub


    'Protected Sub txtButton_Click(sender As Object, e As EventArgs) Handles txtButton.Click
    '    If Page.IsValid Then
    '        lblStatus.Text = "Data Saved"
    '        lblStatus.ForeColor = System.Drawing.Color.Green
    '    Else
    '        lblStatus.Text = "Error"
    '        lblStatus.ForeColor = System.Drawing.Color.Red
    '    End If

    'Dim constr As String
    '    constr = ConfigurationManager.ConnectionStrings("connstr").ToString
    '    Dim sqlConn As New SqlConnection(constr)
    '    sqlConn.Open()
    '    Dim sqlCmd As New SqlCommand
    '    sqlCmd.Connection = sqlConn
    '    sqlCmd.CommandText = "Insert into Make(MakeName, Image) values (@MName, @Image)"


    '    Dim mNameParam As New SqlParameter
    '    mNameParam.ParameterName = "@MName"
    '    mNameParam.Value = make.SelectedItem.Value.ToString

    '    Dim imageParam As New SqlParameter
    '    imageParam.ParameterName = "@Image"
    '    imageParam.Value = fileUpload1.FileName

    '    sqlCmd.Parameters.Add(mNameParam)
    '    sqlCmd.Parameters.Add(imageParam)

    '    Dim rowsInserted As Integer = 0

    '    rowsInserted = sqlCmd.ExecuteNonQuery()

    '    If (rowsInserted > 0) Then
    '        Response.Write("Sucessfully Entered")
    '    Else
    '        Response.Write("Failed")

    '    End If

    '    sqlConn.Close()




    'Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    Makeddl()



    'End Sub





    Public Sub Makeddl()
        Dim li1 As New ListItem("Toyota")
        Make.Items.Add(li1)
        Dim li2 As New ListItem("Isuzu")
        Make.Items.Add(li2)
        Dim li3 As New ListItem("Jaguar")
        Make.Items.Add(li3)
        Dim li4 As New ListItem("Honda")
        Make.Items.Add(li4)
        Dim li5 As New ListItem("Ford")
        Make.Items.Add(li5)
        Dim li6 As New ListItem("Nissan")
        Make.Items.Add(li6)
        Dim li7 As New ListItem("BMW")
        Make.Items.Add(li7)
        Dim li8 As New ListItem("Mazda")
        Make.Items.Add(li8)
        Dim li9 As New ListItem("Kia")
        Make.Items.Add(li9)
        Dim li10 As New ListItem("Audi")
        Make.Items.Add(li10)
        Dim li11 As New ListItem("Mercedes-Benz")
        Make.Items.Add(li11)
        Dim li12 As New ListItem("Peugeot")
        Make.Items.Add(li12)
        Dim li13 As New ListItem("Porche")
        make.Items.Add(li12)

    End Sub





End Class