﻿Public Class Form1
    Public lvlDifficulty As String
    Public lvlType As String
    Private Sub PLAY_Click(sender As Object, e As EventArgs) Handles PLAY.Click

        If ComboDiff.Text = "" Then
            MsgBox("ALL FIELDS MUST BE FILLED IN")
        ElseIf ComboType.Text = "" Then
            MsgBox("ALL FIELDS MUST BE FILLED IN")

        Else
            lvlDifficulty = ComboDiff.Text
            lvlType = ComboType.Text

            Game.Show()
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboType.Items.Add("Planet")
        ComboType.Items.Add("Underwater")
        ComboType.Items.Add("Desert")

        ComboDiff.Items.Add("Easy")
        ComboDiff.Items.Add("Medium")
        ComboDiff.Items.Add("Hard")
    End Sub

    Public Function GetTheme()
        Return lvlType
    End Function

End Class
