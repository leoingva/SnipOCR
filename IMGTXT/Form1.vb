Imports System.ComponentModel
Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1

    Dim x1, y1, x2, y2 As Integer
    Dim isDrawing As Boolean
    Dim memoryImage As Bitmap
    Dim lastRect, curRect As Rectangle

    Sub getRect()
        If x1 < x2 Then
            curRect.X = x1
            curRect.Width = x2 - x1
        Else
            curRect.X = x2
            curRect.Width = x1 - x2
        End If
        If y1 < y2 Then
            curRect.Y = y1
            curRect.Height = y2 - y1
        Else
            curRect.Y = y2
            curRect.Height = y1 - y2
        End If
        lastRect.X -= 1
        lastRect.Y -= 1
        lastRect.Width += 2
        lastRect.Height += 2
    End Sub

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
        Dim img As Bitmap
        Dim myGraphics As Graphics = Me.CreateGraphics()
        img = New Bitmap(curRect.Width, curRect.Height, myGraphics)
        Dim memoryGraphics As Graphics = Graphics.FromImage(img)
        memoryGraphics.DrawImage(memoryImage, New Rectangle(0, 0, curRect.Width, curRect.Height), curRect, GraphicsUnit.Pixel)
        Return img
    End Function


    Private Sub CaptureScreen()
        Dim w As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim h As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim s As Size = New Size(w, h)
        Dim myGraphics As Graphics = Me.CreateGraphics()
        memoryImage = New Bitmap(s.Width, s.Height, myGraphics)
        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)

        memoryGraphics.CopyFromScreen(0, 0, 0, 0, s)

        Me.BackgroundImage = memoryImage
        Me.SetBounds(0, 0, s.Width, s.Height)
        Me.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NotifyIcon.Visible = True
        NotifyIcon.Icon = SystemIcons.Application
        NotifyIcon.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon.BalloonTipTitle = "Leo's Snipping tool"
        NotifyIcon.BalloonTipText = "Start from the icon on system tray"
        NotifyIcon.ShowBalloonTip(100)
        ShowInTaskbar = False
        Me.Hide()
    End Sub

    Private Sub CaptureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CaptureToolStripMenuItem.Click
        CaptureScreen()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DiscardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiscardToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub ReselectToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim rectGraphics As Graphics = Me.CreateGraphics
        rectGraphics.DrawImage(memoryImage, lastRect, lastRect, GraphicsUnit.Pixel)
    End Sub

    Private Sub CopyToClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToClipboardToolStripMenuItem.Click
        Dim memoryImage As Bitmap = CaptureScreen2()
        Clipboard.SetImage(memoryImage)
        Me.Hide()
    End Sub

    Private Sub SaveToFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToFileToolStripMenuItem.Click
        Dim memoryImage As Bitmap = CaptureScreen2()
        Dim saveDialog As New SaveFileDialog
        saveDialog.Filter = "PNG Image|*.PNG"
        saveDialog.Title = "Save Image as"
        saveDialog.ShowDialog()
        If saveDialog.FileName <> "" Then
            memoryImage.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png)
            Me.Hide()
        End If
    End Sub

    Private Sub NotifyIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon.MouseDoubleClick
        CaptureScreen()
    End Sub

    Private Sub GoogleOCRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoogleOCRToolStripMenuItem.Click
        Me.Hide()
        Dim capimage As Image = CaptureScreen2()
        capimage.Save("capture.png", System.Drawing.Imaging.ImageFormat.Png)

        Dim img As Google.Cloud.Vision.V1.Image = Google.Cloud.Vision.V1.Image.FromFile("capture.png")
        Dim client = Google.Cloud.Vision.V1.ImageAnnotatorClient.Create()
        Dim res = client.DetectDocumentText(img)
        Console.WriteLine(res.Text)
        Clipboard.SetText(res.Text)
        NotifyIcon.BalloonTipText = res.Text
        NotifyIcon.ShowBalloonTip(100)
        capimage.Dispose()
    End Sub

    Private Sub OCRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OCRToolStripMenuItem.Click
        Me.Hide()
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
        Dim words As IList = json.SelectToken("words_result")
        Dim ret As String = ""
        For Each obj In words
            Dim subobj As JObject = JObject.Parse(obj.ToString)
            Dim word As String = subobj.SelectToken("words")
            ret += word + vbCrLf
            Console.WriteLine(word)
        Next
        Clipboard.SetText(ret)
        NotifyIcon.BalloonTipText = ret
        NotifyIcon.ShowBalloonTip(100)
        capimage.Dispose()

    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left And isDrawing = False Then
            isDrawing = True
            x1 = e.X
            y1 = e.Y
            Me.Cursor = Cursors.Cross
        End If
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If isDrawing Then
            x2 = e.X
            y2 = e.Y
            getRect()
            Dim rectGraphics As Graphics = Me.CreateGraphics
            rectGraphics.DrawImage(memoryImage, lastRect, lastRect, GraphicsUnit.Pixel)
            rectGraphics.DrawRectangle(Pens.Blue, curRect)
            rectGraphics.Dispose()
            lastRect = curRect
        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = MouseButtons.Left Then
            isDrawing = False
            Me.Cursor = Cursors.Default
            RightClickMenu.Show(e.Location)
        End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        NotifyIcon.Dispose()
    End Sub

End Class
