Imports MySql.Data.MySqlClient
Public Class PhysicalExam

    Dim connection As MySqlConnection

    Dim command As MySqlCommand

    Dim reader As MySqlDataReader

    Dim insertString As String



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim emptyTextBoxes = From txt In Me.TabPage1.Controls.OfType(Of TextBox)() Where txt.Text.Length = 0



        If emptyTextBoxes.Any Then
            MessageBox.Show(String.Format("Please fill following textboxes: {0}",
                    String.Join(",", emptyTextBoxes)))
        Else


            connection = New MySqlConnection

            connection.ConnectionString = "server=localhost;userid=root;password=;database=hospital_management_system"





            Try

                connection.Open()

                insertString = "INSERT INTO `Physical exam`(`ID`, `Skin`, `HeadE`, `LYMPHN`, `Chest`, `Breast`,
`Abdomen`, `Rectum`, `Genetalia`, `Lungs`, `Cardio`) VALUES ('" & txtID.Text & "','" & txtSkin.Text & "','" & txtHead.Text & "',
'" & txtLYM.Text & "','" & txtChest.Text & "','" & txtBreast.Text & "','" & txtAb.Text & "','" & txtR.Text & "',
'" & txtGe.Text & "','" & txtLu.Text & "','" & txtCardi.Text & "')"


                command = New MySqlCommand(insertString, connection)

                reader = command.ExecuteReader




            Catch ex As MySqlException

                MessageBox.Show(ex.ToString)

            Finally

                connection.Dispose()

            End Try

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim emptyTextBoxes = From txt In Me.TabPage2.Controls.OfType(Of TextBox)() Where txt.Text.Length = 0



        If emptyTextBoxes.Any Then
            MessageBox.Show(String.Format("Please fill following textboxes: {0}",
                    String.Join(",", emptyTextBoxes)))
        Else


            connection = New MySqlConnection

            connection.ConnectionString = "server=localhost;userid=root;password=;database=hospital_management_system"





            Try

                connection.Open()

                insertString = "INSERT INTO `Patient_History`(`ID`, `PatientProf`, `PastHistory`, `FamilyHistory`, `Occupation`,
        `drug`, `alcohol`, `tobacco`, `drugall`, `otherall`, `presentco`) 
           VALUES ('" & txtID2.Text & "','" & txtGEN.Text & "','" & txtHis.Text & "','" & txtFam.Text & "',
         '" & txtOcc.Text & "','" & txtDru.Text & "','" & txtAlco.Text & "','" & txtToba.Text & "','" & txtDrug.Text & "','" & txtOA.Text & "','" & txtPres.Text & "')"


                command = New MySqlCommand(insertString, connection)

                reader = command.ExecuteReader




            Catch ex As MySqlException

                MessageBox.Show(ex.ToString)

            Finally

                connection.Dispose()

            End Try

        End If
    End Sub

    Private Sub PhysicalExam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtID.Text = AdmittingER.txtID.Text
        txtID2.Text = AdmittingER.txtID.Text
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AdmittingER.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TabPage1.Show()
    End Sub
End Class