Imports MySql.Data.MySqlClient
Public Class AnnexStation

    Dim connection As MySqlConnection

    Dim command As MySqlCommand

    Dim reader As MySqlDataReader

    Dim searchString As String

    Dim insertString As String

    Dim MysqlConn As MySqlConnection

    Dim ContactsCommand As New MySqlCommand

    Dim ContactsAdapter As New MySqlDataAdapter

    Dim ContactsData As New DataTable

    Dim SQL As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (txtSearch.Text = "") Then
            MessageBox.Show("Please Fill ""Search"" Box")

        Else
            connection = New MySqlConnection

            connection.ConnectionString = "server=localhost;userid=root;password=;database=hospital_management_system"

            Try

                connection.Open()

                searchString = "SELECT `ID`, `Name`, `roomm` FROM `patient_info` WHERE ID = '" & txtSearch.Text & "' UNION SELECT `ID`, `Name`, `roomm` FROM `patient_infom` WHERE ID = '" & txtSearch.Text & "'"

                command = New MySqlCommand(searchString, connection)

                reader = command.ExecuteReader

                While reader.Read


                    txtID.Text = reader.GetString("ID")
                    txtName.Text = reader.GetString("Name")
                    txtRoom.Text = reader.GetString("roomm")



                End While

                connection.Close()

            Catch ex As MySqlException

            Finally

                connection.Dispose()

            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click




        Dim emptyTextBoxes = From txt In Me.Controls.OfType(Of TextBox)() Where txt.Text.Length = 0



        If emptyTextBoxes.Any Then
            MessageBox.Show(String.Format("Please fill following textboxes: {0}",
                    String.Join(",", emptyTextBoxes)))
        Else


            connection = New MySqlConnection

            connection.ConnectionString = "server=localhost;userid=root;password=;database=hospital_management_system"





            Try

                connection.Open()

                If (txtStatus.Text = "Discharged.") Then
                    insertString = "DELETE FROM `patient_medicine` WHERE ID='" & txtID.Text & "'"

                ElseIf (txtStatus.Text = "Confined.") Then
                    insertString = "INSERT INTO `patient_medicine`(`ID`, `Name`, `room`, `Medicine`,
`Status`, `Time`, `Date`) VALUES
('" & txtID.Text & "','" & txtName.Text & "','" & txtRoom.Text & "','" & txtMedicine.Text & "','" & txtStatus.Text & "',
'" & txtTime.Text & "','" & txtDate.Text & "')"

                End If
                command = New MySqlCommand(insertString, connection)

                reader = command.ExecuteReader


            Catch ex As MySqlException

                MessageBox.Show(ex.ToString)

            Finally

                connection.Dispose()

            End Try

        End If
    End Sub

    Private Sub AnnexStation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TimePicker.Enabled = True
        refresher.Enabled = True
    End Sub

    Private Sub refresher_Tick(sender As Object, e As EventArgs) Handles refresher.Tick
        MysqlConn = New MySqlConnection()


        SQL = "SELECT `Name`, `room`, `Medicine`, `Time`, `Date` FROM `patient_medicine` WHERE Time='" & lblTime.Text & "'"

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
        Dim sum As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
            sum = DataGridView1.Rows.Count - 1
        Next

        NoOfPatients.Text = sum.ToString()
    End Sub

    Private Sub NoOfPatients_TextChanged(sender As Object, e As EventArgs) Handles NoOfPatients.TextChanged
        Dim spath As String
        Dim mysound As Media.SoundPlayer
        If (NoOfPatients.Text >= 1) Then
            spath = "C:\mysound\sound.wav"
            mysound = New Media.SoundPlayer(spath)
            mysound.Play()
        End If
    End Sub

    Private Sub TimePicker_Tick(sender As Object, e As EventArgs) Handles TimePicker.Tick
        lblTime.Text = Date.Now.ToString("HH:mm:ss")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        refresher.Stop()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        refresher.Start()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        txtSearch.Text = ""
        txtID.Text = ""
        txtName.Text = ""
        txtRoom.Text = ""
        txtMedicine.Text = ""
        txtTime.Text = ""
        txtDate.Text = ""
        txtStatus.Text = ""

        LOGIN.Show()
        Me.Hide()
    End Sub
End Class