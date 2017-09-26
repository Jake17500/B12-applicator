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

    Dim MaxRow As Integer
    Dim ItemBoxFreq As Integer
    Dim LevelLength As Integer
    Dim EnemyFreq As Integer
    Dim LevelType As Char

    Dim StartOfLevel As Boolean = True
    Dim EndOfLevel As Boolean
    Dim probability As Integer
    Dim IsAIR As Boolean
    Dim ChunkCount As Integer = 0
    Dim NoOfChunks As Integer

    Dim RND As New Random


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For R = 0 To 6
            For C = 1 To 20
                row = 7 - R
                column = C

                probability = 0
                GenConditions()

            Next
        Next
        SaveLevelChunk()
        MsgBox("done")
    End Sub

    Sub SaveLevelChunk()
        Dim filewriter As IO.StreamWriter
        Dim filename As String = ("chunk no " & ChunkCount & ".txt")


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


    End Sub

    Sub AbleToGetOnTop()

        '   on ground row ----------------------------------------------------------------------------
        If row = 6 Then
            If grid(row, column - 4) <> AIR Then
                probability = probability + 30
            Else
                probability = probability - 15
            End If

            'on second row ----------------------------------------------------------------------------
        ElseIf row = 5 Then
            If grid(row - 1, column - 1) <> AIR Then
                probability = probability + 30
            ElseIf grid(row - 2, column - 1) <> AIR Then
                probability = probability + 30
            End If

            'on other rows ----------------------------------------------------------------------------
        Else
            If grid(row - 2, column - 2) <> AIR Then
                probability = probability + 30
            ElseIf grid(row - 1, column - 1) <> AIR Then
                probability = probability + 30
            ElseIf grid(row - 2, column - 1) <> AIR Then
                probability = probability + 30
        End If

        End If

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
End Class
