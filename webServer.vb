
Friend Class LocalWebServer
    Public Property url As String
    Public Property servingFromDirectory As String

    Public Sub New(ByVal Url As String, ByVal ServingFromDirectory As String)
        Url = Url
        ServingFromDirectory = ServingFromDirectory
    End Sub

    Public Sub StartWebServer()
        Dim t As Thread = New Thread(New ThreadStart(AddressOf ThreadProc))
        t.Start()
    End Sub

    Private Sub ThreadProc()
        Using server = New WebServer("http://localhost:80/")
            server.RegisterModule(New LocalSessionModule())
            server.RegisterModule(New StaticFilesModule("C:\Users\jherwig\projects\portable-sim-panels\public"))
            server.[Module](Of StaticFilesModule)().UseRamCache = True
            server.[Module](Of StaticFilesModule)().DefaultExtension = ".html"
            server.[Module](Of StaticFilesModule)().DefaultDocument = "index.html"
            server.RunAsync()
            Thread.Sleep(Timeout.Infinite)
        End Using
    End Sub
End Class
