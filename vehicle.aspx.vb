Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient


Public Class vehicle
    Inherits System.Web.UI.Page
    'call this method to bind gridview
    Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString

    Private Sub BindSubjectData()
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                'cmd.CommandText = "select t.Id, TypesName" +
                '    " from Types as t "
                '                " join Makes as m on m.id = MakeId "

                cmd.CommandText = "select VehicleId, RegistrationNumber, Color, NumberOfDoors, Available, SeatCapacity, FuelType, Engine, PricePerDay, ModelName" +
                    " from Vehicle " +
                               " join Models on ModelsId = ModelId "

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
                cmd.CommandText = "select ModelId, ModelName from Models  "
                cmd.Connection = sqlCon
                sqlCon.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                Model.DataSource = dt
                Model.DataTextField = "ModelName"
                Model.DataValueField = "ModelId"
                Model.DataBind()
                sqlCon.Close()
            End Using


        End Using
    End Sub
    Protected Sub gvSubDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvModelDtl.SelectedIndexChanged
        'txtModelId.Text = gvModelDtl.DataKeys(gvModelDtl.SelectedRow.RowIndex).Value.ToString()
        'Dim a As String = (TryCast(gvModelDtl.SelectedRow.FindControl("lblmake5"), Label)).Text
        'MsgBox(a)
        RegNum.Text = (TryCast(gvModelDtl.SelectedRow.FindControl("reg"), Label)).Text
        color.Text = (TryCast(gvModelDtl.SelectedRow.FindControl("colors"), Label)).Text
        ava.Text = (TryCast(gvModelDtl.SelectedRow.FindControl("available"), Label)).Text
        seat.Text = (TryCast(gvModelDtl.SelectedRow.FindControl("seats"), Label)).Text
        fuel.Text = (TryCast(gvModelDtl.SelectedRow.FindControl("fuels"), Label)).Text
        engine.Text = (TryCast(gvModelDtl.SelectedRow.FindControl("engines"), Label)).Text
        price.Text = (TryCast(gvModelDtl.SelectedRow.FindControl("prices"), Label)).Text


        Model.SelectedItem.Text = (TryCast(gvModelDtl.SelectedRow.FindControl("lblMake2"), Label)).Text

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

        'If RegNum.ToString = "" Then
        '    Exit Sub
        'End If


        Dim RegNum As Integer = Convert.ToInt32(RegNum).ToString
        Dim color1 As String = color.Text.Trim()
        Dim door1 As String = door.Text.Trim()
        Dim ava1 As String = ava.Text.Trim()
        Dim seat1 As String = seat.Text.Trim()
        Dim fuel1 As String = fuel.Text.Trim
        Dim engine1 As String = engine.Text.Trim()
        Dim price1 As String = price.Text.Trim()
        Dim ModelId As Integer = Convert.ToInt32(Model.SelectedItem.Value)

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "INSERT INTO RegistrationNumber, Color, NumberOfDoors, Available, SeatCapacity, FuelType, Engine, PricePerDay, ModelsId" & "VALUES(@num, @color, @door, @ava, @seat, @fuel, @engine, @price, @model_id )"
                cmd.Parameters.AddWithValue("@num", RegNum)
                cmd.Parameters.AddWithValue("@color", color1)
                cmd.Parameters.AddWithValue("@door", door1)
                cmd.Parameters.AddWithValue("@ava", ava1)
                cmd.Parameters.AddWithValue("@seat", seat1)
                cmd.Parameters.AddWithValue("@fuel", fuel)
                cmd.Parameters.AddWithValue("@price", price1)
                cmd.Parameters.AddWithValue("@engine", engine1)
                cmd.Parameters.AddWithValue("@model_id", ModelId)

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsAdded = cmd.ExecuteNonQuery()
                sqlCon.Close()
            End Using
        End Using
        If IsAdded Then
            lblMsg.Text = "'" & RegNum & "' Vehicle details added successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
        Else
            lblMsg.Text = "Error while adding '" & RegNum & "' vehicle details"
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

        Dim RegNum As Integer = Convert.ToInt32(RegNum).ToString
        Dim color1 As String = color.Text.Trim()
        Dim door1 As String = door.Text.Trim()
        Dim ava1 As String = ava.Text.Trim()
        Dim seat1 As String = seat.Text.Trim()
        Dim fuel1 As String = fuel.Text.Trim
        Dim engine1 As String = engine.Text.Trim()
        Dim price1 As String = price.Text.Trim()
        Dim model_id As Integer = Convert.ToInt32(Model.SelectedItem.Value)

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "UPDATE Vehicle SET RegistrationNumber=@num, Color=@color, NumberOfDoors=@door, Available=@ava, SeatCapacity=@seat, FuelType=@fuel, Engine=@engine, PricePerDay=@price" &
                                        "ModelsId=@model_id WHERE VehicleId=@id"

                cmd.Parameters.AddWithValue("@model_id", model_id)
                cmd.Parameters.AddWithValue("@num", RegNum)
                cmd.Parameters.AddWithValue("@color", color1)
                cmd.Parameters.AddWithValue("@door", door1)
                cmd.Parameters.AddWithValue("@ava", ava1)
                cmd.Parameters.AddWithValue("@seat", seat1)
                cmd.Parameters.AddWithValue("@fuel", fuel1)
                cmd.Parameters.AddWithValue("@price", price1)
                cmd.Parameters.AddWithValue("@engine", engine1)
                cmd.Parameters.AddWithValue("@model_id", model_id)


                cmd.Connection = sqlCon
                sqlCon.Open()
                IsUpdated = cmd.ExecuteNonQuery()
                sqlCon.Close()
            End Using
        End Using
        If IsUpdated Then
            lblMsg.Text = "'" & RegNum & "' vehicle details updated successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
        Else
            lblMsg.Text = "Error while updating '" & RegNum & "' vehicle details"
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
        regnum.Text = ""

        Model.Items.Clear()
        BindSubjectData()
    End Sub

End Class