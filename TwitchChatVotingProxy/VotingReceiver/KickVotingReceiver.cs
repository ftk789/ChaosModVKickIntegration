using System;
using System.Net.WebSockets;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using Shared;
using TwitchChatVotingProxy.ChaosPipe;

namespace TwitchChatVotingProxy.VotingReceiver
{
    class KickVotingReceiver : IVotingReceiver
    {
        public static readonly int RECONNECT_INTERVAL = 1000;
        public event EventHandler<OnMessageArgs>? OnMessage = null;

        private readonly string? m_KickChannelName = null;

        private ClientWebSocket? m_KickClient = null;
        private string chatroomId = null;
        private readonly ChaosPipeClient m_KickChaosPipe;
        private readonly ILogger m_Logger = Log.Logger.ForContext<KickVotingReceiver>();

        private bool m_IsReady = false;

        public KickVotingReceiver(OptionsFile config, ChaosPipeClient chaosPipe)
        {
            m_KickChannelName = config.ReadValue("KickChannelName");
            m_KickChaosPipe = chaosPipe;
        }
        
        public async Task<bool> Init()
        {
            if (string.IsNullOrWhiteSpace(m_KickChannelName))
            {
                m_Logger.Fatal("Kick credentials are not properly set!");
                m_KickChaosPipe.SendErrorMessage("Kick credentials are not properly set. Please set them in the config utility.");
                return false;
            }

            m_KickClient = new ClientWebSocket();

            try
            {
                await m_KickClient.ConnectAsync(new Uri("wss://ws-us2.pusher.com/app/32cbd69e4b950bf97679?protocol=7&client=js&version=7.6.0&flash=false"), CancellationToken.None);
                OnConnected();
                ReceiveMessages();
            }
            catch (Exception ex)
            {
                m_Logger.Error(ex, "Failed to connect to Kick.com chatroom");
                return false;
            }
            
            while (!m_IsReady)
            {
                await Task.Delay(100);
            }

            return true;
        }
        
        private async void OnConnected()
        {
            m_Logger.Information("Successfully connected to Kick.com chatroom");
            var subscribeMessage = "{\"event\": \"pusher:subscribe\",\"data\": {\"auth\": \"\",\"channel\": \"chatrooms." + m_KickChannelName + ".v2\"}}";
            await SendMessage(subscribeMessage);
            m_IsReady = true;
        }

        private async Task ReceiveMessages()
        {
            var buffer = new byte[1024 * 4];

            while (m_KickClient?.State == WebSocketState.Open)
            {
                var result = await m_KickClient.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    m_Logger.Error("Disconnected from Kick.com chatroom, trying to reconnect");
                    await Task.Delay(RECONNECT_INTERVAL);
                    await Init();
                }
                else
                {
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    OnMessageReceived(message);
                }
            }
        }

        private void OnMessageReceived(string messageData)
        {
            if (m_Logger == null)
            {
                throw new InvalidOperationException("Logger not initialized.");
            }
    
            m_Logger.Information("Message received from Kick.com chatroom");
            m_Logger.Information(messageData);

            try
            {
                var outerJson = JObject.Parse(messageData);
                var dataJson = outerJson["data"]?.ToString();
                if (dataJson == null)
                {
                    m_Logger.Error("Data field is missing in the received message.");
                    return;
                }

                var data = JObject.Parse(dataJson);
                string content = data["content"]?.ToString() ?? "No content";
                string username = data["sender"]?["username"]?.ToString() ?? "Unknown";
                string clientId = data["id"]?.ToString() ?? "Unknown";
                m_Logger.Information(content);
                m_Logger.Information(username);
                m_Logger.Information(clientId);
                var evnt = new OnMessageArgs
                {
                    Message = content,
                    ClientId = clientId,
                    Username = username,
                };

                OnMessage?.Invoke(this, evnt);
            }
            catch (JsonException ex)
            {
                m_Logger.Error($"Failed to parse messageData: {ex.Message}");
            }
            catch (Exception ex)
            {
                m_Logger.Error($"An unexpected error occurred: {ex.Message}");
            }
        }

        public async Task SendMessage(string message)
        {
            if (m_KickClient is null || m_KickClient.State != WebSocketState.Open)
            {
                return;
            }

            try
            {
                var messageBytes = Encoding.UTF8.GetBytes(message);
                await m_KickClient.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
            }
            catch (Exception e)
            {
                m_Logger.Error(e, $"Failed to send message \"{message}\" to Kick.com chatroom \"{m_KickChannelName}\"");
            }
        }
    }
}
