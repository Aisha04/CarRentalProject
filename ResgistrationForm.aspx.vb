Imports System.Data.SqlClient
Imports System.Configuration

Public Class ResgistrationForm
    Inherits System.Web.UI.Page
    Protected Sub txtClear_Click(sender As Object, e As EventArgs) Handles txtClear.Click
        txtfirstName.Text = ""
        txtSurname.Text = ""
        txtPhone.Text = ""
        txtAdd.Text = ""
        'female.Checked = False
        'male.Checked = False
        'other.Checked = False
        txtAge.Text = ""
        txtEmail.Text = ""
        'Arole.Checked = False
        'Crole.Checked = False
        txtNewUser.Text = ""
        txtNewPassword.Text = ""
        txtConfirm.Text = ""
        license.Text = ""

    End Sub

    Protected Sub txtButton_Click(sender As Object, e As EventArgs) Handles txtButton.Click

        Dim constr As String
        constr = ConfigurationManager.ConnectionStrings("connstr").ToString
        Dim sqlConn As New SqlConnection(constr)
        sqlConn.Open()
        Dim sqlCmd As New SqlCommand
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandText = "Insert into Users(FirstName, Surname, Age, PhoneNumber,  Address, Gender, Email, LicenseNumber, Role, Username,Password) values (@fName, @surname, @age, @pnumber, @address,  @gender, @email, @license, @Role, @Uname, @password)"


        Dim fNameParam As New SqlParameter
        fNameParam.ParameterName = "@fName"
        fNameParam.Value = txtfirstName.Text

        Dim UnameParam As New SqlParameter
        UnameParam.ParameterName = "@Uname"
        UnameParam.Value = txtNewUser.Text

        Dim passwordParam As New SqlParameter
        passwordParam.ParameterName = "@password"
        passwordParam.Value = txtNewPassword.Text

        Dim surnameParam As New SqlParameter
        surnameParam.ParameterName = "@surname"
        surnameParam.Value = txtSurname.Text

        Dim ageParam As New SqlParameter
        ageParam.ParameterName = "@age"
        ageParam.Value = txtAge.Text

        Dim addressParam As New SqlParameter
        addressParam.ParameterName = "@address"
        addressParam.Value = txtAdd.Text

        Dim pnumberParam As New SqlParameter
        pnumberParam.ParameterName = "@pnumber"
        pnumberParam.Value = txtPhone.Text

        Dim emailParam As New SqlParameter
        emailParam.ParameterName = "@email"
        emailParam.Value = txtEmail.Text

        Dim licenseParam As New SqlParameter
        licenseParam.ParameterName = "@license"
        licenseParam.Value = license.Text

        Dim genderParam As New SqlParameter
        genderParam.ParameterName = "@gender"
        If (female.Checked = True) Then
            genderParam.Value = ("F")
        ElseIf (male.Checked = True) Then
            genderParam.Value = ("M")
        Else
            other.Checked = True
            genderParam.Value = ("O")
        End If
        'genderParam.Value = Gender.SelectedItem.Value.ToString

        Dim roleParam As New SqlParameter
        roleParam.ParameterName = "@role"
        If (Arole.Checked = True) Then
            roleParam.Value = ("A")
        Else
            Crole.Checked = True
            roleParam.Value = ("C")
        End If

        'roleParam.Value = Status.SelectedItem.Value.ToString


        sqlCmd.Parameters.Add(fNameParam)
        sqlCmd.Parameters.Add(UnameParam)
        sqlCmd.Parameters.Add(passwordParam)
        sqlCmd.Parameters.Add(surnameParam)
        sqlCmd.Parameters.Add(addressParam)
        sqlCmd.Parameters.Add(ageParam)
        sqlCmd.Parameters.Add(pnumberParam)
        sqlCmd.Parameters.Add(roleParam)
        sqlCmd.Parameters.Add(genderParam)
        sqlCmd.Parameters.Add(emailParam)
        sqlCmd.Parameters.Add(licenseParam)

        Dim rowsInserted As Integer = 0

        rowsInserted = sqlCmd.ExecuteNonQuery()

        If (rowsInserted > 0) Then
            Response.Write("Sucessfully Entered")
        Else
            Response.Write("Failed")

        End If

        sqlConn.Close()




    End Sub

End Class