Imports MySql.Data.MySqlClient

Public Class OPD1
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


    Private Sub LogoutButn_Click(sender As Object, e As EventArgs) Handles LogoutButn.Click
        LOGIN.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PrintBasicInfovb.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PrintMedicalCertificate.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (txtSearch.Text = "") Then
            MessageBox.Show("Please Fill ""Search"" Box")

        Else

            MysqlConn = New MySqlConnection()


            SQL = "SELECT `ID`, `Name`,`dateofdischarge`,`Date_Of_Consultation`FROM `patient_info` WHERE ID='" & txtSearch.Text & "' UNION  SELECT `ID`, `Name`,`dateofdischarge`,`Date_Of_Consultation`FROM `patient_infom` WHERE ID='" & txtSearch.Text & "'"

            MysqlConn.ConnectionString = "server=localhost;" & "user id=root;" & "password=;" & "database=hospital_management_system"

            Try

                MysqlConn.Open()

                ContactsCommand.Connection = MysqlConn

                ContactsCommand.CommandText = Sql

                ContactsAdapter.SelectCommand = ContactsCommand

                ContactsAdapter.Fill(ContactsData)

                DataGridView1.DataSource = ContactsData


            Catch myerror As MySqlException

                MessageBox.Show("Cannot connect to database: " & myerror.Message)
            Finally

                MysqlConn.Close()

                MysqlConn.Dispose()

            End Try
















        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Dim emptyTextBoxes = From txt In Me.Panel1.Controls.OfType(Of TextBox)() Where txt.Text.Length = 0



        If emptyTextBoxes.Any Then
            MessageBox.Show(String.Format("Please fill following textboxes: {0}",
                    String.Join(",", emptyTextBoxes)))
        Else


            connection = New MySqlConnection

            connection.ConnectionString = "server=localhost;userid=root;password=;database=hospital_management_system"





            Try

                connection.Open()




                insertString = "INSERT INTO `opdbasic`(`ID`, `Name`, `Age`, `Gender`,
`Address`, `Nationality`, `Status`, `DateofC`, `DateofA`, `DateofD`, `FinalD`, `Remarks`) VALUES 
('" & txtID.Text & "','" & txtName.Text & "','" & txtAge.Text & "','" & txtSex.Text & "','" & txtAddress.Text & "','" & txtNational.Text & "',
'" & txtStatus.Text & "','" & txtDC.Text & "','" & txtDA.Text & "','" & txtDD.Text & "','" & txtFD.Text & "','" & txtRemarks.Text & "')"


                command = New MySqlCommand(insertString, connection)

                reader = command.ExecuteReader




            Catch ex As MySqlException

                MessageBox.Show(ex.ToString)

            Finally

                connection.Dispose()

            End Try

        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If (CheckBox1.Checked) Then

            txtDD.Enabled = False

        Else

            txtDD.Enabled = True

        End If



    End Sub

    Private Sub OPD1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection = New MySqlConnection

        connection.ConnectionString = "server=localhost;userid=root;password=;database=hospital_management_system"





        Try

            connection.Open()

            Try

                searchString = "SELECT MAX(ID) FROM patient_info UNION SELECT MAX(ID) FROM patient_infom"

                command = New MySqlCommand(searchString, connection)

                reader = command.ExecuteReader

                While reader.Read
                    Dim ID As Integer

                    ID = reader.GetString("MAX(ID)")
                    ID = ID + 1
                    txtID.Text = ID


                End While

                connection.Close()
            Catch ex As MySqlException
                MessageBox.Show("No Data Present.")
            End Try

        Catch ex As MySqlException

            MessageBox.Show(ex.ToString)

        Finally

            connection.Dispose()

        End Try
    End Sub
End Class