namespace portableSimPanelsFsuipcServer
{
    using EmbedIO;
    using EmbedIO.Files;
    using EmbedIO.WebSockets;

    /// <summary>
    /// A HTTP-Server serving the static files (Panels, Gauges etc.).
    /// </summary>
    public partial class HttpSrv
    {
        public static WebServer CreateWebServer(string url, string HtmlRootPath, WebSocketServer webSocketServer)
        {
            var server = new WebServer(o => o
                .WithUrlPrefix(url)
                .WithMode(HttpListenerMode.EmbedIO))
                .WithLocalSessionManager()
                .WithModule(webSocketServer)
                .WithStaticFolder("/", HtmlRootPath, false, m => m
                    .WithContentCaching(true));

            return server;
        }
    }
}
