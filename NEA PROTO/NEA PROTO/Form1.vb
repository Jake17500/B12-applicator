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

    Dim JPoss As Boolean = False
    Dim JLPoss As Boolean = False
    Dim JRPoss As Boolean = False


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MakeAirGrid()
        run()
    End Sub

    Sub MakeAirGrid()

        Dim filewrite As IO.StreamWriter
        Dim filename As String = "TestGrid.txt"

        For row = 1 To GRIDROWS
            For column = 1 To GRIDCOLUMNS
                grid(row, column) = "."
            Next
        Next
        filewrite = New IO.StreamWriter(filename)
        For row = 1 To GRIDROWS
            For column = 1 To GRIDCOLUMNS
                filewrite.Write(grid(row, column))

            Next
            filewrite.WriteLine()
        Next
        filewrite.Close()
    End Sub

    Function GetFileGrid() As Char(,)
        Dim R, C As Integer
        Dim filename As String = "TestGrid.txt"
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


    Sub run()
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
                MsgBox("Success")
            ElseIf AllDead = True Then
                MsgBox("Fail (all players died)")
            ElseIf count > 1000 Then
                MsgBox("fail (over 1000 runs)")
            End If

        Catch ex As Exception
            MsgBox("Crash")
        End Try

    End Sub

End Class

