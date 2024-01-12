Imports System.Speech.Recognition
Public Class Form1
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        'to open about window and to make the main window non visible
        about.Show()
        Me.Visible = False
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        'to change the font of the program
        If fd.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            TextBox1.Font = fd.Font
        End If
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem.Click
        'to change the color of the program
        If cd.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            TextBox1.ForeColor = cd.Color
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        'this is will clear the text box and it will be like a new file
        Dim x As Integer
        x = MsgBox("Do you want to clear the written document", MsgBoxStyle.YesNoCancel)
        If x = 6 Then
            TextBox1.Clear()
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        'this will help to open any file from the directory and read it to the text box
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        'saving filters for file extention by giving brief details of file and .extention name
        SaveFileDialog1.Filter = "text files (*.txt*)|*.txt|Hyper Text Markup Language files (*.html*)|*.html|Cascading style sheet files(*.css*)|*.css|Java file (*.java*)|*.java"
        'SaveFileDialog1.Filter = "Hyper Text Markup Language files (*.html*)|*.html"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            'false button holds written document even after saving true value will remove everything after saving the file
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, True)
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        'it will open a print dialog
        PrintDialog1.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        'it will quit the peogram
        Me.Close()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        'With this we can copy the text from text
        TextBox1.Copy()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        'with this we can cut text from the text box
        TextBox1.Cut()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        'with this we can paste the selected items
        TextBox1.Paste()
    End Sub

    Private Sub UndoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem1.Click
        'we can undo the canges
        TextBox1.Undo()
    End Sub

    Private Sub SelectAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem1.Click
        'with this we can select all the text
        TextBox1.SelectAll()
    End Sub

    Private Sub DarkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DarkToolStripMenuItem.Click
        TextBox1.BackColor = Color.Black
        TextBox1.ForeColor = Color.White
    End Sub

    Private Sub BlueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlueToolStripMenuItem.Click
        TextBox1.BackColor = Color.DarkBlue
        TextBox1.ForeColor = Color.White
    End Sub

    Private Sub LightToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LightToolStripMenuItem.Click
        TextBox1.BackColor = Color.White
        TextBox1.ForeColor = Color.Black
    End Sub

    Private Sub VoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VoiceToolStripMenuItem.Click
        Dim x As Integer
        Dim recognizer As New SpeechRecognitionEngine
        x = MsgBox("Press Yes to start No to stop Cancel to close", MsgBoxStyle.YesNoCancel)
        If x = 6 Then
            recognizer.LoadGrammar(New DictationGrammar)
            recognizer.SetInputToDefaultAudioDevice()
            recognizer.RecognizeAsync(RecognizeMode.Multiple)
            AddHandler recognizer.SpeechRecognized, AddressOf Recognizer_SpeechRecognized
        ElseIf x = 7 Or x = 2 Then
            recognizer.RecognizeAsyncStop()
        End If
    End Sub
    Private Sub Recognizer_SpeechRecognized(sender As Object, e As SpeechRecognizedEventArgs)
        'TextBox1.Text &= e.Result.Text & " "
        TextBox1.Text &= e.Result.Text & Environment.NewLine
    End Sub

    Private Sub ToolStripSeparator5_Click(sender As Object, e As EventArgs) Handles ToolStripSeparator5.Click
        Dim x As Integer
        Dim reader = CreateObject("SAPI.spvoice")
        x = MsgBox("Do You want to start this feature??", MsgBoxStyle.YesNo)
        If x = 6 Then
            reader.speak(TextBox1.Text)
        End If
    End Sub
End Class
