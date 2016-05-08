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
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.cbPort = New System.Windows.Forms.ComboBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.lblTimer = New System.Windows.Forms.Label()
        Me.rtInput = New System.Windows.Forms.RichTextBox()
        Me.lblComPort = New System.Windows.Forms.Label()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tmrData = New System.Windows.Forms.Timer(Me.components)
        Me.spData = New System.IO.Ports.SerialPort(Me.components)
        Me.lblData = New System.Windows.Forms.Label()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbPort
        '
        Me.cbPort.FormattingEnabled = True
        Me.cbPort.Location = New System.Drawing.Point(34, 71)
        Me.cbPort.Name = "cbPort"
        Me.cbPort.Size = New System.Drawing.Size(121, 21)
        Me.cbPort.TabIndex = 0
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(176, 71)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 1
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'lblTimer
        '
        Me.lblTimer.AutoSize = True
        Me.lblTimer.Location = New System.Drawing.Point(31, 145)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(67, 13)
        Me.lblTimer.TabIndex = 2
        Me.lblTimer.Text = "TIMER: OFF"
        '
        'rtInput
        '
        Me.rtInput.Location = New System.Drawing.Point(307, 73)
        Me.rtInput.Name = "rtInput"
        Me.rtInput.Size = New System.Drawing.Size(196, 594)
        Me.rtInput.TabIndex = 3
        Me.rtInput.Text = ""
        '
        'lblComPort
        '
        Me.lblComPort.AutoSize = True
        Me.lblComPort.Location = New System.Drawing.Point(31, 31)
        Me.lblComPort.Name = "lblComPort"
        Me.lblComPort.Size = New System.Drawing.Size(64, 13)
        Me.lblComPort.TabIndex = 4
        Me.lblComPort.Text = "COM PORT"
        '
        'Chart1
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(563, 71)
        Me.Chart1.Name = "Chart1"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(689, 596)
        Me.Chart1.TabIndex = 5
        Me.Chart1.Text = "Chart1"
        '
        'tmrData
        '
        '
        'lblData
        '
        Me.lblData.AutoSize = True
        Me.lblData.Location = New System.Drawing.Point(31, 198)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(0, 13)
        Me.lblData.TabIndex = 6
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.lblData)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.lblComPort)
        Me.Controls.Add(Me.rtInput)
        Me.Controls.Add(Me.lblTimer)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.cbPort)
        Me.Name = "Form1"
        Me.Text = "Monitoring Suhu"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbPort As ComboBox
    Friend WithEvents btnConnect As Button
    Friend WithEvents lblTimer As Label
    Friend WithEvents rtInput As RichTextBox
    Friend WithEvents lblComPort As Label
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents tmrData As Timer
    Friend WithEvents spData As IO.Ports.SerialPort
    Friend WithEvents lblData As Label
End Class
