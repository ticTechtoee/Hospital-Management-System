Imports MySql.Data.MySqlClient
Public Class AdmittingER
    Dim connection As MySqlConnection

    Dim command As MySqlCommand

    Dim reader As MySqlDataReader

    Dim insertString As String

    Dim searchString As String

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
                If (ComboBox3.Text = "Annex.") Then



                    insertString = "INSERT INTO `patient_info`(`ID`, `Name`, `roomm`, `sex`, `address`, `age`,`Nationality.`, `dateofadmission`
               ,timeofadmission,`dateofdischarge`, 
              `timeofdischarge`,`Date_Of_Consultation`,timeofConsultation, `doctorFindings`, `finalD`)
            VALUES ('" & txtID.Text & "','" & txtName.Text & "','" & ComboBox2.Text & "','" & txtSex.Text & "','" & txtAddress.Text & "','" & txtAge.Text & "',
           '" & txtNational.Text & "', '" & txtDateA.Text & "','" & txtTimeA.Text & "','" & txtDateD.Text & "',
           '" & txtTimeD.Text & "','" & txtDateC.Text & "','" & txtTimeC.Text & "','" & txtFD.Text & "','" & txtR.Text & "')"

                ElseIf (ComboBox3.Text = "Main Station.") Then

                    insertString = "INSERT INTO `patient_infom`(`ID`, `Name`, `roomm`, `sex`, `address`, `age`,`Nationality.`, `dateofadmission`
               ,timeofadmission,`dateofdischarge`, 
              `timeofdischarge`,`Date_Of_Consultation`,timeofConsultation, `doctorFindings`, `finalD`)
            VALUES ('" & txtID.Text & "','" & txtName.Text & "','" & ComboBox2.Text & "','" & txtSex.Text & "','" & txtAddress.Text & "','" & txtAge.Text & "',
           '" & txtNational.Text & "', '" & txtDateA.Text & "','" & txtTimeA.Text & "','" & txtDateD.Text & "',
           '" & txtTimeD.Text & "','" & txtDateC.Text & "','" & txtTimeC.Text & "','" & txtFD.Text & "','" & txtR.Text & "')"

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        PhysicalExam.Show()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged


        If (ComboBox3.Text = "Annex.") Then
            ComboBox2.Items.Clear()

            ComboBox2.Items.Add("Deluxe 2")
            ComboBox2.Items.Add("Deluxe 3")
            ComboBox2.Items.Add("Deluxe 4")
            ComboBox2.Items.Add("Deluxe 5")
            ComboBox2.Items.Add("Deluxe 6")
            ComboBox2.Items.Add("Deluxe 7")
            ComboBox2.Items.Add("Deluxe 8")
            ComboBox2.Items.Add("Pedia Ward A")
            ComboBox2.Items.Add("Pedia Ward B")
        ElseIf (ComboBox3.Text = "Main Station.") Then
            ComboBox2.Items.Clear()

            ComboBox2.Items.Add("Private 1")
            ComboBox2.Items.Add("Private 2")
            ComboBox2.Items.Add("Private 3")
            ComboBox2.Items.Add("Private 4")
            ComboBox2.Items.Add("Private 5")
            ComboBox2.Items.Add("Surgery Ward")
            ComboBox2.Items.Add("OB Ward")
            ComboBox2.Items.Add("Male Ward")
            ComboBox2.Items.Add("Female Ward")
            ComboBox2.Items.Add("Deluxe 1")
        End If
    End Sub

    Private Sub AdmittingER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timenow.Start()
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        LOGIN.Show()
        Me.Hide()
    End Sub



    Private Sub Timenow_Tick(sender As Object, e As EventArgs) Handles Timenow.Tick
        txtTimeC.Text = Date.Now.ToString("HH:mm:ss")

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If (txtSearch.Text = "") Then
            MessageBox.Show("Please Fill ""Search"" Box")

        Else
            connection = New MySqlConnection

            connection.ConnectionString = "server=localhost;userid=root;password=;database=hospital_management_system"

            Try

                connection.Open()

                searchString = "SELECT `ID`, `Name`, `Age`, `Gender`, `Address`, `Nationality`, `Status`, `DateofC`, `DateofA`, `DateofD`, `FinalD`, `Remarks` FROM `opdbasic` WHERE ID='" & txtSearch.Text & "'"

                command = New MySqlCommand(searchString, connection)

                reader = command.ExecuteReader

                While reader.Read


                    txtID.Text = reader.GetString("ID")
                    txtName.Text = reader.GetString("Name")
                    txtAge.Text = reader.GetString("Age")
                    txtSex.Text = reader.GetString("Gender")
                    txtAddress.Text = reader.GetString("Address")
                    txtNational.Text = reader.GetString("Nationality")
                    txtStatus.Text = reader.GetString("Status")
                    txtDateC.Text = reader.GetString("DateofC")
                    txtDateA.Text = reader.GetString("DateofA")
                    txtDateD.Text = reader.GetString("DateofD")
                    txtFD.Text = reader.GetString("FinalD")
                    txtR.Text = reader.GetString("Remarks")

                End While

                connection.Close()

            Catch ex As MySqlException

            Finally

                connection.Dispose()

            End Try
        End If
    End Sub
End Class