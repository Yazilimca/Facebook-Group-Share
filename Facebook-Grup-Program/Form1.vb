Imports MySql.Data.MySqlClient
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New MySqlConnection("SERVER=5.250.245.92;PORT=3306;DATABASE=bizimbil_face;UID=bizimbil_face;PASSWORD=1cbc2dyd;")
        Dim cmd As New MySqlCommand()
        Dim dr As MySqlDataReader

        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT usr, pwd FROM uyeler WHERE usr = '" & TextBox1.Text & "' AND pwd ='" & TextBox2.Text & "'"
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                MsgBox("Giriş Yapıldı Yönlendiriliyorsunuz..")
                Facebook_Grup.Show()
                Me.Close()

            Else
                MsgBox("Kullanıcı Adı ve Şifre Yanlış Girdiniz")

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()

        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        MsgBox("TurkHackTeam 'Adige Tarafından Kodlanmıştır..")
        MsgBox("www.turkhackteam.org")
    End Sub
End Class
