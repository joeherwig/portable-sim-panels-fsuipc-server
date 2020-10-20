namespace portableSimPanelsFsuipcServer
{
    using EmbedIO;
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
