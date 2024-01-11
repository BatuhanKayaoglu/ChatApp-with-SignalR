using SignalRChat.Models;
using System.Collections.Generic;

namespace SignalRChat.Data
{
    public static class ClientSource
    {
        public static List<Client> Clients { get; } = new List<Client>();
    }
}
