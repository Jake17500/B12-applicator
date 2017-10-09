<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PLAY = New System.Windows.Forms.Button()
        Me.ComboType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboDiff = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Length = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'PLAY
        '
        Me.PLAY.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLAY.Location = New System.Drawing.Point(26, 21)
        Me.PLAY.Name = "PLAY"
        Me.PLAY.Size = New System.Drawing.Size(144, 62)
        Me.PLAY.TabIndex = 0
        Me.PLAY.Text = "PLAY"
        Me.PLAY.UseVisualStyleBackColor = True
        '
        'ComboType
        '
        Me.ComboType.FormattingEnabled = True
        Me.ComboType.Location = New System.Drawing.Point(223, 106)
        Me.ComboType.Name = "ComboType"
        Me.ComboType.Size = New System.Drawing.Size(226, 21)
        Me.ComboType.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(114, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Level Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(140, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 24)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Difficulty"
        '
        'ComboDiff
        '
        Me.ComboDiff.FormattingEnabled = True
        Me.ComboDiff.Location = New System.Drawing.Point(223, 133)
        Me.ComboDiff.Name = "ComboDiff"
        Me.ComboDiff.Size = New System.Drawing.Size(226, 21)
        Me.ComboDiff.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(149, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 24)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Length"
        '
        'Length
        '
        Me.Length.Location = New System.Drawing.Point(223, 160)
        Me.Length.Name = "Length"
        Me.Length.Size = New System.Drawing.Size(226, 20)
        Me.Length.TabIndex = 6
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(544, 394)
        Me.Controls.Add(Me.Length)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboDiff)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboType)
        Me.Controls.Add(Me.PLAY)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PLAY As Button
    Friend WithEvents ComboType As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboDiff As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Length As TextBox
End Class
