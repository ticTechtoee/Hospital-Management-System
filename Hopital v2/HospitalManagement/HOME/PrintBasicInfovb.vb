Imports MySql.Data.MySqlClient
Imports itextsharp.text.pdf
Imports itextsharp.text
Imports System.IO
Public Class PrintBasicInfovb

    Dim connection As MySqlConnection

    Dim command As MySqlCommand

    Dim reader As MySqlDataReader

    Dim searchString As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (txtSearch.Text = "") Then
            MessageBox.Show("Please Fill ""Search"" Box")

        Else
            connection = New MySqlConnection

            connection.ConnectionString = "server=localhost;userid=root;password=;database=hospital_management_system"

            Try

                connection.Open()

                searchString = "SELECT `ID`, `Name`, `sex`, `address`, `age`, `Nationality.`, `dateofadmission`,`dateofdischarge`,
               `Date_Of_Consultation`,`Status` FROM `patient_info` 
               WHERE ID = '" & txtSearch.Text & "' UNION SELECT `ID`, `Name`, `sex`, `address`, `age`, `Nationality.`, `dateofadmission`,
              `dateofdischarge`,  `Date_Of_Consultation`,`Status` FROM `patient_infom` WHERE ID = '" & txtSearch.Text & "'"

                command = New MySqlCommand(searchString, connection)

                reader = command.ExecuteReader

                While reader.Read


                    txtID.Text = reader.GetString("ID")
                    txtName.Text = reader.GetString("Name")
                    txtSex.Text = reader.GetString("sex")
                    txtAddress.Text = reader.GetString("address")
                    txtAge.Text = reader.GetString("age")
                    txtNational.Text = reader.GetString("Nationality.")
                    txtDA.Text = reader.GetString("dateofadmission")
                    txtDD.Text = reader.GetString("dateofdischarge")
                    txtDC.Text = reader.GetString("Date_Of_Consultation")
                    txtStatus.Text = reader.GetString("Status")



                End While

                connection.Close()

            Catch ex As MySqlException

            Finally

                connection.Dispose()

            End Try
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim emptyTextBoxes =
   From txt In Me.Controls.OfType(Of TextBox)()
   Where txt.Text.Length = 0
   Select txt.Name
        If emptyTextBoxes.Any Then
            MessageBox.Show(String.Format("Please fill following textboxes: {0}",
                    String.Join(",", emptyTextBoxes)))
        Else
            Dim pdfDoc As New Document()
            Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(txtID.Text & txtName.Text & ".pdf", FileMode.Create))
            pdfDoc.Open()
            pdfDoc.Add(New Paragraph(" " & txtID.Text & "   " & txtName.Text & "     " & txtAge.Text & "     " & txtSex.Text & "                " & txtDA.Text & "   " & txtDD.Text & "    " & txtDC.Text))
            pdfDoc.Add(Chunk.NEWLINE)
            pdfDoc.Add(Chunk.NEWLINE)
            pdfDoc.Add(Chunk.NEWLINE)
            pdfDoc.Add(Chunk.NEWLINE)
            pdfDoc.Add(Chunk.NEWLINE)
            pdfDoc.Add(New Paragraph(" " & txtAddress.Text & "            " & txtStatus.Text & "     " & txtNational.Text))
            pdfDoc.Add(Chunk.NEWLINE)
            pdfDoc.Add(Chunk.NEWLINE)
            pdfDoc.Add(Chunk.NEWLINE)
            pdfDoc.Close()





        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class