Public Class about
    Private Sub about_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AutoScroll = True
        Label2.Text = "For new file press           -->        CTRL + N"
        Label3.Text = "To Open new file press       -->        CTRL + O"
        Label4.Text = "To save the file press       -->        CTRL + S"
        Label5.Text = "For print dialog press       -->        CTRL + p"
        Label6.Text = "To copy the text press       -->        CTRL + C"
        Label7.Text = "To cut the text press        -->        CTRL + X"
        Label8.Text = "To paste text press          -->        CTRL + V"
        Label9.Text = "To undo the changes          -->        CTRL + Z"
        Label10.Text = "To select all text          -->         CTRL + A"
        Label11.Text = "To Change the font          -->         CTRL + F"
        Label12.Text = "To Change the color         -->         CTRL + ALT + C"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Visible = True
        Me.Visible = False
    End Sub
End Class