Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms

Public Class Facebook_Grup

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        WebBrowser1.Navigate("https://mbasic.facebook.com/groups/?seemore&refid=27&ref=category_discover_landing_seemore")


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim elementsByTagName As HtmlElementCollection = Me.WebBrowser1.Document.GetElementsByTagName("a")
        Me.ListBox1.Items.Clear()
        Try
            Dim enumerator As IEnumerator = elementsByTagName.GetEnumerator()
            While enumerator.MoveNext()
                Dim htmlElement As HtmlElement = CType(enumerator.Current, HtmlElement)
                Dim obje = htmlElement.GetAttribute("href")
                Dim flag As Boolean = obje.Contains("/groups") AndAlso obje.Contains("?refid=") AndAlso Not obje.Contains("/groups/create/")
                If flag Then
                    Me.ListBox1.Items.Add(htmlElement.GetAttribute("href").ToString())

                End If
            End While
        Finally
            Dim enumerator As IEnumerator
            Dim flag As Boolean = TypeOf enumerator Is IDisposable
            If flag Then
                TryCast(enumerator, IDisposable).Dispose()




            End If

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Timer1.[Stop]()
        Timer2.[Stop]()
        Timer3.[Stop]()

       

    End Sub

    Private Sub Facebook_Grup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaximumSize = Me.Size
        MinimumSize = Me.Size

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim listBox As ListBox = Me.ListBox1
        Dim listBox2 As ListBox = listBox
        If listBox2.Items.Count - 1 <> listBox2.SelectedIndex Then
            listBox2.SelectedIndex += 1

            Me.WebBrowser1.Navigate(Me.ListBox1.Text)
            yuklendimi = False


            Me.Timer1.Enabled = False
            Dim t As Thread = New Thread(AddressOf kontrolThread)
            t.IsBackground = True
            t.Start()
        End If



    End Sub
    Private Sub kontrolThread()
        While Not yuklendimi
            Thread.Sleep(250)
        End While
        Thread.Sleep(1000)
        Me.Invoke(New MethodInvoker(Function()
                                        Me.Timer2.Enabled = True
                                        Timer2.Start()
                                    End Function))
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim obje = Me.WebBrowser1.Document.GetElementById("u_0_0")
        If obje IsNot Nothing Then
            obje.SetAttribute("value", Me.TextBox1.Text)
            Timer2.Enabled = False
            Timer3.Enabled = True
            Dim num As Integer
            Dim flag As Boolean = num <> 0
            If flag Then

            End If
        End If



        
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Dim all As HtmlElementCollection = Me.WebBrowser1.Document.All
        Dim enumerator As IEnumerator = all.GetEnumerator()
        Dim flag As Boolean
        While enumerator.MoveNext()
            Dim obj As Object = enumerator.Current
            Dim htmlElement As HtmlElement = CType(obj, HtmlElement)
            flag = (Operators.CompareString(htmlElement.GetAttribute("value"), "Paylaş", False) <> 0)
            If Not flag Then
                htmlElement.InvokeMember("click")
                Dim obje = Me.WebBrowser1.Document.GetElementById("u_0_0")
                If obje IsNot Nothing Then
                    obje.Focus()
                End If
            End If
        End While
        flag = (TypeOf enumerator Is IDisposable)
        If flag Then
            TryCast(enumerator, IDisposable).Dispose()
        End If
        Me.Timer3.Enabled = False
        Me.Timer1.Enabled = True
        Dim num As Integer
        flag = (num <> 0)
        If flag Then

        End If
    End Sub

    Dim yuklendimi = False

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

        yuklendimi = True
       


    End Sub




End Class