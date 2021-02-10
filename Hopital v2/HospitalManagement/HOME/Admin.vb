Imports MySql.Data.MySqlClient

Public Class Admin

    Dim connection As MySqlConnection

    Dim command As MySqlCommand

    Dim reader As MySqlDataReader


    Dim insertString As String

    Dim MysqlConn As MySqlConnection
    Dim MysqlConn2 As MySqlConnection

    Dim ContactsCommand As New MySqlCommand
    Dim ContactsCommand2 As New MySqlCommand

    Dim ContactsAdapter As New MySqlDataAdapter
    Dim ContactsAdapter2 As New MySqlDataAdapter
    Dim ContactsData As New DataTable
    Dim ContactsData2 As New DataTable
    Dim SQL As String
    Dim SQL2 As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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

                insertString = "INSERT INTO `login1`(`UserName`, `Password`, `role`) VALUES ('" & txtUser.Text & "','" & txtPass.Text & "','" & txtRole.Text & "')"


                command = New MySqlCommand(insertString, connection)

                reader = command.ExecuteReader

                MessageBox.Show("" & txtUser.Text & "  Has Been Registered")

                connection.Close()

            Catch ex As MySqlException

                MessageBox.Show(ex.ToString)

            Finally

                connection.Dispose()

            End Try
            txtUser.Text = ""
            txtPass.Text = ""
            txtRole.Text = ""
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (txtSearch.Text = "") Then
            MessageBox.Show("Please fill the Search Box")
        Else

            connection = New MySqlConnection

            connection.ConnectionString = "server=localhost;userid=root;password=;database=hospital_management_system"


            Try

                connection.Open()

                insertString = "DELETE FROM `login1` WHERE UserName='" & txtSearch.Text & "'"


                command = New MySqlCommand(insertString, connection)

                reader = command.ExecuteReader

                MessageBox.Show("" & txtUser.Text & "  Has Been Removed")

                connection.Close()

            Catch ex As MySqlException

                MessageBox.Show(ex.ToString)

            Finally

                connection.Dispose()

            End Try
        End If
        txtSearch.Text = ""
        txtUser.Text = ""
        txtPass.Text = ""
        txtRole.Text = ""

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If (txtSearch.Text = "") Then
            MessageBox.Show("Please fill the Search Box")
        Else

            connection = New MySqlConnection

            connection.ConnectionString = "server=localhost;userid=root;password=;database=hospital_management_system"


            Try

                connection.Open()

                insertString = "UPDATE `login1` SET `UserName`='" & txtUser.Text & "',`Password`='" & txtPass.Text & "',`role`='" & txtRole.Text & "' WHERE UserName='" & txtSearch.Text & "'"


                command = New MySqlCommand(insertString, connection)

                reader = command.ExecuteReader

                MessageBox.Show("" & txtUser.Text & "  Has Been Updated")

                connection.Close()

            Catch ex As MySqlException

                MessageBox.Show(ex.ToString)

            Finally

                connection.Dispose()

            End Try
        End If
        txtUser.Text = ""
        txtPass.Text = ""
        txtRole.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (txtSearch.Text = "") Then
            MessageBox.Show("Please Fill ""Search"" Box")

        Else
            connection = New MySqlConnection

            connection.ConnectionString = "server=localhost;userid=root;password=;database=hospital_management_system"

            Try

                connection.Open()

                insertString = "SELECT `UserName`,`Password`,`role` FROM `login1` WHERE UserName = '" & txtSearch.Text & "'"

                command = New MySqlCommand(insertString, connection)

                reader = command.ExecuteReader

                While reader.Read


                    txtUser.Text = reader.GetString("UserName")
                    txtPass.Text = reader.GetString("Password")
                    txtRole.Text = reader.GetString("role")


                End While

                connection.Close()

            Catch ex As MySqlException

            Finally

                connection.Dispose()

            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LOGIN.Show()
        Me.Hide()
    End Sub

    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MysqlConn = New MySqlConnection()


        SQL = "SELECT `UserName`, `Password`, `role` FROM `login1`"

        MysqlConn.ConnectionString = "server=localhost;" & "user id=root;" & "password=;" & "database=hospital_management_system"

        Try

            MysqlConn.Open()

            ContactsCommand.Connection = MysqlConn

            ContactsCommand.CommandText = SQL

            ContactsAdapter.SelectCommand = ContactsCommand

            ContactsAdapter.Fill(ContactsData)

            DataGridView1.DataSource = ContactsData


        Catch myerror As MySqlException

            MessageBox.Show("Cannot connect to database: " & myerror.Message)
        Finally

            MysqlConn.Close()

            MysqlConn.Dispose()

        End Try

        MysqlConn2 = New MySqlConnection()


        SQL2 = "SELECT `ID`, `Name`,`dateofadmission`, `dateofdischarge`,`Date_Of_Consultation` FROM `patient_info` UNION SELECT `ID`, `Name`,`dateofadmission`, `dateofdischarge`,`Date_Of_Consultation` FROM `patient_infom`"

        MysqlConn2.ConnectionString = "server=localhost;" & "user id=root;" & "password=;" & "database=hospital_management_system"

        Try

            MysqlConn2.Open()

            ContactsCommand2.Connection = MysqlConn2

            ContactsCommand2.CommandText = SQL2

            ContactsAdapter2.SelectCommand = ContactsCommand2

            ContactsAdapter2.Fill(ContactsData2)

            DataGridView2.DataSource = ContactsData2


        Catch myerror As MySqlException

            MessageBox.Show("Cannot connect to database: " & myerror.Message)
        Finally

            MysqlConn.Close()

            MysqlConn.Dispose()

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        DataGridView2.ClearSelection()
        DataGridView2.BackColor = Color.White

        For Each row As DataGridViewRow In DataGridView2.Rows
            For Each cell As DataGridViewCell In row.Cells

                If cell.Value Is Nothing Then Continue For

                If CStr(cell.Value).ToLower.Contains(txtSearch2.Text.ToLower) Then

                    cell.Selected = True

                    'Yellow background When matched
                    cell.Style.BackColor = Color.Yellow

                End If
            Next

        Next
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        LOGIN.Show()
        Me.Hide()
    End Sub
End Class