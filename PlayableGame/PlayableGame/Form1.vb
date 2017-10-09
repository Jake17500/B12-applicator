Public Class Form1
    Private Sub PLAY_Click(sender As Object, e As EventArgs) Handles PLAY.Click
        Game.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboType.Items.Add("Planet")
        ComboType.Items.Add("Underwater")
        ComboType.Items.Add("Desert")

        ComboDiff.Items.Add("Easy")
        ComboDiff.Items.Add("medium")
        ComboDiff.Items.Add("Hard")
    End Sub


End Class
