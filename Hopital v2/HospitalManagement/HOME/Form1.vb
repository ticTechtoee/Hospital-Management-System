Imports MySql.Data.MySqlClient
Public Class LOGIN
    Dim connection As MySqlConnection

    Dim command As MySqlCommand

    Dim reader As MySqlDataReader

    Dim searchString As String

    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim emptyTextBoxes =
   From txt In Me.Controls.OfType(Of TextBox)()
   Where txt.Text.Length = 0
   Select txt.Name
        If emptyTextBoxes.Any Then
            MessageBox.Show(String.Format("Please fill following textboxes: {0}",
                    String.Join(",", emptyTextBoxes)))
        Else



            connection = New MySqlConnection

            connection.ConnectionString = "server=localhost;userid=root;password=;database=hospital_management_system"

            Try

                connection.Open()


                searchString = "SELECT `Password`, `role` FROM `login1` WHERE  UserName = '" & txtUser.Text & "'"
                command = New MySqlCommand(searchString, connection)

                reader = command.ExecuteReader



                While reader.Read

                    Dim Password As String
                    Dim role As String

                    Password = reader.GetString("Password")
                    role = reader.GetString("role")

                    If (txtPass.Text = Password And role = "OPD Clerk") Then

                        Me.Hide()
                        OPD1.Show()


                    ElseIf (txtPass.Text = Password And role = "Admitting (ER)") Then
                        Me.Hide()
                        AdmittingER.Show()
                    ElseIf (txtPass.Text = Password And role = "Station 1") Then
                        Me.Hide()
                        AnnexStation.Show()
                    ElseIf (txtPass.Text = Password And role = "Station 2") Then
                        Me.Hide()
                        MainStation.Show()
                    ElseIf (txtPass.Text = Password And role = "Medical Records") Then
                        Me.Hide()
                        MainStation.Show()

                    Else
                        MessageBox.Show("Wrong User Name or Password")
                    End If


                End While
            Catch ex As Exception


            End Try
        End If
        If (txtUser.Text = "Admin" And txtPass.Text = "Admin") Then
            Hide()
            Admin.Show()
        End If
    End Sub

    Private Sub CancelButn_Click(sender As Object, e As EventArgs) Handles CancelButn.Click
        Close()
    End Sub


End Class
