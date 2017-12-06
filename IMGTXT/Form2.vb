Imports System.ComponentModel
Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form2
    Dim isDraging As Boolean
    Dim x1, y1, x2, y2 As Integer
    Private bm As Bitmap
    Private gbm As Graphics

    Private Function SendRequest(uri As Uri, jsonDataBytes As Byte(), contentType As String, method As String) As String
        Dim req As WebRequest = WebRequest.Create(uri)
        req.ContentType = contentType
        req.Method = method
        req.ContentLength = jsonDataBytes.Length


        Dim stream = req.GetRequestStream()
        stream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
        stream.Close()

        Dim response = req.GetResponse().GetResponseStream()

        Dim reader As New StreamReader(response)
        Dim res = reader.ReadToEnd()
        reader.Close()
        response.Close()

        Return res
    End Function

    Private Function CaptureScreen2() As Bitmap
        Dim memoryImage As Bitmap
        Dim myGraphics As Graphics = Me.CreateGraphics()
        memoryImage = New Bitmap(pan.Width, pan.Height, myGraphics)
        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
        memoryGraphics.CopyFromScreen(pan.Location.X, pan.Location.Y, 0, 0, pan.Size)
        Return memoryImage
    End Function

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim w As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim h As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim s As Size = New Size(w, h)
        Me.Text = String.Empty
        Me.ControlBox = False
        Me.FormBorderStyle = 0
        Me.SetBounds(0, 0, s.Width, s.Height)

        Pan.BorderStyle = 0
        Pan.BackColor = Color.Transparent
        pan.SetBounds(0, 0, s.Width, s.Height)
        'bm = New Bitmap(s.Width, s.Height)
        'gbm = Graphics.FromImage(bm)
        'pan.BackgroundImage = bm

    End Sub

    Private Sub Form2_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            isDraging = True
            x1 = e.X
            y1 = e.Y
        End If
    End Sub

    Private Sub Form2_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If isDraging Then

        End If
    End Sub

    Private Sub Form2_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If isDraging Then
            isDraging = False
            ContextMenuStrip1.Show(e.Location)
        End If
    End Sub

    Private Sub Form2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Controls.Remove(pan)
        Form1.Show()
    End Sub

    Private Sub SaveToFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToFileToolStripMenuItem.Click
        Dim memoryImage As Bitmap = CaptureScreen2()
        Dim saveDialog As New SaveFileDialog
        saveDialog.Filter = "BMP Image|*.bmp"
        saveDialog.Title = "Save Image as"
        saveDialog.ShowDialog()
        If saveDialog.FileName <> "" Then
            memoryImage.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp)
            Me.Close()
        End If
    End Sub

    Private Sub Pan_Paint(sender As Object, e As PaintEventArgs) Handles Pan.Paint

    End Sub

    Private Sub CopyToClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToClipboardToolStripMenuItem.Click
        Dim memoryImage As Bitmap = CaptureScreen2()
        Clipboard.SetImage(memoryImage)
        Me.Close()
    End Sub

    Private Sub OCRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OCRToolStripMenuItem.Click
        Dim capimage As Image = CaptureScreen2()
        capimage.Save("capture.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim imgStr As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("capture.jpg"))
        imgStr = WebUtility.UrlEncode(imgStr)
        Dim token = "24.8eee42b8d619af1ce47b68acb3e05858.2592000.1515018354.282335-10479770"
        Dim jsonString As String = "access_token=" + token + "&image=" + imgStr
        Dim data = Encoding.UTF8.GetBytes(jsonString)
        Dim Uri As Uri = New Uri("https://aip.baidubce.com/rest/2.0/ocr/v1/general_basic")
        Dim result_post = SendRequest(Uri, data, "application/x-www-form-urlencoded", "POST")
        Console.WriteLine(result_post)
        Dim json As JObject = JObject.Parse(result_post)
        Me.Close()
    End Sub

    Private Sub GoogleOCRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoogleOCRToolStripMenuItem.Click
        Dim capimage As Image = CaptureScreen2()
        capimage.Save("capture.png", System.Drawing.Imaging.ImageFormat.Png)

        Dim img As Google.Cloud.Vision.V1.Image = Google.Cloud.Vision.V1.Image.FromFile("capture.png")
        Dim client = Google.Cloud.Vision.V1.ImageAnnotatorClient.Create()
        Dim res = client.DetectDocumentText(img)
        Console.WriteLine(res.Text)
        Clipboard.SetText(res.Text)

        Me.Close()
    End Sub

    Private Sub Pan_MouseClick(sender As Object, e As MouseEventArgs) Handles Pan.MouseClick
        If e.Button = MouseButtons.Right Then
            Me.Close()
        End If
    End Sub
End Class