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
                SendAsync(context, "Welcome to the FSUIPC socket!"),
                SendToOthersAsync(context, "Someone else subscribed to FSUIPC."));

        /// <inheritdoc />
        protected override Task OnClientDisconnectedAsync(IWebSocketContext context)
            => SendToOthersAsync(context, "Someone unsubscribed.");

        public Task SendToOthersAsync(IWebSocketContext context, string payload)
            => BroadcastAsync(payload, c => c != context);

        // new method here. We have no access to webSocketContext. So we can call BroadcastAsync without context from base class
        public Task SendToOthersAsync(string payload)
	        => BroadcastAsync(payload);
    }
}
