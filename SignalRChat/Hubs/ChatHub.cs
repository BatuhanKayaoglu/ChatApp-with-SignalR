using Microsoft.AspNetCore.SignalR;
using SignalRChat.Data;
using SignalRChat.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task GetNickName(string nickName)
        {

            // connId ile nickName'i eşleştirdik.
            Client client = new Client
            {
                ConnectionId = Context.ConnectionId,
                NickName = nickName
            };

            ClientSource.Clients.Add(client);
            await Clients.Others.SendAsync("clientJoined", nickName); // giriş yapmış kullanıcı clienti dışındaki tüm clientlara bildiriyorum bu kullanıcının giriş yapmış oldugunu.
            await Clients.All.SendAsync("clients", ClientSource.Clients); // tüm giriş yapmış clientlarımın bilgilerini clientlara gönderiyorum.

        }

        public async Task SendMessage(string message, string clientName)
        {
            Client senderClient = ClientSource.Clients.FirstOrDefault(c => c.ConnectionId == Context.ConnectionId); // şu an mesajı gönderenin connectionId'sini yakalıyoruz
            if (clientName == "Tümü")
            {
                await Clients.Others.SendAsync("receiveMessage", message, senderClient.NickName);
            }
            else
            {
                Client client = ClientSource.Clients.FirstOrDefault(c => c.NickName == clientName);
                await Clients.Client(client.ConnectionId).SendAsync("receiveMessage", message, senderClient.NickName); // sadece seçtiğimiz isme mesaj göndersin.

            }

        }

        public async Task AddGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName); // ilk olarak grubu kim açtıysa onu gruba ekliyoruz.

            Group group = new Group { GroupName = groupName };
            group.Clients.Add(ClientSource.Clients.FirstOrDefault(c => c.ConnectionId == Context.ConnectionId)); //grubun içersindeki listeye grubun bireylerini ekliyoruz.

            GroupSource.Groups.Add(group);

            await Clients.All.SendAsync("groups", GroupSource.Groups);
        }



        // Clientların gruplara istek atarak girebilmesi için 
        public async Task AddClientToGroup(IEnumerable<string> groupNames)
        {
            Client client = ClientSource.Clients.FirstOrDefault(c => c.ConnectionId == Context.ConnectionId); //ilgili clienti buluyoruz.

            // istek atan kişinin bilgisini parametreden almamıza gerek yok çünkü Context.ConnectionId ile yakalayabiliyoruz. 
            foreach (var group in groupNames)
            {
                Group _group = GroupSource.Groups.FirstOrDefault(g => g.GroupName == group); // gruplar içersinde eşleşen grubu yakalıyorum.

                // Bir client'în bir gruba birden fazla kez girmesini engellemek için
                var result = _group.Clients.Any(c => c.ConnectionId == Context.ConnectionId);

                if (!result)
                {
                    _group.Clients.Add(client);
                    await Groups.AddToGroupAsync(Context.ConnectionId, group);
                }

            }
        }



        // Tıklanan gruba abone olan kişilerin listelenmesi
        public async Task GetClientToGroup(string groupName)
        {
            if (groupName == "-1") 
            {
                await Clients.Caller.SendAsync("clients", ClientSource.Clients); // tüm clientları gönderiyoruz -1 ise yani tümü seçiliyse
            }

            Group group = GroupSource.Groups.FirstOrDefault(g => g.GroupName == groupName);

            // Tıklanan grupta yer alan kişileri altta listeliyorum clients'a o gruptaki kişilerin isimlerini göndererek.
            await Clients.Caller.SendAsync("clients", group.Clients); // sadece grupları isteyen client'a gönderiyorum grupları caller kullanma sebebim bu. 

        }



        public async Task SendMessageToGroup(string groupName,string message)
        {
            var client = ClientSource.Clients.FirstOrDefault(c => c.ConnectionId == Context.ConnectionId); // mesajı gönderen client'i yakalıyoruz.
            await Clients.Group(groupName).SendAsync("receiveMessage",message,client.NickName); 
        }



    }
}
