using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace realTimeNotificationExample.Web.Hubs
{
    public class NotificationHub : Hub
    {
        private static ConcurrentDictionary<string, DateTime> ConnectedClients = new ConcurrentDictionary<string, DateTime>();
        
        public void BroadcastTextMessage(string message)
        {
            string Id = Context.ConnectionId;
            Clients.All.SendAsync(message);
        }

        public override Task OnConnectedAsync()
        {
            ConnectedClients.TryAdd<string, DateTime>(Context.ConnectionId, DateTime.Now);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            ConnectedClients.Remove(Context.ConnectionId, out _);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
