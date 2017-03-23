using Microsoft.Web.WebSockets;

namespace RZNU_lab2.Models
{
    class ChatWebSocketHandler : WebSocketHandler
    {
        private static WebSocketCollection _chatClientsCollection = new WebSocketCollection();
        private string _username;

        public ChatWebSocketHandler(string username)
        {
            _username = username;
        }

        public override void OnOpen()
        {
            _chatClientsCollection.Add(this);
            _chatClientsCollection.Broadcast(_chatClientsCollection.Count.ToString() + ";" + _username);
        }

        public override void OnClose()
        {
            _chatClientsCollection.Remove(this);
            _chatClientsCollection.Broadcast(_chatClientsCollection.Count.ToString() + ";" + _username + " disconnected");
        }

        public override void OnMessage(string message)
        {
            _chatClientsCollection.Broadcast("<b>"+ _username + "</b>: " + message);
        }
    }
}