Imports System.IO
Public Class Form1
    Const GROUND As Char = "G"
    Const BLOCK As Char = "B"
    Const ITEMBLOCK As Char = "I"
    Const ENEMY As Char = "E"
    Const AIR As Char = "."
    Const DEATH As Char = "X"
    Const SUCCESS As Char = "S"
    Const PLAYER As Char = "O"

    Const GRIDROWS As Integer = 7
    Const GRIDCOLUMNS As Integer = 20
    Dim grid(GRIDROWS, GRIDCOLUMNS) As Char
    Dim COMPLETE As Boolean = False
    Dim row, column As Integer

    Dim MaxRow As Integer = 4
    Dim ItemBoxFreq As Integer = 25
    Dim EnemyFreq As Integer
    Dim LevelType As Char

    Dim StartOfLevel As Boolean = True
    Dim PlayerPlaced As Boolean = False
    Dim EndOfLevel As Boolean
    Dim probability As Integer
    Dim IsAIR As Boolean

    Dim ChunkCount As Integer = 0
    Dim NoOfChunks As Integer
    Dim LevelNo As Integer = 1
    Dim NoOfLevels As Integer


    Dim RND As New Random

    Dim JPoss As Boolean = False
    Dim JLPoss As Boolean = False
    Dim JRPoss As Boolean = False

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        For i = 0 To NoOfChunks
            CreateChunk()
            RunCheck()
        Next
    End Sub

    Sub CreateChunk()
        For R = 0 To 6
            For C = 1 To 20
                row = 7 - R
                column = C

                probability = 25
                GenConditions()

            Next
        Next
        SaveLevelChunk()
        MsgBox("done")
    End Sub

    Sub SaveLevelChunk()
        Dim filewriter As IO.StreamWriter
        Dim filename As String = ("CurrentChunk.txt")


        filewriter = New IO.StreamWriter(filename)
        For row = 1 To GRIDROWS
            For column = 1 To GRIDCOLUMNS
                filewriter.Write(grid(row, column))

            Next
            filewriter.WriteLine()
        Next
        filewriter.Close()
    End Sub


    Sub GenConditions()
        If StartOfLevel = True Then
            LevelStart()



        ElseIf PlayerPlaced = False And row < 6 Then
            PlacePlayer()

        Else
            FillBlock()

        End If

    End Sub

    Sub LevelStart()

        If row = 6 Then
            grid(row, column) = GROUND
            If column = 3 And row = 6 Then
                StartOfLevel = False
            End If
        ElseIf row = 7 Then
            grid(row, column) = DEATH

        End If



    End Sub

    Sub PlacePlayer()

        If row = 5 And column = 1 Then
            grid(row, column) = PLAYER

            PlayerPlaced = True

        End If

    End Sub

    Sub FillBlock()
        SurroundingsCheck()
        IsAIR = Placeblock()

        If IsAIR = True Then
            grid(row, column) = AIR
        ElseIf IsAIR = False Then
            grid(row, column) = BlockContent()
        End If
    End Sub

    Function Placeblock()
        If RND.Next(1, 100) < probability + 1 Then
            Return False
        Else
            Return True
        End If
    End Function

    Function BlockContent()

        If row = 6 Then
            Return GROUND

        ElseIf row = 7 Then
            Return DEATH

        ElseIf column = 20 Then
            Return SUCCESS

        ElseIf row = 1 And column = 5 Then
            Return PLAYER

        ElseIf grid(row - 1, column) = AIR Then
            If grid(row - 2, column) <> AIR Then
                If RND.Next(1, 100) < ItemBoxFreq Then
                    Return ITEMBLOCK
                Else
                    Return BLOCK
                End If
            End If

        Else
            Return BLOCK
        End If


    End Function

    Sub SurroundingsCheck()
        Dim OverMax As Boolean = False
        OverPit()
        TooManyBlocksInRow()
        DeathOrSuccess()
        AbleToGetOnTop()

    End Sub
    'make it work ------------------------------
    Sub AbleToGetOnTop()



    End Sub
    '-------------------------------------------
    Sub GroundRow()

        If row = 6 Then
            If grid(row, column - 4) <> AIR Then
                probability = probability + 30
            Else
                probability = probability - 15
            End If
        End If

    End Sub
    Sub SecondRow()

        If row = 5 Then
            If grid(row - 1, column - 1) <> AIR Then
                probability = probability + 30
            ElseIf grid(row - 2, column - 1) <> AIR Then
                probability = probability + 30
            End If
        End If

    End Sub
    Sub OtherRow()

        If grid(row - 2, column - 2) <> AIR Then
            probability = probability + 30
        ElseIf grid(row - 1, column - 1) <> AIR Then
            probability = probability + 30
        ElseIf grid(row - 2, column - 1) <> AIR Then
            probability = probability + 30
        End If


    End Sub

    Sub FirstColumn()

    End Sub
    Sub SecondColumn()

    End Sub
    Sub OtherColumn()

    End Sub

    Sub OverPit()
        If grid(6, column) = AIR Then
            probability = probability + 10
        End If

    End Sub
    Sub TooManyBlocksInRow()
        Dim OverMax As Boolean = False
        For i = 1 To MaxRow
            If grid(row, column - i) <> AIR Then

            Else
                OverMax = True
            End If
        Next

        If OverMax = True Then
            probability = probability - 25
        End If
    End Sub
    Sub DeathOrSuccess()
        If column = 20 Then
            probability = 100
        End If

        If row = 7 Then
            probability = 100
        End If
    End Sub





    Function GetFileGrid() As Char(,)
        Dim R, C As Integer
        Dim filename As String = "CurrentChunk.txt"
        Dim fileread As IO.StreamReader
        Dim filerow As String
        fileread = New IO.StreamReader(filename)

        For R = 1 To GRIDROWS
            filerow = fileread.ReadLine
            For C = 1 To GRIDCOLUMNS
                grid(R, C) = filerow(C - 1)
            Next
        Next
        fileread.Close()
        Return grid
    End Function

    Sub StartInAir()
        Left()
        Right()
        Fall()
        FallLeft()
        FallRight()
    End Sub
    Sub StartOnSurface()
        Jump()
        JumpLeft()
        JumpRight()

        If JPoss = True Then
            DoubleJump()
            DoubleJumpLeft()
            DoubleJumpRight()
        End If

        If JLPoss = True Then
            DoubleJumpDoubleLeft()
        End If

        If JRPoss = True Then
            DoubleJumpDoubleRight()
        End If

        Left()
        Right()

        FallLeft()
        FallRight()
    End Sub

    Sub Jump()
        If row - 1 < 1 Then

        Else
            If grid(row - 1, column) = AIR Then
                If grid(row - 1, column) = SUCCESS Then
                    COMPLETE = True
                End If
                grid(row - 1, column) = PLAYER
                JPoss = True
            End If
        End If

    End Sub
    Sub JumpLeft()
        If column - 1 < 1 Then

        Else
            If row - 1 < 1 Then

            Else
                If grid(row - 1, column - 1) = AIR Then
                    If grid(row - 1, column - 1) = SUCCESS Then
                        COMPLETE = True
                    End If
                    grid(row - 1, column - 1) = PLAYER
                    JLPoss = True
                End If
            End If
        End If

    End Sub
    Sub JumpRight()
        If column + 1 > 20 Then
            COMPLETE = True
        Else
            If row - 1 < 1 Then

            Else
                If grid(row - 1, column + 1) = AIR Then
                    If grid(row - 1, column + 1) = SUCCESS Then
                        COMPLETE = True
                    End If
                    grid(row - 1, column + 1) = PLAYER
                    JRPoss = True
                End If
            End If
        End If

    End Sub

    Sub DoubleJump()
        If row - 2 < 1 Then

        Else
            If grid(row - 2, column) = AIR Then
                If grid(row - 2, column) = SUCCESS Then
                    COMPLETE = True
                End If
                grid(row - 2, column) = PLAYER
            End If
        End If

    End Sub
    Sub DoubleJumpLeft()
        If column - 1 < 1 Then

        Else
            If row - 2 < 1 Then

            Else
                If grid(row - 2, column - 1) = AIR Then
                    If grid(row - 2, column - 1) = SUCCESS Then
                        COMPLETE = True
                    End If
                    grid(row - 2, column - 1) = PLAYER
                End If
            End If
        End If


    End Sub
    Sub DoubleJumpRight()
        If column + 1 > 20 Then
            COMPLETE = True
        Else
            If row - 2 < 1 Then

            Else
                If grid(row - 2, column + 1) = AIR Then
                    If grid(row - 2, column + 1) = SUCCESS Then
                        COMPLETE = True
                    End If
                    grid(row - 2, column + 1) = PLAYER
                End If
            End If
        End If

    End Sub
    Sub DoubleJumpDoubleLeft()
        If column - 2 < 1 Then

        Else
            If row - 2 < 1 Then

            Else
                If grid(row - 2, column - 2) = AIR Then
                    If grid(row - 2, column - 2) = SUCCESS Then
                        COMPLETE = True
                    End If
                    grid(row - 2, column - 2) = PLAYER
                End If
            End If
        End If

    End Sub
    Sub DoubleJumpDoubleRight()
        If column + 2 > 20 Then
            COMPLETE = True
        Else
            If row - 2 < 1 Then

            Else
                If grid(row - 2, column + 2) = AIR Then
                    If grid(row - 2, column + 2) = SUCCESS Then
                        COMPLETE = True
                    End If
                    grid(row - 2, column + 2) = PLAYER
                End If
            End If
        End If

    End Sub

    Sub Left()
        If column - 1 < 1 Then

        Else
            If grid(row, column - 1) = AIR Then
                If grid(row, column - 1) = SUCCESS Then
                    COMPLETE = True
                End If
                grid(row, column - 1) = PLAYER
            End If
        End If


    End Sub
    Sub Right()
        If column + 1 > 20 Then
            COMPLETE = True
        Else
            If grid(row, column + 1) = AIR Then
                If grid(row, column + 1) = SUCCESS Then
                    COMPLETE = True
                End If
                grid(row, column + 1) = PLAYER
            End If
        End If


    End Sub

    Sub Fall()
        If row + 1 > 7 Then

        Else
            If grid(row + 1, column) = AIR Then
                If grid(row + 1, column) = SUCCESS Then
                    COMPLETE = True
                End If
                grid(row + 1, column) = PLAYER
            End If
        End If


    End Sub
    Sub FallLeft()
        If column - 1 < 1 Then

        Else
            If row + 1 > 7 Then

            Else
                If grid(row + 1, column - 1) = AIR Then
                    If grid(row + 1, column - 1) = SUCCESS Then
                        COMPLETE = True
                    End If
                    grid(row + 1, column - 1) = PLAYER
                End If
            End If
        End If

    End Sub
    Sub FallRight()
        If column + 1 > 20 Then
            COMPLETE = True
        Else
            If row + 1 > 7 Then

            Else
                If grid(row + 1, column + 1) = AIR Then
                    If grid(row + 1, column + 1) = SUCCESS Then
                        COMPLETE = True
                    End If
                    grid(row + 1, column + 1) = PLAYER
                End If
            End If
        End If

    End Sub


    Sub RunCheck()
        Dim AllDead As Boolean
        Dim count As Integer = 0
        grid = GetFileGrid()
        Try
            Do
                AllDead = True
                count = count + 1
                For i = 1 To GRIDROWS
                    For j = 1 To GRIDCOLUMNS
                        If grid(i, j) = PLAYER Then
                            AllDead = False
                            grid(i, j) = AIR
                            row = i
                            column = j
                            If grid(i + 1, j) = AIR Then
                                StartInAir()
                            ElseIf grid(i + 1, j) = PLAYER Then
                                StartInAir()
                            ElseIf grid(i + 1, j) = DEATH Then
                                StartInAir()

                            Else
                                StartOnSurface()
                            End If
                        End If
                    Next
                Next

            Loop Until COMPLETE = True Or AllDead = True Or count > 1000
            If COMPLETE = True Then
                CreateLevelFile()
                SaveToLevelFile()
            ElseIf AllDead = True Then
                MsgBox("FAIL - all players died")
            ElseIf count > 1000 Then
                MsgBox("FAIL - over 1000 runs")
            End If

        Catch ex As Exception
            MsgBox("Crash")
        End Try

    End Sub

    Dim spath As String = Directory.GetCurrentDirectory
    Sub CreateLevelFile()

        If (Not System.IO.Directory.Exists(Path.Combine(spath, "lvl" & LevelNo))) Then
            System.IO.Directory.CreateDirectory(Path.Combine(spath, "lvl" & LevelNo))
        End If
        If (Not System.IO.File.Exists(Path.Combine(spath, "lvl" & LevelNo & "\Chunk" & ChunkCount & ".txt"))) Then
            System.IO.File.Create(Path.Combine(spath, "lvl" & LevelNo & "\Chunk" & ChunkCount & ".txt"))
        End If

    End Sub

    Sub SaveToLevelFile()

        Dim SaveLocation As String = (spath & "\lvl" & LevelNo & "\Chunk" & ChunkCount & ".txt")
        Dim SaveWriter As IO.StreamWriter

        SaveWriter = New IO.StreamWriter(SaveLocation)
        For row = 1 To GRIDROWS
            For column = 1 To GRIDCOLUMNS
                SaveWriter.Write(grid(row, column))
            Next
            SaveWriter.WriteLine()
        Next
        SaveWriter.Close()
    End Sub


End Class