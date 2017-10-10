Imports System.IO
Public Class Game
    Const GROUND As Char = "G"
    Const BLOCK As Char = "B"
    Const ITEMBLOCK As Char = "I"
    Const ENEMY As Char = "E"
    Const AIR As Char = "."
    Const DEATH As Char = "X"
    Const SUCCESS As Char = "S"
    Const PLAYER As Char = "O"

    Const GRIDROWS As Integer = 7
    Const GRIDCOLUMNS As Integer = 19
    Dim grid(GRIDROWS, GRIDCOLUMNS) As Char
    Dim COMPLETE As Boolean = False
    Dim row, column As Integer

    Dim LevelNo As Integer
    Dim chunkcount As Integer

    Dim Theme As String
    Dim BlockTexture As String
    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetTheme()

    End Sub
    Dim Spath As String = Directory.GetCurrentDirectory
    Sub GetLevelGrid()
        Dim FileLocation As String = (Spath & "\lvl" & LevelNo & "\Chunk" & chunkcount & ".txt")
        Dim LevelReader As IO.StreamReader
        Dim filerow As String
        LevelReader = New IO.StreamReader(FileLocation)


    End Sub
    Sub BuildLevel()

    End Sub
    Sub SetTheme()
        Theme = Form1.GetTheme

        If Theme = "Planet" Then
            BlockTexture = "My.Resources.planet_ground"

        ElseIf Theme = "Underwater" Then
            BlockTexture = "My.Resources.underwater_ground"

        ElseIf Theme = "Desert" Then
            BlockTexture = "My.Resources.desert_ground"

        End If


        If Theme = "Planet" Then
            Me.BackgroundImage = My.Resources.PlanetSky

        ElseIf Theme = "Underwater" Then
            Me.BackgroundImage = My.Resources.under_water_sky

        ElseIf Theme = "Desert" Then
            Me.BackgroundImage = My.Resources.DesertSky

        End If
    End Sub
End Class