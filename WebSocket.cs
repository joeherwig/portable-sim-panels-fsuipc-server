namespace portableSimPanelsFsuipcServer
{
    using EmbedIO.WebSockets;
    using System.Threading.Tasks;

    /// <summary>
    /// The FSUIPC websocket server.
    /// </summary>
    public class WebSocketServer : WebSocketModule
    {
        public WebSocketServer(string urlPath)
            : base(urlPath, true)
        {
            // placeholder
        }

        /// <inheritdoc />
        protected override Task OnMessageReceivedAsync(IWebSocketContext context, byte[] buffer, IWebSocketReceiveResult result)
            => SendToOthersAsync(context, Encoding.GetString(buffer));


        /// <inheritdoc />
        protected override Task OnClientConnectedAsync(IWebSocketContext context)
        => Task.WhenAll(
                SendAsync(context, "Welcome to the chat room!"),
                SendToOthersAsync(context, "Someone joined the chat room."));

        /// <inheritdoc />
        protected override Task OnClientDisconnectedAsync(IWebSocketContext context)
            => SendToOthersAsync(context, "Someone left the chat room.");

        public Task SendToOthersAsync(IWebSocketContext context, string payload)
            => BroadcastAsync(payload, c => c != context);
    }
}
