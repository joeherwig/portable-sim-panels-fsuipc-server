namespace portableSimPanelsFsuipcServer
{
    using System;
    using System.IO;
    using EmbedIO;
    using EmbedIO.WebApi;
    using EmbedIO.WebSockets;
    using EmbedIO.Net;
    using EmbedIO.Files;

    public partial class httpSrv
    {
        public static WebServer CreateWebServer(string url, string HtmlRootPath)
        {
            var server = new WebServer(o => o
                .WithUrlPrefix(url)
                .WithMode(HttpListenerMode.EmbedIO))
                .WithLocalSessionManager()
                .WithStaticFolder("/", HtmlRootPath, false, m => m
                    .WithContentCaching(true));

            return server;
        }
    }
}
