Imports System.Data.OleDb
Imports System.IO.Ports
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1

    Dim dr As OleDbDataReader
    Dim comPORT As String = ""
    Dim receivedData As String = ""
    Dim i As Int32 = 1
    Dim s As New Series
    Dim tanggal As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrData.Enabled = False
        comPORT = ""
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cbPort.Items.Add(sp)
        Next

        Chart1.Series.Clear()
        Chart1.Titles.Add("Suhu")
        s.Name = "Hasil"
        s.ChartType = SeriesChartType.Line
        Chart1.Series.Add(s)
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If (btnConnect.Text = "Connect") Then
            If (comPORT <> "") Then
                spData.Close()
                spData.PortName = comPORT
                spData.BaudRate = 9600
                spData.DataBits = 8
                spData.Parity = Parity.None
                spData.StopBits = StopBits.One
                spData.Handshake = Handshake.None
                spData.Encoding = System.Text.Encoding.Default 'very important!
                spData.ReadTimeout = 10000

                spData.Open()
                btnConnect.Text = "Dis-connect"
                tmrData.Enabled = True
                lblTimer.Text = "Timer: ON"
            Else
                MsgBox("Select a COM port first")
            End If
        Else
            spData.Close()
            btnConnect.Text = "Connect"
            tmrData.Enabled = False
            lblTimer.Text = "Timer: OFF"
        End If
    End Sub

    Private Sub cbPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPort.SelectedIndexChanged
        If (cbPort.SelectedItem <> "") Then
            comPORT = cbPort.SelectedItem
        End If
    End Sub

    Private Sub tmrData_Tick(sender As Object, e As EventArgs) Handles tmrData.Tick
        receivedData = ReceiveSerialData()
        rtInput.Text &= receivedData
        Dim conn As New OleDbConnection
        Dim cmd_input As New OleDbCommand
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Users\Lambok\OneDrive\ta\firstDb.accdb"

        Try
            conn.Open()
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            cmd_input.Connection = conn
            If receivedData <> "" Then
                tanggal = String.Format(Date.Now)
                cmd_input.CommandText = "INSERT INTO ta(Tanggal, Hasil) VALUES('" & tanggal & "', '" & receivedData & "')"

                If cmd_input.ExecuteNonQuery Then
                    Dim cmd_select5 As New OleDbCommand("SELECT COUNT(*) FROM ta", conn)
                    Dim cmd_select1 As New OleDbCommand("SELECT TOP 1 * FROM ta", conn)

                    Dim read As OleDbDataReader = cmd_select1.ExecuteReader
                    Dim data1 As String
                    If read.Read Then
                        data1 = read("hasil")
                    End If
                    If cmd_select5.ExecuteScalar > 5 Then
                        Dim cmd_delete As New OleDbCommand("DELETE FROM ta WHERE hasil='" & data1 & "'", conn)
                        If cmd_delete.ExecuteNonQuery Then

                        End If
                        lblData.Text = i & " data masuk database."
                        i += 1
                        Dim cmd_select2 As New OleDbCommand("SELECT TOP 5 * FROM ta ORDER BY ID DESC", conn)
                        dr = cmd_select2.ExecuteReader
                        While dr.Read()
                            s.Points.AddXY(dr("ID").ToString, dr("Hasil").ToString)
                        End While
                        dr.Close()
                        cmd_select2.Dispose()
                    End If
                End If

                lblData.Text = i & " data masuk database."
                i += 1
                Dim cmd_select As New OleDbCommand("SELECT TOP 5 * FROM ta ORDER BY ID DESC", conn)
                dr = cmd_select.ExecuteReader
                While dr.Read()
                    s.Points.AddXY(dr("ID").ToString, dr("Hasil").ToString)
                End While
                dr.Close()
                cmd_select.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'close the connection
        conn.Close()
    End Sub

    Function ReceiveSerialData() As String
        Dim Incoming As String
        Try
            Incoming = spData.ReadExisting()
            If Incoming Is Nothing Then
                Return "nothing" & vbCrLf
            Else
                Return Incoming
            End If
        Catch ex As TimeoutException
            Return "Error: Serial Port read timed out."
        End Try

    End Function
End Class
